using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface IWorkflow
    {
        BPMTask[] GetGateTask(string pid, string businessKey, string name, string processDefinitionName);

        BPMTask[] GetGateTaskUrl(string requrl);

        string Startdefinition(Dictionary<string, object> formdata, string businessKey, string processName);

        string StartdefinitionStr(string postData, string processName);

        string PostTask(string taskid, Dictionary<string, object> formdata, string businessKey);

        string SendTaskComment(string taskid, string msgname, string businessKey, string msgComment, string JWUser, string ExceptionType);

        bool VehicleInformation(string orders, string GDELINO, string TRUCKNO, string CDRIVER, string OUTTIME, out string ErrMsg);

        bool GetShippingOrder(string voucherID, string Trantype, string Outno, out string ErrMsg);
    }
}
