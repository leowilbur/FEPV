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

namespace FEPV.Implementation
{
    public class TruckInOutService : MarshalByRefObject, ITruckInOut
    {
        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");
        ReportService rep = new ReportService();

        public bool CheckIn(string voucherid, string type)
        {
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.CheckIn(voucherid);
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public bool CheckOut(string voucherid, string type)
        {
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.CheckOut(voucherid);
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public bool WeightOne(string voucherid, decimal weight, string type)
        {
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.WeightOne(voucherid, weight);
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public bool WeightTwo(string voucherid, decimal weight, string type)
        {
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.WeightTwo(voucherid, weight);
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public bool PonderationValidate(string voucherid, decimal weight, string type, out string msg)
        {
            try
            {
                msg = "";
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.PonderationValidate(voucherid, weight, out msg);
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public bool PrintWeight(string voucherid, string type)
        {
            //记录日志
            //打印
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.PrintWeight(voucherid);
                return r;
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
        /// 冲销一磅
        /// </summary>
        public bool CancelWeightOne(string voucherid, string type)
        {
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.CancelWeightOne(voucherid);
                return r;
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
        /// 冲销二磅
        /// </summary>
        public bool CancelWeightTwo(string voucherid, string type)
        {
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.CancelWeightTwo(voucherid);
                return r;
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
        /// 冲销打印磅单
        /// </summary>
        public bool CancelPrintWeight(string voucherid, string type)
        {
            try
            {
                ITruckDAL truckDAL = Trucks_Factory.CreateTruck(type);
                bool r = truckDAL.CancelPrintWeight(voucherid);
                return r;
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
        /// 记录日志冲销磅单
        /// </summary>
        void RecordBackLogs(string voucherID, string backType, string backReason)
        {
            rep.Reporting("Q_RecordBackLogs", new string[] { "VoucherID", "BackType", "BackReason" }, new object[] { voucherID, backType, backReason });
        }
    }
}
