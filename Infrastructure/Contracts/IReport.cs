using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Infrastructure.Contract
{
    public interface IReport
    {
        byte[] GetSYSReport(string procedureName, string[] paramenters, object[] values);
    }
}
