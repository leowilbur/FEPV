using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using Shawoo.Core;

namespace FEPV.BLL
{
    public class UIReporting
    {
        private readonly IUIReport proxy = ServiceFactory.Create<IUIReport>();

        public DataSet GetMISReportByPage(string procedureName, string[] paramenters, object[] values, out int count)
        {
            DataSet result = null;
            byte[] b = proxy.GetMISReportByPage(procedureName, paramenters, values, out count);
            result = DataFormatter.RetrieveDataSetDecompress(b);
            return result;
        }

        public DataSet GetMISReport(string procdureName, string[] paramenters, object[] values)
        {
            DataSet result = null;
            byte[] b = proxy.GetMISReport(procdureName, paramenters, values);
            result = DataFormatter.RetrieveDataSetDecompress(b);

            return result;
        }

        public DataSet SearchDataByPage(string TableName, string Select, string OrderBy, int Size, int Index, bool ASC, string Where, out int Count)
        {
            DataSet result = null;
            byte[] b = proxy.SearchDataByPage(TableName, Select, OrderBy, Size, Index,ASC,Where,out Count);
            result = DataFormatter.RetrieveDataSetDecompress(b);

            return result;
        }
    }
}
