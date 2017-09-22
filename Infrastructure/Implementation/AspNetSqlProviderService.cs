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

namespace CredentialsManager
{
    /// <summary>
    /// AspNetSqlProviderService implements the IRoleManager,IApplicationManager,IPasswordManager,IMembershipManager,and IUserManager interfaces. The service should be deployed over secure transports
    /// </summary>
    public partial class AspNetSqlProviderService : MarshalByRefObject, IRoleManager, IApplicationManager, IPasswordManager, IMembershipManager, IUserManager
    {
        string[] IApplicationManager.GetApplications()
        {
            Console.WriteLine("GetApplications");
            ApplicationsTableAdapter adapter = new ApplicationsTableAdapter();
      
            Converter<AspNetDbDataSet.aspnet_ApplicationsRow, string> converter = delegate(AspNetDbDataSet.aspnet_ApplicationsRow row)
                                                                                 {
                                                                                     return row.ApplicationName;
                                                                                 };
            string[] applications = DataTableHelper.ToArray(adapter.GetData(), converter);
            if (applications == null)
            {
                applications = new string[] { };
            }
            return applications;
        }
        void IApplicationManager.DeleteAllApplications()
        {
            AspNetDbTablesAdapter aspNetDbTablesAdapter = new AspNetDbTablesAdapter();
            aspNetDbTablesAdapter.DeleteAllApplications();
        }
        
        void IApplicationManager.DeleteApplication(string application)
        {
            AspNetDbTablesAdapter aspNetDbTablesAdapter = new AspNetDbTablesAdapter();
            aspNetDbTablesAdapter.DeleteApplication(application);
        }
        
        void IMembershipManager.DeleteAllUsers(string application, bool deleteAllRelatedData)
        {
            IMembershipManager membershipManager = this;
            string[] users = membershipManager.GetAllUsers(application);

            Action<string> deleteUser = delegate(string user)
                                          {
                                              membershipManager.DeleteUser(application, user, deleteAllRelatedData);
                                          };
            Array.ForEach(users, deleteUser);
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        MembershipCreateStatus IMembershipManager.CreateUser(string application, string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved)
        {
            MembershipCreateStatus status = MembershipCreateStatus.UserRejected;

            Membership.ApplicationName = application;
            Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, out status);

            return status;
        }
        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        bool IMembershipManager.DeleteUser(string application, string userName, bool deleteAllRelatedData)
        {
            Membership.ApplicationName = application;
            return Membership.DeleteUser(userName, deleteAllRelatedData);
        }
        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        void IMembershipManager.UpdateUser(string application, string userName, string email, string oldAnswer, string newQuestion, string newAnswer, bool isApproved, bool isLockedOut)
        {
            Console.WriteLine("-------------UpdateUser----------------");
            Console.WriteLine("UpdateUser:" + isLockedOut + email + isApproved + application);
         
            Membership.ApplicationName = application;
            MembershipUser membershipUser = Membership.GetUser(userName);
            membershipUser.Email = email;
            membershipUser.IsApproved = isApproved;
  
            if (isLockedOut == false)
            {
                membershipUser.UnlockUser();
            }
            
            Console.WriteLine(Membership.EnablePasswordRetrieval);
            //if (Membership.EnablePasswordRetrieval)
            //{
            //    string password = membershipUser.GetPassword(oldAnswer);
            //    membershipUser.ChangePasswordQuestionAndAnswer(password, newQuestion, newAnswer);
            //}

            Console.WriteLine(membershipUser.IsLockedOut + " " + membershipUser.Email);
            Membership.UpdateUser(membershipUser);
        }
       
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        UserInfo IMembershipManager.GetUserInfo(string application, string userName)
        {
            Membership.ApplicationName = application;
            MembershipUser membershipUser = Membership.GetUser(userName);

            string answer = Infrastructure.ServiceImplementation.ServiceHelper.Gate.SelectScalar<string>("SELECT PasswordAnswer FROM dbo.vJiveUser WHERE username = @username",
                                                                              new object[] { userName}); //用户名 + 旧密码

            return new UserInfo(membershipUser.UserName, membershipUser.Email, membershipUser.PasswordQuestion,answer, membershipUser.IsApproved, membershipUser.IsLockedOut);
        }
        //[OperationBehavior(TransactionScopeRequired = true)]
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        string[] IMembershipManager.GetAllUsers(string application)
        {
            Membership.ApplicationName = application;
            MembershipUserCollection collection = Membership.GetAllUsers();
            Converter<object, string> converter = delegate(object obj)
                                                   {
                                                       MembershipUser membershipUser = obj as MembershipUser;
                                                       return membershipUser.UserName;
                                                   };
            return Collection.UnsafeToArray(collection, converter);
        }
       
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        int IMembershipManager.GetNumberOfUsersOnline(string application)
        {
            Membership.ApplicationName = application;
            return Membership.GetNumberOfUsersOnline();
        }
        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        int IMembershipManager.UserIsOnlineTimeWindow(string application)
        {
            Membership.ApplicationName = application;
            return Membership.UserIsOnlineTimeWindow;
        }
        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        string IMembershipManager.GetUserNameByEmail(string application, string email)
        {
            Membership.ApplicationName = application;
            return Membership.GetUserNameByEmail(email);
        }
       
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        bool IPasswordManager.EnablePasswordReset(string application)
        {
            Membership.ApplicationName = application;
            return Membership.EnablePasswordReset;
        }
       
