using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Contract;
using Shawoo.Core;

namespace FEPV.Implementation
{
    /// <summary>
    /// 成品过磅车辆
    /// </summary>
    public class JointTruck_DAL : ITruckDAL
    {
        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");
        public bool CheckIn(string voucherid)
        {
            Console.WriteLine("JointTruck_DAL - CheckIn()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "Q";
            string status = "I";
            ac.ExecuteNonQuery("Update JointTruck SET InTime=@InTime,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM JointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool CheckOut(string voucherid)
        {
            Console.WriteLine("JointTruck_DAL - CheckOut()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "D";
            string status = "O";
            ac.ExecuteNonQuery("Update JointTruck SET OutTime=@OutTime,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM JointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool WeightOne(string voucherid, decimal weight)
        {
            Console.WriteLine("JointTruck_DAL - WeightOne()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "I";
            string status = "Y";
            ac.ExecuteNonQuery("Update JointTruck SET FirstTime=@FirstTime,FirstWeight=@FirstWeight,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, weight, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM JointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool WeightTwo(string voucherid, decimal weight)
        {
            Console.WriteLine("JointTruck_DAL - WeightTwo()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "Y";
            string status = "E";
            ac.ExecuteNonQuery("Update JointTruck SET SecondTime=@SecondTime,SecondWeight=@SecondWeight,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, weight, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM JointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }
        public bool PonderationValidate(string voucherid, decimal weight, out string msg)
        {
            Console.WriteLine("JointTruck_DAL - PonderationValidate()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            msg = "";
            ac.ExecuteNonQuery("Update JointTruck SET SecondWeight=@SecondWeight,Stamp=@Stamp Where VoucherID=@VoucherID AND Status='Y'"
                                , new object[] { weight, DateTime.Now, voucherid });


            string validateMsg = ac.DbHelper.ExecuteStoredProcedure("WF_MIS_AC_PonderationValidate", 
                new string[] { "VoucherID" }, new object[] { voucherid }).Tables[0].Rows[0][0].ToString();

            if (string.IsNullOrEmpty(validateMsg))
                rValue = true;
            else
                msg = validateMsg;

            return rValue;
        }

        public bool PrintWeight(string voucherid)
        {
            Console.WriteLine("JointTruck_DAL - PrintWeight()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "E", "D");
        }

        public bool CancelWeightOne(string voucherid)
        {
            Console.WriteLine("JointTruck_DAL - CancelWeightOne()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "Y", "I");
        }
        public bool CancelWeightTwo(string voucherid)
        {
            Console.WriteLine("JointTruck_DAL - CancelWeightTwo()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "E", "Y");
        }
        public bool CancelPrintWeight(string voucherid)
        {
            Console.WriteLine("JointTruck_DAL - CancelPrintWeight()" + " - " + DateTime.Now.ToString());
            return UpdateStatus(voucherid, "D", "Y");
        }
        private bool UpdateStatus(string voucherid, string currentStatus, string status)
        {
            Console.WriteLine("JointTruck_DAL - UpdateStatus()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            ac.ExecuteNonQuery("Update JointTruck SET Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM JointTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }
    }
}
