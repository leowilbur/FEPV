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
    public class ShortTruckBiz
    {
        private readonly IShortTruck proxy = ServiceFactory.Create<IShortTruck>();

        /// <summary>
        /// 得到进厂的计划列表
        /// </summary>
        /// <param name="ps"></param>
        /// <param name="vs"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetCheckInOnePlan(string[] ps, object[] vs, string UserId)
        {
            DataTable results = new DataTable();
            try
            {
                results = proxy.GetCheckInOnePlan(ps, vs, UserId);
            }
            catch (Exception ee)
            {
                throw new Exception("得到计划列表异常 - " + ee.Message);
            }
            return results;
        }
        /// <summary>
        /// 进厂的计划的ITEM列表
        /// </summary>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        public DataTable GetPlanItemById(string voucherid, string itemid)
        {
            DataTable results = new DataTable();
            try
            {
                results = proxy.GetPlanItemById(voucherid, itemid);
            }
            catch (Exception ee)
            {
                throw new Exception("得到ITEM列表异常 - " + ee.Message);
            }
            return results;
        }
        /// <summary>
        /// 得到短驳运输信息
        /// </summary>
        /// <param name="voucherid"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public ShortTruckTransport GetShortTruckTransport(string voucherid, string itemid)
        {
            ShortTruckTransport results = new ShortTruckTransport();
            try
            {
                results = proxy.GetShortTruckTransport(voucherid, itemid);
            }
            catch (Exception ee)
            {
                throw new Exception("得到运输信息异常 - " + ee.Message);
            }
            return results;
        }
        /// <summary>
        /// 保存短驳过磅信息
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        public bool SaveShortTruckTransport(ShortTruckTransport transport)
        {
            bool results = false;
            try
            {
                results = proxy.SaveShortTruckTransport(transport);
            }
            catch (Exception ee)
            {
                throw new Exception("保存运输信息异常 - " + ee.Message);
            }
            return results;
        }
        /// <summary>
        /// 是否这辆车已经进厂称过一次磅重
        /// </summary>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        public DataTable IsCheckinWeightOne(string voucherid)
        {
            DataTable results = new DataTable();
            try
            {
                results = proxy.IsCheckinWeightOne(voucherid);
            }
            catch (Exception ee)
            {
                throw new Exception("是否进厂称过异常 - " + ee.Message);
            }
            return results;
        }

        private readonly IReport reportproxy = ServiceFactory.Create<IReport>();
        /// <summary>
        /// 判断成品短驳从装货区至卸货区是否超时
        /// </summary>
        /// <param name="reasonId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string IsOverInTime(string voucherid,string itemid)
        {
            byte[] b = reportproxy.Reporting("A_Q_ShortTruck_IsOverInTime", new string[] { "VoucherID", "ItemID " }, new object[] { voucherid, itemid });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 显示建单者信息：工号，姓名，部门，邮件
        /// </summary>
        /// <param name="createuserid"></param>
        /// <returns></returns>
        public string GetCreaterInfo(string createuserid)
        {
            byte[] b = reportproxy.Reporting("A_Q_ShowUserIDInfo", new string[] { "initiator" }, new object[] { createuserid });
            DataSet ds = DataFormatter.RetrieveDataSetDecompress(b);
            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
