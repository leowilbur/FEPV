using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpUtils
{
  public  class ProcessMessage
    {
      public string id { set; get; }
      public string definitionId { set; get; }
      public string businessKey { set; get; }
      //public string caseInstanceId { set; get; }
      public string ended { set; get; }
      public string suspended { set; get; }
      public object links { set; get; }
    }
}
