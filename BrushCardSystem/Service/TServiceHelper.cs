using System;
using System.Collections.Generic;
using System.Text;
using BAS.DAL;
using System.Data;

namespace Service
{
    public class TServiceHelper : MarshalByRefObject
    {
        public TServiceHelper()
        {
            // Console.WriteLine("TServiceHelper activated");
        }

        DAL dal = new DAL();
        public DataTable Report(string storeName, string[] parameters, object[] values)
        {
            Console.WriteLine("FEPV flash Report----" + storeName +" || "+ DateTime.Now.ToString());
            return dal.Report(storeName, parameters, values);
        }
    }
}
