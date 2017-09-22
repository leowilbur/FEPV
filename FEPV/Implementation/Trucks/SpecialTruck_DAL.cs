using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Contract;
using Shawoo.Core;

namespace FEPV.Implementation
{
    /// <summary>
    /// 特种车辆
    /// </summary>
    public class SpecialTruck_DAL : ITruckDAL
    {
        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");
        public bool CheckIn(string voucherid)
        {
            Console.WriteLine("SpecialTruck_DAL - CheckIn()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "Q";
            string status = "W";
            ac.ExecuteNonQuery("Update SpecialTruck SET InTime=@InTime,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM SpecialTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool CheckOut(string voucherid)
        {
            Console.WriteLine("SpecialTruck_DAL - CheckOut()" + " - " + DateTime.Now.ToString());
            bool rValue = false;
            string currentStatus = "W";
            string status = "O";
            ac.ExecuteNonQuery("Update SpecialTruck SET OutTime=@OutTime,Status=@Status,Stamp=@Stamp Where VoucherID=@VoucherID AND Status=@currentStatus"
                                , new object[] { DateTime.Now, status, DateTime.Now, voucherid, currentStatus });

            if (ac.SelectScalar<int>("SELECT COUNT(*) FROM SpecialTruck WHERE VoucherID=@VoucherID AND Status=@Status", new object[] { voucherid, status }) == 1)
                rValue = true;

            return rValue;
        }

        public bool WeightOne(string voucherid, decimal weight)
        {
            throw new NotImplementedException();
        }

        public bool WeightTwo(string voucherid, decimal weight)
        {
            throw new NotImplementedException();
        }

        public bool PonderationValidate(string voucherid, decimal weight, out string msg)
        {
            throw new NotImplementedException();
        }

        public bool PrintWeight(string voucherid)
        {
            throw new NotImplementedException();
        }

        public bool CancelWeightOne(string voucherid)
        {
            throw new NotImplementedException();
        }

        public bool CancelWeightTwo(string voucherid)
        {
            throw new NotImplementedException();
        }

        public bool CancelPrintWeight(string voucherid)
        {
            throw new NotImplementedException();
        }
    }
}
