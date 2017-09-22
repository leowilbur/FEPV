using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Infrastructure.Contract
{
    public interface IRF
    {
        int CallFunction(int functionId,string uid,string pwd,DataSet dsIn,out DataSet dsOut, object[] parameter, out object[] returnParameter,out string message);
    }
}
