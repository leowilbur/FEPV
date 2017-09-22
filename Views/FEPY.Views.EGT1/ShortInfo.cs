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
    public partial class ShortInfo : UserControl
    {
        ReportBiz rep = new ReportBiz();
        public ShortInfo()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGT1", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewShort1");
            if (gridData != null)
            {
                this.gcShort.DataSource = gridData;
                gridViewShort1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewShort1, "gridViewShort1", dsgrid);
            }
            #endregion

            dtListShortState = rep.GetMISReport("Q_AC_State", new string[] { "Ctype", "Language" }
                , new object[] { "Short", MyLanguage.Language }).Tables[0];
            gridViewShort1.DoubleClick += new EventHandler(gridViewShort1_DoubleClick);
            gridViewShort1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(gridViewShort1_RowStyle);
        }

        public event EventHandler eventShowShortView;
        void gridViewShort1_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewShort1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewShort1.GetDataRow(gridViewShort1.GetSelectedRows()[0]);
            VoucherID = row["VoucherID"].ToString();
            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowShortView != null)
            {
                eventShowShortView(this, new FEPV.Views.EGATE1.EgateArgs { EgateDictionary = paramenters });
            }
        }

        void gridViewShort1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int hand = e.RowHandle;
            if (hand < 0)
                return;

            DataRow dr = this.gridViewShort1.GetDataRow(hand);
            if (dr == null)
                return;

            if (dr["Status"].ToString() != "")
            {
                e.Appearance.ForeColor = Color.Red;// 改变行字体颜色
                //e.Appearance.BackColor = Color.Red;// 改变行背景颜色
                //e.Appearance.BackColor2 = Color.Blue;// 添加渐变颜色                
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "VehicleNO", "InOrOut", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { txtVehicleNO.Text.Trim(), InOutState, MyLanguage.Language }; }
        }

        string InOutState
        {
            get
            {
                return cbInOrOut.Text.Trim().Split('-')[0];
            }
        }

        public DataTable dtListShortState
        {
            set
            {
                cbInOrOut.DataSource = value;
                cbInOrOut.DisplayMember = "State";
                cbInOrOut.ValueMember = "State";
            }
        }

        public DataTable Plan4ShortTable
        {
            set
            {
                gcShort.DataSource = value;
                gridViewShort1.BestFitColumns();
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
