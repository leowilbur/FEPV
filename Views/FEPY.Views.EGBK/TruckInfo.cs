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
        AcBiz ab = new AcBiz();

        public TruckInfo()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGBK", this.Name);
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
            gridViewTruck1.Click += new EventHandler(gridViewTruck1_Click);
        }

        public event EventHandler eventShowTruckView;
        void gridViewTruck1_Click(object sender, EventArgs e)
        {
            int rowCount = gridViewTruck1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewTruck1.GetDataRow(gridViewTruck1.GetSelectedRows()[0]);
            VoucherID = row["VoucherID"].ToString();
            ItemID = row["ItemID"].ToString();
            Flag = row["Types"].ToString();
            State = ab.GetVoucherStatus(row["VoucherID"].ToString(), row["ItemID"].ToString());
            //State = row["Status"].ToString();
            VehicleNO = row["VehicleNO"].ToString();
            if (eventShowTruckView != null)
            {
                eventShowTruckView(this, null);
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
                //gridViewTruck1.Columns.Clear();
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

        public string VoucherID
        {
            get { return txtVoucherID.Text; }
            set { txtVoucherID.Text = value; }
        }

        public string ItemID
        {
            get { return txtItemID.Text; }
            set { txtItemID.Text = value; }
        }
        //标识
        public string Flag
        {
            get { return _Flag.Text; }
            set { _Flag.Text = value; }
        }
        //状态
        public string State
        {
            get { return _State.Text; }
            set { _State.Text = value; }
        }
        //车号
        public string VehicleNO
        {
            get { return _VehicleNO.Text; }
            set { _VehicleNO.Text = value; }
        }
    }
}