        string IPasswordManager.ResetPassword(string application, string userName)
        {
            Membership.ApplicationName = application;
            if (Membership.EnablePasswordReset && !Membership.RequiresQuestionAndAnswer)
            {
                MembershipUser membershipUser = Membership.GetUser(userName);
                return membershipUser.ResetPassword();
            }
            return String.Empty;
        }
        
        string IPasswordManager.ResetPasswordWithQuestionAndAnswer(string application, string userName, string passwordAnswer)
        {
            Membership.ApplicationName = application;
            if (Membership.EnablePasswordReset)
            {
                MembershipUser membershipUser = Membership.GetUser(userName);
                return membershipUser.ResetPassword(passwordAnswer);
            }
            return String.Empty;
        }
       
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        string IPasswordManager.GetPassword(string application, string userName, string passwordAnswer)
        {
            Membership.ApplicationName = application;
            Debug.Assert(Membership.EnablePasswordRetrieval);

            MembershipUser membershipUser = Membership.GetUser(userName);
            return membershipUser.GetPassword(passwordAnswer);
        }
        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        string IPasswordManager.GetPasswordQuestion(string application, string userName)
        {
            Membership.ApplicationName = application;
            MembershipUser membershipUser = Membership.GetUser(userName);

            return membershipUser.PasswordQuestion;
        }

        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        void IPasswordManager.ChangePassword(string application, string userName, string newPassword)
        {
            Membership.ApplicationName = application;
            Debug.Assert(Membership.EnablePasswordRetrieval && !Membership.RequiresQuestionAndAnswer);

            MembershipUser membershipUser = Membership.GetUser(userName);
            membershipUser.ChangePassword(membershipUser.GetPassword(), newPassword);
        }
        
        void IPasswordManager.ChangePasswordWithAnswer(string application, string userName, string passwordAnswer, string newPassword)
        {
            Membership.ApplicationName = "MES";//application;
            Debug.Assert(Membership.EnablePasswordRetrieval);

            //SELECT PasswordAnswer FROM dbo.vJiveUser WHERE username = @username AND password = @password
            //SELECT PasswordAnswer FROM dbo.vJiveUser WHERE username = @username AND dbo.EncodePassword(@UID,password) = @password
            string answer = Infrastructure.ServiceImplementation.ServiceHelper.Gate.SelectScalar<string>("SELECT PasswordAnswer FROM dbo.vJiveUser WHERE username = @username AND password = @password",
                                                                              new object[] { userName,passwordAnswer }); //用户名 + 旧密码
            if (answer == null)
                throw new Exception("wrong password!");
            MembershipUser membershipUser = Membership.GetUser(userName);
            membershipUser.ChangePassword(membershipUser.GetPassword(answer), newPassword);
        }
        
        bool IPasswordManager.EnablePasswordRetrieval(string application)
        {
            Membership.ApplicationName = application;
            return Membership.EnablePasswordRetrieval;
        }
        
        string IPasswordManager.GeneratePassword(string application, int length, int numberOfNonAlphanumericCharacters)
        {
            Membership.ApplicationName = application;
            return Membership.GeneratePassword(length, numberOfNonAlphanumericCharacters);
        }
        
        int IPasswordManager.GetMaxInvalidPasswordAttempts(string application)
        {
            Membership.ApplicationName = application;
            return Membership.MaxInvalidPasswordAttempts;
        }
        
        int IPasswordManager.GetMinRequiredNonAlphanumericCharacters(string application)
        {
            Membership.ApplicationName = application;
            return Membership.MinRequiredNonAlphanumericCharacters;
        }
        
