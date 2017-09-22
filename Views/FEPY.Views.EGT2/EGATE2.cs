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
using BasicLanuage;

namespace FEPV.Views
{
    public partial class EGATE2 : Infrastructure.BaseForm
    {
        public EGATE2()
        {
            InitializeComponent();
            this.Load += new EventHandler(EGATE_Load);
            CultureLanuage.ApplyResourcesFrom(this, "EGT2", "EGATE2");
            RegisterCommand();
        }

        void EGATE_Load(object sender, EventArgs e)
        {
            BtnShow4Guest1();
            BtnShow4Goods1();

            //Card serial interface
            try
            {
                porisManage = new Poris(ManageCOM);
                porisManage.eventPassportScaned += new EventHandler(porisManage_eventPassportScaned);
            }
            catch (Exception exc)
            {
                MainMsg = "PorisManage fault : " + exc.Message;
            }
            //Generation ID card reader
            //try
            //{
            //    Int32 result;
            //    Int32 port;
            //    UInt32 flag;

            //    port = Convert.ToInt32("0", 10);
            //    flag = Convert.ToUInt32("02", 16);
            //    result = IDCardReader.OpenCardReader(port, flag);
            //}
            //catch (Exception ex)
            //{
            //    MainMsg = "ID card reader fault : " + ex.Message;
            //}

            this.BeginInvoke(new VoidDelegate(delegate()
            {
                timer.Enabled = true;
                timer.Interval = 1000;
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
            }));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //17:00 Is not the factory staff that
            if (DateTime.Now.ToString("HH:mm:ss") == "17:00:00")
            {
                DataTable dt = rep.GetMISReport("FK_AC_Q_GetInGuests", new string[] { }, new object[] { }).Tables[0];
                string str = dt.Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(str))
                    MessageBox.Show(str, "The stranded visitors to remind the factory");
            }
        }
        /// <summary>
        /// Register button
        /// </summary>
        private void RegisterCommand()
        {
            //Guest button
            btnSearchGuest.Click += new EventHandler(btnSearchGuest_Click);
            btnInGuest.Click += new EventHandler(btnInGuest_Click);
            btnOutGuest.Click += new EventHandler(btnOutGuest_Click);
            btnSaveGuest.Click += new EventHandler(btnSaveGuest_Click);
            btnBackGuest.Click += new EventHandler(btnBackGuest_Click);
            btnCameraGuest.Click += new EventHandler(btnCameraGuest_Click);
            _GuestInfo.eventShowGuestView += new EventHandler(_GuestInfo_eventShowGuestView);
            _GuestInfo.eventShowGuestBar += new EventHandler(_GuestInfo_eventShowGuestBar);
            _GuestInfo.eventBtnQueryPlan += new EventHandler(_GuestInfo_eventBtnQueryPlan);
            _GuestInfo.eventBtnQueryPlanTrip += new EventHandler(_GuestInfo_eventBtnQueryPlanTrip);
            _JobGuestView.eventShowCamera += new EventHandler(_JobGuestView_eventShowCamera);
            _JobCameraView.eventShowListView += new EventHandler(_JobCameraView_eventShowListView);

            //Goods button
            btnSearchGoods.Click += new EventHandler(btnSearchGoods_Click);
            btnScanGoods.Click += new EventHandler(btnScanGoods_Click);
            btnInGoods.Click += new EventHandler(btnInGoods_Click);
            btnOutGoods.Click += new EventHandler(btnOutGoods_Click);
            btnBackGoods.Click += new EventHandler(btnBackGoods_Click);
            _GoodsInfo.eventShowGoodsView += new EventHandler(_GoodsInfo_eventShowGoodsView);
            _GoodsInfo.eventShowGoodsViewByScan += new EventHandler(_GoodsInfo_eventShowGoodsViewByScan);
        }

        Poris porisManage = null;
        GuestInfo _GuestInfo = new GuestInfo();
        GoodsInfo _GoodsInfo = new GoodsInfo();
        JobGuestView _JobGuestView = new JobGuestView();
        JobCameraView _JobCameraView = new JobCameraView();
        JobGoodsView _JobGoodsView = new JobGoodsView();
        JobGoodsReceiveView _JobGoodsReceiveView = new JobGoodsReceiveView();

        public string ManageCOM { get; set; }//Card COM serial port
        Timer timer = new Timer();//17:00 Timer
        public string UserID { get; set; }//The people of processing workflow
         
