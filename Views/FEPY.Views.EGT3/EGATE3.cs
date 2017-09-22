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
    public partial class EGATE3 : Infrastructure.BaseForm
    {
        public EGATE3()
        {
            InitializeComponent();
            this.Load += new EventHandler(EGATE_Load);
            CultureLanuage.ApplyResourcesFrom(this, "EGT3", "EGATE3");
            RegisterCommand();
        }

        void EGATE_Load(object sender, EventArgs e)
        {
            BtnShow4Guest1();

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
        }
        /// <summary>
        /// Register button
        /// </summary>
        private void RegisterCommand()
        {
            //Guest button
            btnSearchGuest.Click += new EventHandler(btnSearchGuest_Click);
            btnInGuest.Click += new EventHandler(btnInGuest_Click);
            btnPrintMore.Click += new EventHandler(btnPrintMore_Click);
            btnSaveGuest.Click += new EventHandler(btnSaveGuest_Click);
            btnBackGuest.Click += new EventHandler(btnBackGuest_Click);
            btnCameraGuest.Click += new EventHandler(btnCameraGuest_Click);
            btnGetCardBack.Click += btnGetCardBack_Click; //Leo-20170503
            _GuestInfo.eventShowGuestView += new EventHandler(_GuestInfo_eventShowGuestView);
            _GuestInfo.eventShowGuestBar += new EventHandler(_GuestInfo_eventShowGuestBar);
            _GuestInfo.eventBtnQueryPlan += new EventHandler(_GuestInfo_eventBtnQueryPlan);
            _GuestInfo.eventBtnQueryPlanTrip += new EventHandler(_GuestInfo_eventBtnQueryPlanTrip);
            _JobGuestView.eventShowCamera += new EventHandler(_JobGuestView_eventShowCamera);
            _JobCameraView.eventShowListView += new EventHandler(_JobCameraView_eventShowListView);
        }

        Poris porisManage = null;
        GuestInfo _GuestInfo = new GuestInfo();
        JobGuestView _JobGuestView = new JobGuestView();
        JobCameraView _JobCameraView = new JobCameraView();

        public string ManageCOM { get; set; }//Card COM serial port
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
                base.OnClosed(e);
            }
            catch (Exception ex)
            {
                base.OnClosed(e);
            }
        }
        #region 
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

        void btnPrintMore_Click(object sender, EventArgs e)
        {
            PrintMore();
        }

        void btnInGuest_Click(object sender, EventArgs e)
        {
            CheckIn4Guest();
        }

        void btnSearchGuest_Click(object sender, EventArgs e)
        {
            SearchPlan4Guest();
        }
        void btnGetCardBack_Click(object sender, EventArgs e)
        {
            GetCardBack();

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
            btnGetCardBack.Visible = false;//Leo
            btnPrintMore.Visible = true;
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
            if(_JobGuestView.IsNeedGetCardBack)
            btnGetCardBack.Visible = true;//Leo-Show button Get Card Back
            btnPrintMore.Visible = false;
            btnSaveGuest.Visible = true;
            btnBackGuest.Visible = true;
            btnCameraGuest.Visible = false;
            barGuest.Refresh();
            deckWorkspaceGuest.Show(_JobGuestView);
        }
        void BtnShow4Guest3()
        {
            btnSearchGuest.Visible = false;
            btnInGuest.Visible = false;
            btnGetCardBack.Visible = false;//Leo
            btnPrintMore.Visible = false;
            btnSaveGuest.Visible = false;
            btnBackGuest.Visible = true;
            btnCameraGuest.Visible = true;
            barGuest.Refresh();
            deckWorkspaceGuest.Show(_JobCameraView);
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
