using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;
using MIS.Utility;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class TruckInfo : UserControl
    {
        ReportBiz rep = new ReportBiz();
        public TruckInfo()
        {
            InitializeComponent();
            dateEditB.Text = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            dateEditE.Text = DateTime.Today.ToString("yyyy-MM-dd");
            dtListTruckState = rep.GetMISReport("Q_Logs_Truck_State", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            dtListVehicleType = rep.GetMISReport("Q_Logs_Truck_Type", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            //gridViewTruck1.DoubleClick += new EventHandler(gridViewTruck1_DoubleClick);

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGRP", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewTruck1");
            if (gridData != null)
            {
                this.gcTruck.DataSource = gridData;
                gridViewTruck1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewTruck1, "gridViewTruck1", dsgrid);
            }
            #endregion
        }

        public event EventHandler eventShowTruckProcess;
        void gridViewTruck1_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewTruck1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewTruck1.GetDataRow(gridViewTruck1.GetSelectedRows()[0]);

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
            get { return new string[] { "B", "E", "PonderationID", "VehicleNO", "InOrOut", "VehicleType", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { B, E, PonderationID, txtVehicleNO.Text.Trim(), InOutState, VehicleType, MyLanguage.Language }; }
        }

        DateTime? B
        {
            get
            {
                if (string.IsNullOrEmpty(dateEditB.Text))
                {
                    return DateTime.Today;
                }
                return Convert.ToDateTime(dateEditB.Text);
            }
        }

        DateTime? E
        {
            get
            {
                if (string.IsNullOrEmpty(dateEditE.Text))
                {
                    return DateTime.Today;
                }
                return Convert.ToDateTime(dateEditE.Text);
            }
        }

        string PonderationID
        {
            get
            {
                return _磅单号码.Text.Trim();
            }
        }

        string InOutState
        {
            get
            {
                return cbInOrOut.Text.Trim().Split('-')[0];
            }
        }

        string VehicleType
        {
            get
            {
                return cbType.Text.Trim().Split('-')[0];
            }
        }

        public DataTable Plan4TruckTable
        {
            set
            {
                gcTruck.DataSource = value;
                gridViewTruck1.BestFitColumns();
            }
        }

        public DataTable dtListTruckState
        {
            set
            {
                cbInOrOut.DataSource = value;
                cbInOrOut.DisplayMember = "State";
                cbInOrOut.ValueMember = "State";
            }
        }

        public DataTable dtListVehicleType
        {
            set
            {
                cbType.DataSource = value;
                cbType.DisplayMember = "TypeName";
                cbType.ValueMember = "TypeName";
            }
        }

        public void TruckExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "ToExcel";
            sfd.FileName = "Vehicle Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridViewTruck1.ExportToXls(sfd.FileName);
                MessageBox.Show(@"Success" + "Vehicle Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls", "Prompt information");
            }   
        }
    }
}
