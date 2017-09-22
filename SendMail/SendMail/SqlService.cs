using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;
using Shawoo.Core;
using Shawoo.Common;
using System.ServiceModel;
using NBear.Data;
using log4net;
using System.Data;

namespace SendMail
{
    public class SqlService
    {
        public Gateway gateBeling = new Gateway("IM");

        public DataTable GetProcessNode()
        {
            return gateBeling.ExecuteStoredProcedure("Email_GetProcessNode", new string[] { }, new object[] { }).Tables[0];
        }
        /// <summary>
        /// get task emails
        /// </summary>
        /// <returns></returns>
        public string GetMailsByUserID(string userid)
        {
            return gateBeling.ExecuteStoredProcedure("Email_GetMails4Task", new string[] { "UserID" }, new object[] { userid }).Tables[0].Rows[0][0].ToString();
        }
    }
}
