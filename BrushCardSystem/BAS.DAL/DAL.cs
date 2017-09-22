using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Remoting;
using System.Xml;
using System.Drawing;

namespace BAS.DAL
{
    public class DAL
    {
        public DAL()
        {
            //读取服务器配置
            //XmlDocument xml = new XmlDocument();
            //xml.Load(AppDomain.CurrentDomain.BaseDirectory + @"BAS.DAL.dll.config");

            //XmlNodeReader reader = new XmlNodeReader(xml);
            //string s = "";
            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element:
            //            s = reader.Name;
            //            break;
            //        case XmlNodeType.Text:
            //            if (s.Equals("constring"))
            //                constring = reader.Value;
            //            break;
            //    }
            //}
           // gate = new NBear.Data.Gateway(NBear.Data.DatabaseType.SqlServer, constring);
        }

      //  static string constring = string.Empty;
        protected static NBear.Data.Gateway gate = new NBear.Data.Gateway("Beling");
     
        /// <summary>
        /// 报表
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="parameters"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable Report(string storeName, string[] parameters, object[] values)
        {
            Console.WriteLine(storeName);
            return gate.ExecuteStoredProcedure(storeName, parameters, values).Tables[0];
        }
    }
}
