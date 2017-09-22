using System;
using System.Data;
using System.Text;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CredentialsManager
{
    public interface ITCode
    {

        string GetTCodeScript(string tCode,DateTime time);

        bool Create(string tCode, string spec, string Script);

        bool ChangeState(string tCode, bool enabled);

        bool ChangeScript(string tCode, string Script);

        bool Delete(string tCode);
    }
}
