using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO.Ports;
using System.Collections;
using Newtonsoft.Json;
using FEPV.BLL;
using FEPV.Model;
using MIS.Utility;

namespace FEPV.Views
{
    public partial class EGATE3
    {
        #region Declare a variable
        AcBiz ab = new AcBiz();
        ReportBiz rep = new ReportBiz();
        WorkflowBiz wf = new WorkflowBiz();
        string currentPageGuest = "";//A record of the current page cab-a visitor
        #endregion

        #region Guest
        DataTable dtGuests = new DataTable();
        private void SearchPlan4Guest()
        {
            GuestQueryPlan();
        }
        /// <summary>
        /// The visitors' plan for the query
        /// </summary>
        private void GuestQueryPlan()
        {
            dtGuests = ab.GetGuests(_GuestInfo.Parameters, _GuestInfo.Values, UserID);
            _GuestInfo.Plan4GuestTable = dtGuests;
            MainMsg = "";
            BtnShow4Guest1();
        }

        /// <summary>
        /// The release of incoming visitors
        /// </summary>
        private void CheckIn4Guest()
        {
            try
            {
                if (_JobGuestView.Flag == "HS")
                {
                    //The card number is empty
                    string strHS = rep.GetMISReport("HS_Q_Check_Contractor_CardNO", new string[] { "IdCard", "Employer" }, new object[] { _JobGuestView.IDCard, _JobGuestView.Enterprise }).Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(strHS))
                    {
                        MainMsg = strHS;
                        return;
                    }
                    //Check the validity of the contractor's another card
                    string strsameHS = rep.GetMISReport("HS_Q_Check_Contractor_IdCard", new string[] { "IdCard", "Employer" }, new object[] { _JobGuestView.IDCard, _JobGuestView.Enterprise }).Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(strsameHS))
                    {
                        MainMsg = strsameHS;
                        if (DialogResult.OK != MessageBox.Show("There are other valid card of the contractor, to continue operation will lead to the failure of other valid cards, do you wish to continue？"
                            , "Prompt information", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
                        {
                            return;
                        }
                    }
                    
                    string msgHS = rep.GetMISReport("HS_i_Contractor4CheckOut", new string[] { "IdCard", "Employer" }, new object[] { _JobGuestView.IDCard, _JobGuestView.Enterprise }).Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(msgHS))
                    {
                        MainMsg = msgHS;
                        return;
                    }
                    MainMsg = "Check in over!";
                    //
                    GuestQueryPlan();
                    //
                    BtnShow4Guest1();
                    
                }
                else
                {
                    MainMsg = "Check in error!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }
        /// <summary>
        /// Save cardid
        /// </summary>
        private void Save4Guest()
        {
            try
            {
                //To check data
                if (_JobGuestView.IsReady)
                {

                    //save info
                    if (_JobGuestView.Flag == "HS")
                    {
                        //Check Invalid card
                        string strInvalid = rep.GetMISReport("HS_Q_Check_InvalidCard",
                            new string[] { "CardNO"},
                            new object[] { _JobGuestView.CardNO }).Tables[0].Rows[0][0].ToString();
                        if (!string.IsNullOrEmpty(strInvalid))
                        {
                            MainMsg = strInvalid; 
                            return;
                        }
                        //Check card is used
                        string strsameHS = rep.GetMISReport("HS_Q_Check_ThisCardNO",
                            new string[] { "CardNO", "IdCard", "Employer" },
                            new object[] { _JobGuestView.CardNO, _JobGuestView.IDCard, _JobGuestView.Enterprise }).Tables[0].Rows[0][0].ToString();
                        if (!string.IsNullOrEmpty(strsameHS))
                        {
                            MainMsg = strsameHS;
                            if (DialogResult.OK != MessageBox.Show(strsameHS + "\n to be continue？"
                                , "Prompt information", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
                            {
                                return;
                            }
                        }

                        string str = rep.GetMISReport("HS_Q_Update_Contractor_CardNO",
                                        new string[] { "CardNO", "Name", "IdCard", "Employer" },
                                        new object[] { _JobGuestView.CardNO, _JobGuestView.GuestName, _JobGuestView.IDCard, _JobGuestView.Enterprise }).Tables[0].Rows[0][0].ToString();

                        if (!string.IsNullOrEmpty(str))
                        {
                            MainMsg = str;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Save success", "infomation");
                            Back4Guest();//Leo
                            return;
                        }
                    }
                    else
                    {
                        MainMsg = "Save GuestItem failed";
                        return;
                    }
                    //
                    //if (DialogResult.OK == MessageBox.Show("Save the information of success, whether the printed document?", "Print", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
                    //{
                    //    DataCardRep _DataCardRep = new DataCardRep();
                    //    string bgcolor = "blue";
                    //    if (!_DataCardRep.InitializeValues(_JobGuestView.IDCard, _JobGuestView.Enterprise, bgcolor))
                    //    {
                    //        MessageBox.Show("Please upload a photo...");
                    //    }
                    //    else
                    //    {
                    //        //_DataCardRep.Print();
                    //        _DataCardRep.ShowPreview();
                    //        //
                    //        BtnShow4Guest1();
                    //        GuestQueryPlan();
                    //    }
                    //}
                    //else
                    //{
                    //    return;
                    //}
                    
                }
                else
                {
                    MainMsg = _JobGuestView.MsgGuest;
                    MessageBox.Show(_JobGuestView.MsgGuest);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }

        private void PrintMore()
        {
            if (_GuestInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the data to be printed!", "information");
                return;
            }
            //打印
            if (DialogResult.OK == MessageBox.Show("Whether to print?", "Print", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
            {
                DataCardRep _DataCardRep = new DataCardRep();
                //获取打印背景颜色值
                string bgcolor = "bluevn";
                if (!_DataCardRep.InitializeValues(_GuestInfo.SelectedRows, bgcolor))
                {
                    MessageBox.Show("Please upload a photo...");
                }
                else
                {
                    //_DataCardRep.Print();
                    _DataCardRep.ShowPreview();
                }
            }
        }

        private void GetCardBack() 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_JobGuestView.CardNO)) { MessageBox.Show("No IDCard to get back", "FEPV"); return; }
                rep.GetMISReport("EGT3_GetCardBack", new string[] { "Name", "IdCard" }, new object[] { _JobGuestView.Name, _JobGuestView.IDCardName });
                MessageBox.Show("Get CardBack successfull", "FEPV");
                _JobGuestView.CardNO = "";
                _JobGuestView._cbCNO = "";
            }
            catch { MessageBox.Show("Error while get card back", "FEPV"); }

        }

        /// <summary>
        /// Visitors to return to the view
        /// </summary>
        private void Back4Guest()
        {
            if (currentPageGuest == "_JobGuestView")
            {
                //
                BtnShow4Guest1();
                //
                SearchPlan4Guest();
            }
            else if (currentPageGuest == "_JobCameraView")
            {
                _JobCameraView.VcUnLoad();
                //
                BtnShow4Guest2In();
                currentPageGuest = "_JobGuestView";
            }
        }
        /// <summary>
        /// Take pictures
        /// </summary>
        private void CaptureImage()
        {
            _JobCameraView.CaptureImage();
        }
        #endregion
        
        #region event
        string rData = string.Empty;
        //Visitor Card Serial Interface
        void porisManage_eventPassportScaned(object sender, EventArgs e)
        {
            switch (SelectTabPagName)
            {
                case "tabPageTruck":
                    break;
                case "tabPageGuest":
                    rData = (string)sender;
                    MyInvoke(rData);
                    rData = string.Empty;
                    break;
            }
        }

        public void MyInvoke(string cardid)
        {
            try
            {
                CardIDelegate mygate = new CardIDelegate(ReadCardIdByporisManage);
                this.Invoke(mygate, new object[] { cardid });
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void ReadCardIdByporisManage(string cardid)
        {
            if (currentPageGuest == "_JobGuestView")
            {
                _JobGuestView.CardNO = cardid;
            }
            else if (currentPageGuest == "_GuestInfo")
            {
                _GuestInfo.CardNO = cardid;
                GuestQueryPlan();
                _GuestInfo.CardNO = "";
            }
        }
                
        public delegate void VoidDelegate();
        public delegate void CardIDelegate(string cardid);

        void _GuestInfo_eventShowGuestView(object sender, EventArgs e)
        {
            if (dtGuests.Rows.Count == 0)
                return;

            EgateArgs args = (EgateArgs)e;
            _JobGuestView.Paras = args.EgateDictionary;

            #region 
            string state = (string)args.EgateDictionary["Status"];
            string flag = (string)args.EgateDictionary["Types"];
            _JobGuestView.Flag = flag;

            BtnShow4Guest2In();

            #endregion
            currentPageGuest = "_JobGuestView";
        }

        void _GuestInfo_eventShowGuestBar(object sender, EventArgs e)
        {
            if (dtGuests.Rows.Count == 0)
                return;

            EgateArgs args = (EgateArgs)e;
            _JobGuestView.Paras = args.EgateDictionary;

            #region 
            string state = (string)args.EgateDictionary["Status"];
            string flag = (string)args.EgateDictionary["Types"];
            MainMsg = flag + " - " + state;
            #endregion            
        }

        void _GuestInfo_eventBtnQueryPlan(object sender, EventArgs e)
        {
            GuestQueryPlan(); 
        }

        void _GuestInfo_eventBtnQueryPlanTrip(object sender, EventArgs e)
        {
            ReadCardIdByporisManage(_GuestInfo.CardNO);
        }

        void _JobGuestView_eventShowCamera(object sender, EventArgs e)
        {
            _JobCameraView.InitView();
            BtnShow4Guest3();
            currentPageGuest = "_JobCameraView";
        }

        void _JobCameraView_eventShowListView(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;
            _JobGuestView.Parameters = args.EgateDictionary;
            BtnShow4Guest2In();
            //
            _JobGuestView.ImgUpdate();
        }
        #endregion
    }
}
