using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Implementation
{
    public interface ITruckDAL
    {
        bool CheckIn(string voucherid);

        bool CheckOut(string voucherid);

        bool WeightOne(string voucherid, decimal weight);

        bool WeightTwo(string voucherid, decimal weight);

        bool PonderationValidate(string voucherid, decimal weight, out string msg);

        bool PrintWeight(string voucherid);

        bool CancelWeightOne(string voucherid);

        bool CancelWeightTwo(string voucherid);

        bool CancelPrintWeight(string voucherid);

    }
}
