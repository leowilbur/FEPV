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
using System.ServiceModel;

namespace FEPV.Implementation
{
    public class UIReportDAL : MarshalByRefObject, IUIReport
    {
        public UIReportDAL()
        {
            acMIS.RegisterSqlLogger(new NBear.Common.LogHandler(Logger.Trace));
        }
        //FEPV MIS
        protected static NBear.Data.Gateway acMIS = new NBear.Data.Gateway("MIS");

        public byte[] GetMISReportByPage(string procedureName, string[] paramenters, object[] values, out int count)
        {
            Console.WriteLine("MaterialDAL - DataTable GetMISReportByPage()" + " - " + DateTime.Now.ToString());

            List<string> ps = paramenters.ToList();
            ps.Add("UserID");
            paramenters = ps.ToArray();
            List<object> vs = values.ToList();
            vs.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
            values = vs.ToArray();

            try
            {
                object[] outParameters;
                DataSet ds = acMIS.DbHelper.ExecuteStoredProcedure(procedureName, paramenters, values,
                                           new string[] { "Count" }, new DbType[] { DbType.Int32 },
                                          out outParameters);

                count = (int)outParameters.ElementAt(0);
                return DataFormatter.GetBinaryFormatDataCompress(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        
        public byte[] GetMISReport(string procdureName, string[] paramenters, object[] values)
        {
            try
            {
                List<string> ps = paramenters.ToList();
                ps.Add("UserID");
                paramenters = ps.ToArray();
                List<object> vs = values.ToList();
                vs.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
                values = vs.ToArray();

                DataSet ds = acMIS.DbHelper.ExecuteStoredProcedure(procdureName, paramenters, values);
                return DataFormatter.GetBinaryFormatDataCompress(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public byte[] SearchDataByPage(string TableName, string Select, string OrderBy, int Size, int Index, bool ASC, string Where, out int Count)
        {

            object[] outParameters;
            DataSet ds=new DataSet();
            try
            {
                ds = acMIS.ExecuteStoredProcedure("_PagerSql2016_out_count",
                                                   new string[] { "tblName", "fldCow", "fldName", "PageSize", "PageIndex", "OrderType", "strWhere" },
                                                   new object[] { TableName, Select, OrderBy, Size, Index, ASC, Where },
                                                   new string[] { "count" },
                                                   new DbType[] { DbType.Int32 },
                                                   out outParameters
                                                   );
                Count = (int)outParameters.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DataFormatter.GetBinaryFormatDataCompress(ds);
        }
    }
}
