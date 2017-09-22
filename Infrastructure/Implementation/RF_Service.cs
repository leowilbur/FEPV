using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Infrastructure.ServiceImplementation;
using Infrastructure.Contract;
using Shawoo.Core;

namespace Infrastructure.Service
{
        
    public class RF_Service :MarshalByRefObject, IRF
    {
        #region IRF Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <param name="dsIn"></param>
        /// <param name="dsOut"></param>
        /// <param name="parameter"></param>
        /// <param name="returnParameter"></param>
        /// <param name="message"></param>
        /// <returns>1:正确,-1:系统错误,0:错误</returns>
        public int CallFunction(int functionId, string uid, string pwd, DataSet dsIn, out DataSet dsOut, object[] parameter, out object[] returnParameter, out string message)
        {
            returnParameter = null;
            dsOut = new DataSet();
            message = string.Empty;
            try
            {
                //不进行用户验证的方法
                switch (functionId)
                {
                    case -1:
                        string ip = Shawoo.GenuineChannels.GenuineUtility.CurrentRemoteHost.PhysicalAddress.ToString().Split(":".ToCharArray()).First(); //((RemoteEndpointMessageProperty)OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name]).Address;
                        string mac = Shawoo.Common.Logger.IP2MAC(ip);
                        message = string.Format("{0}->{1} {2}", ip, Shawoo.Common.Logger.NetRange(ip, null), mac);
                        return 1;
                    case 0://HELLO
                        message = DateTime.Now.ToString();//+ "(" + ((RemoteEndpointMessageProperty)OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name]).Address + ")";
                        return 1;
                    default:
                        return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                message = e.Message;
                return -1;
            }

        #endregion
        }
    }
}
