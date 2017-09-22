using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class ContractorInfo : UserControl
    {
        public ContractorInfo()
        {
            InitializeComponent();
            gridViewContractor.DoubleClick += new EventHandler(gridViewContractor_DoubleClick);
        }

        public event EventHandler eventShowContractorProcess;
        void gridViewContractor_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewContractor.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewContractor.GetDataRow(gridViewContractor.GetSelectedRows()[0]);

            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowContractorProcess != null)
            {
                eventShowContractorProcess(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "ContractorName", "Mac", "IdCard" }; }
        }

        public object[] Values
        {
            get { return new object[] { txtContractorName.Text.Trim(),txtMac.Text.Trim(),txtIdCard.Text.Trim() }; }
        }

        public DataTable Plan4ContractorTable
        {
            set
            {
                gridViewContractor.Columns.Clear();
                gcContractor.DataSource = value;
                gridViewContractor.BestFitColumns();
            }
        }

        public void ContractorExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "Excel export data";
            sfd.FileName = DateTime.Now.ToString("The blacklist the contractor statisticalyyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridViewContractor.ExportToXls(sfd.FileName);
                MessageBox.Show(@"To export successfully " + DateTime.Now.ToString("The blacklist the contractor statisticalyyyyMMdd") + ".xls", "Prompt information");
            }
        }

        public event EventHandler eventShowContractorUnlock;
        internal void ContractorUnlock()
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewContractor.SelectedRowsCount;
            if (rowCount != 1)
            {
                MessageBox.Show("Please choose and try again");
                return;
            }

            DataRow row = gridViewContractor.GetDataRow(gridViewContractor.GetSelectedRows()[0]);

            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowContractorUnlock != null)
            {
                eventShowContractorUnlock(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }
    }
}
