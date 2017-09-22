using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Contract;
using Shawoo.Core;

namespace FEPV.Implementation
{
    /// <summary>
    /// 多次过磅车辆PTA/EG
    /// </summary>
    public class PtaEgTruck_DAL : ITruckDAL
    {
        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");
        public bool CheckIn(string itemid)
        {
            Console.WriteLine("PtaEgTruck_DAL - CheckIn()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "";
            string status = "I";
            ac.ExecuteNonQuery("Update PtaEgItem SET InTime=@InTime,Status=@Status,Stamp=@Stamp Where ItemID=@ItemID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, itemid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM PtaEgItem WHERE ItemID=@ItemID AND Status=@Status", new object[] { itemid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool CheckOut(string itemid)
        {
            Console.WriteLine("PtaEgTruck_DAL - CheckOut()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "D";
            string status = "O";
            ac.ExecuteNonQuery("Update PtaEgItem SET OutTime=@OutTime,Status=@Status,Stamp=@Stamp Where ItemID=@ItemID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, itemid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM PtaEgItem WHERE ItemID=@ItemID AND Status=@Status", new object[] { itemid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool WeightOne(string itemid, decimal weight)
        {
            Console.WriteLine("PtaEgTruck_DAL - WeightOne()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "I";
            string status = "W";
            ac.ExecuteNonQuery("Update PtaEgItem SET FirstTime=@FirstTime,FirstWeight=@FirstWeight,Status=@Status,Stamp=@Stamp Where ItemID=@ItemID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, weight, status, DateTime.Now, itemid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM PtaEgItem WHERE ItemID=@ItemID AND Status=@Status", new object[] { itemid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool WeightTwo(string itemid, decimal weight)
        {
            Console.WriteLine("PtaEgTruck_DAL - WeightTwo()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "W";
            string status = "E";
            ac.ExecuteNonQuery("Update PtaEgItem SET SecondTime=@SecondTime,SecondWeight=@SecondWeight,Status=@Status,Stamp=@Stamp Where ItemID=@ItemID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, weight, status, DateTime.Now, itemid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM PtaEgItem WHERE ItemID=@ItemID AND Status=@Status", new object[] { itemid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool PonderationValidate(string itemid, decimal weight, out string msg)
        {
            Console.WriteLine("PtaEgTruck_DAL - PonderationValidate()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            msg = "";
            ac.ExecuteNonQuery("Update PtaEgItem SET FirstWeight=@FirstWeight,Stamp=@Stamp Where ItemID=@ItemID AND Status='I'"
                                , new object[] { weight, DateTime.Now, itemid });


            string validateMsg = ac.DbHelper.ExecuteStoredProcedure("WF_EG_AC_PonderationValidate",
                new string[] { "ItemID" }, new object[] { itemid }).Tables[0].Rows[0][0].ToString();

            if (string.IsNullOrEmpty(validateMsg))
                rValue = true;
            else
                msg = validateMsg;

            return rValue;
        }

        public bool PrintWeight(string itemid)
        {
            Console.WriteLine("PtaEgTruck_DAL - PrintWeight()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(itemid, "E", "D");
        }

        public bool CancelWeightOne(string itemid)
        {
            Console.WriteLine("PtaEgTruck_DAL - CancelWeightOne()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(itemid, "W", "I");
        }

        public bool CancelWeightTwo(string itemid)
        {
            Console.WriteLine("PtaEgTruck_DAL - CancelWeightTwo()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(itemid, "E", "W");
        }

        public bool CancelPrintWeight(string itemid)
        {
            Console.WriteLine("PtaEgTruck_DAL - CancelPrintWeight()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(itemid, "D", "W");
        }
        private bool UpdateStatus(string itemid, string currentStatus, string status)
        {
            Console.WriteLine("PtaEgTruck_DAL - UpdateStatus()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            ac.ExecuteNonQuery("Update PtaEgItem SET Status=@Status,Stamp=@Stamp Where ItemID=@ItemID AND Status=@currentStatus"
                                , new object[] { status, DateTime.Now, itemid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM PtaEgItem WHERE ItemID=@ItemID AND Status=@Status", new object[] { itemid, status }) == 1)
                rValue = true;

            return rValue;
        }
    }
}
