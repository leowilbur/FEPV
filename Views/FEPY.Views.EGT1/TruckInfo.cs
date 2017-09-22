using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;
using BasicLanuage;
using MIS.Utility;

namespace FEPV.Views
{
    public partial class TruckInfo : UserControl
    {
        ReportBiz rep = new ReportBiz();
        public TruckInfo()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGT1", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewTruck1");
            if (gridData != null)
            {
                this.gcTruck.DataSource = gridData;
                gridViewTruck1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewTruck1, "gridViewTruck1", dsgrid);
            }
            #endregion

            dtListTruckState = rep.GetMISReport("Q_AC_State", new string[] { "Ctype", "Language" }
                , new object[] { "Truck", MyLanguage.Language }).Tables[0];
            dtListVehicleType = rep.GetMISReport("Q_Vehicle_Type", new string[] { "Language" },
                new object[] { MyLanguage.Language }).Tables[0];
            gridViewTruck1.DoubleClick += new EventHandler(gridViewTruck1_DoubleClick);
            gridViewTruck1.Click += new EventHandler(gridViewTruck1_Click);
            gridViewTruck1.RowStyle+=new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(gridViewTruck1_RowStyle);
            txtVehicleNO.KeyDown += new KeyEventHandler(txtVehicleNO_KeyDown);
        }

        public event EventHandler eventBtnQueryPlan;
        void txtVehicleNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                eventBtnQueryPlan(this, EventArgs.Empty);
        }

        public event EventHandler eventShowTruckBar;
        void gridViewTruck1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewTruck1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewTruck1.GetDataRow(gridViewTruck1.GetSelectedRows()[0]);
            VoucherID = row["VoucherID"].ToString();
            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowTruckBar != null)
            {
                eventShowTruckBar(this, new FEPV.Views.EGATE1.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public event EventHandler eventShowTruckView;
        void gridViewTruck1_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewTruck1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewTruck1.GetDataRow(gridViewTruck1.GetSelectedRows()[0]);
            VoucherID = row["VoucherID"].ToString();
            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowTruckView != null)
            {
                eventShowTruckView(this, new FEPV.Views.EGATE1.EgateArgs { EgateDictionary = paramenters });
            }
        }

        private void gridViewTruck1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int hand = e.RowHandle;
            if (hand < 0) 
                return;

            DataRow dr = this.gridViewTruck1.GetDataRow(hand);
            if (dr == null) 
                return;

            if (dr["Types"].ToString() == "ST")
            {
                //e.Appearance.ForeColor = Color.LightYellow;// 改变行字体颜色
                e.Appearance.BackColor = Color.Red;// 改变行背景颜色
                //e.Appearance.BackColor2 = Color.Blue;// 添加渐变颜色                
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "VehicleNO", "InOrOut", "VehicleType", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { txtVehicleNO.Text.Trim(), InOutState, VehicleType, MyLanguage.Language }; }
        }

        string InOutState
        {
            get
            {
                return cbInOrOut.Text.Trim();
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
                cbType.DisplayMember = "VehicleType";
                cbType.ValueMember = "VehicleType";
            }
        }

        string _voucherid;
        public string VoucherID
        {
            get { return _voucherid; }
            set { _voucherid = value; }
        }
    }
}
