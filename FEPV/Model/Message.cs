using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Model
{
    [Serializable]
    public class Message
    {
        public string Action { get; set; }
        public string BookMark { get; set; }
        public string Form { get; set; }
        public string InstanceId { get; set; }
        public string Key { get; set; }
        public string SchemaId { get; set; }
        public string Who { get; set; }
    }
}
