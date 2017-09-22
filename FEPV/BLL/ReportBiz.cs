using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FEPV.Contract;
using MIS.Utility;

namespace FEPV.BLL
{
    public class ReportBiz
    {
        public DataSet GetMISReport(string procdureName, string[] paramenters, object[] values)
        {
            DataSet result = null;
            IReport proxy = Shawoo.Core.ServiceFactory.Create<IReport>();
            {
                byte[] b = proxy.Reporting(procdureName, paramenters, values);
                //及时关闭通道
                result = DataFormatter.RetrieveDataSetDecompress(b);
            }
            return result;
        }

        public DataSet GetMISReportByPage(string procedureName, string[] paramenters, object[] values, out int count)
        {
            DataSet result = null;
            IReport proxy = Shawoo.Core.ServiceFactory.Create<IReport>();
            {
                byte[] b = proxy.ReportingByPage(procedureName, paramenters, values, out count);
                result = DataFormatter.RetrieveDataSetDecompress(b);
            }
            return result;
        }
    }
}
