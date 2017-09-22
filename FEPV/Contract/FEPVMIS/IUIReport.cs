using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface IUIReport
    {
        byte[] GetMISReportByPage(string procedureName, string[] ps, object[] vs, out int count);

        byte[] GetMISReport(string procdureName, string[] paramenters, object[] values);

        byte[] SearchDataByPage(string tableName, string select, string orderBy, int size, int index, bool asc, string where, out int count);
    }
}
