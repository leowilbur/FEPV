using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using FEPV.Model;
using Newtonsoft.Json;
using System.ServiceModel;
using Shawoo.Core;
using Shawoo.Common;

namespace HttpUtils
{
    public class RestService
    {
        /// <summary>
        /// 根据变量得到这个进程的任务
        /// </summary>
        /// <param name="url">url路径</param>
        /// <param name="pid">进程ID(没用到)</param>
        /// <param name="businessKey">VoucherID计划单号</param>
        /// <param name="name">进程节点名</param>
        /// <param name="processDefinitionName">进程名称</param>
        /// <returns></returns>
        public BPMTask[] GetGateTask(string url, string pid, string businessKey, string name, string processDefinitionName)
        {
            //例如：processDefinitionName="短驳运输流程",name="异常原因"
            try
            {
                Console.WriteLine("RestService - GetGateTask()" + " - " + DateTime.Now.ToString());
                var client = new RestClient();
                client.EndPoint = url + "task";
                client.Method = HttpVerb.GET;

                string requrl = "";
                if (name == "")
                {
                    requrl = string.Format("?processDefinitionName={0}&processInstanceBusinessKey={1}", processDefinitionName, businessKey);
                }
                else
                {
                    requrl = string.Format("?processDefinitionName={0}&processInstanceBusinessKey={1}&name={2}", processDefinitionName, businessKey, name);
                }

                var json = client.MakeRequest(requrl);
                //Console.WriteLine("tasks json:" + json.ToString());
                BPMTask[] tasks = (BPMTask[])JsonConvert.DeserializeObject(json, typeof(BPMTask[]));
                //tasks
                if (tasks.Count() > 0)
                {
                    Console.WriteLine("BPMTask Count:" + tasks.Count());
                    foreach (BPMTask task in tasks)
                    {
                        Console.WriteLine(string.Format("taskid:{0},name:{1},des:{2}", task.id, task.name, task.description));
                    }
                }
                return tasks;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, " RestService GetGateTask异常：" + ee.Message + ee.InnerException);
            }
        }

