using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Contract
{
    public interface IReport
    {
        byte[] Reporting(string procdureName, string[] paramenters, object[] values);

        byte[] ReportingByPage(string procedureName, string[] paramenters, object[] values, out int count);
    }
}
