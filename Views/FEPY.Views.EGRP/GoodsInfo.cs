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
using FEPV.BLL;
using MIS.Utility;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class GoodsInfo : UserControl
    {
        ReportBiz rep = new ReportBiz();
        public GoodsInfo()
        {
            InitializeComponent();
            dateEditB.Text = DateTime.Today.ToString("yyyy-MM-dd");
            dateEditE.Text = DateTime.Today.ToString("yyyy-MM-dd");
            dtListGoodsState = rep.GetMISReport("Q_Logs_Goods_State", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            dtListGoodsType = rep.GetMISReport("Q_Logs_Goods_Type", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            //gridViewGoods1.DoubleClick += new EventHandler(gridViewGoods1_DoubleClick);

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGRP", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewGoods1");
            if (gridData != null)
            {
                this.gcGoods.DataSource = gridData;
                gridViewGoods1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewGoods1, "gridViewGoods1", dsgrid);
            }
            #endregion
        }

        public event EventHandler eventShowGoodsProcess;
        void gridViewGoods1_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewGoods1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewGoods1.GetDataRow(gridViewGoods1.GetSelectedRows()[0]);
            
            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            if (eventShowGoodsProcess != null)
            {
                eventShowGoodsProcess(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "B", "E", "GoodsState", "GoodsType", "VoucherID", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { B, E, GoodsState, GoodsType, VoucherID, MyLanguage.Language }; }
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

        public string GoodsState
        {
            get
            {
                return _状态.Text.Trim().Split('-')[0];
            }
        }

        string GoodsType
        {
            get
            {
                return _物品类型.Text.Trim().Split('-')[0];
            }
        }

        public string VoucherID
        {
            get { return txtVehicleNO.Text.Trim(); }
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
                _状态.DataSource = value;
                _状态.DisplayMember = "State";
                _状态.ValueMember = "State";
            }
        }

        public DataTable dtListGoodsType
        {
            set
            {
                _物品类型.DataSource = value;
                _物品类型.DisplayMember = "TypeName";
                _物品类型.ValueMember = "TypeName";
            }
        }

        public void GoodsExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "ToExcel";
            sfd.FileName = "Items Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridViewGoods1.ExportToXls(sfd.FileName);
                MessageBox.Show(@"Success" + "Items Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls", "Prompt information");
            }
        }
    }
}