        /// <summary>
        /// 根据字典得到这个进程的任务
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requrl"></param>
        /// <returns></returns>
        public BPMTask[] GetGateTaskUrl(string url, string requrl)
        {
            //例如：processDefinitionName="短驳运输流程",name="异常原因"
            try
            {
                Console.WriteLine("RestService - GetGateTaskUrl()" + " - " + DateTime.Now.ToString());
                Console.WriteLine("url:" + url);
                Console.WriteLine("requrl:" + requrl);
                //
                var client = new RestClient();
                client.EndPoint = url + "task";
                client.Method = HttpVerb.GET;

                var json = client.MakeRequest(requrl);
                //Console.WriteLine("tasks json:" + json.ToString());
                BPMTask[] tasks = (BPMTask[])JsonConvert.DeserializeObject(json, typeof(BPMTask[]));
                //tasks
                if (tasks.Count() > 0)
                {
                    Console.WriteLine("BPMTask Count:" + tasks.Count());
                    foreach (BPMTask task in tasks)
                    {
                        Console.WriteLine(string.Format("taskid:{0},name:{1},des:{2}", task.id, task.name, task.description));
                    }
                }
                return tasks;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, " RestService GetGateTask异常：" + ee.Message + ee.InnerException);
            }
        }

        /// <summary>
        /// 启动流程
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formdata"></param>
        /// <param name="businessKey"></param>
        /// <param name="processName"></param>
        /// <returns></returns>
        public string Startdefinition(string url, Dictionary<string, object> formdata, string businessKey, string processName)
        {
            //例如：processName="ProcessShortTruck"
            try
            {
                Console.WriteLine("RestService - Startdefinition()" + " - " + DateTime.Now.ToString());

                RestClient client = new RestClient();
                //url + "process-definition/key/ProcessShortTruck/start";
                client.EndPoint = string.Format(url + "process-definition/key/{0}/start", processName);
                client.Method = HttpVerb.POST;
                string plyload = client.ConvertFormData(formdata, businessKey);
                client.PostData = plyload;
                string json = client.MakeRequest();
                Console.WriteLine(json);

                ProcessMessage process = (ProcessMessage)JsonConvert.DeserializeObject(json, typeof(ProcessMessage));
                Console.WriteLine("id:" + process.id.ToString());
                Console.WriteLine("definitionId:" + process.definitionId.ToString());
                Console.WriteLine("businessKey:" + process.businessKey.ToString());
                Console.WriteLine("ended:" + process.ended.ToString());
                Console.WriteLine("suspended:" + process.suspended.ToString());

                return process.id;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString() + ee.StackTrace);
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, "RestService Startdefinition异常：" + ee.Message + ee.InnerException);
            }
        }

        //启动流程2
        public string Startdefinition2(string url, string formdata, string processName)
        {
            //例如：processName="ProcessShortTruck"
            try
            {
                Console.WriteLine("RestService - Startdefinition2()" + " - " + DateTime.Now.ToString());

                RestClient client = new RestClient();
                //url + "process-definition/key/ProcessShortTruck/start";
                client.EndPoint = string.Format(url + "process-definition/key/{0}/start", processName);
                client.Method = HttpVerb.POST;
                string plyload = formdata;
                Console.WriteLine("formdata:");
                Console.WriteLine(formdata);
                client.PostData = plyload;
                string json = client.MakeRequest();
                Console.WriteLine(json);

                ProcessMessage process = (ProcessMessage)JsonConvert.DeserializeObject(json, typeof(ProcessMessage));
                Console.WriteLine("id:" + process.id.ToString());
                Console.WriteLine("definitionId:" + process.definitionId.ToString());
                Console.WriteLine("businessKey:" + process.businessKey.ToString());
                Console.WriteLine("ended:" + process.ended.ToString());
                Console.WriteLine("suspended:" + process.suspended.ToString());

                return process.id;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString() + ee.StackTrace);
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, " RestService Startdefinition异常：" + ee.Message + ee.InnerException);
            }
        }

        /// <summary>
        /// 提交一个任务
        /// </summary>
        /// <param name="taskid"></param>
        /// <param name="formdata"></param>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public string PostTask(string url, string taskid, Dictionary<string, object> formdata, string businessKey)
        {
            try
            {
                Console.WriteLine("RestService - PostTask()" + " - " + DateTime.Now.ToString());
                var client = new RestClient();
                client.EndPoint = url + "task/" + taskid + "/complete";
                Console.WriteLine(url + "task/" + taskid + "/complete");
                client.Method = HttpVerb.POST;

                string plyload = client.ConvertFormData(formdata, "");
                client.PostData = plyload;
                return client.MakeRequest();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString() + ee.StackTrace);
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, " RestService PostTask异常：" + ee.Message + ee.InnerException);
            }
        }

        /// <summary>
        /// 发送消息，当这个超出容差，产生错误的任务
        /// </summary>
        /// <param name="taskid"></param>
        /// <param name="messageName">消息名称</param>
        /// <param name="businessKey"></param>
        /// <param name="messageComment"></param>
        /// <param name="JWUser">流程启动人</param>
        /// <param name="ExceptionType">异常类型</param>
        /// <returns></returns>
        public string SendTaskComment(string url, string taskid, string messageName, string businessKey, string messageComment, string JWUser, string ExceptionType)
        {
            try
            {
                //例如：ExceptionType="成品短驳超重"
                Console.WriteLine("RestService - SendTaskComment()" + " - " + DateTime.Now.ToString());
                var _restclient = new RestClient();
                _restclient.EndPoint = url + "message";
                _restclient.Method = HttpVerb.POST;

                Console.WriteLine(_restclient.EndPoint);
                Dictionary<string, object> processVariables = new Dictionary<string, object>();

                FormDatas fdReasonTitle = new FormDatas();
                fdReasonTitle.value = messageComment;
                fdReasonTitle.type = "String";
                FormDatas fdJWUser = new FormDatas();
                fdJWUser.value = JWUser;
                fdJWUser.type = "String";
                FormDatas fdExceptionType = new FormDatas();
                fdExceptionType.value = ExceptionType;
                fdExceptionType.type = "String";
                processVariables.Add("ReasonTitle", fdReasonTitle);
                processVariables.Add("JWUser", fdJWUser);
                processVariables.Add("ExceptionType", fdExceptionType);

                var formdate = new Dictionary<string, object>
                 {
                    { "messageName", messageName },
                    { "businessKey", businessKey },
                    { "processVariables", processVariables },           
                 };

                Console.WriteLine("formdate");
                string plyload = JsonConvert.SerializeObject(formdate);
                Console.WriteLine(plyload);
                _restclient.PostData = plyload;
                return _restclient.MakeRequest();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString() + ee.StackTrace);
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, " RestService SendTaskComment异常：" + ee.Message + ee.InnerException);
            }
        }

        public bool VehicleInformation(string url, string orders, string GDELINO, string TRUCKNO, string CDRIVER, string OUTTIME, out string ErrMsg)
        {
            try
            {
                ErrMsg = "";
                Console.WriteLine("RestService - VehicleInformation()" + " - " + DateTime.Now.ToString());
                var client = new RestClient();
                client.EndPoint = url + "api/Gate/JointTruck/VehicleInformation";
                client.Method = HttpVerb.POST;

                //string requrl = "";
                //requrl = string.Format("?orders={0}&GDELINO={1}&TRUCKNO={2}&CDRIVER={3}&OUTTIME={4}", orders, GDELINO, TRUCKNO, CDRIVER, OUTTIME);
                VehicleERPInput verp = new VehicleERPInput();
                verp.orders = orders;
                verp.GDELINO = GDELINO;
                verp.TRUCKNO = TRUCKNO;
                verp.CDRIVER = CDRIVER;
                verp.OUTTIME = OUTTIME;
                string plyload = JsonConvert.SerializeObject(verp);
                client.PostData = plyload;
                var json = client.MakeRequest();
                Console.WriteLine("json:" + json.ToString());
                VehicleERPOutput[] vehicleERPs = (VehicleERPOutput[])JsonConvert.DeserializeObject(json, typeof(VehicleERPOutput[]));
                //vehicleERPs
                ErrMsg = "";
                if (vehicleERPs.Count() > 0)
                {
                    Console.WriteLine("VehicleERP Count:" + vehicleERPs.Count());
                    foreach (VehicleERPOutput vehicleERP in vehicleERPs)
                    {
                        Console.WriteLine(string.Format("OUTNO:{0},ErrCode:{1},ErrMsg:{2}", vehicleERP.OUTNO, vehicleERP.ErrCode, vehicleERP.ErrMsg));
                        if (!string.IsNullOrEmpty(vehicleERP.ErrCode))
                        {
                            ErrMsg += vehicleERP.OUTNO + ":" + vehicleERP.ErrMsg + "|";
                        }
                    }
                }
                if (ErrMsg == "")//空白:作業成功；反之，則有錯誤,ErrCode 是以(outno)為依據 MIS 必須確定 ErrCode = 空白，才能在 MIS 做相應處理
                {
                    return true;
                }
                else 
                {
                    ErrMsg = "ERP System Message:" + ErrMsg;
                    return false;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, " RestService VehicleInformation异常：" + ee.Message + ee.InnerException);
            }
        }

        public bool GetShippingOrder(string url, string Trantype, string Outno, out string ErrMsg, out decimal REQUAN)
        {
            try
            {
                Console.WriteLine("RestService - GetShippingOrder()" + " - " + DateTime.Now.ToString());

                var client = new RestClient();
                client.EndPoint = url + "api/Gate/JointTruck/GetShippingOrder";
                client.Method = HttpVerb.GET;
                string requrl = string.Format("?Trantype={0}&Outno={1}", Trantype, Outno);

                var json = client.MakeRequest(requrl);
                Console.WriteLine("tasks json:" + json.ToString());
                ShippingOrderERPOutput[] orderinfoArray = (ShippingOrderERPOutput[])JsonConvert.DeserializeObject(json, typeof(ShippingOrderERPOutput[]));
                ShippingOrderERPOutput orderinfo = orderinfoArray[0];
                //ShippingOrder
                Console.WriteLine(string.Format("OUTNO:{0},ErrCode:{1},ErrMsg:{2},REQUAN:{3}", orderinfo.OUTNO, orderinfo.ErrCode, orderinfo.ErrMsg, orderinfo.REQUAN));

                ErrMsg = "";
                REQUAN = 0;
                if (!string.IsNullOrEmpty(orderinfo.ErrCode))
                {
                    ErrMsg += orderinfo.OUTNO + ":" + orderinfo.ErrMsg;
                }

                if (ErrMsg == "")//空白:作業成功；反之，則有錯誤,ErrCode 是以(outno)為依據 MIS 必須確定 ErrCode = 空白，才能在 MIS 做相應處理
                {
                    REQUAN = orderinfo.REQUAN;
                    return true;
                }
                else
                {
                    ErrMsg = "ERP System Message:" + ErrMsg;
                    return false;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, " RestService GetShippingOrder异常：" + ee.Message + ee.InnerException);
            }
        }
    }
}