        int IPasswordManager.GetMinRequiredPasswordLength(string application)
        {
            Membership.ApplicationName = application;
            return Membership.MinRequiredPasswordLength;
        }
        
        int IPasswordManager.GetPasswordAttemptWindow(string application)
        {
            Membership.ApplicationName = application;
            return Membership.PasswordAttemptWindow;
        }
        
        string IPasswordManager.GetPasswordStrengthRegularExpression(string application)
        {
            Membership.ApplicationName = application;
            return Membership.PasswordStrengthRegularExpression;
        }
        
        bool IPasswordManager.RequiresQuestionAndAnswer(string application)
        {
            Membership.ApplicationName = application;
            return Membership.RequiresQuestionAndAnswer;
        }
        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        void IRoleManager.DeleteAllRoles(string application, bool throwOnPopulatedRole)
        {
            IRoleManager roleManager = this;
            string[] roles = roleManager.GetAllRoles(application);

            Action<string> deleteRole = delegate(string role)
                                          {
                                              roleManager.DeleteRole(application, role, throwOnPopulatedRole);
                                          };
            Array.ForEach(roles, deleteRole);
        }
        
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        string[] IRoleManager.GetAllRoles(string application)
        {
            Roles.ApplicationName = application;
            return Roles.GetAllRoles();
        }
       
        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        string[] IRoleManager.GetRolesForUser(string application, string userName)
        {
            Roles.ApplicationName = application;
            return Roles.GetRolesForUser(userName);
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        string[] IRoleManager.GetUsersInRole(string application, string role)
        {
            Roles.ApplicationName = application;
            return Roles.GetUsersInRole(role);
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        bool IRoleManager.RoleExists(string application, string role)
        {
            Roles.ApplicationName = application;
            return Roles.RoleExists(role);
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        void IRoleManager.AddUsersToRole(string application, string[] userNames, string role)
        {
            Roles.ApplicationName = application;
            Roles.AddUsersToRole(userNames, role);
        }

        void IRoleManager.AddUsersToRoles(string application, string[] userNames, string[] roles)
        {
            Roles.ApplicationName = application;
            Roles.AddUsersToRoles(userNames, roles);
        }

        void IRoleManager.AddUserToRole(string application, string userName, string role)
        {
            Roles.ApplicationName = application;
            Roles.AddUserToRole(userName, role);
        }

        void IRoleManager.AddUserToRoles(string application, string userName, string[] roles)
        {
            Roles.ApplicationName = application;
            Roles.AddUserToRoles(userName, roles);
        }

        void IRoleManager.CreateRole(string application, string role)
        {
            Roles.ApplicationName = application;
            Roles.CreateRole(role);
        }
        
        bool IRoleManager.DeleteRole(string application, string role, bool throwOnPopulatedRole)
        {
            Roles.ApplicationName = application;
            return Roles.DeleteRole(role, throwOnPopulatedRole);
        }
        
        bool IRoleManager.IsRolesEnabled(string application)
        {
            Roles.ApplicationName = application;
            return Roles.Enabled;
        }
        
        void IRoleManager.RemoveUserFromRole(string application, string userName, string roleName)
        {
            Roles.ApplicationName = application;
            Roles.RemoveUserFromRole(userName, roleName);
        }
        
        void IRoleManager.RemoveUserFromRoles(string application, string userName, string[] roles)
        {
            Roles.ApplicationName = application;
            Roles.RemoveUserFromRoles(userName, roles);
        }
        
        void IRoleManager.RemoveUsersFromRole(string application, string[] users, string roleName)
        {
            Roles.ApplicationName = application;
            Roles.RemoveUsersFromRole(users, roleName);
        }
        
        void IRoleManager.RemoveUsersFromRoles(string application, string[] users, string[] roles)
        {
            Roles.ApplicationName = application;
            Roles.RemoveUsersFromRoles(users, roles);
        }
      

        bool IUserManager.Authenticate(string application, string userName, string password)
        {
            Console.WriteLine("------------Authenticate---------------------");
            Membership.ApplicationName = "MES";
            Console.WriteLine("MES");
           // Console.WriteLine(Membership.ValidateUser(userName, password));
            return Membership.ValidateUser(userName, password);
        }
        
        bool IUserManager.IsInRole(string application, string userName, string role)
        {
            Roles.ApplicationName = application;
            return Roles.IsUserInRole(userName, role);
        }
        
        string[] IUserManager.GetRoles(string application, string userName)
        {
            IRoleManager roleManager = this;
            return roleManager.GetRolesForUser(application, userName);
        }
    }

}