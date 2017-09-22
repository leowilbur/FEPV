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
    public partial class TruckInfo : UserControl
    {
        public TruckInfo()
        {
            InitializeComponent();
            gridViewTruck.DoubleClick += new EventHandler(gridViewTruck_DoubleClick);
        }

        public event EventHandler eventShowTruckProcess;
        void gridViewTruck_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewTruck.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewTruck.GetDataRow(gridViewTruck.GetSelectedRows()[0]);

            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowTruckProcess != null)
            {
                eventShowTruckProcess(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "VehicleNO"}; }
        }

        public object[] Values
        {
            get { return new object[] { txtVehicleNO.Text.Trim() }; }
        }

        public DataTable Plan4TruckTable
        {
            set
            {
                gridViewTruck.Columns.Clear();
                gcTruck.DataSource = value;
                gridViewTruck.BestFitColumns();
            }
        }

        public void TruckExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "报表导出Excel";
            sfd.FileName = DateTime.Now.ToString("车辆黑名单统计表yyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridViewTruck.ExportToXls(sfd.FileName);
                MessageBox.Show(@"成功导出" + DateTime.Now.ToString("车辆黑名单统计表yyyyMMdd") + ".xls", "提示信息");
            }
        }

        public event EventHandler eventShowTruckUnlock;
        internal void TruckUnlock()
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewTruck.SelectedRowsCount;
            if (rowCount != 1)
            {
                MessageBox.Show("请选择后再试");
                return;
            }

            DataRow row = gridViewTruck.GetDataRow(gridViewTruck.GetSelectedRows()[0]);

            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowTruckUnlock != null)
            {
                eventShowTruckUnlock(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }
    }
}
