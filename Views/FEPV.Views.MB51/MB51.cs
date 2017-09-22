using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FEPV.BLL;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class MB51 : Infrastructure.BaseForm
    {
        public MB51()
        {
            InitializeComponent();
            RegisterEvent();
            CultureLanuage.ApplyResourcesFrom(this, "MB51", this.Name);
        }

        int Count = 0;

        string GetCellValue(string columnName)
        {
            ArrayList rows = new ArrayList();
            string result = string.Empty;
            // Add the select row to the List
            for (int i = 0; i < voucher.gridData.SelectedRowsCount; i++)
            {
                if (voucher.gridData.GetSelectedRows()[i] >= 0)
                {
                    rows.Add(voucher.gridData.GetDataRow(voucher.gridData.GetSelectedRows()[i]));
                }
            }
            try
            {
                voucher.gridData.BeginUpdate();
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i] as DataRow;
                    // Change the field value.  
                    //row["Discontinued"] = true;
                }
            }
            finally
            {
                voucher.gridData.EndUpdate();
                foreach (var i in rows)
                {
                    result = ((DataRow)i)[columnName].ToString();
                }
            }
            if (result == string.Empty)
                throw new Exception("未找到值:" + columnName);
            return result;
        }

        #region Event

        void RegisterEvent()
        {
            btSearch.Click += btSearch_Click;
            btExcel.Click += btExcel_Click;
            btReturn.Click += btReturn_Click;
            voucher.gridData.DoubleClick += gridData_DoubleClick;
            voucher.gridData.Click += gridData_Click;
            this.Load += MB51_Load;
        }

        private void MB51_Load(object sender, EventArgs e)
        {
            Input();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            tb = report.GetMISReportByPage("Q_MB51_SearchVoucherFORMB51", parameter.Parameter, parameter.Values, out Count).Tables[0];
            this.voucher.StockTable = tb;
            btnext.Text = "Total:(" + Count + ")";
            Ouput();

        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            Input();
        }
        // Save file Excel
        private void btExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "Export to Excel";
            sfd.FileName = "MB02_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.voucher.VouListData.ExportToXls(sfd.FileName);
                MessageBox.Show(@"Success", "information");
            }
        }

        // Click row in grid
        private void gridData_Click(object sender, EventArgs e)
        {
            master.VoucherID = GetCellValue("VoucherID");
        }
        // Double click in grid
        private void gridData_DoubleClick(object sender, EventArgs e)
        {
            master.VoucherID = GetCellValue("VoucherID");
            MasterShow();
        }

        #endregion

        #region MB51 Members
        ParameterView parameter = new ParameterView();
        VoucherView voucher = new VoucherView();
        DataTable tb = new DataTable();
        UIReporting report = new UIReporting();
        MasterShow master = new MasterShow();
        #endregion

        #region WorkSpaceMember
        //Input Parameter
        void Input()
        {
            Workspace.Show(parameter);
            btSearch.Visible = true;
            btExcel.Visible = false;
            btReturn.Visible = false;
            btnext.Visible = false;
            bar1.Refresh();
        }

        //Output Parameter
        void Ouput()
        {
            Workspace.Show(voucher);
            btSearch.Visible = false;
            btExcel.Visible = true;
            btReturn.Visible = true;
            btnext.Visible = true;
            bar1.Refresh();
        }
        // Master and Details Show 
        public void MasterShow()
        {
            Workspace.Show(master);
            btSearch.Visible = false;
            btExcel.Visible = false;
            btReturn.Visible = true;
            btnext.Visible = false;
            bar1.Refresh();
        }
        #endregion

    }
}
