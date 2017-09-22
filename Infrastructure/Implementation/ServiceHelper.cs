using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
//using System.Data.Linq;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
//using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Sql;
using System.Data.Common;


namespace Infrastructure.ServiceImplementation
{
    public static class ServiceHelper
    {
        static NBear.Data.Gateway gate = new NBear.Data.Gateway("IM");
        //static Database db = DatabaseFactory.CreateDatabase("SYS");
        //public static Database DB
        //{
        //    get
        //    {
        //        return db;
        //    }
        //}
        public static NBear.Data.Gateway Gate
        {
            get
            {
                //return gate;
                return new NBear.Data.Gateway("IM");
            }
        }
        static ServiceHelper()
        {
            //gate.RegisterSqlLogger(new NBear.Common.LogHandler(Console.WriteLine));
        }

        public static DataSet SearchData(string Application,string ProcedureName,string[] paramenters,object[] values)
        {
            NBear.Data.Gateway db = new NBear.Data.Gateway(Application);
            //db.RegisterSqlLogger(new NBear.Common.LogHandler(Console.WriteLine));

            return db.DbHelper.ExecuteStoredProcedure(ProcedureName, paramenters, values);
        }

        public static DataSet SearchData(string Application, string ProcedureName, string[] paramenters, object[] values,
                                         string[] outParameterNames,DbType[] outDbTypes, out object[] outParameters)
        {
            NBear.Data.Gateway db = new NBear.Data.Gateway(Application);
            //db.RegisterSqlLogger(new NBear.Common.LogHandler(Console.WriteLine));
            DataSet result;
            try
            {
                result = db.DbHelper.ExecuteStoredProcedure(ProcedureName, paramenters, values, outParameterNames, outDbTypes, out outParameters);
                                                   //new string[] { "count" },
                                                   //new DbType[] { DbType.Int32 },
                                                   //out outParameters
                //Count = (int)outParameters.ElementAt(0);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                throw ex;
            }
            //return db.DbHelper.ExecuteStoredProcedure(ProcedureName, paramenters, values);
            return result;
        }

