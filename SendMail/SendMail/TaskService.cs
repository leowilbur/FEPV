using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Shawoo.Common;
using Newtonsoft.Json;
using System.Configuration;

namespace SendMail
{
    public class TaskService
    {
        public static string GetRestUrl()
        {
            string key = "RestUrl";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }
        public List<BPMTask> GetUserTasks(string processDefinitionId, string taskDefinitionKey)
        {
            try
            {
                Console.WriteLine("TaskService - GetUserTasks()" + " - " + DateTime.Now.ToString());
                string url = GetRestUrl();
                string requrl = string.Format("task?processDefinitionId={0}&taskDefinitionKey={1}", processDefinitionId, taskDefinitionKey);
                Console.WriteLine("url:" + url);
                Console.WriteLine("requrl:" + requrl);
                //
                var client = new RestClient();
                client.EndPoint = url;
                client.Method = HttpVerb.GET;

                var json = client.MakeRequest(requrl);
                //Console.WriteLine("tasks json:" + json.ToString());
                List<BPMTask> tasks = (List<BPMTask>)JsonConvert.DeserializeObject(json, typeof(List<BPMTask>));
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
                throw new FaultException<ExceptionDetail>(d, "GetGateTask Exception：" + ee.Message + ee.InnerException);
            }
        }

        public List<Candidates> GetUseridByTaskid(string taskid)
        {
            try
            {
                Console.WriteLine("TaskService - GetUseridByTaskid()" + " - " + DateTime.Now.ToString());
                string url = GetRestUrl();
                string requrl = string.Format("task/{0}/identity-links", taskid);
                Console.WriteLine("url:" + url);
                Console.WriteLine("requrl:" + requrl);
                //
                var client = new RestClient();
                client.EndPoint = url;
                client.Method = HttpVerb.GET;

                var json = client.MakeRequest(requrl);
                //Console.WriteLine("tasks json:" + json.ToString());
                List<Candidates> tasks = (List<Candidates>)JsonConvert.DeserializeObject(json, typeof(List<Candidates>));
                return tasks;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                ExceptionDetail d = new ExceptionDetail(ee);
                Logger.Trace(ee.ToString());
                throw new FaultException<ExceptionDetail>(d, "GetUseridByTaskid Exception：" + ee.Message + ee.InnerException);
            }
        }
    }

    public class Candidates
    {
        public string userId { get; set; }
        public string groupId { get; set; }
        public string type { get; set; }
        public string WorkFlow { get; set; }
    }
}
