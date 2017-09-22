using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using FEPV.BLL;

namespace FEPV.Views
{
    public class REIMBiz
    {
        public REIMBiz()
        {
            bwQuery.DoWork += new DoWorkEventHandler(bwQuery_DoWork);
            bwQuery.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwQuery_RunWorkerCompleted);
        }

        public string StoreName { get; set; }

        IReimView _IReimView;

        public IReimView IReimView
        {
            get { return _IReimView; }
            set { _IReimView = value; }
        }

        IQueryParametersView _IQueryParametersView;

        public IQueryParametersView IQueryParametersView
        {
            get { return _IQueryParametersView; }
            set { _IQueryParametersView = value; }
        }

        IShowVoucherView _IShowVoucherView;

        public IShowVoucherView IShowVoucherView
        {
            get { return _IShowVoucherView; }
            set { _IShowVoucherView = value; }
        }


        UIReporting report = new UIReporting();
        
        //Check Ready Status
        public bool Ready2Work()
        {
            GotoStep(STEP.QueryStep);
            GetCenterID();
            return true;
        }
        void GetCenterID()
        {
            IQueryParametersView.dtCenterID = report.GetMISReport("Q_ListCostCenter", new string[] { }, new object[] { }).Tables[0];
        }

        public void GotoStep(STEP step)
        {
            IReimView.Step = step;
        }

        public void Back()
        {
            IReimView.Step--;
        }

        public bool QueryVoucher()
        {
            GotoStep(STEP.ShowStep);
            dtVoucher.Clear();
            p = IQueryParametersView.Parameters;
            v = IQueryParametersView.Values;
            if (bwQuery.IsBusy)
            {
                IReimView.Msg = "Loading...";
                return false;
            }
            bwQuery.RunWorkerAsync();
            return true;
        }

        string[] p;
        object[] v;
        void bwQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IShowVoucherView.dtVoucher = dtVoucher;
        }

        void bwQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            dtVoucher = report.GetMISReport(StoreName, p, v).Tables[0];
        }

        BackgroundWorker bwQuery = new BackgroundWorker();

        DataTable dtVoucher = new DataTable();

        public void CollectInfo()
        {
            RepSSP_POLY rep = new RepSSP_POLY();
            rep.Date = Convert.ToDateTime(IQueryParametersView.Values[0]).ToString("yyyy-MM-dd");
            rep.CenterID = IQueryParametersView.Values[1].ToString();
            rep.dataSource = dtVoucher;

            rep.ShowPreview();
        }
    }

    public enum STEP
    {
        QueryStep, ShowStep
    }
}
