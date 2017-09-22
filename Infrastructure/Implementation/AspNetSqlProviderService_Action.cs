// ?2007 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Security.Principal;
using System.Web.Security;

using ServiceModelEx;
using Shawoo.Core.Administration;
using System.Data;
using Shawoo.Core;
namespace CredentialsManager
{
    /// <summary>
    /// AspNetSqlProviderService implements the IRoleManager,IApplicationManager,IPasswordManager,IMembershipManager,and IUserManager interfaces. The service should be deployed over secure transports
    /// </summary>
    public partial class AspNetSqlProviderService :MarshalByRefObject, IRoleManager, IApplicationManager, IPasswordManager, IMembershipManager, IUserManager
    {
        DB db = new DB("IM");
        public Function[] GetAllActions()
        {
            return ORM.Fill<Function>(db.GateWay.DbHelper.Select("SELECT * FROM AD_Functions", new object[] { }).Tables[0], true).ToArray();
        }

        public bool SaveAction(Function action)
        {
            return db.GateWay.DbHelper.ExecuteNonQuery(@"UPDATE AD_Functions 
                                                            SET Spec =@Spec,
                                                                IsPublic = @IsPublic
                                                           WHERE Action = @Action",
                                                          new object[] {
                                                                        action.Spec, 
                                                                        action.IsPublic,
                                                                        action.Action
                                                                       }) > 0;
            
        }



        public DataTable GetActionsLogs(string[] columns, object[] values)
        {
            return db.GateWay.DbHelper.ExecuteStoredProcedure("AD_GetActionsLogs", columns, values).Tables[0];
        }

        public DataTable GetActionRights(string role)
        {
            return db.GateWay.DbHelper.ExecuteStoredProcedure("AD_GetActionRights", new string[]{ "Role" }, new object[]{ role }).Tables[0];
        }

        public DataTable GetTCodeRights(string role)
        {
            return db.GateWay.DbHelper.ExecuteStoredProcedure("AD_GetTCodeRights", new string[] { "Role" }, new object[] { role }).Tables[0];
        }

        public void AddActionToRole(string action, string role)
        {
            db.GateWay.DbHelper.ExecuteStoredProcedure("AD_AddActionToRole", 
                                                        new string[] {"action","role" },
                                                        new object[] {action,role });
        }

        public void RemoveActionFromRole(string action, string role)
        {
            db.GateWay.DbHelper.ExecuteStoredProcedure("AD_RemoveActionFromRole",
                                                        new string[] { "action", "role" },
                                                        new object[] { action, role });
        }

        public void AddTCodeToRole(string tcode, string role)
        {
            db.GateWay.DbHelper.ExecuteStoredProcedure("AD_AddTCodeToRole",
                                                        new string[] { "tcode", "role" },
                                                        new object[] { tcode, role });
        }

        public void RemoveTCodeFromRole(string tcode, string role)
        {
            db.GateWay.DbHelper.ExecuteStoredProcedure("AD_RemoveTCodeFromRole",
                                                        new string[] { "tcode", "role" },
                                                        new object[] { tcode, role });
        }
    }

}