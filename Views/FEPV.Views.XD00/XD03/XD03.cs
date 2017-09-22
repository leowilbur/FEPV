using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using BasicLanuage;

namespace FEPV.Views
{
    public partial class XD03 : Infrastructure.BaseForm, IXD03
    {
        public XD03()
        {
            InitializeComponent();
            biz.IXD03 = this;
            biz.IQueryGoodsView = _QueryGoodsView;
            biz.IEditGoodsView = _EditGoodsView;
            RegisterEvent();
            CultureLanuage.ApplyResourcesFrom(this, "XD00", this.Name);
            CultureLanuage.ApplyResourcesFrom(remark, "MESD", "MISRemark");
        }

        #region Event
        void RegisterEvent()
        {
            
            this.Load += XD03_Load;
            btSerchBarCode.Click += btSerchBarCode_Click;
            btDeleteBarCode.Click += btDeleteBarCode_Click;
            btEditBarCode.Click += btEditBarCode_Click;
            btMoreGoods.Click += btMoreGoods_Click;
            btRePrint.Click += btRePrint_Click;
            btSave.Click += btSave_Click;
            btReturn.Click += btReturn_Click;
        }

        private void btSerchBarCode_Click(object sender, EventArgs e)
        {
            biz.QueryGoods();
        }

        private void btEditBarCode_Click(object sender, EventArgs e)
        {
            biz.EditGoods();
        }

        private void btDeleteBarCode_Click(object sender, EventArgs e)
        {
            biz.DeleteGoods();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            biz.UpdateGoods();
        }

        private void XD03_Load(object sender, EventArgs e)
        {
            biz.Ready2Work();
            biz.GetMaterial();
            btMoreGoodsVisiable = false;
        }

        private void btMoreGoods_Click(object sender, EventArgs e)
        {
            biz.QueryMoreGoods();
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            biz.Back();
        }

        private void btRePrint_Click(object sender, EventArgs e)
        {
            biz.RePrint();
        }

        #endregion

        public bool IsPrintDate
        {
            set
            {
                biz.IsPrintDate = value;
            }
        }

        XD03Biz biz = new XD03Biz();

        MISRemark remark = new MISRemark();

        Step _Step;

        string _ProdType = string.Empty;

        QueryGoodsView _QueryGoodsView = new QueryGoodsView();

        EditGoodsView _EditGoodsView = new EditGoodsView();

        #region IXD03 Members

        public bool btMoreGoodsVisiable
        {
            set
            {
                btMoreGoods.Visible = value;
                bar1.Refresh();
            }
        }

        public Step step
        {
            get
            {
                return _Step;
            }
            set
            {
                _Step = value;

                if (_Step < Step.QueryBarCodes)
                    _Step = Step.QueryBarCodes;
                if (_Step > Step.EditGoods)
                    _Step = Step.EditGoods;

                switch (_Step)
                {
                    case Step.QueryBarCodes:
                        QueryGoodsButtonVisiable = true;
                        EditGoodsButtonVisiable = false;
                        WorkSpace.Show(_QueryGoodsView);
                        bar1.Refresh();
                        this.Refresh();
                        break;
                    case Step.EditGoods:
                        EditGoodsButtonVisiable = true;
                        QueryGoodsButtonVisiable = false;
                        btMoreGoodsVisiable = false;
                        WorkSpace.Show(_EditGoodsView);
                        bar1.Refresh();
                        this.Refresh();
                        break;
                }
            }
        }

        public string Msg
        {
            set
            {
                msg.Text = value;
                msg.Refresh();
            }
        }

        public string DialogMsg
        {
            get 
            {
                return remark.Msg;
            }
        }

        public string DialogTitle
        {
            set 
            {
                remark.Text = value; 
            }
        }

        public bool IsNotarize
        {
            get
            {
                remark.ShowDialog();
                return remark.RValue;
            }
        }

        #endregion

        public string Setting { get; set; }

        bool QueryGoodsButtonVisiable
        {
            set
            {
                btSerchBarCode.Visible = value;
                btEditBarCode.Visible = value;
                btDeleteBarCode.Visible = value;
                btRePrint.Visible = value;
            }
        }

        bool EditGoodsButtonVisiable
        {
            set
            {
                btSave.Visible = value;
                btReturn.Visible = value;
            }
        }

        public string ProdType
        {

            set
            {
                if (string.IsNullOrEmpty(value))
                    Msg = "Invalid ProdType!";
                else
                    biz.ProdType = value;
            }
        }

        public IQueryGoodsParametersView _IQueryGoodsParametersView
        {
            set
            {
                if (value != null)
                    biz.IQueryGoodsParametersView = value;
                else
                    Msg = "Query Parameter is null!";
            }
        }

        public IEditGoodsParametersView _IEditGoodsParametersView
        {
            set
            {
                if (value != null)
                    biz.IEditGoodsParametersView = value;
                else
                    Msg = "Good Parameter for edit is null!";
            }
        }

    }

}
