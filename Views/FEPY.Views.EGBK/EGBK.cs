using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO.Ports;
using FEPV.BLL;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class EGBK : Infrastructure.BaseForm
    {
        public EGBK()
        {
            InitializeComponent();
            this.Load += new EventHandler(EGATE_Load);
            CultureLanuage.ApplyResourcesFrom(this, "EGBK", "EGBK");
            RegisterCommand();
        }

        void EGATE_Load(object sender, EventArgs e)
        {
            BtnShow4Truck0Q();
            deckWorkspaceTruck.Show(_TruckInfo);
        }

        TruckInfo _TruckInfo = new TruckInfo();

        /// <summary>
        /// 按钮注册
        /// </summary>
        private void RegisterCommand()
        {
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnWeight1Back.Click += new EventHandler(btnWeight1Back_Click);
            btnWeight2Back.Click += new EventHandler(btnWeight2Back_Click);
            btnPrintBack.Click += new EventHandler(btnPrintBack_Click);
            btnAlterTkno.Click += new EventHandler(btnAlterTkno_Click);
            _TruckInfo.eventShowTruckView += new EventHandler(_TruckInfo_eventShowTruckView);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            TruckQueryPlan();
        }
        /// <summary>
        /// 冲销一磅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnWeight1Back_Click(object sender, EventArgs e)
        {
            DialogTitle = "Cancel the first weighing";         
            if (IsNotarize)
            {
                MainMsg = DialogMsg;
                Weight1Back(DialogMsg);
            }
        }
        /// <summary>
        /// 冲销二磅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnWeight2Back_Click(object sender, EventArgs e)
        {
            DialogTitle = "Cancel the second weighing";
            if (IsNotarize)
            {
                MainMsg = DialogMsg;
                Weight2Back(DialogMsg);
            }            
        }
        /// <summary>
        /// 冲销打印磅单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnPrintBack_Click(object sender, EventArgs e)
        {
            DialogTitle = "Cancel print";
            if (IsNotarize)
            {
                MainMsg = DialogMsg;
                PrintBack(DialogMsg);
            }               
        }
        /// <summary>
        /// 修改车号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAlterTkno_Click(object sender, EventArgs e)
        {
            DialogTitleUTK = "Update truck number";
            TruckNOUTK = _TruckInfo.VehicleNO;
            if (IsNotarizeUTK)
            {
                MainMsg = DialogMsgUTK;
                UpdateTruckNo(DialogMsgUTK, TruckNONEWUTK);
            }
            else
                MainMsg = "Some data is empty";
        }

        void BtnShow4Truck0()
        {
            btnSearch.Visible = true;
            btnWeight1Back.Visible = false;
            btnWeight2Back.Visible = false;
            btnPrintBack.Visible = false;
            btnAlterTkno.Visible = false;
            barTruck.Refresh();
        }
        void BtnShow4Truck0Q()
        {
            btnSearch.Visible = true;
            btnWeight1Back.Visible = false;
            btnWeight2Back.Visible = false;
            btnPrintBack.Visible = false;
            btnAlterTkno.Visible = false;
            barTruck.Refresh();
            TruckQueryPlan();
        }
        void BtnShow4TruckWB1()
        {
            btnSearch.Visible = true;
            btnWeight1Back.Visible = true;
            btnWeight2Back.Visible = false;
            btnPrintBack.Visible = false;
            btnAlterTkno.Visible = false;
            barTruck.Refresh();
        }
        void BtnShow4TruckWB2()
        {
            btnSearch.Visible = true;
            btnWeight1Back.Visible = false;
            btnWeight2Back.Visible = true;
            btnPrintBack.Visible = false;
            btnAlterTkno.Visible = false;
            barTruck.Refresh();
        }
        void BtnShow4TruckPB()
        {
            btnSearch.Visible = true;
            btnWeight1Back.Visible = false;
            btnWeight2Back.Visible = false;
            btnPrintBack.Visible = true;
            btnAlterTkno.Visible = false;
            barTruck.Refresh();
        }
        void BtnShow4TruckUK()
        {
            btnSearch.Visible = true;
            btnWeight1Back.Visible = false;
            btnWeight2Back.Visible = false;
            btnPrintBack.Visible = false;
            btnAlterTkno.Visible = true;
            barTruck.Refresh();
        }

        AcBiz ab = new AcBiz();
        ReportBiz rep = new ReportBiz();
        WorkflowBiz wf = new WorkflowBiz();
        TruckInOutBiz tio = new TruckInOutBiz();
        DataTable dtTruck = new DataTable(); 
        public string UserID { get; set; }//工作流处理人

        string MainMsg 
        {
            set 
            { 
                _txtMsg.Text = value; 
                _txtMsg.Refresh(); 
            }
        }

        Remark remark = new Remark();
        public string DialogMsg
        {
            get { return remark.Msg; }
        }

        public string DialogTitle
        {
            set { remark.TitleText = value; }
        }

        public bool IsNotarize
        {
            get
            {
                remark.ShowDialog();
                return remark.RValue;
            }
        }
        //修改车号的原因
        UpdateTKForm utk = new UpdateTKForm();
        public string DialogMsgUTK
        {
            get { return utk.Msg; }
        }

        public string DialogTitleUTK
        {
            set { utk.TitleText = value; }
        }

        public string TruckNOUTK
        {
            set { utk.TKNO = value; }
        }

        public string TruckNONEWUTK
        {
            get { return utk.TKNONEW; }
        }

        public bool IsNotarizeUTK
        {
            get
            {
                utk.ShowDialog();
                return utk.RValue;
            }
        }
    }
}
