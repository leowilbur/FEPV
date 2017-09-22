using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FEPV.Contract;
using MIS.Utility;
using Shawoo.Common;

namespace FEPV.Implementation
{
    public class ReportService : MarshalByRefObject, IReport
    {
        #region IReport Members
        NBear.Data.Gateway gate = new NBear.Data.Gateway("Beling");
        public ReportService()
        {
            gate.RegisterSqlLogger(new NBear.Common.LogHandler(Logger.Trace));
        }

        public byte[] Reporting(string procdureName, string[] paramenters, object[] values)
        {
            try
            {
                List<string> ps = paramenters.ToList();
                //ps.Add("CostCenters");
                ps.Add("UserID");
                paramenters = ps.ToArray();
                List<object> vs = values.ToList();
                //vs.Add(string.Join(",", ServiceHelper.CostCenters));
                vs.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
                values = vs.ToArray();

                DataSet ds = gate.DbHelper.ExecuteStoredProcedure(procdureName, paramenters, values);
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

        public byte[] ReportingByPage(string procedureName, string[] paramenters, object[] values, out int count)
        {
            List<string> ps = paramenters.ToList();
            //ps.Add("CostCenters");
            ps.Add("UserID");
            paramenters = ps.ToArray();
            List<object> vs = values.ToList();
            //vs.Add(string.Join(",", ServiceHelper.CostCenters));
            vs.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
            values = vs.ToArray();

            try
            {
                object[] outParameters;
                DataSet ds = gate.DbHelper.ExecuteStoredProcedure(procedureName, paramenters, values,
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

        #endregion
    }
}
