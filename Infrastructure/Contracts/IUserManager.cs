// ?2007 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
namespace CredentialsManager
{
    public interface IUserManager
    {

       
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        bool Authenticate(string applicationName, string userName, string password);

        /// <summary>
        /// Verifies user role's membership.
        /// </summary>
        bool IsInRole(string applicationName, string userName, string role);

        /// <summary>
        /// Returns all roleList the user is a member of.
        /// </summary>
        string[] GetRoles(string applicationName, string userName);
    }
}