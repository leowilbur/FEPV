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
    public partial class GuestInfo : UserControl
    {
        public GuestInfo()
        {
            InitializeComponent();
            gridViewGuest.DoubleClick += new EventHandler(gridViewGuest_DoubleClick);
        }

        public event EventHandler eventShowGuestProcess;
        void gridViewGuest_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewGuest.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewGuest.GetDataRow(gridViewGuest.GetSelectedRows()[0]);

            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowGuestProcess != null)
            {
                eventShowGuestProcess(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "GuestName", "IdCard" }; }
        }

        public object[] Values
        {
            get { return new object[] {  txtGuestName.Text.Trim(), txtIdCard.Text.Trim()}; }
        }

        public DataTable Plan4GuestTable
        {
            set
            {
                gridViewGuest.Columns.Clear();
                gcGuest.DataSource = value;
                gridViewGuest.BestFitColumns();
            }
        }

        public void GuestExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "Excel export data";
            sfd.FileName = DateTime.Now.ToString("A blacklist of visitors statisticsyyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridViewGuest.ExportToXls(sfd.FileName);
                MessageBox.Show(@"To export successfully " + DateTime.Now.ToString("A blacklist of visitors statisticsyyyyMMdd") + ".xls", "Prompt information");
            }
        }

        public event EventHandler eventShowGuestUnlock;
        internal void GuestUnlock()
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewGuest.SelectedRowsCount;
            if (rowCount != 1)
            {
                MessageBox.Show("Please choose and try again");
                return;
            }

            DataRow row = gridViewGuest.GetDataRow(gridViewGuest.GetSelectedRows()[0]);

            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowGuestUnlock != null)
            {
                eventShowGuestUnlock(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }
    }
}
