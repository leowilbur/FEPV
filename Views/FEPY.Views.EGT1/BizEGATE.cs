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
using FEPV.BLL;
using FEPV.Model;
using BasicLanuage;
using MIS.Utility;

namespace FEPV.Views
{
    public partial class EGATE1
    {
        #region Lanuage 变量

        #endregion
        #region 声明变量
        AcBiz ab = new AcBiz();
        ReportBiz rep = new ReportBiz();
        WorkflowBiz wf = new WorkflowBiz();
        ShortTruckBiz st = new ShortTruckBiz();
        TruckInOutBiz tio = new TruckInOutBiz();
        #endregion

        #region Truck
        DataTable dtTruck = new DataTable();
        /// <summary>
        /// 车辆计划查询
        /// </summary>
        private void TruckQueryPlan()
        {
            //GetTrucks
            dtTruck = ab.GetTrucks(_TruckInfo.Parameters, _TruckInfo.Values, UserID);
            _TruckInfo.Plan4TruckTable = dtTruck;

            btnWeightTruck.Enabled = true;
            MainMsg = "*_*";
            BtnShow4Truck0();
        }
        /// <summary>
        /// 车辆进厂放行
        /// </summary>
        private void CheckIn4Truck()
        {
            try
            {
                string _VoucherID = _JobTruckView.VoucherID;

                //检查厂内车辆是否存在
                if (_JobTruckView.IsReady4VehicleNO)
                {
                    if (_JobTruckView.Flag == "ST" && _JobTruckView.State == "Q")
                    {
                        // 【特种车辆】 进厂放行
                        if (tio.CheckIn(_VoucherID, "SpecialTruck"))
                        {
                            MainMsg = "Successful operation!";
                            //返回主页面
                            BtnShow4Truck1();
                        }
                        else
                        {
                            MainMsg = "Operation failed.";
                        }
                    }
                }
                else
                {
                    MainMsg = _JobTruckView.MsgTruck;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }
        /// <summary>
        /// 车辆出厂放行
        /// </summary>
        private void CheckOut4Truck()
        {
            try
            {
                string _VoucherID = _JobTruckView.VoucherID;//计划单号
                string _ItemID = _JobTruckView.ItemID.ToLower();//项次号
                if (_JobTruckView.Flag == "ST")
                {
                    // 【特种车辆】 出厂放行   
                    if (tio.CheckOut(_VoucherID, "SpecialTruck"))
                    {
                        MainMsg = "Successful operation!";
                        //返回主页面
                        BtnShow4Truck1();
                    }
                    else
                    {
                        MainMsg = "operation failed.";
                    }
                }
                else if (_JobTruckView.Flag == "PE")
                {
                    //提交工作流 ********************
                    PostTaskUrl(_ItemID, "GateGoodConfirm");
                    //等待提交流程的处理
                    System.Threading.Thread.Sleep(1000);

                    MainMsg = "Check out Success!";
                    //
                    tio.CheckOut(_ItemID, "PtaEgTruck");
                    //返回主页面
                    BtnShow4Truck1();
                }
                else if (_JobTruckView.Flag == "XT")
                {
                    //提交工作流 ********************
                    PostTaskUrl(_VoucherID, "FEPVJointTruck");
                    //等待提交流程的处理
                    System.Threading.Thread.Sleep(1000);

                    MainMsg = "Check out Success!";
                    //
                    tio.CheckOut(_VoucherID, "JointTruck");
                    //todo:调用ERP接口 *****************************************************************************************
                    //返回主页面
                    BtnShow4Truck1();
                }
                else if (_JobTruckView.Flag == "FX")
                {
                    //废料车辆现场是否确认
                    string processDefinitionName = "FEPVUnJointTruck";
                    string taskDefinitionKey = "UserTask_6";//出厂前的装卸货确认
                    //判断节点此时是否有任务
                    if (TaskIsExists(_VoucherID, taskDefinitionKey, processDefinitionName))
                    {
                        MainMsg = _VoucherID + " - Need to be confirmed on site" + " " + taskDefinitionKey;
                        MessageBox.Show("The vehicle needs to be confirmed on site！");
                        return;
                    }
                    //提交工作流 ********************
                    PostTaskUrl(_VoucherID, "FEPVUnJointTruck");
                    //等待提交流程的处理
                    System.Threading.Thread.Sleep(1000);

                    MainMsg = "Check out Success!";
                    //
                    tio.CheckOut(_VoucherID, "UnJointTruck");

                    //返回主页面
                    BtnShow4Truck1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }
        /// <summary>
        /// 称重
        /// </summary>
        private void Weight()
        {
            if (WeightMode == "HandMode")
            {
                Weighting(Convert.ToDecimal(txtHandWeight.Text.Trim()));
            }
            else
            {
                if (led1.ForeColor != Color.Blue)
                    return;
                Weighting(Convert.ToDecimal(led1.Text));
            }
            btnUpWeightTruck.Enabled = true;//重量上传按钮
        }

        string lanLess40KG = CultureLanuage.GetTranslation("Less40KG");
        /// <summary>
        /// 称重调用
        /// </summary>
        /// <param name="weight"></param>
        private void Weighting(decimal weightTruck)
        {
            weight = 0m;
            if (weightTruck < 40m)
            {
                MessageBox.Show(lanLess40KG, "Information");
                return;
            }

            weight = weightTruck;
            if (_JobTruckView.State == "I" || _JobTruckView.State == "Q")
            {
                _JobTruckView.FirstWeight = weight;
                _JobTruckView.FirstTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                _JobTruckView.SecondWeight = weight;
                _JobTruckView.SecondTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                _JobTruckView.TotalWeight = weight - _JobTruckView.FirstWeight;
            }
        }

        decimal weight = 0;
        /// <summary>
        /// 车辆重量上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnUpWeightTruck_Click(object sender, EventArgs e)
        {
            if (Infrastructure.ConfirmBox.Show("Confirm the information", "Is uploading this weight " + weight.ToString(), 14f, Color.Red))            
            //if (DialogResult.Yes == MessageBox.Show("Is uploading this weight " + weight.ToString(), "Confirm the information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
            {
                //提交数据,完成工作流
                string _VoucherID = _JobTruckView.VoucherID;//计划单号

                #region PE
                if (_JobTruckView.Flag == "PE")
                {
                    string typeName = "PtaEgTruck";
                    //
                    if (_JobTruckView.State == "Q")
                    {
                        //检查数据完整性
                        if (_JobTruckView.IsReady)
                        {
                            btnWeightTruck.Enabled = false;
                            btnUpWeightTruck.Enabled = false;//重量上传按钮
                            //检查厂内车辆是否存在
                            if (_JobTruckView.IsReady4VehicleNO)
                            {
                                //创建工作流 ********************
                                PtaEgItem _PtaEgItem = new PtaEgItem();
                                _PtaEgItem.ItemID = Guid.NewGuid();
                                _PtaEgItem.VoucherID = _TruckInfo.VoucherID;
                                _PtaEgItem.CupboardNO = _JobTruckView.CupboardNO;
                                _PtaEgItem.Discharge = _JobTruckView.Discharge;
                                if (ab.CreatePtaEgItem(_PtaEgItem))
                                {
                                    //TODO:ProcessPtaEgTruck
                                    string pid = StartTask(_VoucherID, _PtaEgItem.ItemID.ToString().ToLower(), "GateGoodConfirm");
                                    //等待启动流程的处理
                                    System.Threading.Thread.Sleep(2000);
                                    MainMsg = "pid - " + pid.ToString();
                                    //
                                    if (!string.IsNullOrEmpty(pid))
                                    {
                                        if (tio.CheckIn(_PtaEgItem.ItemID.ToString(), typeName))
                                        {
                                            MainMsg = "Check in success!";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Check in failed!");
                                            return;
                                        }
                                        
                                        SaveDischarge(_PtaEgItem.ItemID.ToString(), _JobTruckView.CupboardNO, _JobTruckView.Discharge, _JobTruckView.TruckRemark, _JobTruckView.ReferWeight);

                                        string outmsg = "";
                                        if (!tio.PonderationValidate(_PtaEgItem.ItemID.ToString(), weight, typeName, out outmsg))
                                        {
                                            //显示建单者信息：工号，姓名，部门，邮件
                                            string ptaUserid = ab.GetUserIDByItemID(_PtaEgItem.ItemID.ToString());
                                            string strUserid = st.GetCreaterInfo(ptaUserid);
                                            if (DialogResult.Yes == MessageBox.Show(outmsg + "\n\nDo you want to send a message? Please contact the creator after sending：" + strUserid + "，Complete the cause of the exception", "Exception message", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                                            {
                                                //获取taskid
                                                BPMTask[] taskswg = GetTask(_PtaEgItem.ItemID.ToString().ToLower(), "", "GateGoodConfirm");
                                                string taskid = taskswg[0].id;

                                                wf.SendTaskComment(taskid, "WeightValidMessage", _PtaEgItem.ItemID.ToString().ToLower(), outmsg, UserID, "EG1stOverWeight");
                                                //等待后台填写 当前处理意见
                                                System.Threading.Thread.Sleep(1000);
                                            }
                                            else
                                            {
                                                MessageBox.Show(outmsg + "\nPlease remove the pound difference often re-weighed!");
                                                //返回主页面
                                                BtnShow4Truck1();
                                                return;
                                            }
                                        }
                                        //一次过磅
                                        if (tio.WeightOne(_PtaEgItem.ItemID.ToString(), weight, typeName))
                                        {
                                            MainMsg = "WeightOne success!!";
                                            //返回主页面
                                            BtnShow4Truck1();
                                        }
                                        else
                                        {
                                            MessageBox.Show("WeightOne failed!");
                                        }
                                    }
                                    else
                                    {
                                        MainMsg = "The vehicle created the workflow failed!";
                                    }
                                }
                                else
                                {
                                    MainMsg = "The vehicle saved itemID message failed!";
                                }
                            }
                            else
                            {
                                MainMsg = _JobTruckView.MsgTruck;
                            }
                        }
                        else
                        {
                            MessageBox.Show(_JobTruckView.MsgTruck, "Data check");
                        }
                    }
                    else
                    {
                        btnWeightTruck.Enabled = false;
                        btnUpWeightTruck.Enabled = false;
                        //
                        string _ItemID = _JobTruckView.ItemID;//项次号
                        SaveDischarge(_ItemID, _JobTruckView.CupboardNO, _JobTruckView.Discharge, _JobTruckView.TruckRemark, _JobTruckView.ReferWeight);

                        if (_JobTruckView.State == "I")
                        {
                            string outmsg = "";
                            if (!tio.PonderationValidate(_ItemID, weight, typeName, out outmsg))
                            {
                                //显示建单者信息：工号，姓名，部门，邮件
                                string ptaUserid = ab.GetUserIDByItemID(_ItemID);
                                string strUserid = st.GetCreaterInfo(ptaUserid);
                                if (DialogResult.Yes == MessageBox.Show(outmsg + "\n\nDo you want to send a message? Please contact the creator after sending：" + strUserid + "，Complete the cause of the exception", "Exception message", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                                {
                                    //获取taskid
                                    BPMTask[] taskswg = GetTask(_ItemID.ToLower(), "", "GateGoodConfirm");
                                    string taskid = taskswg[0].id;

                                    wf.SendTaskComment(taskid, "WeightValidMessage", _ItemID.ToString(), outmsg, UserID, "EG1stOverWeight");
                                    //等待后台填写 当前处理意见
                                    System.Threading.Thread.Sleep(1000);
                                }
                                else
                                {
                                    MessageBox.Show(outmsg + "\nPlease remove the pound difference often re-weighed!");
                                    //返回主页面
                                    BtnShow4Truck1();
                                    return;
                                }
                            }

                            if (tio.WeightOne(_ItemID, weight, typeName))
                            {
                                MainMsg = "WeightOne success!";
                                BtnShow4Truck1();
                            }
                            else
                            {
                                MainMsg = "WeightOne failed!";
                            }
                        }
                        else
                        {
                            if (tio.WeightTwo(_ItemID, weight, typeName))
                            {
                                MainMsg = "WeightTwo success!";
                                //
                                btnPrintTruck.Enabled = true;
                                //
                                _JobTruckView.WeightRefresh(_ItemID);
                                _JobTruckView.PlanDetail4TruckTable = ab.QueryPlanData4TruckDetails(_ItemID, MyLanguage.Language);
                            }
                            else
                            {
                                MainMsg = "WeightTwo failed!";
                            }
                        }
                    }
                }
                #endregion

                #region NOT PE
                else
                {
                    if (_JobTruckView.State == "Q")
                    {
                        #region State = Q
                        btnWeightTruck.Enabled = false;
                        btnUpWeightTruck.Enabled = false;
                        //检查厂内车辆是否存在
                        if (_JobTruckView.IsReady4VehicleNO)
                        {
                            if (_JobTruckView.Flag == "XT")
                            {
                                //提交工作流 ********************
                                PostTaskUrl(_VoucherID, "FEPVJointTruck");
                                //等待提交流程的处理
                                System.Threading.Thread.Sleep(1000);

                                //提交工作流 ********************
                                if (tio.CheckIn(_VoucherID, "JointTruck"))
                                {
                                    MainMsg = "Check in success!";
                                    //
                                    ab.TruckDispatchCheckInDelete(_VoucherID);
                                    //
                                    if (tio.WeightOne(_VoucherID, weight, "JointTruck"))
                                    {
                                        MainMsg = "First weighing success!!";
                                        // todocsp tk :一磅后调用一个方法刷新未进厂成品车信息
                                    }
                                    else
                                    {
                                        MessageBox.Show("First weighing failed!");
                                    }
                                    //返回主页面
                                    BtnShow4Truck1();
                                }
                                else
                                {
                                    MainMsg = "Check in failed!";
                                }
                            }
                            else
                            {
                                //提交工作流 ********************
                                PostTaskUrl(_VoucherID, "FEPVUnJointTruck");
                                //等待提交流程的处理
                                System.Threading.Thread.Sleep(1000);

                                if (tio.CheckIn(_VoucherID, "UnJointTruck"))
                                {
                                    MainMsg = "Check in success!";
                                    //等待后台填写 当前处理意见
                                    System.Threading.Thread.Sleep(500);
                                    //
                                    if (tio.WeightOne(_VoucherID, weight, "UnJointTruck"))
                                    {
                                        MainMsg = "First weighing success!";
                                    }
                                    else
                                    {
                                        MessageBox.Show("First weighing failed!");
                                    }
                                    //返回主页面
                                    BtnShow4Truck1();
                                }
                                else
                                {
                                    MainMsg = "Check in failed!";
                                }
                            }
                        }
                        else
                        {
                            MainMsg = _JobTruckView.MsgTruck;
                        }
                        #endregion
                    }
                    else
                    {
                        #region State in (I,Y,W,E,D)
                        if (_JobTruckView.State == "I")
                        {
                            btnWeightTruck.Enabled = false;
                            btnUpWeightTruck.Enabled = false;
                            if (_JobTruckView.Flag == "XT")
                            {
                                if (tio.WeightOne(_VoucherID, weight, "JointTruck"))
                                {
                                    MainMsg = "First weighing success!!";
                                    //
                                    // todocsp tk :一磅后调用一个方法刷新未进厂成品车信息
                                    //
                                    BtnShow4Truck1();
                                }
                                else
                                {
                                    MainMsg = "First weighing failed!";
                                }
                            }
                            else
                            {
                                if (tio.WeightOne(_VoucherID, weight, "UnJointTruck"))
                                {
                                    MainMsg = "First weighing success!!";
                                    //
                                    BtnShow4Truck1();
                                }
                                else
                                {
                                    MainMsg = "First weighing failed!";
                                }
                            }
                        }
                        else
                        {
                            if (_JobTruckView.Flag == "XT")
                            {
                                #region Flag=XT

                                if (IsCallERP == "YES")
                                {
                                    //验证容差之前先更新发货单的实发量
                                    string orders = _JobTruckView.ShippingOrder;
                                    if (string.IsNullOrEmpty(orders))
                                    {
                                        MessageBox.Show(_VoucherID + "'s order is empty! " + "\nPlease contact the storage and transportation department!");
                                        return;
                                    }

                                    string msgOrder = "";
                                    bool rOrder = false;
                                    string trantype = "1";
                                    string strmsgorder = "";
                                    string[] ordergroup = orders.Split(',');
                                    foreach (string orderitem in ordergroup)
                                    {
                                        if (orderitem.Substring(0, 1) != "W")
                                            trantype = "1";
                                        else
                                            trantype = "2";
                                        rOrder = wf.GetShippingOrder(_VoucherID, trantype, orderitem, out msgOrder);
                                        if (!rOrder)
                                        {
                                            strmsgorder += msgOrder + "|";
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(strmsgorder))
                                    {
                                        MessageBox.Show("" + strmsgorder);
                                        return;
                                    }
                                    //
                                }
                                
                                string outmsg = "";
                                if (!tio.PonderationValidate(_VoucherID, weight, "JointTruck", out outmsg))
                                {
                                    string[] strmsg = outmsg.Split('|');
                                    if (strmsg.Length == 2)
                                    {
                                        MessageBox.Show(strmsg[1] + "\nPlease remove the exception and reweigh it!");
                                        //返回主页面
                                        BtnShow4Truck1();
                                        return;
                                    }
                                    else
                                    {
                                        //显示建单者信息：工号，姓名，部门，邮件
                                        string strUserid = st.GetCreaterInfo(_JobTruckView.CreateUserID);
                                        if (DialogResult.Yes == MessageBox.Show(outmsg + "\n\nDo you want to send a message? Please contact the creator after sending：" + strUserid + "，Complete the cause of the exception", "Exception message", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                                        {
                                            //获取taskid
                                            BPMTask[] taskswg = GetTask(_VoucherID, "", "FEPVJointTruck");
                                            string taskid = taskswg[0].id;

                                            wf.SendTaskComment(taskid, "WeightValidMessage", _VoucherID, outmsg, UserID, "JK2ndOverWeight");
                                            //等待后台填写 当前处理意见
                                            System.Threading.Thread.Sleep(1000);
                                            //
                                            if (tio.WeightTwo(_VoucherID, weight, "JointTruck"))
                                            {
                                                MainMsg = "Second weighing success!";
                                                //返回主页面
                                                BtnShow4Truck1();
                                            }
                                            else
                                            {
                                                MainMsg = "Second weighing failed!";
                                            }
                                        }
                                        else
                                        {
                                            //返回主页面
                                            BtnShow4Truck1();
                                            return;
                                        }
                                    }
                                }

                                if (tio.WeightTwo(_VoucherID, weight, "JointTruck"))
                                {
                                    MainMsg = "Second weighing success!";
                                    //
                                    btnPrintTruck.Enabled = true;
                                    btnWeightTruck.Enabled = false;
                                    btnUpWeightTruck.Enabled = false;
                                    //
                                    _JobTruckView.WeightRefresh(_VoucherID);
                                    _JobTruckView.PlanDetail4TruckTable = ab.QueryPlanData4TruckDetails(_VoucherID, MyLanguage.Language);
                                }
                                else
                                {
                                    MainMsg = "Second weighing failed!";
                                }
                                #endregion
                            }
                            else
                            {
                                btnWeightTruck.Enabled = false;
                                btnUpWeightTruck.Enabled = false;
                                //提交工作流 ********************
                                PostTaskUrl(_VoucherID, "FEPVUnJointTruck");
                                //等待提交流程的处理
                                System.Threading.Thread.Sleep(1000);

                                if (tio.WeightTwo(_VoucherID, weight, "UnJointTruck"))
                                {
                                    MainMsg = "Second weighing success!";
                                    //
                                    btnPrintTruck.Enabled = true;
                                    //
                                    _JobTruckView.WeightRefresh(_VoucherID);
                                    _JobTruckView.PlanDetail4TruckTable = ab.QueryPlanData4TruckDetails(_VoucherID, MyLanguage.Language);
                                }
                                else
                                {
                                    MainMsg = "Second weighing failed!";
                                }
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }
        }
        /// <summary>
        /// 打印磅单调用
        /// </summary>
        private void PrintPonderation()
        {
            string _VoucherID = _JobTruckView.VoucherID;//计划单号
            string _ItemID = _JobTruckView.ItemID.ToLower();//项次号

            if (_JobTruckView.Flag == "PE")
            {
                #region Flag = PE
                string typeName = "PtaEgTruck";
                //保存 柜号,卸货点
                SaveDischarge(_ItemID, _JobTruckView.CupboardNO, _JobTruckView.Discharge, _JobTruckView.TruckRemark, _JobTruckView.ReferWeight);
                
                //提交数据,完成工作流
                if (tio.PrintWeight(_ItemID, typeName))
                {
                    //打印磅单
                    Print(_VoucherID, "PE", true);
                    MainMsg = "Print success!";
                    //多次卸货提示
                    #region 多次卸货
                    if (DialogResult.Yes == MessageBox.Show("Whether the Truck to go to other unloading point unloading the goods?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                    {
                        MainMsg = "Please wait for the next time you create the data...!";
                        SelectDialog _Dialog = new SelectDialog();
                        _Dialog.Text = "Select the unloading point";
                        _Dialog.ShowDialog();

                        if (_Dialog.RValue)
                        {
                            //提交工作流 ********************结束本次工作流
                            PostTaskUrl(_ItemID, "GateGoodConfirm");
                            //等待提交流程的处理
                            System.Threading.Thread.Sleep(1000);

                            if (tio.CheckOut(_ItemID, typeName))
                            {
                                MainMsg = "Check out Success!";
                            }
                            else
                            {
                                MainMsg = "Check out failed!";
                                return;
                            }

                            //下一次工作流
                            string _Discharge = _Dialog.Discharge;//卸货点

                            if (!string.IsNullOrEmpty(_Discharge))
                            {
                                //创建工作流 ********************
                                PtaEgItem _PtaEgItem = new PtaEgItem();
                                _PtaEgItem.ItemID = Guid.NewGuid();
                                _PtaEgItem.VoucherID = _TruckInfo.VoucherID;
                                _PtaEgItem.CupboardNO = _JobTruckView.CupboardNO;
                                _PtaEgItem.Discharge = _Discharge;
                                ab.CreatePtaEgItem(_PtaEgItem);

                                string _NextItemID = _PtaEgItem.ItemID.ToString();
                                //
                                string pid = StartTask(_VoucherID, _NextItemID.ToLower(), "GateGoodConfirm");
                                //等待启动流程的处理
                                System.Threading.Thread.Sleep(2000);
                                MainMsg = "pid - " + pid.ToString();
                                //
                                if (!string.IsNullOrEmpty(pid))
                                {
                                    if (tio.CheckIn(_PtaEgItem.ItemID.ToString(), typeName))
                                    {
                                        MainMsg = "Check in success!";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Check in failed!");
                                        return;
                                    }
                                    //进厂称重
                                    decimal _Weight = 0;
                                    if (WeightMode == "HandMode")
                                    {
                                        _Weight = Convert.ToDecimal(txtHandWeight.Text.Trim());
                                    }
                                    else
                                    {
                                        _Weight = Convert.ToDecimal(led1.Text);
                                    }
                                    if (tio.WeightOne(_PtaEgItem.ItemID.ToString(), _Weight, typeName))
                                    {
                                        MainMsg = "First weighing success!";
                                    }
                                    else
                                    {
                                        MainMsg = "First weighing failed!";
                                    }
                                }
                                else
                                {
                                    MainMsg = "The PtaEg vehicle created the workflow failed!";
                                }
                            }
                            else
                            {
                                MainMsg = "The unloading point is empty and can not create a workflow!";
                            }
                        }
                    }
                    #endregion

                    //返回主页面
                    BtnShow4Truck1();
                    MainMsg = "";
                }
                else
                {
                    MainMsg = "Print failed!";
                }
                #endregion
            }
            else
            {
                #region Flag<>PE
                //提交数据,完成工作流
                if (_JobTruckView.Flag == "XT")
                {
                    if (IsCallERP=="YES")
                    {
                        //回填ERP系统车号等信息(接口)
                        string ErrMsg = "";
                        DataTable jtktb = ab.QueryPlanData4TruckDetails(_VoucherID, MyLanguage.Language);
                        DataRow jtkrow = jtktb.Rows[0];
                        if (jtkrow["ShippingOrder"].ToString().Substring(0, 1) != "W")
                        {
                            bool result = wf.VehicleInformation(jtkrow["ShippingOrder"].ToString(), jtkrow["TransferCompany"].ToString()
                                , jtkrow["VehicleNO"].ToString(), jtkrow["Driver"].ToString(), Convert.ToDateTime(jtkrow["SecondTime"]).ToString("yyyy-MM-dd HH:mm:ss"), out ErrMsg);
                            if (!result)
                            {
                                MessageBox.Show(ErrMsg, "Information");
                                return;
                            }
                        }
                        //
                    }
                    SaveRemark4XT(_VoucherID, _JobTruckView.TruckRemark);

                    if (tio.PrintWeight(_VoucherID, "JointTruck"))
                    {
                        //打印磅单
                        Print(_VoucherID, "XT", true);
                        MainMsg = "Print success!";
                        //
                        BtnShow4Truck1();
                        //成品车辆提示放行
                        if (DialogResult.Yes == MessageBox.Show("Whether to check out?", "JointTruck", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                        {
                            //提交工作流 ********************
                            PostTaskUrl(_VoucherID, "FEPVJointTruck");
                            //等待提交流程的处理
                            System.Threading.Thread.Sleep(1000);

                            if (tio.CheckOut(_VoucherID, "JointTruck"))
                            {
                                MainMsg = "Check out Success!";
                                //等待后台填写 当前处理意见
                                System.Threading.Thread.Sleep(500);
                                //返回主页面
                                BtnShow4Truck1();
                            }
                            else
                            {
                                MainMsg = "Check out failed!";
                            }
                        }
                    }
                    else
                    {
                        MainMsg = "Print failed!";
                    }
                }
                else if (_JobTruckView.Flag == "FX")
                {
                    if (tio.PrintWeight(_VoucherID, "UnJointTruck"))
                    {
                        if (DialogResult.Yes == MessageBox.Show("Whether to print?", "UnJointTruck", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                        {
                            //打印磅单
                            Print(_VoucherID, "XT", true);
                            MainMsg = "Print success!";
                        }
                        //
                        BtnShow4Truck1();
                    }
                    else
                    {
                        MainMsg = "Print failed!";
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// 保存 柜号,卸货点
        /// </summary>
        /// <param name="_ItemID"></param>
        /// <param name="_CupboardNO"></param>
        /// <param name="_Discharge"></param>
        private void SaveDischarge(string _ItemID, string _CupboardNO, string _Discharge, string _Remark, decimal _ReferWeight)
        {
            ab.SaveDischarge(_ItemID, _CupboardNO, _Discharge, _Remark, _ReferWeight);
        }

        /// <summary>
        /// 成品车辆保存备注
        /// </summary>
        /// <param name="_VoucherID"></param>
        private void SaveRemark4XT(string _VoucherID, string _Remark)
        {
            ab.SaveRemark4XT(_VoucherID, _Remark);
        }
        /// <summary>
        /// 打印磅单
        /// </summary>
        private void Print(string VoucherID, string Type, bool isPaperPrint)
        {
            Print doc = new Print(VoucherID, Type);
            doc.Setting = Setting4Print;
            doc.PrintBill(isPaperPrint);
        }
        /// <summary>
        /// 车辆返回界面
        /// </summary>
        private void Back4Truck()
        {
            //返回主页面
            BtnShow4Truck1();
        }
        #endregion
        
        #region ShortTruck

        DataTable dtShortTruck = new DataTable();

        /// <summary>
        /// 成品短驳车辆查询
        /// </summary>
        private void ShortQueryPlan()
        {
            string msg = string.Empty;
            dtShortTruck = st.GetCheckInOnePlan(_ShortInfo.Parameters, _ShortInfo.Values, UserID);
            _ShortInfo.Plan4ShortTable = dtShortTruck;
            btnWeightShort.Enabled = true;
            MainMsg = "*_*";
        }
        /// <summary>
        /// 成品短驳车辆进厂放行
        /// </summary>
        private void CheckIn4Short()
        {
            try
            {
                string _VoucherID = _JobShortView.VoucherID;
                string _ItemID = _JobShortView.ItemID;

                if (_JobShortView.State == "Q")
                {
                    //检查厂内车辆是否存在
                    if (_JobShortView.IsReady4VehicleNO)
                    {
                        //创建运输数据
                        if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                        {
                            //启动流程 ********************
                            //TODO: 成品短驳启动流程
                            string pid = StartTask(_VoucherID, _ItemID, "ProcessShortTruck");
                            //等待启动流程的处理
                            System.Threading.Thread.Sleep(2000);
                            MainMsg = "pid - " + pid.ToString();

                            if (!string.IsNullOrEmpty(pid))
                            {
                                //获取运输信息并保存PID
                                SaveShortTruckTransportKey(_VoucherID, _ItemID, "PID", pid);

                                MainMsg = "Check in success!";

                                //成品短驳是否有过第一次空磅记录
                                DataTable dtChk = st.IsCheckinWeightOne(_VoucherID);
                                if (dtChk.Rows.Count > 0)
                                {
                                    DataRow row = dtChk.Rows[0];
                                    decimal weightchk = Convert.ToDecimal(row["Weight1"]);
                                    //后台完成一次进厂过磅,重量取自第一次空磅记录
                                    //获取运输信息
                                    ShortTruckTransport _ShortTruckTransport = st.GetShortTruckTransport(_VoucherID, _ItemID);
                                    _ShortTruckTransport.Weight1 = weightchk;
                                    _ShortTruckTransport.Weight1Time = DateTime.Now;
                                    _ShortTruckTransport.Status = "Y1";
                                    //保存运输信息
                                    if (!st.SaveShortTruckTransport(_ShortTruckTransport))
                                    {
                                        MessageBox.Show("Message saved failed！");
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Finished short piece of the first single plan, please [empty pounds] to make the reference weight！", "prompt");
                                }

                                //返回主页面
                                BtnShow4Short1();
                            }
                            else
                            {
                                MainMsg = "The vehicle failed to start the process!";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Message saved failed！");
                            return;
                        }
                    }
                    else
                    {
                        MainMsg = _JobShortView.MsgTruck;
                    }
                }
                else if (_JobShortView.State == "O1")
                {
                    //获取运输信息并保存
                    if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                    {
                        //提交工作流 ********************
                        PostTask(_VoucherID, _ItemID, "", "短驳运输流程");
                        //等待提交流程的处理
                        System.Threading.Thread.Sleep(2000);
                        //
                        MainMsg = "Check in success!";
                        //返回主页面
                        BtnShow4Short1();
                    }
                    else
                    {
                        MainMsg = "Message saved failed!";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }
        /// <summary>
        /// 成品短驳车辆出厂放行
        /// </summary>
        private void CheckOut4Short()
        {
            try
            {
                string _VoucherID = _JobShortView.VoucherID;//计划单号
                string _ItemID = _JobShortView.ItemID;//计划项次

                //保存 ********************
                if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                {
                    //提交工作流 ********************
                    PostTask(_VoucherID, _ItemID, "", "短驳运输流程");
                    //等待提交流程的处理
                    System.Threading.Thread.Sleep(2000);
                    MainMsg = "Check out Success!";
                    //返回主页面
                    BtnShow4Short1();
                }
                else
                {
                    MainMsg = "Message saved failed!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message");
            }
        }
        /// <summary>
        /// 成品短驳车辆称重
        /// </summary>
        private void WeightShort()
        {

            if (WeightMode == "HandMode")
            {
                ShortWeighting(Convert.ToDecimal(txtHandWeight3.Text.Trim()));
            }
            else
            {
                if (led3.ForeColor != Color.Blue)
                    return;
                ShortWeighting(Convert.ToDecimal(led3.Text));
            }
            btnUpWeightShort.Enabled = true;
        }

        private void ShortWeighting(decimal weightShort)
        {
            if (weightShort < 40m)
                return;

            weight = weightShort;
            if (_JobShortView.State == "I1" || _JobShortView.State == "I2")
            {
                _JobShortView.FirstWeight = weight;
                _JobShortView.FirstTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                _JobShortView.SecondWeight = weight;
                _JobShortView.SecondTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                _JobShortView.TotalWeight = weight - _JobShortView.FirstWeight;
            }
        }
        /// <summary>
        /// 成品短驳车辆上传重量
        /// </summary>
        private void UpWeightShort()
        {
            if (DialogResult.Yes == MessageBox.Show("Whether to upload this weight" + weight.ToString(), "information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
            {
                btnWeightShort.Enabled = false;
                btnUpWeightShort.Enabled = false;
                btnPrintShort.Enabled = true;

                //提交数据,完成工作流
                string _VoucherID = _JobShortView.VoucherID;//计划单号
                string _ItemID = _JobShortView.ItemID;//计划项次

                if (_JobShortView.State == "I1")
                {
                    //获取运输信息
                    if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                    {
                        MainMsg = "First weighing success!!";
                        //
                        BtnShow4Short1();
                    }
                    else
                    {
                        MainMsg = "Message saved failed!";
                    }
                }
                else if (_JobShortView.State == "Y1")
                {
                    if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                    {
                        MainMsg = "Second weighing success!";
                        //
                        _JobShortView.WeightRefresh(_VoucherID);
                    }
                    else
                    {
                        MainMsg = "Message saved failed!";
                    }
                }
                else if (_JobShortView.State == "I2")
                {
                    //成品短驳验证容差
                    //获取运输信息
                    ShortTruckTransport _ShortTruckTransportRC = st.GetShortTruckTransport(_VoucherID, _ItemID);
                    decimal _weight2 = _ShortTruckTransportRC.Weight2;//装货区总重
                    decimal _weight3now = weight;//当前地磅值
                    //获取成品短驳磅差设定值
                    DataRow rowRC = rep.GetMISReport("A_Q_ShortTruck_Validate", new string[] { }, new object[] { }).Tables[0].Rows[0];
                    decimal _weightRCset = Convert.ToDecimal(rowRC[0]);//容差设定值
                    decimal _wRC = Math.Abs(_weight3now - _weight2);//偏差值
                    if (_wRC > _weightRCset)//如果超出磅值管控范围
                    {
                        //发送异常消息内容
                        string messageComment = string.Format(@"容差异常:装车处重车重量为{0}KG,卸车处重车重量为{1}KG,容差范围设定为上下{2}KG,实际磅差{3}KG"
                                                                        , _weight2.ToString()
                                                                        , _weight3now.ToString()
                                                                        , _weightRCset.ToString()
                                                                        , _wRC.ToString());

                        //显示建单者信息：工号，姓名，部门，邮件
                        string strUserid = st.GetCreaterInfo(_JobShortView.CreateUserID);
                        if (DialogResult.Yes == MessageBox.Show(messageComment + "，Do you want to send a message? Please contact the creator after sending：" + strUserid + "，Complete the cause of the exception", "Exception message", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                        {
                            //获取taskid
                            BPMTask[] taskswg = GetTask(_VoucherID, "", "短驳运输流程");
                            string taskid = taskswg[0].id;

                            wf.SendTaskComment(taskid, "WeightValidMessage", _VoucherID, messageComment, UserID, "SToverWeight");
                            //等待后台填写 当前处理意见
                            System.Threading.Thread.Sleep(2000);
                        }
                        else
                        {
                            //返回主页面
                            BtnShow4Short1();
                            return;
                        }
                    }

                    if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                    {
                        MainMsg = "Third weighing success!";

                        //成品短驳是否有过第一次空磅记录
                        DataTable dtChk = st.IsCheckinWeightOne(_VoucherID);
                        if (dtChk.Rows.Count > 0)
                        {
                            DataRow row = dtChk.Rows[0];
                            decimal weightchk = Convert.ToDecimal(row["Weight1"]);
                            //后台完成二次出厂过磅,重量取自第一次空磅记录
                            //获取运输信息
                            ShortTruckTransport _ShortTruckTransport = st.GetShortTruckTransport(_VoucherID, _ItemID);
                            _ShortTruckTransport.Weight4 = weightchk;
                            _ShortTruckTransport.Weight4Time = DateTime.Now;
                            _ShortTruckTransport.Status = "E2";
                            //保存运输信息
                            if (!st.SaveShortTruckTransport(_ShortTruckTransport))
                            {
                                MessageBox.Show("Message saved failed！");
                                return;
                            }
                        }
                        //返回主页面
                        BtnShow4Short1();
                    }
                    else
                    {
                        MainMsg = "Message saved failed!";
                    }
                }
                else if (_JobShortView.State == "Y2")
                {
                    if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                    {
                        //等待后台填写 当前处理意见
                        System.Threading.Thread.Sleep(500);

                        string _Message = "";

                        if (string.IsNullOrEmpty(_Message))
                        {
                            MainMsg = "Fourth weighing success!";
                            //
                            _JobShortView.WeightRefresh(_VoucherID);
                        }
                        else
                        {
                            MessageBox.Show(_Message + "\nPound difference often, please create person to deal with!");
                            //返回主页面
                            BtnShow4Short1();
                        }
                    }
                    else
                    {
                        MainMsg = "Message saved failed!";
                    }
                }
            }
        }

        /// <summary>
        /// 获取成品短驳运输信息并保存
        /// </summary>
        /// <param name="voucherId"></param>
        /// <param name="itemId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private bool CallSaveShortTruckTransport(string voucherId, string itemId, string state, string datamsg)
        {
            bool rValue = false;
            //获取运输信息
            ShortTruckTransport _ShortTruckTransport = st.GetShortTruckTransport(voucherId, itemId);

            //等待后台填写 当前处理意见
            System.Threading.Thread.Sleep(1000);

            string status = "";//当前状态
            string nextstate = "";//下一个状态
            if (state != "Q")
            {
                status = _ShortTruckTransport.Status;//获取当前状态
            }
            switch (status)
            {
                case "": nextstate = "Q";
                    break;
                case "I1": nextstate = "I1";
                    break;
                case "Y1": nextstate = "Y1";
                    break;
                case "E1": nextstate = "E1";
                    break;
                case "D1": nextstate = "D1";
                    break;
                case "O1": nextstate = "O1";
                    break;
                case "I2": nextstate = "I2";
                    break;
                case "Y2": nextstate = "Y2";
                    break;
                case "E2": nextstate = "E2";
                    break;
                case "D2": nextstate = "D2";
                    break;
                default: MessageBox.Show("The status is incorrect!");
                    break;
            }
            switch (nextstate)
            {
                case "Q":
                    _ShortTruckTransport.VoucherID = voucherId;
                    _ShortTruckTransport.ItemID = itemId;
                    _ShortTruckTransport.InTime = DateTime.Now;
                    _ShortTruckTransport.Status = "I1";
                    _ShortTruckTransport.Stamp = DateTime.Now;
                    _ShortTruckTransport.UserID = UserID;
                    _ShortTruckTransport.Message = "";
                    _ShortTruckTransport.Reason = "";
                    _ShortTruckTransport.OverTimeMessage = "";
                    _ShortTruckTransport.OverTimeReason = "";
                    break;
                case "I1":
                    _ShortTruckTransport.Weight1 = weight;
                    _ShortTruckTransport.Weight1Time = DateTime.Now;
                    _ShortTruckTransport.Status = "Y1";
                    break;
                case "Y1":
                    _ShortTruckTransport.Weight2 = weight;
                    _ShortTruckTransport.Weight2Time = DateTime.Now;
                    _ShortTruckTransport.Status = "E1";
                    break;
                case "E1":
                    _ShortTruckTransport.Status = "D1";
                    break;
                case "D1":
                    _ShortTruckTransport.OutTime1 = DateTime.Now;
                    _ShortTruckTransport.Status = "O1";
                    break;
                case "O1":
                    _ShortTruckTransport.InTime2 = DateTime.Now;
                    _ShortTruckTransport.Status = "I2";
                    break;
                case "I2":
                    _ShortTruckTransport.Weight3 = weight;
                    _ShortTruckTransport.Weight3Time = DateTime.Now;
                    _ShortTruckTransport.Status = "Y2";
                    break;
                case "Y2":
                    _ShortTruckTransport.Weight4 = weight;
                    _ShortTruckTransport.Weight4Time = DateTime.Now;
                    _ShortTruckTransport.Status = "E2";
                    break;
                case "E2":
                    _ShortTruckTransport.Status = "D2";
                    break;
                case "D2":
                    _ShortTruckTransport.OutTime2 = DateTime.Now;
                    _ShortTruckTransport.Status = "O2";
                    break;
                default: MessageBox.Show("The status is incorrect!");
                    break;
            }
            //保存运输信息
            if (st.SaveShortTruckTransport(_ShortTruckTransport))
            {
                rValue = true;
            }
            return rValue;
        }
        /// <summary>
        /// 根据关键字保存运输信息
        /// </summary>
        /// <param name="voucherId"></param>
        /// <param name="itemId"></param>
        /// <param name="keyvalue"></param>
        /// <param name="datamsg"></param>
        /// <returns></returns>
        private bool SaveShortTruckTransportKey(string voucherId, string itemId, string keyvalue, string datamsg)
        {
            bool rValue = false;
            //获取运输信息
            ShortTruckTransport _ShortTruckTransport = st.GetShortTruckTransport(voucherId, itemId);

            //等待后台填写 当前处理意见
            System.Threading.Thread.Sleep(1000);

            switch (keyvalue)
            {
                case "PID":
                    _ShortTruckTransport.PID = datamsg;
                    break;
                case "Message":
                    _ShortTruckTransport.Message = datamsg;
                    break;
                default: MessageBox.Show("The keyword is incorrect!");
                    break;
            }
            //保存运输信息
            if (st.SaveShortTruckTransport(_ShortTruckTransport))
            {
                rValue = true;
            }
            return rValue;
        }
        
        /// <summary>
        /// 查询是否有异常
        /// </summary>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        private bool RestIsExceptionTruck(string voucherid, string processDefinitionName)
        {
            if (processDefinitionName == "短驳运输流程")
            {
                BPMTask[] tasks = GetTask(voucherid, "异常原因", processDefinitionName);
                if (tasks.Count() > 0)
                {
                    MainMsg = "Task ID：" + tasks[0].id;
                    return true;
                }
                else
                {
                    MainMsg = "^_^";
                    return false;
                }
            }
            else
            {
                //BPMTask[] tasks = GetTask(voucherid, "异常处理", processDefinitionName);
                BPMTask[] tasks = GetTask(voucherid, "exception handling", processDefinitionName);
                if (tasks.Count() > 0)
                {
                    MainMsg = "Task ID：" + tasks[0].id;
                    return true;
                }
                else
                {
                    MainMsg = "^_^";
                    return false;
                }
            }            
        }

        /// <summary>
        /// 成品短驳车辆打印磅单
        /// </summary>
        private void PrintPonderationShort()
        {
            MainMsg = _JobShortView.State;
            string _VoucherID = _JobShortView.VoucherID;//计划单号
            string _ItemID = _JobShortView.ItemID;//计划项次
            bool isPaperPrint = false;
            if (_JobShortView.State == "Y1" || _JobShortView.State == "E1")
            {
                if (DialogResult.Yes == MessageBox.Show("Whether to print?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                {
                    isPaperPrint = true;
                }
                //打印磅单
                Print(_VoucherID + _ItemID, "ST1", isPaperPrint);
                //提交数据,完成工作流
                if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                {
                    MainMsg = "Print success!";
                    //
                    BtnShow4Short1();
                }
                else
                {
                    MainMsg = "Print failed!";
                }
            }
            else if (_JobShortView.State == "Y2" || _JobShortView.State == "E2")
            {
                if (DialogResult.Yes == MessageBox.Show("Whether to print?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                {
                    isPaperPrint = true;
                }
                //打印磅单
                Print(_VoucherID + _ItemID, "ST2", isPaperPrint);
                //提交数据,完成工作流
                if (CallSaveShortTruckTransport(_VoucherID, _ItemID, _JobShortView.State, ""))
                {
                    MainMsg = "Print success!";
                    //
                    BtnShow4Short1();
                }
                else
                {
                    MainMsg = "Print failed!";
                }
            }
            else
            {
                MessageBox.Show("The short state is:" + _JobShortView.State + ",The status is incorrect,Can not print!", "information");
            }
        }
        /// <summary>
        /// 成品短驳车辆返回界面
        /// </summary>
        private void Back4Short()
        {
            //返回主页面
            BtnShow4Short1();
        }
        /// <summary>
        /// 成品短驳是否有过第一次空磅记录
        /// </summary>
        /// <param name="voucherid">成品短驳计划单号</param>
        /// <returns></returns>
        private bool IsCheckinWeightOne(string voucherid)
        {
            bool rValue = false;
            DataTable dtChk = st.IsCheckinWeightOne(voucherid);

            if (dtChk.Rows.Count > 0)
            {
                rValue = true;
            }
            return rValue;
        }
        #endregion

        #region event

        void _TruckInfo_eventShowTruckView(object sender, EventArgs e)
        {
            if (dtTruck.Rows.Count == 0)
                return;
            //Add parameter to JobTruckView
            _JobTruckView.Setting4Print = Setting4Print;

            EgateArgs args = (EgateArgs)e;
            _JobTruckView.ParasPtaEg = args.EgateDictionary;

            #region
            string _VoucherID = _JobTruckView.VoucherID;//Plan number
            string _ItemID = _JobTruckView.ItemID.ToLower();//Item number
            string flag = (string)args.EgateDictionary["Types"];
            string state = ab.GetVoucherStatus(_VoucherID, _ItemID);
            //string state = (string)args.EgateDictionary["Status"];
            _JobTruckView.Flag = flag;
            _JobTruckView.State = state;

            MainMsg = flag + " - " + state;

            if (!CheckTruckState(_VoucherID, _ItemID, state, flag))
            {
                MainMsg = "The status of the document has been updated, please re-query!";
                return;
            }

            if (_JobTruckView.State == "Q")
            {
                string processDefinitionName = "";
                string taskDefinitionKey = "";
                if (_JobTruckView.Flag == "XT")
                {
                    processDefinitionName = "FEPVJointTruck";
                    taskDefinitionKey = "checkintask";
                    //判断节点此时是否有任务
                    if (!TaskIsExists(_VoucherID, taskDefinitionKey, processDefinitionName))
                    {
                        MainMsg = _VoucherID + " - Is in approving State" + " " + taskDefinitionKey;
                        return;
                    }
                }
                else if (_JobTruckView.Flag == "FX")
                {
                    processDefinitionName = "FEPVUnJointTruck";
                    taskDefinitionKey = "UserTask_3";
                    //判断节点此时是否有任务
                    if (!TaskIsExists(_VoucherID, taskDefinitionKey, processDefinitionName))
                    {
                        MainMsg = _VoucherID + " - In the signing" + " " + taskDefinitionKey;
                        return;
                    }
                }                
            }

            if (_JobTruckView.Flag == "XT" && _JobTruckView.State == "E")
            {
                //是否有异常
                if (RestIsExceptionTruck(_VoucherID, "FEPVJointTruck"))
                {
                    //显示建单者信息：工号，姓名，部门，邮件
                    string strUserid = st.GetCreaterInfo(_JobTruckView.CreateUserID);
                    MessageBox.Show("Documents have questions, please contact the creator：" + strUserid + "，Complete the cause of the exception", "information");
                    return;
                }
            }

            if (_JobTruckView.Flag == "PE" && _JobTruckView.State == "W")
            {
                //是否有异常
                if (RestIsExceptionTruck(_ItemID, "GateGoodConfirm"))
                {
                    //显示建单者信息：工号，姓名，部门，邮件
                    string ptaUserid = ab.GetUserIDByItemID(_ItemID);
                    string strUserid = st.GetCreaterInfo(ptaUserid);
                    MessageBox.Show("Documents have questions, please contact the creator：" + strUserid + "，Complete the cause of the exception", "information");
                    return;
                }
            }

            if (_JobTruckView.Flag == "FX" && _JobTruckView.State == "W")
            {
                //车辆现场是否确认
                string processDefinitionName = "FEPVUnJointTruck";
                string taskDefinitionKey = "UserTask_5";//二次过磅前的装卸货确认
                //判断节点此时是否有任务
                if (TaskIsExists(_VoucherID, taskDefinitionKey, processDefinitionName))
                {
                    MainMsg = _VoucherID + " - In confirmation" + " " + taskDefinitionKey;
                    MessageBox.Show("The vehicle needs to be confirmed on the spot in order to weigh the second time！");
                    return;
                }
            }

            //卸货点
            if (flag == "PE")
            {
                _JobTruckView.CupboardNO_Enable = true;
            }
            else
            {
                _JobTruckView.CupboardNO_Enable = false;
            }
            //计划明细
            if (flag == "PE" && state != "Q")
            {
                _JobTruckView.WeightRefresh(_ItemID);
                _JobTruckView.PlanDetail4TruckTable = ab.QueryPlanData4TruckDetails(_ItemID, MyLanguage.Language);
            }
            else
            {
                _JobTruckView.WeightRefresh(_VoucherID);
                _JobTruckView.PlanDetail4TruckTable = ab.QueryPlanData4TruckDetails(_VoucherID, MyLanguage.Language);
            }
            //Button Show
            btnUpWeightTruck.Enabled = false;
            btnPrintTruck.Enabled = false;
            //
            switch (state)
            {
                case "Q":
                    if (flag == "ST")
                    {
                        BtnShow4Truck2In();
                    }
                    else
                    {
                        BtnShow4Truck2Weight1();
                    }
                    break;
                case "I":
                    BtnShow4Truck2Weight1();
                    break;
                case "Y":
                case "W":
                    BtnShow4Truck2Weight2();
                    break;
                case "E":
                    btnPrintTruck.Enabled = true;
                    BtnShow4Truck2Print();
                    break;
                case "D":
                    BtnShow4Truck2Out();
                    break;
                default: MessageBox.Show("Plan status is not correct!");
                    break;
            }
            #endregion
        }

        void _ShortInfo_eventShowShortView(object sender, EventArgs e)
        {
            if (dtShortTruck.Rows.Count == 0)
                return;
            //Add parameter to JobShortView
            _JobShortView.Setting4Print = Setting4Print;
            EgateArgs args = (EgateArgs)e;
            _JobShortView.ParasPtaEg = args.EgateDictionary;

            #region 
            string state = (string)args.EgateDictionary["Status"];
            _JobShortView.State = state;

            MainMsg = state;

            string _VoucherID = _JobShortView.VoucherID; 
            string _ItemID = _JobShortView.ItemID;

            //Anything unusual
            if (RestIsExceptionTruck(_VoucherID, "短驳运输流程"))
            {
                //显示建单者信息：工号，姓名，部门，邮件
                string strUserid = st.GetCreaterInfo(_JobShortView.CreateUserID);
                MessageBox.Show("Documents have questions, please contact the creator：" + strUserid + "，Complete the cause of the exception", "information");
                return;
            }

            _JobShortView.WeightRefresh(_VoucherID);
            _JobShortView.PlanDetail4TruckTable = st.GetPlanItemById(_VoucherID, _ItemID);
            //
            btnUpWeightShort.Enabled = false;
            btnPrintShort.Enabled = false;

            //成品短驳是否有过第一次空磅记录
            bool countChk = IsCheckinWeightOne(_VoucherID);

            //按钮显示
            switch (state)
            {
                case "Q":
                    //检查厂内车辆是否存在
                    if (_JobShortView.IsReady4VehicleNO)
                    {
                        BtnShow4Short2In();
                    }
                    else
                    {
                        MainMsg = _JobShortView.MsgTruck;
                    }
                    break;
                case "I1":
                    BtnShow4Short2Weight1();
                    break;
                case "Y1":
                    BtnShow4Short2Weight2();
                    break;
                case "E1":
                    btnPrintShort.Enabled = true;
                    BtnShow4Short2Print();
                    break;
                case "D1":
                    BtnShow4Short2Out();
                    break;
                case "O1":
                    BtnShow4Short2In();
                    break;
                case "I2":
                    BtnShow4Short2Weight1();
                    break;
                case "Y2":
                    BtnShow4Short2Weight2();
                    break;
                case "E2":
                    btnPrintShort.Enabled = true;
                    BtnShow4Short2Print();
                    break;
                case "D2":
                    BtnShow4Short2Out();
                    break;
                default: MessageBox.Show("Plan status is not correct!!");
                    break;
            }
            #endregion
        }

        string Data = string.Empty;
        /// <summary>
        /// serialPort Data Received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Data += serialPort.ReadExisting();
            dataPackage.LastActive = DateTime.Now;

            //Add by Leo for new ToLeDo at FEPV 20170415
            if (FEPVTOLEDO.DoTransfer(Data, out weight))
            {
                dataPackage.Weight = weight;
                //MainMsg = DateTime.Now.ToString() + "-TOLEDO-" + weight.ToString();
                Data = string.Empty;
                return;
            }
            if (TOLEDO.DoTransfer(Data, out weight))
            {
                dataPackage.Weight = weight;
                //MainMsg = DateTime.Now.ToString() + "-TOLEDO-" + weight.ToString();
                Data = string.Empty;
                return;
            }
            if (BeiChang.DoTransfer(Data, out weight))
            {
                dataPackage.Weight = weight;
                //MainMsg = DateTime.Now.ToString() + "-BeiChang-" + weight.ToString();
                Data = string.Empty;
                return;
            }
            if (DongChang.DoTransfer(Data, out weight))
            {
                dataPackage.Weight = weight;
                //MainMsg = DateTime.Now.ToString() + "-DongChang-" + weight.ToString();
                Data = string.Empty;
                return;
            }
            if (YaoHua.DoTransfer(Data, out weight))
            {
                dataPackage.Weight = weight;
                //MainMsg = DateTime.Now.ToString() + "-YaoHua-" + weight.ToString();
                Data = string.Empty;
                return;
            }
            if (Data.Length > 1000)
                Data = string.Empty;
        }

        void _TruckInfo_eventShowTruckBar(object sender, EventArgs e)
        {
            if (dtTruck.Rows.Count == 0)
                return;

            EgateArgs args = (EgateArgs)e;
            _JobTruckView.ParasPtaEg = args.EgateDictionary;

            string _VoucherID = _JobTruckView.VoucherID;//计划单号
            string _ItemID = _JobTruckView.ItemID;//项次号
            string flag = (string)args.EgateDictionary["Types"];
            string state = ab.GetVoucherStatus(_VoucherID, _ItemID);
            //string state = (string)args.EgateDictionary["Status"];
            _JobTruckView.Flag = flag;
            _JobTruckView.State = state;

            MainMsg = flag + " - " + state;

            if (flag == "ST" && state == "Q")
            {
                #region [special Truck]
                //不过磅
                btnInTruck.Visible = true;
                btnOutTruck.Visible = false;
                barTruck.Refresh();
                #endregion
            }
            else if (state == "D")
            {
                btnInTruck.Visible = false;
                btnOutTruck.Visible = true;
                barTruck.Refresh();
            }
            else
            {
                btnInTruck.Visible = false;
                btnOutTruck.Visible = false;
                barTruck.Refresh();
            }
        }

        void _TruckInfo_eventBtnQueryPlan(object sender, EventArgs e)
        {
            //TODO:废料车辆打印磅单后需系统确认 
            string[] str = TruckQueryPlanState(_TruckInfo.Values[0].ToString()).Split('|');
            string _VoucherID = str[0];
            if (str[1] == "D")
            {
                //废料车辆现场是否确认
                string processDefinitionName = "FEPVUnJointTruck";
                string taskDefinitionKey = "UserTask_6";//出厂前的装卸货确认
                //判断节点此时是否有任务
                if (TaskIsExists(_VoucherID, taskDefinitionKey, processDefinitionName))
                {
                    MainMsg = _VoucherID + " - The scene is confirming" + " " + taskDefinitionKey;
                    //现场单据未确认的显示进度
                    MessageBox.Show(str[2].ToString());
                    return;
                }
                else
                {
                    TruckQueryPlan();
                }
            }
            else
            {
                TruckQueryPlan();
            }
        }
        /// <summary>
        /// 车辆计划状态查询
        /// </summary>
        private string TruckQueryPlanState(string vehicleNO)
        {
            string rResult = "";
            //rep
            DataRow row = rep.GetMISReport("Q_TruckQueryPlanState", new string[] { "VehicleNO", "UserWF" }, new object[] { vehicleNO, UserID }).Tables[0].Rows[0];
            rResult = row[0].ToString() + "|" + row[1].ToString() + "|" + row[2].ToString();
            //
            return rResult;
        }

        /// <summary>
        /// 判断前后台状态是否一致
        /// </summary>
        /// <param name="_VoucherID"></param>
        /// <param name="_ItemID"></param>
        /// <param name="state"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private bool CheckTruckState(string _VoucherID, string _ItemID, string state, string flag)
        {
            string sqlVoucherId = "";
            string sqlstate = "";
            if (flag == "PE" && state != "Q")
            {
                sqlVoucherId = _ItemID;
            }
            else
            {
                sqlVoucherId = _VoucherID;
            }

            DataTable sqldt = ab.QueryPlanData4TruckDetails(sqlVoucherId, MyLanguage.Language);

            if (flag == "PE" && state == "Q")
                return true;
            else
                sqlstate = sqldt.Rows[0]["Status"].ToString();

            if (state == sqlstate)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断此businessKey在警卫的CheckIn和CheckOut节点是否有任务
        /// </summary>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        private bool TaskIsExists(string businessKey, string taskDefinitionKey, string processDefinitionName)
        {
            // taskDefinitionKey="UserTask_checkin"
            // 门禁访客 Check In：id="UserTask_checkin" Check Out：id="UserTask_checkout" 
            // 物品出厂 警卫CheckOut：id="UserTask_CheckOut"
            // 物品回厂 物品回厂修正：id="UserTask_Update" 
            // 协同车辆流程 装卸货：id="UserTask_3"

            BPMTask[] tasks = GetTaskUrl(businessKey, taskDefinitionKey, processDefinitionName);
            if (tasks.Count() > 0)
            {
                MainMsg = "Task Id：" + tasks[0].id;
                return true;
            }
            else
            {
                return false;
            }
        }        
        #endregion
        
        #region REST
        /// <summary>
        /// 启动进程(成品短驳)
        /// </summary>
        /// <param name="voucherid"></param>
        /// <param name="itemid"></param>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public string StartTask(string voucherid, string itemid, string processName)
        {
            //initiator：建计划人/处理异常人，JWUser：流程启动人(警卫)
            var formdata = new Dictionary<string, object> { };
            if (processName == "ProcessShortTruck")
            {
                formdata = new Dictionary<string, object>
                {
                    { "PlanId", voucherid },
                    { "ItemId", itemid },
                    { "initiator", _JobShortView.CreateUserID },
                    { "JWUser", UserID }
                };
                return wf.Startdefinition(formdata, voucherid, processName);
            }
            else if (processName == "GateGoodConfirm")
            {
                string ptaUserid = ab.GetUserIDByItemID(itemid);//PtaEgTruck表的建单人
                formdata = new Dictionary<string, object>
                {
                    { "VoucherID", voucherid },
                    { "start_remark", itemid },
                    { "initiator", ptaUserid },
                    { "JWUser", UserID }
                };
                return wf.Startdefinition(formdata, itemid, processName);
            }
            else
                return "";
        }
        /// <summary>
        /// 获取任务(根据节点名称)
        /// </summary>
        /// <param name="businessKey"></param>
        /// <param name="name"></param>
        /// <param name="processDefinitionName"></param>
        /// <returns></returns>
        public BPMTask[] GetTask(string businessKey, string name, string processDefinitionName)
        {
            //例如：processDefinitionName="短驳运输流程",name="异常原因"
            BPMTask[] tasks = wf.GetGateTask("", businessKey, name, processDefinitionName);
            return tasks;
        }
        /// <summary>
        /// 提交一个任务(成品短驳)
        /// </summary>
        /// <param name="voucherid"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public string PostTask(string voucherid, string itemid, string name, string processDefinitionName)
        {
            string jsonstr = string.Empty;

            BPMTask[] tasks = GetTask(voucherid, name, processDefinitionName);
            foreach (BPMTask task in tasks)
            {
                Console.WriteLine(string.Format("taskid:{0},name:{1},des:{2}", task.id, task.name, task.description));
                var formdata = new Dictionary<string, object>
                {
                   { "PlanId", voucherid },
                   { "ItemId", itemid },             
                };
                jsonstr = wf.PostTask(task.id, formdata, voucherid);
            }
            return jsonstr;
        }        
        /// <summary>
        /// 获取任务
        /// </summary>
        /// <param name="businessKey"></param>
        /// <param name="taskDefinitionKey">进程节点变量名</param>
        /// <param name="processDefinitionName">进程名称</param>
        /// <returns></returns>
        public BPMTask[] GetTaskUrl(string businessKey, string taskDefinitionKey, string processDefinitionName)
        {
            //例如：processDefinitionName="短驳运输流程",门禁访客,物品出厂,物品回厂,协同车辆流程
            // taskDefinitionKey="UserTask_checkin"
            // 门禁访客 id="UserTask_checkin" 
            //          id="UserTask_checkout" 
            // 物品出厂 id="UserTask_CheckOut"
            // 物品回厂 id="UserTask_confirm" 
            // 协同车辆流程 id="UserTask_3"
            string requrl = string.Format("?processDefinitionName={0}&processInstanceBusinessKey={1}&taskDefinitionKey={2}", processDefinitionName, businessKey, taskDefinitionKey);
            BPMTask[] tasks = wf.GetGateTaskUrl(requrl);
            return tasks;
        }
        /// <summary>
        /// 提交一个任务
        /// </summary>
        /// <param name="voucherid">businessKey</param>
        /// <param name="itemid"></param>
        /// <param name="name">进程节点名称</param>
        /// <param name="processDefinitionName">进程名称</param>
        /// <returns></returns>
        public string PostTaskUrl(string businessKey, string processDefinitionName)
        {
            try
            {
                string requrl = string.Format("?processDefinitionName={0}&processInstanceBusinessKey={1}", processDefinitionName, businessKey);
                BPMTask[] tasks = wf.GetGateTaskUrl(requrl);

                //等待提交流程的处理
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
