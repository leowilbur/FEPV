using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class REIM : Infrastructure.BaseForm, IReimView
    {
        public REIM()
        {
            InitializeComponent();

            biz.IReimView = this;
            biz.IQueryParametersView = _QueryParametersView;
            biz.IShowVoucherView = _ShowVoucherView;

            btSearch.Click += new System.EventHandler(this.btSearch_Click);
            btMaster.Click += new System.EventHandler(this.btMaster_Click);
            BtExcel.Click += new System.EventHandler(this.BtExcel_Click);
            btPrev.Click += new System.EventHandler(this.btPrev_Click);
            this.Load += new System.EventHandler(this.REIM_Load);
        }

        REIMBiz biz = new REIMBiz();

        QueryParametersView _QueryParametersView = new QueryParametersView();
        ShowVoucherView _ShowVoucherView = new ShowVoucherView();

        #region IReimView Members
        public string StoreName { set { biz.StoreName = value; } }

        public string Msg
        {
            set { txtMsg.Text = value; }
        }

        STEP step = STEP.QueryStep;
        public STEP Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;

                if (step < STEP.QueryStep)
                    step = STEP.QueryStep;

                if (step > STEP.ShowStep)
                    step = STEP.ShowStep;

                switch (step)
                {
                    case STEP.QueryStep:
                        QueryButtonVisible = true;
                        ShowButtonVisible = false;
                        WorkSpace.Show(_QueryParametersView);
                        Bar1.Refresh();
                        break;
                    case STEP.ShowStep:
                        ShowButtonVisible = true;
                        QueryButtonVisible = false;
                        WorkSpace.Show(_ShowVoucherView);
                        Bar1.Refresh();
                        break;
                }
            }
        }

        bool QueryButtonVisible
        {
            set
            {
                btSearch.Visible = value;
            }
        }

        bool ShowButtonVisible
        {
            set
            {
                btPrev.Visible = value;
                btMaster.Visible = value;
                BtExcel.Visible = value;
            }
        }

        #endregion

        private void btSearch_Click(object sender, EventArgs e)
        {
            biz.QueryVoucher();
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            biz.Back();
        }

        private void REIM_Load(object sender, EventArgs e)
        {
            if (!biz.Ready2Work())
                this.Close();
        }

        private void btMaster_Click(object sender, EventArgs e)
        {
            biz.CollectInfo();
        }

        private void BtExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "Export Finished Stock Report Excel";
            sfd.FileName = "FinishedStockReportExcel_" + DateTime.Now.ToString("yyMMddmmss") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
                this._ShowVoucherView.VouList.ExportToXls(sfd.FileName);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            biz.Back();
        }
    }
}
