using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Security;

namespace CredentialsManager
{
    public partial class TreeService:MarshalByRefObject,  ITCode
    {
        static NBear.Data.Gateway gate = Infrastructure.ServiceImplementation.ServiceHelper.Gate;
        //static Infrastructure.DAL.IGateway gate = (Infrastructure.DAL.IGateway)Activator.GetObject(typeof(Infrastructure.DAL.IGateway),"tcp://localhost:9099/DbGate.soap");

        //new NBear.Data.Gateway("Gilpin");
        public TreeService()
        {
            //gate.RegisterSqlLogger(new NBear.Common.LogHandler(Console.WriteLine));
        }

        #region ITCode Members

        public string GetTCodeScript(string tCode,DateTime time)
        {
            try
            {
                if (tCode.Trim() == "")
                    return "";

                string userId = Infrastructure.ServiceImplementation.ServiceHelper.User;
                string CenterId = Infrastructure.ServiceImplementation.ServiceHelper.CostCenterId;

                Roles.ApplicationName = "MES";

                string[] ags = Roles.GetRolesForUser(userId);

                for (int i = 0; i < ags.Length; i++)
                {
                    ags[i] = "'" + ags[i] + "'";
                }

                string roles = "''";
                if (ags.Length != 0)
                    roles = string.Join(",", ags);

                roles += ",'" + userId + "'";

                Console.WriteLine(time.ToString("yyyy MM dd HH:mm:ss.ffff") + " " + userId + " @[" + roles + "] ->" + tCode);

                string ver = string.Empty;
                foreach (DataRow row in
                                      gate.DbHelper.Select(
                                      "SELECT * FROM vRole_TCode WHERE TCode = 'ver' and @TCode NOT IN  ('ver','se38') AND RoleName IN (" + roles + ")",
                                                           new object[] { tCode }).Tables[0].Rows)
                {
                    ver = (string)row["Scripts"];
                }

                foreach (DataRow row in
                                      gate.DbHelper.Select(
                                      "SELECT * FROM vRole_TCode WHERE TCode = @TCode AND RoleName IN (" + roles + ")",
                                                           new object[] { tCode }).Tables[0].Rows)
                {
                    //Console.WriteLine(DateTime.Now.ToString("yyyy MM dd HH:mm:ss.ffff"));
                    return ver+(string)row["Scripts"];
                }

                //string ttCode = gate.SelectScalar<string>("SELECT AB FROM CostCenter WHERE ID = @ID", new object[] { CenterId })
                //        + tCode;

                //foreach (DataRow row in
                //                      gate.SelectDataSet(
                //                      "SELECT * FROM vRole_TCode WHERE TCode = @TCode AND RoleName IN (" + roles + ")",
                //                                           new object[] { ttCode }).Tables[0].Rows)
                //{
                //    return (string)row["Scripts"];
                //}

                foreach (DataRow row in
                          gate.DbHelper.Select(
                          "SELECT * FROM vRole_TCode WHERE TCode = @TCode AND RoleName IN (" + roles + ")",
                                               new object[] { "X" }).Tables[0].Rows)
                {
                    return (string)row["Scripts"];
                }


                return "";
            }
            catch (Exception e)
            {

                Warnning(e);
                //ExceptionDetail d = new ExceptionDetail(e);
                throw e;
            }
            
        }

        public bool Create(string tCode, string spec, string script)
        {
            try
            {
                gate.ExecuteNonQuery("INSERT INTO TCode(TCode,Spec,Enabled,Scripts) VALUES(@tCode,@spec,@enabled,@scripts)", new object[] { tCode, spec, true, script });
                return true;
            }
            catch (Exception e)
            {

                Warnning(e);
                throw e;
            }
        }

        public bool ChangeState(string tCode, bool enabled)
        {
            if (tCode.Trim().ToUpper() == "SE38")
                return false;
            try
            {
                gate.ExecuteNonQuery("UPDATE TCode SET Enabled = @Enabled WHERE TCode = @TCode", new object[] { enabled, tCode });
                return true;
            }
            catch (Exception e)
            {

                Warnning(e);

                throw e;
            }
        }

        public bool ChangeScript(string tCode, string Script)
        {
            if (tCode.Trim().ToUpper() == "SE38")
                return false;
            try
            {
                gate.ExecuteNonQuery("UPDATE TCode SET Scripts = @Script WHERE TCode = @TCode", new object[] { Script, tCode });
                return true;
            }
            catch (Exception e)
            {

                Warnning(e);
                //ExceptionDetail d = new ExceptionDetail(e);
                throw e;// new FaultException<ExceptionDetail>(d, e.Message);
            }
        }

        public bool Delete(string tCode)
        {
            if (tCode.Trim().ToUpper() == "SE38")
                return false;
            try
            {
                gate.ExecuteNonQuery("DELETE FROM  TCode WHERE TCode = @TCode", new object[] { tCode });
                return true;
            }
            catch (Exception e)
            {

                Warnning(e);
                //ExceptionDetail d = new ExceptionDetail(e);
                throw e;// new FaultException<ExceptionDetail>(d, e.Message);
            }
        }

        #endregion

        public static void Warnning(object o)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╱╲╱╲");
            Console.WriteLine("╲警╲╱");
            Console.WriteLine("╱╲告╲   " + DateTime.Now.ToString());
            Console.WriteLine("╲╱╲╱-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(o);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
