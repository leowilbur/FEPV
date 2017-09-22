using System;

namespace CredentialsManager
{
    public interface IUserSurrogateManager
    {
        bool UserProxySet(string Proposer,string Proxyer,DateTime startTime,DateTime endTime,string Spec,out string Msg);

        
        bool UserProxyAccept(string Proposer, string Proxyer, DateTime startTime, DateTime endTime, out string Msg);

        
        bool UserProxyCancel(string Proposer, string Proxyer, DateTime startTime, DateTime endTime, out string Msg);

    }
}
