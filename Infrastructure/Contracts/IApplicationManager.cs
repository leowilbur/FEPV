// © 2007 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
namespace CredentialsManager
{
    public interface IApplicationManager
    {
        /// <summary>
        /// Removes all users and roles from the application and deletes the application.
        /// </summary>
        /// <param name="application"></param>
        void DeleteApplication(string application);

        /// <summary>
        /// Deletes all applications,and removes all users and roles from  all applications.
        /// </summary>
        void DeleteAllApplications();

        /// <summary>
        /// Returns available applications.
        /// </summary>
        /// <returns></returns>
        string[] GetApplications();
    }
}