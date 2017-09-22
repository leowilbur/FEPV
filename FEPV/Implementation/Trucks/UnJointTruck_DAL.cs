using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Contract;
using Shawoo.Core;

namespace FEPV.Implementation
{
    /// <summary>
    /// 废料/辅料 车辆
    /// </summary>
    public class UnJointTruck_DAL : ITruckDAL
    {
        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");
        public bool CheckIn(string voucherid)
        {
            Console.WriteLine("UnJointTruck_DAL - CheckIn()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "Q";
            string status = "I";
            ac.ExecuteNonQuery("Update UnJointTruck SET InTime=@InTime,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM UnJointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool CheckOut(string voucherid)
        {
            Console.WriteLine("UnJointTruck_DAL - CheckOut()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "D";
            string status = "O";
            ac.ExecuteNonQuery("Update UnJointTruck SET OutTime=@OutTime,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM UnJointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool WeightOne(string voucherid, decimal weight)
        {
            Console.WriteLine("UnJointTruck_DAL - WeightOne()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "I";
            string status = "W";
            ac.ExecuteNonQuery("Update UnJointTruck SET FirstTime=@FirstTime,FirstWeight=@FirstWeight,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, weight, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM UnJointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool WeightTwo(string voucherid, decimal weight)
        {
            Console.WriteLine("UnJointTruck_DAL - WeightTwo()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "W";
            string status = "E";
            ac.ExecuteNonQuery("Update UnJointTruck SET SecondTime=@SecondTime,SecondWeight=@SecondWeight,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, weight, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM UnJointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool PonderationValidate(string voucherid, decimal weight, out string msg)
        {
            Console.WriteLine("UnJointTruck_DAL - PonderationValidate()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            msg = "";
            ac.ExecuteNonQuery("Update UnJointTruck SET SecondWeight=@SecondWeight,Stamp=@Stamp Where VoucherID=@VoucherID AND Status='W'"
                                , new object[] { weight, DateTime.Now, voucherid });


            string validateMsg = ac.DbHelper.ExecuteStoredProcedure("WF_UK_AC_PonderationValidate",
                new string[] { "VoucherID" }, new object[] { voucherid }).Tables[0].Rows[0][0].ToString();

            if (string.IsNullOrEmpty(validateMsg))
                rValue = true;
            else
                msg = validateMsg;

            return rValue;
        }

        public bool PrintWeight(string voucherid)
        {
            Console.WriteLine("UnJointTruck_DAL - PrintWeight()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "E", "D");
        }

        public bool CancelWeightOne(string voucherid)
        {
            Console.WriteLine("UnJointTruck_DAL - CancelWeightOne()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "W", "I");
        }
        public bool CancelWeightTwo(string voucherid)
        {
            Console.WriteLine("UnJointTruck_DAL - CancelWeightTwo()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "E", "W");
        }
        public bool CancelPrintWeight(string voucherid)
        {
            Console.WriteLine("UnJointTruck_DAL - CancelPrintWeight()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "D", "W");
        }
        private bool UpdateStatus(string voucherid, string currentStatus, string status)
        {
            Console.WriteLine("UnJointTruck_DAL - UpdateStatus()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            ac.ExecuteNonQuery("Update UnJointTruck SET Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM UnJointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }
    }
}