        public string SelectTabPagName
        {
            get { return tabControl1.SelectedTab.Name; }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (porisManage != null)
                porisManage.Dispose();
            try
            {
                //IDCardReader.CloseCardReader();
                base.OnClosed(e);
            }
            catch (Exception ex)
            {
                base.OnClosed(e);
            }
        }
        #region 
        void btnBackGoods_Click(object sender, EventArgs e)
        {
            Back4Goods();
        }

        void btnOutGoods_Click(object sender, EventArgs e)
        {
            CheckOut4Goods();
        }

        void btnInGoods_Click(object sender, EventArgs e)
        {
            CheckIn4Goods();
        }

        void btnSearchGoods_Click(object sender, EventArgs e)
        {
            SearchPlan4Goods();
        }

        void btnScanGoods_Click(object sender, EventArgs e)
        {
            GoodsScan();
        }

        void btnCameraGuest_Click(object sender, EventArgs e)
        {
            CaptureImage();
        }

        void btnBackGuest_Click(object sender, EventArgs e)
        {
            Back4Guest();
        }

        void btnSaveGuest_Click(object sender, EventArgs e)
        {
            Save4Guest();
        }

        void btnOutGuest_Click(object sender, EventArgs e)
        {
            CheckOut4Guest();
        }

        void btnInGuest_Click(object sender, EventArgs e)
        {
            CheckIn4Guest();
        }

        void btnSearchGuest_Click(object sender, EventArgs e)
        {
            SearchPlan4Guest();
        }
        #endregion

        #region button show
        /// <summary>
        /// The initial button to display
        /// </summary>
        //guest
        void BtnShow4Guest1()
        {
            btnSearchGuest.Visible = true;
            btnInGuest.Visible = false;
            btnOutGuest.Visible = false;
            btnSaveGuest.Visible = false;
            btnBackGuest.Visible = false;
            btnCameraGuest.Visible = false;
            barGuest.Refresh();
            deckWorkspaceGuest.Show(_GuestInfo);
            currentPageGuest = "_GuestInfo";
        }
        void BtnShow4Guest2In()
        {
            btnSearchGuest.Visible = false;
            btnInGuest.Visible = true;
            btnOutGuest.Visible = false;
            btnSaveGuest.Visible = true;
            btnBackGuest.Visible = true;
            btnCameraGuest.Visible = false;
            barGuest.Refresh();
            deckWorkspaceGuest.Show(_JobGuestView);
        }
        void BtnShow4Guest2Out()
        {
            btnSearchGuest.Visible = false;
            btnInGuest.Visible = false;
            btnOutGuest.Visible = true;
            btnSaveGuest.Visible = false;
            btnBackGuest.Visible = true;
            btnCameraGuest.Visible = false;
            barGuest.Refresh();
            deckWorkspaceGuest.Show(_JobGuestView);
        }
        void BtnShow4Guest3()
        {
            btnSearchGuest.Visible = false;
            btnInGuest.Visible = false;
            btnOutGuest.Visible = false;
            btnSaveGuest.Visible = false;
            btnBackGuest.Visible = true;
            btnCameraGuest.Visible = true;
            barGuest.Refresh();
            deckWorkspaceGuest.Show(_JobCameraView);
        }
        //Goods
        void BtnShow4Goods1()
        {
            btnSearchGoods.Visible = true;
            btnScanGoods.Visible = true;
            btnInGoods.Visible = false;
            btnOutGoods.Visible = false;
            btnBackGoods.Visible = false;
            barGoods.Refresh();
            deckWorkspaceGoods.Show(_GoodsInfo);
        }
        void BtnShow4Goods2In()
        {
            btnSearchGoods.Visible = false;
            btnScanGoods.Visible = false;
            btnInGoods.Visible = true;
            btnOutGoods.Visible = false;
            btnBackGoods.Visible = true;
            barGoods.Refresh();
            deckWorkspaceGoods.Show(_JobGoodsReceiveView);
        }
        void BtnShow4Goods2Out()
        {
            btnSearchGoods.Visible = false;
            btnScanGoods.Visible = false;
            btnInGoods.Visible = false;
            btnOutGoods.Visible = true;
            btnBackGoods.Visible = true;
            barGoods.Refresh();
            deckWorkspaceGoods.Show(_JobGoodsView);
        }
        #endregion

        public class EgateArgs : EventArgs
        {
            public Dictionary<string, object> EgateDictionary { get; set; }
        }

        string MainMsg 
        {
            set 
            { 
                _txtMsg.Text = value; 
                _txtMsg.Refresh(); 
            }
        }
    }
}
