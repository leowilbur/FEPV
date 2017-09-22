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
    public partial class EGATE2
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
                    string _VoucherID = _JobGuestView.KeyValue;
                    //
                    string str = rep.GetMISReport("FK_AC_Check_GuestItem_CardNO", new string[] { "VoucherID" }, new object[] { _VoucherID }).Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        MainMsg = str;
                        return;
                    }

                    GuestPostTask(_VoucherID, "Check in");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }
        /// <summary>
        /// Visitors check out
        /// </summary>
        private void CheckOut4Guest()
        {
            //
            string _VoucherID = _JobGuestView.KeyValue;

            //is over time
            string str = rep.GetMISReport("FK_AC_Q_GetInGuestsByVoucherID", new string[] { "VoucherID" }, new object[] { _VoucherID }).Tables[0].Rows[0][0].ToString();
            if (!string.IsNullOrEmpty(str))
            {
                MessageBox.Show(str);
            }

            GuestPostTask(_VoucherID, "Check out");
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
                    if (_JobGuestView.Flag == "FK")
                    {
                        GuestItem guestitem = new GuestItem()
                        {
                            ID = _JobGuestView.ID,
                            CardNO = _JobGuestView.CardNO,
                            GuestName = _JobGuestView.GuestName,
                            IdCard = _JobGuestView.IDCard,
                            IsAbsent=_JobGuestView.IsAbsent
                        };
                        //save remark
                        rep.GetMISReport("FK_AC_Update_Guest_Remark",
                                        new string[] { "VoucherID", "Remark" },
                                        new object[] { _JobGuestView.KeyValue, _JobGuestView.Remark });
                        //
                        string str = rep.GetMISReport("FK_AC_Update_GuestItem_CardNO_Check",
                                        new string[] { "CardNO"},
                                        new object[] { _JobGuestView.CardNO }).Tables[0].Rows[0][0].ToString();

                        if (!string.IsNullOrEmpty(str))
                        {
                            MessageBox.Show(str);
                            MainMsg = str;
                            return;
                        }
                        else if(!ab.SaveGuestItem(guestitem))
                        {
                            MainMsg = "Save GuestItem failed";
                            return;
                        }
                    }
                    else
                    {
                        string str = rep.GetMISReport("HS_Q_Update_Contractor_CardNO",
                                        new string[] { "CardNO", "Name", "IdCard", "Employer" },
                                        new object[] { _JobGuestView.CardNO, _JobGuestView.GuestName, _JobGuestView.IDCard, _JobGuestView.Enterprise }).Tables[0].Rows[0][0].ToString();

                        if (!string.IsNullOrEmpty(str))
                        {
                            MainMsg = str;
                            return;
                        }
                    }
                    //
                    //if (DialogResult.OK == MessageBox.Show("Save the information of success, whether the printed document?", "Print", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
                    //{
                    //    DataCardRep _DataCardRep = new DataCardRep();
                    //    if (_JobGuestView.Flag == "FK")
                    //    {
                    //        if (!_DataCardRep.InitializeValues(_JobGuestView.ID))
                    //        {
                    //            MessageBox.Show("Please upload a photo...");
                    //        }
                    //        else
                    //        {
                    //            //_DataCardRep.Print();
                    //            _DataCardRep.ShowPreview();
                    //            //
                    //            BtnShow4Guest1();
                    //            GuestQueryPlan();
                    //        }
                    //    }
                    //    else if (_JobGuestView.Flag == "HS")
                    //    {
                    //        if (!_DataCardRep.InitializeValues(_JobGuestView.IDCard, _JobGuestView.Enterprise))
                    //        {
                    //            MessageBox.Show("Please upload a photo...");
                    //        }
                    //        else
                    //        {
                    //            //_DataCardRep.Print();
                    //            _DataCardRep.ShowPreview();
                    //            //
                    //            BtnShow4Guest1();
                    //            GuestQueryPlan();
                    //        }
                    //    }
                    //}
                    //else
                    //{
                        if (_JobGuestView.Flag == "HS")
                        {
                            MainMsg = "Saved successfully, please check in";
                            return;
                        }
                        else
                        {
                            //check cardid
                            string str = rep.GetMISReport("FK_AC_Check_GuestItem_CardNO", new string[] { "VoucherID" }, new object[] { _JobGuestView.KeyValue }).Tables[0].Rows[0][0].ToString();
                            if (string.IsNullOrEmpty(str))
                            {
                                if (Infrastructure.ConfirmBox.Show("Information", "Saved successfully, please check in..."))
                                {
                                    GuestPostTask(_JobGuestView.KeyValue, "Check in");
                                }
                            }
                            else
                            {
                                //
                                BtnShow4Guest1();
                                GuestQueryPlan();
                            }
                        }
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

        #region Goods
        DataTable dtGoods = new DataTable();
        private void SearchPlan4Goods()
        {
            GoodsQueryPlan();
        }
        /// <summary>
        /// Goods query plan
        /// </summary>
        private void GoodsQueryPlan()
        {
            if (_GoodsInfo.InOutState == "Q")
            {
                dtGoods = ab.GetGoods(_GoodsInfo.Parameters, _GoodsInfo.Values, UserID);
                _GoodsInfo.Plan4GoodsTable = dtGoods;
                //
                BtnShow4Goods1();
            }
            else
            {
                dtGoods = ab.GetGoodsBack(_GoodsInfo.Parameters, _GoodsInfo.Values);
                _GoodsInfo.Plan4GoodsTable = dtGoods;
                //
                BtnShow4Goods1();
            }
            MainMsg = "";
        }

        /// <summary>
        /// Scan the document number
        /// </summary>
        private void GoodsScan()
        {
            _GoodsInfo.Scan();
        }
        /// <summary>
        /// Goods check in
        /// </summary>
        private void CheckIn4Goods()
        {
            try
            {
                GoodsBackItem _GoodsBackItem;

                DataTable dt = _JobGoodsReceiveView.dtGoodsBack;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string _itemid = Guid.NewGuid().ToString();

                        _GoodsBackItem = new GoodsBackItem();
                        _GoodsBackItem.ItemID = new Guid(_itemid);
                        _GoodsBackItem.VoucherID = _GoodsInfo.VoucherID;
                        _GoodsBackItem.GoodsName = row["GoodsName"].ToString();
                        _GoodsBackItem.GoodsAmount = row["GoodsAmount"].ToString();
                        _GoodsBackItem.Unit = row["Unit"].ToString();
                        if (!ab.SaveGoodsBackItem(_GoodsBackItem))
                        {
                            MainMsg = "Save goodsItemID info failed!";
                            return;
                        }
                        else
                        {
                            //启动流程 ********************
                            string pid = StartTask(_GoodsInfo.VoucherID, _itemid, "GateGoodIn");
                            //等待启动流程的处理
                            System.Threading.Thread.Sleep(1000);
                            MainMsg = "pid - " + pid.ToString();

                            if (!string.IsNullOrEmpty(_itemid))
                                rep.GetMISReport("GD_AC_Update_GoodsBackItem_Status", new string[] { "ItemID" }, new object[] { new Guid(_itemid) });
                        }
                    }

                    GoodsQueryPlan();
                    MainMsg = "Check in over!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Goods check out
        /// </summary>
        private void CheckOut4Goods()
        {
            try
            {
                //
                string _VoucherID = _GoodsInfo.VoucherID;
                //
                PostTaskUrl(_VoucherID, "GoodsOut");
                //
                System.Threading.Thread.Sleep(1000);

                //Gets the object information
                Goods _Goods = ab.GetGoodsEntity(_VoucherID);
                string status = _Goods.Status;//Gets the current state

                if (status == "Q")
                {
                    _Goods.OutTime = DateTime.Now;
                    _Goods.Status = "O";
                }
                else
                {
                    MessageBox.Show("An incorrect state was on the visitors list!");
                }
                //保存物品信息
                if (ab.SaveGoods(_Goods))
                {
                    GoodsQueryPlan();
                    MainMsg = "Check out over!";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Goods return to the view
        /// </summary>
        private void Back4Goods()
        {
            BtnShow4Goods1();
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
                string[] str = GuestQueryPlanState(cardid).Split('|');
                if (str[1] == "W")
                {
                    //
                    if (Infrastructure.ConfirmBox.Show("Information", "The scene has not yet confirmed, can't check out."))
                    {
                        //is over time
                        string str2 = rep.GetMISReport("FK_AC_Q_GetInGuestsByVoucherID", new string[] { "VoucherID" }, new object[] { str[0] }).Tables[0].Rows[0][0].ToString();
                        if (!string.IsNullOrEmpty(str2))
                        {
                            MessageBox.Show(str2);
                        }

                        GuestPostTask(str[0], "Check out");
                    }
                }
                else if (str[1] == "I")
                {
                    //Unidentified display progress
                    MessageBox.Show(str[2].ToString());
                }
                else 
                {
                    MessageBox.Show("CardNo " + cardid + " Non-registered authorized!");
                }
                _GuestInfo.CardNO = "";
            }
        }

        /// <summary>
        /// The visitors' plan status query
        /// </summary>
        private string GuestQueryPlanState(string cardid)
        {
            string rResult = "";
            //rep
            DataRow row = rep.GetMISReport("FK_AC_Q_GuestQueryPlanState", new string[] { "Mac" }, new object[] { cardid }).Tables[0].Rows[0];
            rResult = row[0].ToString() + "|" + row[1].ToString() + "|" + row[2].ToString();
            return rResult;
        }

        /// <summary>
        /// To update a visitor with one State
        /// </summary>
        /// <param name="voucherId"></param>
        /// <param name="itemId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private bool CallSaveGuest(string voucherId)
        {
            bool rValue = false;
            //
            Guest _Guest = ab.GetGuestEntity(voucherId);
            string status = _Guest.Status;
            
            switch (status)
            {
                case "Q":
                    _Guest.InTime = DateTime.Now;
                    _Guest.Status = "I";
                    break;
                case "I":
                case "W":
                    _Guest.OutTime = DateTime.Now;
                    _Guest.Status = "O";
                    break;
                default: MessageBox.Show("VoucherID state error!");
                    break;
            }
            //Save the visitors' information
            if (ab.SaveGuest(_Guest))
            {
                rValue = true;
            }
            return rValue;
        }

        /// <summary>
        /// Task is exist or not
        /// </summary>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        private bool TaskIsExists(string businessKey, string state, string processDefinitionName)
        {
            // taskDefinitionKey="UserTask_checkin"
            // Visitor Check In：id="UserTask_checkin" Check Out：id="UserTask_checkout" 
            // GoodsOut CheckOut：id="UserTask_CheckOut"
            // GoodsBack Update：id="UserTask_Update" 
            // JointTruck Loading：id="UserTask_3"
            
            string taskDefinitionKey = "";
            if (state == "Q")
            {
                if (processDefinitionName == "Visitor")
                    taskDefinitionKey = "UserTask_checkin";
                else
                    taskDefinitionKey = "UserTaskCheckOut";//for Goods
            }
            else
            {
                if (processDefinitionName == "Visitor")
                    taskDefinitionKey = "UserTask_checkout";

            }           

            BPMTask[] tasks = GetTaskUrl(businessKey, taskDefinitionKey, processDefinitionName);
            if (tasks.Count() > 0)
            {
                MainMsg = "Task Id：" + tasks[0].id;
                return true;
            }
            else
            {
                MainMsg = businessKey + " - Is in approving State" + " " + taskDefinitionKey;
                return false;
            }
        }

        /// <summary>
        /// Visitors to save and submit work flow
        /// </summary>
        /// <param name="voucherid"></param>
        /// <param name="iospec"></param>
        private void GuestPostTask(string voucherid,string iospec)
        {
            try
            {
                //Submission workflow
                //PostTaskUrl(voucherid, "Visitor");
                PostSendMail(voucherid, "Visitor");
                //Waiting for handle the submission process
                System.Threading.Thread.Sleep(1000);
                
                if (CallSaveGuest(voucherid))
                {
                    MainMsg = iospec + "Let go complete!";
                    //
                    GuestQueryPlan();
                    //Back to the main page
                    BtnShow4Guest1();
                }
                else
                {
                    MainMsg = "Guest " + iospec + " Save failed!";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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

            if (_JobGuestView.Flag == "FK")
            {
                //Judging whether the task at this node
                if (!TaskIsExists(_JobGuestView.KeyValue, state, "Visitor"))
                    return;
            }

            if (state == "Q")
            {
                BtnShow4Guest2In();
            }
            else
            {
                BtnShow4Guest2Out();
            }
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

            if (state == "I" || state == "W")
            {
                btnInGuest.Visible = false;
                btnOutGuest.Visible = true;
                barGuest.Refresh();
            }
            else
            {
                btnInGuest.Visible = false;
                btnOutGuest.Visible = false;
                barGuest.Refresh();
            }
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

        void _GoodsInfo_eventShowGoodsView(object sender, EventArgs e)
        {
            if (dtGoods.Rows.Count == 0)
                return;

            EgateArgs args = (EgateArgs)e;

            #region 
            string state = (string)args.EgateDictionary["Status"];

            MainMsg = state;

            if (state == "O")
            {  
                _JobGoodsReceiveView.Paras = args.EgateDictionary;
                _JobGoodsReceiveView.dtListGoodsName = rep.GetMISReport("GD_AC_GetGoodsNameByVoucherID", new string[] { "VoucherID" }, new object[] { (string)args.EgateDictionary["VoucherID"] }).Tables[0];
                _JobGoodsReceiveView.GoodsAmount = "0";
                _JobGoodsReceiveView.GoodsBackAmount = "";

                //DataTable dt = new DataTable();
                //dt.Columns.Add("GoodsName");
                //dt.Columns.Add("GoodsAmount");
                //dt.Columns.Add("Unit");
                //dt.Columns.Add("UnitRemark");
                //_JobGoodsReceiveView.dtGoodsBackItems = dt;
                _JobGoodsReceiveView.dtGoodsBack.Rows.Clear();
                BtnShow4Goods2In();
            }
            else
            {
                //
                if (!TaskIsExists((string)args.EgateDictionary["VoucherID"], state, "GoodsOut"))
                    return;

                _JobGoodsView.Paras = args.EgateDictionary;
                _JobGoodsView.Plan4GoodsDetailsTable = rep.GetMISReport("GD_AC_Q_PlanData4GoodsDetails",
                    new string[] { "VoucherID", "Language" },
                    new object[] { (string)args.EgateDictionary["VoucherID"], MyLanguage.Language }).Tables[0];
                BtnShow4Goods2Out();
            }
            #endregion
        }

        void _GoodsInfo_eventShowGoodsViewByScan(object sender, EventArgs e)
        {
            GoodsQueryPlan();
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
        
        #region REST
        /// <summary>
        /// To start the process
        /// </summary>
        /// <param name="voucherid">businessKey</param>
        /// <param name="itemid"></param>
        /// <param name="processName"></param>
        /// <returns></returns>
        public string StartTask(string voucherid, string itemid, string processName)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                //GoodInChecher：Confirm the deal，initiator：Process initiation people(Guard)

                Dictionary<string, Object> dictionary = new Dictionary<string, Object>();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                Dictionary<string, object> item = null;
                item = new Dictionary<string, object>() 
            {
                  { "value", UserID },
                  { "type", "String" }
            };
                dict.Add("initiator", item);

                item = new Dictionary<string, object>() 
            {
                  { "value", voucherid },
                  { "type", "String" }
            };
                dict.Add("start_remark", item);

                item = new Dictionary<string, object>() 
            {
                  { "value", itemid },
                  { "type", "String" }
            };
                dict.Add("VoucherID", item);

                string[] _CreateUserID = { _GoodsInfo.CreateUserID };
                item = new Dictionary<string, object>() 
            {
                  { "value", _CreateUserID }
            };
                dict.Add("GoodInChecher", item);

                dictionary.Add("variables", dict);
                dictionary.Add("businessKey", itemid);

                string json = JsonConvert.SerializeObject(dictionary);
                return wf.StartdefinitionStr(json, processName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the task
        /// </summary>
        /// <param name="businessKey"></param>
        /// <param name="taskDefinitionKey">The process of node variable name</param>
        /// <param name="processDefinitionName">Process name</param>
        /// <returns></returns>
        public BPMTask[] GetTaskUrl(string businessKey, string taskDefinitionKey, string processDefinitionName)
        {
            //eg：processDefinitionName=Visitor
            // taskDefinitionKey="UserTask_checkin"
            // Visitor id="UserTask_checkin" 
            //          id="UserTask_checkout" 
            // GoodsOut id="UserTask_CheckOut"
            // GoodsBack id="UserTask_confirm" 
            
            string requrl = string.Format("?processDefinitionName={0}&processInstanceBusinessKey={1}&taskDefinitionKey={2}", processDefinitionName, businessKey, taskDefinitionKey);
            BPMTask[] tasks = wf.GetGateTaskUrl(requrl);
            return tasks;
        }
        /// <summary>
        /// To submit task
        /// </summary>
        /// <param name="voucherid">businessKey</param>
        /// <param name="itemid"></param>
        /// <param name="name">Process node name</param>
        /// <param name="processDefinitionName">Process name</param>
        /// <returns></returns>
        public string PostTaskUrl(string businessKey, string processDefinitionName)
        {
            string requrl = string.Format("?processDefinitionName={0}&processInstanceBusinessKey={1}", processDefinitionName, businessKey);
            BPMTask[] tasks = wf.GetGateTaskUrl(requrl);

            //
            System.Threading.Thread.Sleep(1000);

            string jsonstr = string.Empty;
            foreach (BPMTask task in tasks)
            {
                Console.WriteLine(string.Format("taskid:{0},name:{1},des:{2}", task.id, task.name, task.description));
                var formdata = new Dictionary<string, object>
                {
                   //{ "start_confirm", _JobGuestView.IsNeedConfirm }     
                };
                jsonstr = wf.PostTask(task.id, formdata, businessKey);
            }
            return jsonstr;
        }
        public string PostSendMail(string businessKey, string processDefinitionName)
        {
            string requrl = string.Format("?processDefinitionName={0}&processInstanceBusinessKey={1}", processDefinitionName, businessKey);
            BPMTask[] tasks = wf.GetGateTaskUrl(requrl);

            System.Threading.Thread.Sleep(1000);

            string jsonstr = string.Empty;

            //Get Guest Information
            DataTable dtGuests = rep.GetMISReport("EGT2_GetGuestInformation", new string[] { "VoucherID" }, new object[] { _JobGuestView.KeyValue }).Tables[0];
            
            //Get User Name And Email
            DataTable dtCreator = rep.GetMISReport("GetUserInformation", new string[] { "CreatorID" }, new object[] { dtGuests.Rows[0]["UserID"].ToString() }).Tables[0];
            
            //Make Email Body
            StringBuilder EmailBody = new StringBuilder();
            EmailBody.AppendLine("Dear Mr/Mrs: <b>" + dtCreator.Rows[0]["name"].ToString() + "</b><br>&emsp;&emsp;");
            EmailBody.AppendLine("<b>List guests :</b><br>&emsp;&emsp;");
            foreach (DataRow dr in dtGuests.Rows)
            {
                if (dr["CardNo"].ToString().Substring(0, 1) != "A")
                    EmailBody.AppendLine("   - " + dr["Name"].ToString() + " : has enter<br>&emsp;&emsp;"); //Enter Company Guest
                else
                    EmailBody.AppendLine("   - <del>" + dr["Name"].ToString() + "</del> : absent" + "<br>&emsp;&emsp;");
            }
            EmailBody.AppendLine("<b>Time check in: </b> " + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "<br>&emsp;&emsp;");
            EmailBody.AppendLine("<b>Respondent :</b> " + dtGuests.Rows[0]["RespondentName"].ToString() + " - " + dtGuests.Rows[0]["Respondent"].ToString() + "<br>&emsp;&emsp;");
            EmailBody.AppendLine("<b>ExtNo : </b>" + dtGuests.Rows[0]["ExtNO"].ToString() + "<br>&emsp;&emsp;");
            EmailBody.AppendLine("<b>Please, confirm before guests leave company</b><br>");
            EmailBody.AppendLine("<b>FEPV ACS 系統(<i><a href='http://10.20.46.22'>http://10.20.46.22</a></i>)</b><br>");
            EmailBody.AppendLine("Thanks,<br><b>FEPV IT Team</b>");

            //POST task with 3 parameter: email_to, email_subject and email_body
            string emailto = dtCreator.Rows[0]["Email"].ToString();
            string subject = "Confirm Guest CheckOut - " + _JobGuestView.KeyValue;
            if (emailto != "")
            foreach (BPMTask task in tasks)
            {
                Console.WriteLine(string.Format("taskid:{0},name:{1},des:{2}", task.id, task.name, task.description));
                var formdata = new Dictionary<string, object>
                {
                    {"email_to",emailto} ,
                    {"email_subject",subject},
                    {"email_text",EmailBody.ToString()}
                };
                jsonstr = wf.PostTask(task.id, formdata, businessKey);
            }
            return jsonstr;
        }
        #endregion
    }
}
