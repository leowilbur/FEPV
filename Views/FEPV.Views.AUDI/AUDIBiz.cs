using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FEPV.BLL;

namespace FEPV.Views
{
    public class AUDIBiz
    {
        public AUDIBiz()
        {
            ProcName = "Q_QueryVoucherFORQPass";
            bwQSS.DoWork += new DoWorkEventHandler(bwQSS_DoWork);
            bwQSS.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwQSS_RunWorkerCompleted);
        }

        public string ProcName
        {
            get;
            set;
        }

        BackgroundWorker bwQSS = new BackgroundWorker();

        IQueryVoucherView _IQueryVoucherView;

        public IQueryVoucherView IQueryVoucherView
        {
            get { return _IQueryVoucherView; }
            set
            {
                _IQueryVoucherView = value;
                _IQueryVoucherView.eventGetSelectVoucher += new EventHandler(_IQueryVoucherView_eventGetSelectVoucher);
            }
        }

        void _IQueryVoucherView_eventGetSelectVoucher(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_IQueryVoucherView.selectVoucher))
            {
                _IAUDI.Msg = "No Package!";
            }
            else
            {
                GotoStep(2);
                _IVoucherDetailsView.listMaster = voucher.TakeMaster(_IQueryVoucherView.selectVoucher);
                _IVoucherDetailsView.listVoucherDetails = voucher.TakeDetails(_IQueryVoucherView.selectVoucher);
            }
        }

        IAUDI _IAUDI;

        public IAUDI IAUDI
        {
            get { return _IAUDI; }
            set { _IAUDI = value; }
        }

        IVoucherDetailsView _IVoucherDetailsView;

        public IVoucherDetailsView IVoucherDetailsView
        {
            get { return _IVoucherDetailsView; }
            set { _IVoucherDetailsView = value; }
        }

        UIReporting report = new UIReporting();

        VoucherBiz voucher = new VoucherBiz();

        void GotoStep(int i)
        {
            _IAUDI.Step = i;
        }

        public void GetUnsettledVoucher()
        {
            _IQueryVoucherView.listVoucher = report.GetMISReport(ProcName, _IQueryVoucherView.Parameters, _IQueryVoucherView.Values).Tables[0];
        }

        public bool QPass2SAP2Stock()
        {
            _IAUDI.Msg = "Running...";
            _IAUDI.frmEnable = false;
            _IAUDI.PBarVisible = true;
            if (bwQSS.IsBusy)
            {
                _IAUDI.Msg = "Running......";
                return false;
            }
            bwQSS.RunWorkerAsync();
            return true;
        }

        void bwQSS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (rValue)
            {
                GotoStep(1);
            }
            IAUDI.Msg = myMsg;

            _IAUDI.PBarVisible = false;
            GetUnsettledVoucher();
            _IAUDI.frmEnable = true;
        }

        void bwQSS_DoWork(object sender, DoWorkEventArgs e)
        {
            QPass();
        }

        bool rValue;
        string myMsg = string.Empty;
        void QPass()
        {
            rValue = false;
            string msg = string.Empty;
            if (voucher.Qpass(_IQueryVoucherView.selectVoucher))
            {
                myMsg = "Audit Successful(Submit SAP fail)";
                _IAUDI.SetPBar = 30;
                if (voucher.Sync2SAP(_IQueryVoucherView.selectVoucher, out msg))
                {
                    myMsg = "Sync to SAP successful (Submit Inventory Failed)";
                    _IAUDI.SetPBar = 70;
                    if (voucher.Submit2Stock(_IQueryVoucherView.selectVoucher))
                    {
                        myMsg = "Submit to inventory successfully!";
                        rValue = true;
                        _IAUDI.SetPBar = 100;
                    }

                }
                else
                {
                    _IAUDI.MessBox = msg;
                }
            }
            else
                _IAUDI.Msg = "Synchronization to SAP failed!";

        }

        public void Back()
        {
            _IAUDI.Step--;
        }

        public bool Untread()
        {
            rValue = false;
            if (IAUDI.IsAffirm)
            {
                string msg = string.Empty;
                if (voucher.Withdrawal(_IQueryVoucherView.selectVoucher, IAUDI.Remarks, out msg))
                { 
                    IAUDI.Msg = "Success!";
                    rValue = true;
                }
                else
                    IAUDI.Msg = msg;
            }
            return rValue;
        }
    }
}
