

using System;
using System.Data;
using Shawoo.Core;
using Shawoo.Core.Administration;
namespace CredentialsManager
{

    public partial interface IRoleManager
    {
        Function[] GetAllActions();

        bool SaveAction(Function action);

        DataTable GetActionsLogs(string[] columns, object[] values);

        DataTable GetActionRights(string role);

        DataTable GetTCodeRights(string role);

        void AddTCodeToRole(string tcode, string role);

        void RemoveTCodeFromRole(string tcode, string role);

        //[OperationContract]
        //void AddActionsToRole(string[] actions, string role);

        //[OperationContract]
        //void AddActionsToRoles(string[] actions, string[] roles);

        void AddActionToRole(string action, string role);

        //[OperationContract]
        //void AddActionToRoles(string action, string[] roles);

        //[OperationContract]
        //string[] GetRolesForAction(string action);

        //[OperationContract]
        //string[] GetActionsInRole(string role);

        void RemoveActionFromRole(string action, string role);

        //[OperationContract]
        //void RemoveActionsFromRole(string[] actions, string role);

        //[OperationContract]
        //void RemoveActionFromRoles(string action, string[] roles);

        //[OperationContract]
        //void RemoveActionsFromRoles(string[] actions, string[] roles);
    }
}