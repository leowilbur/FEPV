using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using System.Data;
using Shawoo.Core;
using Shawoo.Common;
using System.Net;
using System.IO;

using Newtonsoft.Json;
using HttpUtils;
using System.Configuration;

namespace FEPV.Implementation
{
    //成品短驳
    public class ShortTruckService : MarshalByRefObject, IShortTruck
    {
        //系统配置
        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");        

        /// <summary>
        /// 得到进厂的计划列表
        /// </summary>
        /// <param name="ps">查询参数</param>
        /// <param name="vs">值</param>
        /// <param name="UserId">用户/角色</param>
        /// <returns></returns>
        public DataTable GetCheckInOnePlan(string[] ps, object[] vs, string UserId)
        {
            Console.WriteLine("ShortTruckService - GetCheckInOnePlan()" + " - " + DateTime.Now.ToString());
            List<string> paramenters = ps.ToList();
            paramenters.Add("UserID");
            ps = paramenters.ToArray();
            List<object> values = vs.ToList();
            values.Add(UserId);
            vs = values.ToArray();
            DataTable dtPlans = ac.DbHelper.ExecuteStoredProcedure("A_GetTrucksShort", ps, vs).Tables[0];
            return dtPlans;
        }

        /// <summary>
        /// 进厂的计划的ITEM列表
        /// </summary>
        /// <param name="voucherid">计划单号</param>
        /// <returns></returns>
        public DataTable GetPlanItemById(string voucherid, string itemid)
        {
            Console.WriteLine("ShortTruckService - GetPlanItemById()" + " - " + DateTime.Now.ToString());
            DataTable dtPlans = ac.DbHelper.ExecuteStoredProcedure("A_GetTrucksShortItem", new string[] { "VoucherID", "ItemID" },
                new object[] { voucherid, itemid }).Tables[0];
            return dtPlans;
        }

        /// <summary>
        /// 得到短驳运输信息
        /// </summary>
        /// <param name="voucherid">单据号</param>
        /// <param name="itemid">项次</param>
        /// <returns></returns>
        public ShortTruckTransport GetShortTruckTransport(string voucherid, string itemid)
        {
            Console.WriteLine("ShortTruckService - GetShortTruckTransport()" + " - " + DateTime.Now.ToString());
            return db.Select<ShortTruckTransport>(new ShortTruckTransport { VoucherID = voucherid, ItemID = itemid });
        }

        /// <summary>
        /// 保存短驳运输信息
        /// </summary>
        /// <param name="transport">过磅对象</param>
        /// <returns></returns>
        public bool SaveShortTruckTransport(ShortTruckTransport transport)
        {
            Console.WriteLine("ShortTruckService - SaveShortTruckTransport()" + " - " + DateTime.Now.ToString());
            Console.WriteLine(transport.VoucherID);
            Console.WriteLine(transport.ItemID);
            Console.WriteLine(transport.Status);
            Console.WriteLine(transport.InTime);
            Console.WriteLine(transport.Weight1);
            Console.WriteLine(transport.Weight2);
            Console.WriteLine(transport.Weight3);
            Console.WriteLine(transport.Weight4);
            try 
            {
                int flow = (int)ac.DbHelper.SelectScalar(@"SELECT COUNT(*) FROM ShortTruckTransport WHERE VoucherID=@VoucherID AND ItemID=@ItemID",
                    new object[] { transport.VoucherID, transport.ItemID });
                if (flow == 0)
                {
                    db.Save<ShortTruckTransport>(transport);
                }
                else
                {
                    ac.ExecuteNonQuery(@"UPDATE [ShortTruckTransport]
                           SET [InTime] = @InTime
                              ,[Weight1Time] = @Weight1Time
                              ,[Weight1] = @Weight1
                              ,[Weight2Time] = @Weight2Time
                              ,[Weight2] = @Weight2
                              ,[OutTime1] = @OutTime1
                              ,[InTime2] = @InTime2
                              ,[Weight3] = @Weight3
                              ,[Weight3Time] = @Weight3Time
                              ,[Weight4] = @Weight4
                              ,[Weight4Time] = @Weight4Time
                              ,[OutTime2] = @OutTime2
                              ,[Status] = @Status
                              ,[Stamp] = @Stamp
                              ,[UserID] = @UserID
                              ,[Message] = @Message
                              ,[Reason] = @Reason
                              ,[OverTimeMessage] = @OverTimeMessage
                              ,[OverTimeReason] = @OverTimeReason
                              ,[PID] = @PID
                        WHERE VoucherID=@VoucherID AND ItemID=@ItemID ",
                        new object[] { 
                            transport.InTime
                            ,transport.Weight1Time
                            ,transport.Weight1
                            ,transport.Weight2Time
                            ,transport.Weight2
                            ,transport.OutTime1
                            ,transport.InTime2
                            ,transport.Weight3
                            ,transport.Weight3Time
                            ,transport.Weight4
                            ,transport.Weight4Time
                            ,transport.OutTime2
                            ,transport.Status
                            ,transport.Stamp
                            ,transport.UserID
                            ,transport.Message
                            ,transport.Reason
                            ,transport.OverTimeMessage
                            ,transport.OverTimeReason
                            ,transport.PID
                            ,transport.VoucherID
                            ,transport.ItemID});
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        
        /// <summary>
        /// 是否这辆车已经进厂称过一次磅重
        /// </summary>
        /// <param name="voucherid">单据号</param>
        /// <returns></returns>
        public DataTable IsCheckinWeightOne(string voucherid)
        {
            Console.WriteLine("ShortTruckService - IsCheckinWeightOne()" + " - " + DateTime.Now.ToString());
            return ac.SelectDataSet("SELECT TOP 1 * FROM ShortTruckTransport WHERE VoucherID = @voucherid AND [Status] NOT IN ('X','I1') ORDER BY InTime",
                                         new object[] { voucherid }).Tables[0];
        }
    }
}
