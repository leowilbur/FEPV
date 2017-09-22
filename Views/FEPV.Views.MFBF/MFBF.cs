 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.Model;
using BasicLanuage;

namespace FEPV.Views
{

    public partial class MFBF : Infrastructure.BaseForm, IMFBFView
    {
        public MFBF()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "MFBF", this.Name);
            CultureLanuage.ApplyResourcesFrom(mesd, "MESD", "MISRemark");
            BizInit();
            RegisterEvent();
        }

        #region Init
        void BizInit()
        {
            biz = new MFBFBiz();
            biz.MFBFView = this;
            biz.UnsettledJobsView = _UnsettledJobsStep;
            biz.QueryBatchView = _QueryBatchStep;
            biz.QueryGoodsView = _QueryGoodsStep;
            biz.QueryVoucherView = _QueryVoucherStep;
            biz.dtLine = listLine;
        }
        #endregion

        #region Events

        void RegisterEvent()
        {
            this.Load += MFBF_Load;
            btQueryUnsettled.Click += btQueryUnsettled_Click;
            btSearchBatch.Click += btSearchBatch_Click;
            btNewVoucher.Click += btNewVoucher_Click;
            btUnPick.Click += btUnPick_Click;
            btDeleteVoucher.Click += btDeleteVoucher_Click;
            btCommit2Flow.Click += btCommit2Flow_Click;
            btPrint.Click += btPrint_Click;
            btReturn.Click += btReturn_Click;
            btComplete.Click += btComplete_Click;
            trDosomething.Tick += trDosomething_Tick;
        }

        private void MFBF_Load(object sender, EventArgs e)
        {
            if (!biz.Ready2Work())
            {
                this.Close();
            }
            biz.dtGrade = listGrade;
            biz.dtLine = listLine;
            biz.dtPlant = listPlant;
            biz.dt_Plant = list_Plant;
            biz.dtLoc = listLoc;
            biz.dt_Loc = list_Loc;
            biz.dt_CenterID = listCenterID;
            trDosomething.Start();
        }

        void trDosomething_Tick(object sender, EventArgs e)
        {
            trDosomething.Stop();
            this.MSG = "Looking for documents that are not submitted this month......";
            biz.GetUnSettledVouchers();
            this.MSG = "*_*";
        }

        private void btQueryUnsettled_Click(object sender, EventArgs e)
        {
            biz.GetUnSettledVouchers();
        }

        private void btSearchBatch_Click(object sender, EventArgs e)
        {
            biz.SearchBatch();
        }

        private void btNewVoucher_Click(object sender, EventArgs e)
        {
            biz.DoRequest();
        }

        private void btUnPick_Click(object sender, EventArgs e)
        {
            if (biz.RemoveGoods4Voucher())
                MSG = "*_*";
        }

        private void btDeleteVoucher_Click(object sender, EventArgs e)
        {
            if (biz.CancelVoucher())
                MSG = "*_*";
        }

        private void btCommit2Flow_Click(object sender, EventArgs e)
        {
            if (biz.Commit2Flow())
                MSG = "*_*";
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            biz.PrintVoucher();
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            biz.Back();
        }

        private void btComplete_Click(object sender, EventArgs e)
        {
            biz.Complete();
        }

        #endregion

        #region Data Member
        MISRemark mesd = new MISRemark();
        MFBFBiz biz;
        string _DialogMsg = string.Empty;
        string _DialogTitle = string.Empty;
        UnsettledJobsStep _UnsettledJobsStep = new UnsettledJobsStep();
        QueryBatchStep _QueryBatchStep = new QueryBatchStep();
        QueryGoodsStep _QueryGoodsStep = new QueryGoodsStep();
        QueryVoucherStep _QueryVoucherStep = new QueryVoucherStep();
        List<string> listPlant = new List<string>();
        List<string> list_Plant = new List<string>();
        List<string> listLoc = new List<string>();
        List<string> list_Loc = new List<string>();
        List<string> listGrade = new List<string>();
        List<string> listLine = new List<string>();
        List<string> listCenterID = new List<string>();

        #endregion

        #region MFBF Members

        public string P1 { set { biz.StoreName_Batch = value; } }

        public string P2 { set { biz.StoreName_Goods = value; } }

        public bool IsConverseMaterial
        {
            set
            {
                biz.IsConvertMatreial = value;
            }
        }

        public string IsimmobilityPlantAndLoc
        {
            set
            {
                biz.QueryGoodsView.ParamentersView.IsimmobilityPlantAndLoc = value;
            }
        }

        public string _CenterID
        {
            set { listCenterID.Add(value); }
        }

        public string _Loc
        {
            set { list_Loc.Add(value); }
        }

        public string Loc
        {
            set { listLoc.Add(value); }
        }

        public string Plant
        {
            set
            {
                listPlant.Add(value);
            }
        }

        public string _Plant
        {
            set
            {
                list_Plant.Add(value);
            }
        }

        public string Grade
        {
            set
            {
                listGrade.Add(value);

            }
        }

        public string Line
        {
            set
            {
                listLine.Add(value);
            }
        }

        Step _step = Step.UnsettledVouchers;

        public Step STEP
        {
            get
            {
                return _step;
            }
            set
            {
                _step = value;
                if (_step < Step.UnsettledVouchers)
                    _step = Step.UnsettledVouchers;

                if (_step > Step.QueryVoucher)
                    _step = Step.QueryVoucher;

                switch (_step)
                {
                    case Step.UnsettledVouchers:
                        btSearchBatch.Text = CultureLanuage.GetTranslation("MFBF_btnNew");
                        btSearchBatch.Image = Resource._New;
                        _UnsettledJobsButtonVisible = true;
                        _QueryBatchButtonVisible = true;
                        _ReturnButtonVisible = false;
                        _QueryGoodsButtonVisible = false;
                        _QueryVoucherButtonVisible = false;
                        WorkSpace.Show(_UnsettledJobsStep);
                        MSG = "*_*";
                        bar1.Refresh();
                        break;
                    case Step.QueryBatchs:
                        btSearchBatch.Text =  CultureLanuage.GetTranslation("MFBF_btnSearch");;
                        btSearchBatch.Image = Resource._Search;
                        _UnsettledJobsButtonVisible = false;
                        _QueryBatchButtonVisible = true;
                        _ReturnButtonVisible = true;
                        _QueryGoodsButtonVisible = false;
                        _QueryVoucherButtonVisible = false;
                        WorkSpace.Show(_QueryBatchStep);
                        MSG = "*_*";
                        bar1.Refresh();
                        break;
                    case Step.QueryGoods:
                        _UnsettledJobsButtonVisible = false;
                        _QueryBatchButtonVisible = false;
                        _ReturnButtonVisible = true;
                        _QueryGoodsButtonVisible = true;
                        _QueryVoucherButtonVisible = false;
                        WorkSpace.Show(_QueryGoodsStep);
                        MSG = "*_*";
                        bar1.Refresh();
                        break;
                    case Step.QueryVoucher:
                        _QueryVoucherButtonVisible = true;
                        _UnsettledJobsButtonVisible = false;
                        _QueryBatchButtonVisible = false;
                        _ReturnButtonVisible = false;
                        _QueryGoodsButtonVisible = false;
                        WorkSpace.Show(_QueryVoucherStep);
                        MSG = "*_*";
                        bar1.Refresh();
                        break;
                    case Step.AddGoods2Voucher:
                        _QueryVoucherButtonVisible = false;
                        _UnsettledJobsButtonVisible = false;
                        _QueryBatchButtonVisible = false;
                        _ReturnButtonVisible = true;
                        _QueryGoodsButtonVisible = false;
                        //WorkSpace.Show(_AddGoods2VoucherStep);
                        bar1.Refresh();
                        break;
                }
            }
        }

        public string MSG
        {
            set
            {
                _MSG.Text = value;
                _MSG.Update();
                this.Update();
            }
        }

        public string _ProdType
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.MSG = "Invalid ProdType!";
                else
                    biz.ProdType = value;
            }
        }

        public string _MT
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.MSG = "Invalid Move Type!";
                else
                    biz.MT = value;
            }
        }

        public string _TransID
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.MSG = "Invalid Transaction Type!";
                else
                    biz.TransID = value;
            }
        }

        public string DialogMsg { set { _DialogMsg = value; } }

        public string DialogTitle { set { _DialogTitle = value; } }

        public bool IsNotarize
        {
            get
            {
                mesd.Msg = _DialogMsg;
                mesd.Text = _DialogTitle;
                mesd.ShowDialog();

                return mesd.RValue;
            }
        }

        public IUnsettledJobsParamenters _UnsettledJobsParamenters
        {
            set
            {
                biz.UnsettledJobsView.ParamentersView = value;
            }
        }

        public IQueryBatchParamenters _QueryBatchParamenters
        {
            set
            {
                if (value == null)
                    MSG = "The query batch parameter is empty!";
                else
                    biz.QueryBatchView.ParamentersView = value;//new STAP.QueryBatchParamentersView();
            }
        }

        public IVoucherView _VoucherView
        {
            set
            {
                if (value == null)
                    MSG = "The query item is empty!";
                else
                    biz.QueryGoodsView.ParamentersView = value;//new STAP.SihVoucherView();
            }
        }

        #region ButtonVisiable

        bool _UnsettledJobsButtonVisible
        {
            set
            {
                btQueryUnsettled.Visible = value;
            }
        }

        bool _QueryBatchButtonVisible
        {
            set
            {
                btSearchBatch.Visible = value;
            }
        }

        bool _ReturnButtonVisible
        {
            set
            {
                btReturn.Visible = value;
            }
        }

        bool _QueryGoodsButtonVisible
        {
            set
            {
                btNewVoucher.Visible = value;
            }
        }

        bool _QueryVoucherButtonVisible
        {
            set
            {
                btDeleteVoucher.Visible = value;
                btCommit2Flow.Visible = value;
                btPrint.Visible = value;
                btUnPick.Visible = value;
                btComplete.Visible = value;
            }
        }

        bool _PickButtonVisiable
        {
            set
            {

            }
        }

        #endregion

        #endregion

        #region IMFBFView Members

        public string messshow
        {
            set { MessageBox.Show(value); }
        }

        #endregion
    }
}
