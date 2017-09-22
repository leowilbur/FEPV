using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using BasicLanuage;
using MIS.Utility;
using FEPV.BLL;

namespace FEPV.Views
{
    public partial class GoodsInfo : UserControl
    {
        public GoodsInfo()
        {
            InitializeComponent();
            dtListGoodsState = rep.GetMISReport("Q_AC_State", new string[] { "Ctype", "Language" }
                , new object[] { "Goods", MyLanguage.Language }).Tables[0];

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGT2", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewGoods1");
            if (gridData != null)
            {
                this.gcGoods.DataSource = gridData;
                gridViewGoods1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewGoods1, "gridViewGoods1", dsgrid);
            }
            #endregion

            gridViewGoods1.DoubleClick += new EventHandler(gridViewGoods1_DoubleClick);
            txtVehicleNO.KeyDown += new KeyEventHandler(txtVehicleNO_KeyDown);
        }

        ReportBiz rep = new ReportBiz();
        public event EventHandler eventShowGoodsViewByScan;
        void txtVehicleNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            string barCode = txtVehicleNO.Text.Trim().ToUpper();//.Split('-')[0];

            txtVehicleNO.Text = barCode;
            txtVehicleNO.Focus();

            Dictionary<string, object> paramenters = new Dictionary<string, object>();
            paramenters.Add("VoucherID", barCode);

            if (eventShowGoodsViewByScan != null)
            {
                eventShowGoodsViewByScan(this, new FEPV.Views.EGATE2.EgateArgs { EgateDictionary = paramenters });
            }

            txtVehicleNO.Text = "";
            txtVehicleNO.Focus();
        }

        public event EventHandler eventShowGoodsView;
        void gridViewGoods1_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewGoods1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewGoods1.GetDataRow(gridViewGoods1.GetSelectedRows()[0]);
            VoucherID = row["VoucherID"].ToString();
            CreateUserID = row["UserID"].ToString();
            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowGoodsView != null)
            {
                eventShowGoodsView(this, new FEPV.Views.EGATE2.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "VoucherID", "InOrOut", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { txtVehicleNO.Text.Trim(), InOutState, MyLanguage.Language }; }
        }

        public string InOutState
        {
            get
            {
                return cbInOrOut.Text.Trim().Split('-')[0];
            }
        }

        public DataTable Plan4GoodsTable
        {
            set
            {
                gcGoods.DataSource = value;
                gridViewGoods1.BestFitColumns();
            }
        }

        public DataTable dtListGoodsState
        {
            set
            {
                cbInOrOut.DataSource = value;
                cbInOrOut.DisplayMember = "State";
                cbInOrOut.ValueMember = "State";
            }
        }

        string _voucherid;
        public string VoucherID
        {
            get { return _voucherid; }
            set { _voucherid = value; }
        }

        //Creater
        public string CreateUserID { get; set; }

        internal void Scan()
        {
            txtVehicleNO.Text = "";
            txtVehicleNO.Focus();
        }
    }
}
