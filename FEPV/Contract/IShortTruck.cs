using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface IShortTruck
    {
        DataTable GetCheckInOnePlan(string[] ps, object[] vs, string UserId);
        
        DataTable GetPlanItemById(string voucherid, string itemid);
        
        ShortTruckTransport GetShortTruckTransport(string voucherid, string itemid);
        
        bool SaveShortTruckTransport(ShortTruckTransport transport);
        
        DataTable IsCheckinWeightOne(string voucherid);
    }
}