        public static DataSet SearchDataByPage(string Application,string TableName,string Select,string OrderBy,int Size,int Index,bool ASC,string Where,out int Count)
        {
            NBear.Data.Gateway db = new NBear.Data.Gateway(Application);
            //db.RegisterSqlLogger(new NBear.Common.LogHandler(Console.WriteLine));
            
            object[] outParameters ;
            DataSet result;
            try
            {
                result = db.DbHelper.ExecuteStoredProcedure("_PagerSql2005_out_count",
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
                //Console.WriteLine(ex.ToString());
                throw ex;
            }
            //return db.DbHelper.ExecuteStoredProcedure(ProcedureName, paramenters, values);
            return result;
        }

        public static string IP
        {
            get
            {
                return Shawoo.GenuineChannels.GenuineUtility.CurrentRemoteHost.PhysicalAddress.ToString().Split(":".ToCharArray()).First();
                //((RemoteEndpointMessageProperty)OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name]).Address;
            }
        }
        
        public static string User
        {
            get
            {
                return Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();//OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
            }
        }

        public static string CostCenterId
        {
            get
            {
                return GetCostCenterId(ServiceHelper.User);
            }
        }

        public static string  GetCostCenterId(string User)
        {
            Console.WriteLine("-----------------GetCostCenterId----------------");
            DataTable tb = gate.DbHelper.Select("SELECT * FROM vEmployeeInCostCenter WHERE UserName = @UserName AND Serves = '1'",
                                new object[] { User }).Tables[0];
           
            if (tb.Rows.Count == 1)
            {
                Console.WriteLine(tb.Rows[0]["CostCenterID"]);
                return tb.Rows[0]["CostCenterID"].ToString();
            }

            return "";
            //throw new Exception(User +":成本中心存疑!");
            //Infrastructure.DAL.MesDataBase db = new Infrastructure.DAL.MesDataBase("");
            //var q = from i in db.EmployeeInCostCenter
            //        where i.UserName == User
            //          && i.Serves == true
            //        select i;
            //if (q.Count() == 0)
            //    throw new Exception(string.Format("{0} is not Employee of some cost center ", User));

            //if (q.Count() > 1)
            //    throw new Exception(string.Format("{0} joins to more than one cost center ", User));

            //return q.FirstOrDefault().CostCenterID;
        }

        public static bool Validate(string uid, string pwd, out string msg)
        {
            DataTable tb = gate.DbHelper.Select("SELECT password FROM vjiveUser WHERE username = @username",
                                  new object[] { uid }).Tables[0];
            if (tb.Rows.Count == 0)
            {
                msg = "无此用户,或用户被锁定:"+uid;
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ffff")+" "+msg);
                return false;
            }

            foreach (DataRow row in tb.Rows)
            {
                if ((string)row["password"] == pwd)
                {
                    msg = "验证成功";
                    //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ffff") + " " + msg);
                    return true;
                }
            }

            msg = "密码错误";
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ffff") + " " + msg);
            return false;

        }

        public static string CostCenter
        {
            get
            {
                return ServiceHelper.CostCenterId.ToString();
            }
        }

        public static string[] CostCenters
        {
            get
            {
                List<string> result = new List<string>();
                foreach (DataRow r in gate.SelectDataSet("SELECT * FROM vEmployeeInCostCenter WHERE UserName = @UserName",
                    new object[] { ServiceHelper.User }).Tables[0].Rows)
                {
                    result.Add(r["CostCenterID"].ToString());
                }
                //Infrastructure.DAL.MesDataBase db = new Infrastructure.DAL.MesDataBase("");
                //var q = from i in db.EmployeeInCostCenter
                //        where i.UserName == ServiceHelper.User
                //        select i;

                //string[] result = new String[q.Count()];
                //int j = 0;
                //foreach (var i in q)
                //{
                //    result[j] = i.CostCenterID.ToString();
                //    j++;
                //}
                return result.ToArray();
                //return result;
            }
        }

        public static bool UserHasRight4Function(Guid ModelID)
        {
            return true;
        }

        public static void Add2Logs(LOGS logs)
        {
            try
            {
                gate.DbHelper.Insert("SYS_LOGS",
                                     new string[]
                                         {
                                             "ID", "FunctionModel", "UserID", "IP", "B", "E", "Paramenters", "Result",
                                             "Momo"
                                         },
                                     new object[]
                                         {
                                             logs.ID, logs.FunctionModel, logs.UserID, logs.IP, logs.B, logs.E,
                                             logs.Paramenters, logs.Result, logs.Momo
                                         },
                                     null);
                foreach (var detail in logs.Details)
                {
                    gate.DbHelper.Insert("SYS_LOGS_DETAIL",
                                         new string[] {"ID", "Paramenters", "Result", "Momo"},
                                         new object[] {detail.ID, detail.Paramenters, detail.Result, detail.Momo},
                                         null);
                }
            }catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
    }

    public class LOGS
    {
        private Guid _ID;
        public Guid ID
        {
            get
            {
                return _ID;
            }
        }
        public LOGS()
        {
            _ID = Guid.NewGuid();
           
            Result="";
            Momo = "";
        }

        public string FunctionModel{get;set;}
        public string UserID{get;set;}
        public string IP{get;set;}
        public DateTime B{get;set;}
        public DateTime E{get;set;}
        public string Paramenters{get;set;}
        public string Result{get;set;}
        public string Momo{get;set;}

        BindingList<LOGS_DETAIL> _Details = new BindingList<LOGS_DETAIL>();
        public void AddDetail(string paramenters,string result,string momo)
        {
            _Details.Add(new LOGS_DETAIL {ID = _ID, Paramenters = paramenters, Result = result, Momo = momo});
        }

        public BindingList<LOGS_DETAIL> Details
        {
            get { return _Details; }
        }
    }

    public class LOGS_DETAIL
    {
        public Guid ID{get;set;}
        public string Paramenters{get;set;}
        public string Result{get;set;}
        public string Momo{get;set;}
    }
}
