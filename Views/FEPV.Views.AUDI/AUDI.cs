using BasicLanuage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace FEPV.Views
{
    public partial class AUDI : Infrastructure.BaseForm, IAUDI
    {
        public AUDI()
        {
            
            InitializeComponent();
            biz = new AUDIBiz();
            biz.IAUDI = this;
            biz.IQueryVoucherView = _QueryVoucherView;
            biz.IVoucherDetailsView = _VoucherDetailsView;
            RegisterEvent();
            #region Language
            CultureLanuage.ApplyResourcesFrom(remark, "MESD", "MISRemark");
            CultureLanuage.ApplyResourcesFrom(this, this.Name,"AUDI");
            #endregion
        }

        public AUDI(string proName)
        {
            InitializeComponent();
            biz = new AUDIBiz();
            biz.ProcName = proName;
            biz.IAUDI = this;
            biz.IQueryVoucherView = _QueryVoucherView;
            biz.IVoucherDetailsView = _VoucherDetailsView;

            timerQuery.Tick += new EventHandler(timerQuery_Tick);
        }

        #region AUDIEvent

        void RegisterEvent()
        {
            timerQuery.Tick += new EventHandler(timerQuery_Tick);
            btQueryUnsettled.Click += new System.EventHandler(this.btQueryUnsettled_Click);
            btQPass.Click += new System.EventHandler(this.btQPass_Click);
            btReturn.Click += new System.EventHandler(this.btReturn_Click);
            btUntread.Click += new System.EventHandler(this.btUntread_Click);
            this.Load += new System.EventHandler(this.AUDI_Load);
        }

        void timerQuery_Tick(object sender, EventArgs e)
        {
            timerQuery.Stop();
            Msg = "Looking for documents that are not audited this month......";
            biz.GetUnsettledVoucher();
            Msg = "@_@";
        }

        private void AUDI_Load(object sender, EventArgs e)
        {
            Step = 1;
            timerQuery.Start();
            PBarVisible = false;
        }

        private void btQueryUnsettled_Click(object sender, EventArgs e)
        {
            biz.GetUnsettledVoucher();
        }

        private void btQPass_Click(object sender, EventArgs e)
        {
            biz.QPass2SAP2Stock();
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            biz.Back();
        }

        private void btUntread_Click(object sender, EventArgs e)
        {
            if (biz.Untread())
            {
                biz.Back();
                biz.GetUnsettledVoucher();
            }
        }
        #endregion

        #region IAUDI Members
        public bool IsAffirm
        {
            get
            {
                remark.Text = "Confirm UnTreat";
                remark.ShowDialog();
                return remark.RValue;
            }
        }

        public string Remarks
        {
            get { return remark.Msg; }
        }

        public bool frmEnable
        {
            set { this.Enabled = value; }
        }

        public string MessBox
        {
            set
            {
                if (value.Trim() != "")
                    MessageBox.Show(value, "[Synchronization information]");
            }
        }

        public int SetPBar
        {
            set
            {
                pBar.Value = value;
                pBar.Update();
            }
        }

        public string Msg
        {
            set
            {
                txtMsg.Text = value;
            }
        }

        int _step;

        public int Step
        {
            get
            {
                return _step;
            }
            set
            {
                _step = value;
                switch (_step)
                {
                    case 1:
                        WorkSpace.Show(_QueryVoucherView);
                        QueryButtonVisiable = true;
                        QPassButtonVisiable = false;
                        bar2.Refresh();
                        break;
                    case 2:
                        WorkSpace.Show(_VoucherDetailsView);
                        QPassButtonVisiable = true;
                        QueryButtonVisiable = false;
                        bar2.Refresh();
                        break;
                }
            }
        }

        public bool PBarVisible
        {
            set
            {
                pBar.Visible = value;
                pBar.Update();
            }
        }
        #endregion

        #region AUDI Members
        AUDIBiz biz;

        MISRemark remark = new MISRemark();

        QueryVoucherView _QueryVoucherView = new QueryVoucherView();

        VoucherDetailsView _VoucherDetailsView = new VoucherDetailsView();

        bool QueryButtonVisiable
        {
            set
            {
                btQueryUnsettled.Visible = value;
            }
        }

        bool QPassButtonVisiable
        {
            set
            {
                btUntread.Visible = value;
                btReturn.Visible = value;
                btQPass.Visible = value;
            }
        }
        #endregion
    }
}
