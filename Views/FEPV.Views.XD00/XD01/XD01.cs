using BasicLanuage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class XD01 : Infrastructure.BaseForm, IXD01
    {
        public XD01()
        {
            InitializeComponent();
            RegisterEvent();
            biz = new XD01Biz();
            biz.IXD01 = this;
        }

        #region Event

        void RegisterEvent()
        {
            btCreatBarCode.Click += btCreatBarCode_Click;
            btIsPrint.CheckedChanged += btIsPrint_CheckedChanged;
        }

        private void XD01_Load(object sender, EventArgs e)
        {

            listGoods = biz.GetColumnsName();
            bsGoods = new BindingSource();


            bsGoods.DataSource = listGoods;
            gcGoods.DataSource = bsGoods;

            try
            {
                biz.GetMaterial();
                biz.GetLine();
                GetIsPrint();
            }
            catch
            {
                MessageBox.Show("You account does not have permission to pick Line!", "Information",MessageBoxButtons.OK);
            }

        }

        private void btCreatBarCode_Click(object sender, EventArgs e)
        {
            biz.CreatGoods();
        }

        private void btIsPrint_CheckedChanged(object sender,EventArgs e)
        {
            GetIsPrint();
        }

        #endregion

        XD01Biz biz;
        BindingSource bsGoods;
        DataTable listGoods;
        string _ProdType = string.Empty;
        IGoodsView _goodsView;
        bool _Printable = false;

        #region IXD01 Members

        public string ProdType
        {
            get
            {
                return _ProdType;
            }
            set
            {
                _ProdType = value;
                switch (ProdType)
                {
                    case "C":
                        _goodsView = new SSPView();
                        break;
                    case "L":
                        _goodsView = new POLYView();
                        break;
                    //case "S":
                    //    _goodsView = new STAPView();
                    //    break;
                    //case "H":
                    //    _goodsView = new SHETView();
                    //    break;

                    //case "D":
                    //    _goodsView = new FOBView();
                    //    break;
                    default:
                        _goodsView = null;
                        Msg = "Invalid Product Type!";
                        break;
                }
                if (_goodsView != null)
                {

                    biz.IGoodsView = _goodsView;
                    Workspace.Show(_goodsView);
                    Workspace.Update();
                }
            }
        }

        public DataTable GoodsList
        {
            set
            {
                if (value != null)
                {
                    DataRow row = listGoods.NewRow();
                    foreach (DataColumn column in listGoods.Columns)
                    {
                        row[column.ColumnName] = value.Rows[0][column.ColumnName].ToString();
                    }
                    listGoods.Rows.InsertAt(row, 0);
                    gridViewGood1.BestFitColumns();
                    this.Update();
                    gcGoods.Update();
                }
            }
        }

        public string Msg
        {
            set
            {
                txtMsg.Text = value;
                txtMsg.Update();
            }
            get
            {
                return txtMsg.Text;
            }
        }

        public string Setting { get; set; }

        public bool Printable
        {
            get { return _Printable; }
        }

        #endregion
 
        void GetIsPrint()
        {

            if (btIsPrint.Checked)
                _Printable = true;
            else
                _Printable = false;
        }

    }
}
