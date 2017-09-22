using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using FEPV.Views.XD02;
using BasicLanuage;
using System.Data.SqlClient;
using FEPV.BLL;

namespace FEPV.Views
{
    public partial class EGATE : Infrastructure.BaseForm
    {
        public EGATE()
        {
            InitializeComponent();

            #region Languages
            CultureLanuage.ApplyResourcesFrom(this, "XD02", this.Name);
            #endregion

            RegisterEvent();

            index = 1;
        }

        private void ShowParameters_Load(object sender, EventArgs e)
        {
            Input();
        }

        ShowVoucher showvoucher = new ShowVoucher();
        ShowParameters paraviews = new ShowParameters();
        DataTable tb = new DataTable();

        //Event
        void RegisterEvent()
        {
            btSearch.Click += btSearch_Click;
            btReturn.Click += btReturn_Click;
            btExcel.Click += btExcel_Click;
        }

        //Input Parameter
        void Input()
        {
            Workspace.Show(paraviews);
            btSearch.Visible = true;
            btExcel.Visible = false;
            btReturn.Visible = false;
            btnext.Visible = false;
            bar1.Refresh();
        }

        //Output Parameter
        void Ouput()
        {
            Workspace.Show(showvoucher);
            btSearch.Visible = false;
            btExcel.Visible = true;
            btReturn.Visible = true;
            bar1.Refresh();
        }

        #region Event

        private void btExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "Export to Excel";
            sfd.FileName = "XD02GoodsList_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.showvoucher.VouList.ExportToXls(sfd.FileName);
                MessageBox.Show(@"Success", "information");
            }
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            Input();
            btnext.Visible = false;
            index = 1; // IF user press return then index = 1.
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (this.paraviews.IsReady)
            {
                tb1 = new DataTable();
                tb = queryMz.GetMISReportByPage("Q_XD02_GetGoodsIM", this.paraviews.Parameter, this.paraviews.Values, out Count).Tables[0];
                this.showvoucher.StockTable = tb;
                btnext.Text = "Next(" + Count + ")";
                Workspace.Show(showvoucher);
                btSearch.Visible = false;
                btExcel.Visible = true;
                btReturn.Visible = true;
                btnext.Visible = true;
                bar1.Refresh();
                tb1 = tb;
            }
            else
            {
                MessageBox.Show(this.paraviews.Msg, "提示信息");
            }
        }

        private void btnext_Click(object sender, EventArgs e)
        {
            if (tb1.Rows.Count > Count)
            {

                index = 1;
                return;
            }
            index++;
            string[] ps = new string[] { "BeginDate", "EndDate", "CenterID", "MaterialNO", "plant", "Batch", "State", "BarCode", "repUserID", "pageIndex", "pageSize" };
            object[] vs = new object[] { paraviews.B, paraviews.E, paraviews.CenterID, paraviews.MaterialNO, paraviews.plant, paraviews.Batch, paraviews.State, paraviews.BarCode, paraviews.User, index, "" };
            // Merge data.
            tb1.Merge(queryMz.GetMISReportByPage("Q_XD02_GetGoodsIM", ps, vs, out Count).Tables[0]);
            this.showvoucher.StockTable = tb1;
            btSearch.Visible = false;
            btExcel.Visible = true;
            btReturn.Visible = true;
            bar1.Refresh();
            // Declace pasrameter and value.

        }

        #endregion
        UIReporting queryMz = new UIReporting();
        int index { get; set; }
        int Count = 0;
        DataTable tb1 { get; set; }

    }
}
