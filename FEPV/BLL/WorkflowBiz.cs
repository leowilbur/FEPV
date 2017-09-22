using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using Shawoo.Core;

namespace FEPV.BLL
{
    public class WorkflowBiz
    {
        private readonly IWorkflow proxy = ServiceFactory.Create<IWorkflow>();
        
        /// <summary>
        /// 得到这个进程的任务
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="requrl"></param>
        /// <returns></returns>
        public BPMTask[] GetGateTask(string pid, string businessKey, string name, string processDefinitionName)
        {
            BPMTask[] results = null;
            try
            {
                results = proxy.GetGateTask(pid, businessKey, name, processDefinitionName);
            }
            catch (Exception ee)
            {
                throw new Exception("得到任务异常 - " + ee.Message);
            }
            return results;
        }

        /// <summary>
        /// 得到这个进程的任务
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public BPMTask[] GetGateTaskUrl(string requrl)
        {
            BPMTask[] results = null;
            try
            {
                results = proxy.GetGateTaskUrl(requrl);
            }
            catch (Exception ee)
            {
                throw new Exception("Url得到任务异常 - " + ee.Message);
            }
            return results;
        }

        /// <summary>
        /// 启动流程
        /// </summary>
        /// <param name="formdata"></param>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public string Startdefinition(Dictionary<string, object> formdata, string businessKey, string processName)
        {
            string results = string.Empty;
            try
            {
                results = proxy.Startdefinition(formdata, businessKey, processName);
            }
            catch (Exception ee)
            {
                throw new Exception("启动流程异常 - " + ee.Message);
            }
            return results;
        }

        /// <summary>
        /// 启动流程2(Dictionary参数中有数组，但是WCF不支持)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="businessKey"></param>
        /// <param name="processName"></param>
        /// <returns></returns>
        public string StartdefinitionStr(string postData, string processName)
        {
            string results = string.Empty;
            try
            {
                results = proxy.StartdefinitionStr(postData, processName);
            }
            catch (Exception ee)
            {
                throw new Exception("启动流程异常str - " + ee.Message);
            }
            return results;
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
            string results = string.Empty;
            try
            {
                results = proxy.PostTask(taskid, formdata, businessKey);
            }
            catch (Exception ee)
            {
                throw new Exception("提交任务异常 - " + ee.Message);
            }
            return results;
        }

        /// <summary>
        /// 发送消息，当这个超出容差，产生错误的任务
        /// </summary>
        /// <param name="taskid"></param>
        /// <param name="msgname"></param>
        /// <param name="businessKey"></param>
        /// <param name="msgComment"></param>
        /// <returns></returns>
        public string SendTaskComment(string taskid, string msgname, string businessKey, string msgComment, string JWUser, string ExceptionType)
        {
            string results = string.Empty;
            try
            {
                results = proxy.SendTaskComment(taskid, msgname, businessKey, msgComment, JWUser, ExceptionType);
            }
            catch (Exception ee)
            {
                throw new Exception("发送消息异常 - " + ee.Message);
            }
            return results;
        }

        public bool VehicleInformation(string orders, string GDELINO, string TRUCKNO, string CDRIVER, string OUTTIME, out string ErrMsg)
        {
            bool results = false;
            try
            {
                results = proxy.VehicleInformation(orders, GDELINO, TRUCKNO, CDRIVER, OUTTIME, out ErrMsg);
            }
            catch (Exception ee)
            {
                throw new Exception("Exception for VehicleInformation - " + ee.Message);
            }
            return results;
        }

        public bool GetShippingOrder(string voucherID, string Trantype, string Outno, out string ErrMsg)
        {
            bool results = false;
            try
            {
                results = proxy.GetShippingOrder(voucherID, Trantype, Outno, out ErrMsg);
            }
            catch (Exception ee)
            {
                throw new Exception("Exception for GetShippingOrder - " + ee.Message);
            }
            return results;
        }
    }
}
