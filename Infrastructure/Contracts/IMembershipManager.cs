// © 2007 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Runtime.Serialization;
using System.Web.Security;

namespace CredentialsManager
{
    [Serializable]
    public class UserInfo
    {
        string m_Name;
        string m_Email;
        string m_PasswordQuestion;
        string m_PasswordAnswer;
        bool m_IsApproved;
        bool m_IsLockedOut;

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }

        public string PasswordQuestion
        {
            get
            {
                return m_PasswordQuestion;
            }
            set
            {
                m_PasswordQuestion = value;
            }
        }

        public string PasswordAnswer
        {
            get
            {
                return m_PasswordAnswer;
            }
            set
            {
                m_PasswordAnswer = value;
            }
        }

        public bool IsApproved
        {
            get
            {
                return m_IsApproved;
            }
            set
            {
                m_IsApproved = value;
            }
        }

        public bool IsLockedOut
        {
            get
            {
                return m_IsLockedOut;
            }
            set
            {
                m_IsLockedOut = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public UserInfo(string name, string email, string passwordQuestion,string passwordAnswer, bool isApproved, bool isLockedOut)
        {
            Name = name;
            Email = email;
            PasswordQuestion = passwordQuestion;
            PasswordAnswer = passwordAnswer;
            IsApproved = isApproved;
            IsLockedOut = isLockedOut;
        }
        public UserInfo()
        { }
    }

    public interface IMembershipManager
    {
        /// <summary>
        /// Creates a new user.
        /// </summary>
        MembershipCreateStatus CreateUser(string application, string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved);

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        bool DeleteUser(string application, string userName, bool deleteAllRelatedData);

        /// <summary>
        /// Deletes all users,and optionally removed all relevant data
        /// </summary>
        void DeleteAllUsers(string application, bool deleteAllRelatedData);

        /// <summary>
        /// Returns the user matching the specified email.
        /// </summary>
        string GetUserNameByEmail(string application, string email);

        /// <summary>
        /// Gets the number of users currently accessing an application
        /// </summary>
        int GetNumberOfUsersOnline(string application);

        /// <summary>
        /// Updates the user record and status. May require a password answer.
        /// </summary>
        void UpdateUser(string application, string userName, string email, string oldAnswer, string newQuestion, string newAnswer, bool isApproved, bool isLockedOut);

        /// <summary>
        /// ]Specifies the number of minutes after the last activity date-time stamp for a user during which the user is considered on-line. Returns the number of minutes after the last activity date-time stamp for a user during which the user is considered on-line
        /// </summary>
        int UserIsOnlineTimeWindow(string application);

        /// <summary>
        /// Returns all of the users in the database.
        /// </summary>
        string[] GetAllUsers(string application);

        /// <summary>
        /// Gets the information from the data source for the specified user.
        /// </summary>
        UserInfo GetUserInfo(string application, string userName);
    }

}