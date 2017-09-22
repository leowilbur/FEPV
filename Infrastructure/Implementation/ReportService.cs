using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Infrastructure.ServiceImplementation;
using Infrastructure.Contract;
using MIS.Utility;
using System.ServiceModel;
using System.Security.Permissions;

namespace Infrastructure.Service
{
    public class ReportService :MarshalByRefObject, IReport
    {
        public ReportService()
        {
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public byte[] GetSYSReport(string procedureName, string[] paramenters, object[] values)
        {
            try
            {
                Console.WriteLine("SSSS");
                DataSet ds = ServiceHelper.SearchData("IM", procedureName, paramenters, values);
             
                return DataFormatter.GetBinaryFormatDataCompress(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
