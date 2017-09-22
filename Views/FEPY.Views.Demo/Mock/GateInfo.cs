using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPY.Views.Demo
{
  public  class GateInfo
    {
      NBear.Data.Gateway gate = new NBear.Data.Gateway("Beling");

      public DataTable SearchGateBasicLanguage(string procdureName, string[] paramenters, object[] values)
      {
          List<string> ps = paramenters.ToList();
          //ps.Add("CostCenters");
          ps.Add("UserID");
          paramenters = ps.ToArray();
          List<object> vs = values.ToList();
          //vs.Add(string.Join(",", ServiceHelper.CostCenters));
          vs.Add("cassie");
          values = vs.ToArray();

          DataTable dt = gate.DbHelper.ExecuteStoredProcedure(procdureName, paramenters, values).Tables[0];
        
          return dt;
      }


      public DataTable SearchGateGridLanguage(string procdureName, string[] paramenters, object[] values)
      {
          List<string> ps = paramenters.ToList();
          //ps.Add("CostCenters");
          ps.Add("UserID");
          paramenters = ps.ToArray();
          List<object> vs = values.ToList();
          //vs.Add(string.Join(",", ServiceHelper.CostCenters));
          vs.Add("cassie");
          values = vs.ToArray();

          DataTable dt = gate.DbHelper.ExecuteStoredProcedure(procdureName, paramenters, values).Tables[0];

          return dt;
      }
      public DataTable GetGuests(string[] ps, object[] vs, string UserId)
      {
          DataTable dtGuests = gate.DbHelper.ExecuteStoredProcedure("FK_AC_GetTasks_Guest", ps, vs).Tables[0];
          return dtGuests;
      }

      public DataTable SearchGuestInfo(string procdureName, string[] paramenters, object[] values)
      {
          List<string> ps = paramenters.ToList();
          //ps.Add("CostCenters");
          ps.Add("UserID");
          paramenters = ps.ToArray();
          List<object> vs = values.ToList();
          //vs.Add(string.Join(",", ServiceHelper.CostCenters));
          vs.Add("cassie");
          values = vs.ToArray();

          DataTable dt = gate.DbHelper.ExecuteStoredProcedure(procdureName, paramenters, values).Tables[0];

          return dt;
      } 
    }
}
