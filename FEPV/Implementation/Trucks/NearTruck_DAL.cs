using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Contract;
using Shawoo.Core;

namespace FEPV.Implementation
{
    /// <summary>
    /// 原料短驳车辆
    /// </summary>
    public class NearTruck_DAL : ITruckDAL
    {
        public bool CheckIn(string voucherid)
        {
            throw new NotImplementedException();
        }

        public bool CheckOut(string voucherid)
        {
            throw new NotImplementedException();
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
