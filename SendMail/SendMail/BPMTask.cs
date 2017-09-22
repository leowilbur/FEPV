using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendMail
{
    public class BPMTask
    {
        public string id { set; get; }
        public string name { set; get; }
        public string assignee { set; get; }
        public string created { set; get; }
        public string due { set; get; }
        public string followUp { set; get; }
        public string delegationState { set; get; }
        public string description { set; get; }
        public string executionId { set; get; }
        public string owner { set; get; }
        public string parentTaskId { set; get; }
        public string priority { set; get; }
        public string processDefinitionId { set; get; }
        public string processInstanceId { set; get; }
        public string taskDefinitionKey { set; get; }
    }
}
