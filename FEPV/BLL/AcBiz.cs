using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using Shawoo.Core;

namespace FEPV.BLL
{
    public class AcBiz
    {
        private readonly IAc proxy = ServiceFactory.Create<IAc>();

        public DataTable GetGuests(string[] ps, object[] vs, string UserId)
        {
            return proxy.GetGuests(ps, vs, UserId);
        }

        public bool SaveGuestItem(GuestItem guestItem)
        {
            return proxy.SaveGuestItem(guestItem);
        }

        public DataTable GetTrucks(string[] ps, object[] vs, string UserId)
        {
            return proxy.GetTrucks(ps, vs, UserId); 
        }

        public bool CreatePtaEgItem(PtaEgItem ptaEgItem)
        {
            return proxy.CreatePtaEgItem(ptaEgItem);
        }

        public DataTable GetGoods(string[] ps, object[] vs, string UserId)
        {
            return proxy.GetGoods(ps, vs, UserId);
        }

        public DataTable GetGoodsBack(string[] ps, object[] vs)
        {
            return proxy.GetGoodsBack(ps, vs);
        }

        public bool SaveGoodsBackItem(GoodsBackItem goodsBackItem)
        {
            return proxy.SaveGoodsBackItem(goodsBackItem);
        }

        public Guest GetGuestEntity(string voucherid)
        {
            return proxy.GetGuestEntity(voucherid);
        }

        public bool SaveGuest(Guest guest)
        {
            return proxy.SaveGuest(guest);
        }

        public Goods GetGoodsEntity(string voucherid)
        {
            return proxy.GetGoodsEntity(voucherid);
        }

        public bool SaveGoods(Goods goods)
        {
            return proxy.SaveGoods(goods);
        }

        private readonly IReport reportproxy = ServiceFactory.Create<IReport>();
        /// <summary>
        /// 根据单号获取车辆明细
        /// </summary>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public DataTable QueryPlanData4TruckDetails(string voucherId, string language)
        {
            byte[] b = reportproxy.Reporting("Q_PlanData4TruckDetails", new string[] { "VoucherID", "Language" }, new object[] { voucherId, language });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }

        /// <summary>
        /// 检查厂内车辆是否存在
        /// </summary>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public DataTable QueryVehicleNoState(string vehicleNo)
        {
            byte[] b = reportproxy.Reporting("Q_VehicleNO_Validate", new string[] { "VehicleNO" }, new object[] { vehicleNo });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }

        /// <summary>
        /// 保存 柜号,卸货点
        /// </summary>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public DataTable SaveDischarge(string _ItemID, string _CupboardNO, string _Discharge, string _Remark, decimal _ReferWeight)
        {
            byte[] b = reportproxy.Reporting("Q_SaveDischarge", new string[] { "ItemID", "CupboardNO", "Discharge", "Remark", "ReferWeight" },
                                                new object[] { new Guid(_ItemID), _CupboardNO, _Discharge, _Remark, _ReferWeight });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }

        /// <summary>
        /// 成品车辆保存备注
        /// </summary>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public DataTable SaveRemark4XT(string _VoucherID, string _Remark)
        {
            byte[] b = reportproxy.Reporting("Q_SaveRemark4XT", new string[] { "VoucherID", "Remark" },
                                                new object[] { _VoucherID, _Remark });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }

        /// <summary>
        /// 记录日志-磅单冲销
        /// </summary>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public DataTable RecordBackLogs(string voucherID, string backType, string backReason)
        {
            byte[] b = reportproxy.Reporting("Q_RecordBackLogs", new string[] { "VoucherID", "BackType", "BackReason" },
                                                                  new object[] { voucherID, backType, backReason });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }

        public DataTable UpdateTKNO(string types, string voucherID, string updateReason, string truckNoNew)
        {
            byte[] b = reportproxy.Reporting("EGBK_UpdateTKNO", new string[] { "Types", "VoucherID", "UpdateReason", "VehicleNO" },
                                                                  new object[] { types, voucherID, updateReason, truckNoNew });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }

        public string GetVoucherStatus(string _VoucherID, string _ItemID)
        {
            string rValue = "";
            Guid itemid = new Guid();
            if (!string.IsNullOrEmpty(_ItemID))
                itemid = new Guid(_ItemID);

            byte[] b = reportproxy.Reporting("TK_GetVoucherStatus", new string[] { "VoucherID", "ItemID" },
                                                                  new object[] { _VoucherID, itemid });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            rValue = ds.Tables[0].Rows[0][0].ToString();
            return rValue;
        }

        /// <summary>
        /// 检查厂内车辆数量限制
        /// </summary>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public DataTable TruckIn_Capacity_Check(string materielType)
        {
            byte[] b = reportproxy.Reporting("A_TruckIn_Capacity_Check",
                                new string[] { "MaterielType" }, new object[] { materielType });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }

        /// <summary>
        /// PTAEG车辆根据ItemID查找PtaEgTruck表的建单人
        /// </summary>
        /// <param name="createuserid"></param>
        /// <returns></returns>
        public string GetUserIDByItemID(string itemId)
        {
            byte[] b = reportproxy.Reporting("A_Q_GetUserIDByItemID", new string[] { "itemId" }, new object[] { itemId });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 车辆进厂后删除车辆调度表信息
        /// </summary>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public DataTable TruckDispatchCheckInDelete(string voucherID)
        {
            byte[] b = reportproxy.Reporting("GT_TruckDispatchCheckInDelete",
                                new string[] { "VoucherID" }, new object[] { voucherID });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0];
        }
    }
}
