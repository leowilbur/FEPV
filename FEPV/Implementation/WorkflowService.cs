using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using Shawoo.Core;
using Shawoo.Common;
using Newtonsoft.Json;
using HttpUtils;
using System.Configuration;
using System.Collections.Generic;

namespace FEPV.Implementation
{
    public class WorkflowService : MarshalByRefObject, IWorkflow
    {
        #region REST
        /// <summary>
        /// 服务链接
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetRestUrl()
        {
            string key = "RestUrl";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }

        RestService _restService = new RestService();

        /// <summary>
        /// 得到这个进程的任务
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="requrl"></param>
        /// <returns></returns>
        public BPMTask[] GetGateTask(string pid, string businessKey, string name, string processDefinitionName)
        {
            Console.WriteLine("WorkflowService - GetGateTask(businessKey)" + " - " + DateTime.Now.ToString());
            try
            {
                string url = GetRestUrl();
                return _restService.GetGateTask(url, pid, businessKey, name, processDefinitionName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public BPMTask[] GetGateTaskUrl(string requrl)
        {
            Console.WriteLine("WorkflowService - GetGateTask(requrl)" + " - " + DateTime.Now.ToString());
            try
            {
                string url = GetRestUrl();
                return _restService.GetGateTaskUrl(url, requrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        /// <summary>
        /// 启动流程
        /// </summary>
        /// <param name="formdata"></param>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public string Startdefinition(Dictionary<string, object> formdata, string businessKey, string processName)
        {
            Console.WriteLine("WorkflowService - Startdefinition()" + " - " + DateTime.Now.ToString());
            try
            {
                string url = GetRestUrl();
                return _restService.Startdefinition(url, formdata, businessKey, processName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        
        /// <summary>
        /// 启动流程
        /// </summary>
        /// <param name="formdata"></param>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public string StartdefinitionStr(string postData, string processName)
        {
            Console.WriteLine("WorkflowService - StartdefinitionStr()" + " - " + DateTime.Now.ToString());
            try
            {               
                string url = GetRestUrl();
                return _restService.Startdefinition2(url, postData, processName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        /// <summary>
        /// 提交一个任务
        /// </summary>
        /// <param name="taskid"></param>
        /// <param name="formdata"></param>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public string PostTask(string taskid, Dictionary<string, object> formdata, string businessKey)
        {
            Console.WriteLine("WorkflowService - PostTask()" + " - " + DateTime.Now.ToString());
            try
            {
                string url = GetRestUrl();
                return _restService.PostTask(url, taskid, formdata, businessKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        /// <summary>
        /// 发送消息，当这个超出容差，产生错误的任务
        /// </summary>
        /// <param name="taskid"></param>
        /// <param name="msgname"></param>
        /// <param name="businessKey"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string SendTaskComment(string taskid, string messageName, string businessKey, string messageComment, string JWUser, string ExceptionType)
        {
            Console.WriteLine("WorkflowService - SendTaskComment()" + " - " + DateTime.Now.ToString());
            try
            {
                string url = GetRestUrl();
                return _restService.SendTaskComment(url, taskid, messageName, businessKey, messageComment, JWUser, ExceptionType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        #endregion    
    
        public static string GetVehicleUrl()
        {
            string key = "VehicleUrl";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }

        public bool VehicleInformation(string orders, string GDELINO, string TRUCKNO, string CDRIVER, string OUTTIME, out string ErrMsg)
        {
            Console.WriteLine("WorkflowService - VehicleInformation" + " - " + DateTime.Now.ToString());
            try
            {
                string url = GetVehicleUrl();
                return _restService.VehicleInformation(url, orders, GDELINO, TRUCKNO, CDRIVER, OUTTIME, out ErrMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        public bool GetShippingOrder(string voucherID, string Trantype, string Outno, out string ErrMsg)
        {
            Console.WriteLine("WorkflowService - GetShippingOrder" + " - " + DateTime.Now.ToString());
            try
            {
                string url = GetVehicleUrl();
                bool rValue = false;
                decimal REQUAN = 0;
                rValue = _restService.GetShippingOrder(url, Trantype, Outno, out ErrMsg, out REQUAN);
                //更新发货单实发量
                ac.ExecuteNonQuery("Update JointTruckItem SET Requan=@Requan,Stamp=@Stamp Where ShippingOrder=@ShippingOrder AND VoucherID=@VoucherID"
                                    , new object[] { REQUAN, DateTime.Now, Outno, voucherID });
                return rValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
    }
}
