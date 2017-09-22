using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class EGBK
    {
        /// <summary>
        /// 车辆计划查询
        /// </summary>
        private void TruckQueryPlan()
        {
            dtTruck = ab.GetTrucks(_TruckInfo.Parameters, _TruckInfo.Values, UserID);
            _TruckInfo.Plan4TruckTable = dtTruck;
            MainMsg = "";
        }
        /// <summary>
        /// 取消过磅操作
        /// </summary>
        /// <param name="flag">标识</param>
        /// <param name="cancelName">取消类型</param>
        /// <param name="_VoucherID">计划单号</param>
        /// <param name="_ItemID">项次号</param>
        /// <param name="backReason">取消原因</param>
        void ProcessCancel(string flag, string cancelName, string _VoucherID, string _ItemID, string backReason)
        {
            bool rValue = false;
            switch (flag)
            {
                case "XT":
                    if (string.IsNullOrEmpty(_VoucherID))
                    {
                        MessageBox.Show("Please select the order number from the table below");
                        return;
                    }
                    switch (cancelName)
                    {
                        case "CancelOne":
                            if (tio.CancelWeightOne(_VoucherID, "JointTruck"))
                            {
                                rValue = true;
                                // todocsp :一磅冲销后调用一个方法刷新未进厂成品车信息
                            }
                            break;
                        case "CancelTwo":
                            if (tio.CancelWeightTwo(_VoucherID, "JointTruck"))
                                rValue = true;
                            break;
                        case "CancelPrint":
                            if (tio.CancelPrintWeight(_VoucherID, "JointTruck"))
                                rValue = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case "FX":
                    if (string.IsNullOrEmpty(_VoucherID))
                    {
                        MessageBox.Show("Please select the order number from the table below");
                        return;
                    }
                    switch (cancelName)
                    {
                        case "CancelOne":
                            if (tio.CancelWeightOne(_VoucherID, "UnJointTruck"))
                                rValue = true;
                            break;
                        case "CancelTwo":
                            if (tio.CancelWeightTwo(_VoucherID, "UnJointTruck"))
                                rValue = true;
                            break;
                        case "CancelPrint":
                            if (tio.CancelPrintWeight(_VoucherID, "UnJointTruck"))
                                rValue = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case "PE":
                    if (string.IsNullOrEmpty(_ItemID))
                    {
                        MessageBox.Show("Please select the order number from the table below");
                        return;
                    }
                    switch (cancelName)
                    {
                        case "CancelOne":
                            if (tio.CancelWeightOne(_ItemID, "PtaEgTruck"))
                                rValue = true;
                            break;
                        case "CancelTwo":
                            if (tio.CancelWeightTwo(_ItemID, "PtaEgTruck"))
                                rValue = true;
                            break;
                        case "CancelPrint":
                            if (tio.CancelPrintWeight(_ItemID, "PtaEgTruck"))
                                rValue = true;
                            break;
                        default:
                            break;
                    }
                    break;
                default: 
                    break;
            }

            if (rValue)
            {
                if (flag == "PE")
                {
                    RecordBackLogs(_ItemID, cancelName, backReason);
                }
                else
                {
                    RecordBackLogs(_VoucherID, cancelName, backReason);
                }
                //
                MainMsg = cancelName + " success!";
                //
                BtnShow4Truck0Q();
            }
            else
                MainMsg = cancelName + " failed!";
        }

        /// <summary>
        /// 修改车号
        /// </summary>
        private void UpdateTruckNo(string updateReason, string truckNoNew)
        {
            string _VoucherID = _TruckInfo.VoucherID;//计划单号
            if (string.IsNullOrEmpty(_VoucherID))
            {
                MessageBox.Show("Please select the order number from the table below");
                return;
            }
            DataTable dt = ab.UpdateTKNO(_TruckInfo.Flag, _VoucherID, updateReason, truckNoNew);
            string msg = dt.Rows[0][0].ToString();
            if (string.IsNullOrEmpty(msg))
            {       
                MainMsg = "Update success!";
                //
                BtnShow4Truck0Q();
            }
            else
                MainMsg = "Update failed!";
        }

        /// <summary>
        /// 打印磅单冲销
        /// </summary>
        private void PrintBack(string backReason)
        {
            string _VoucherID = _TruckInfo.VoucherID;//计划单号
            string _ItemID = _TruckInfo.ItemID;//项次号
            ProcessCancel(_TruckInfo.Flag, "CancelPrint", _VoucherID, _ItemID, backReason); 
        }

        /// <summary>
        /// 一次过磅冲销
        /// </summary>
        private void Weight1Back(string backReason)
        {
            string _VoucherID = _TruckInfo.VoucherID;//计划单号
            string _ItemID = _TruckInfo.ItemID;//项次号
            ProcessCancel(_TruckInfo.Flag, "CancelOne", _VoucherID, _ItemID, backReason);            
        }        
        
        /// <summary>
        /// 二次过磅冲销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Weight2Back(string backReason)
        {
            string _VoucherID = _TruckInfo.VoucherID;//计划单号
            string _ItemID = _TruckInfo.ItemID;//项次号
            ProcessCancel(_TruckInfo.Flag, "CancelTwo", _VoucherID, _ItemID, backReason);   
        }

        /// <summary>
        /// 记录磅单冲销
        /// </summary>
        /// <param name="voucherID"></param>
        /// <param name="backType"></param>
        /// <param name="backReason"></param>
        void RecordBackLogs(string voucherID, string backType, string backReason)
        {
            ab.RecordBackLogs(voucherID, backType, backReason);
        }

        void _TruckInfo_eventShowTruckView(object sender, EventArgs e)
        {
            if (_TruckInfo.State == "Q")
            {
                BtnShow4TruckUK();
                return;
            }

            if (_TruckInfo.Flag == "XT" || _TruckInfo.Flag == "PE")
            {
                switch (_TruckInfo.State)
                {
                    case "Y":
                    case "W":
                        BtnShow4TruckWB1();
                        break;
                    case "E":
                        BtnShow4TruckWB2();
                        break;
                    case "D":
                        BtnShow4TruckPB();
                        break;
                    default:
                        BtnShow4Truck0();
                        break;
                }
            }
            else if (_TruckInfo.Flag == "FX")
            {
                switch (_TruckInfo.State)
                {
                    case "W":
                        BtnShow4TruckWB1();
                        break;
                    case "E":
                        BtnShow4TruckWB2();
                        break;
                    case "D":
                        BtnShow4TruckPB();
                        break;
                    default:
                        BtnShow4Truck0();
                        break;
                }
            }
            else
            {
                BtnShow4Truck0();
            }
        }
    }
}
