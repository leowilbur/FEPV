using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CredentialsManager;

namespace CredentialsManager
{
    /// <summary>
    /// 用户权限转交服务
    /// </summary>
    partial class UserSurrogateService : MarshalByRefObject, IUserSurrogateManager
    {

        #region IProxyManager Members
        /// <summary>
        /// 申请权限转交服务
        /// </summary>
        /// <param name="Proposer"></param>
        /// <param name="Proxyer"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="Spec"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool UserProxySet(string Proposer, string Proxyer, DateTime startTime, DateTime endTime, string Spec, out string Msg)
        {
            Msg = "";
            int result = Infrastructure.ServiceImplementation.ServiceHelper.Gate.SelectScalar<int>(@"SELECT Count(*)
                                                                                            FROM bd_Users_Proxy
                                                                                            WHERE (UserName =@UserName  OR  ProxyName =@ProxyName)
                                                                                             AND  BeginDate >= @B
                                                                                             AND  EndDate <= @E
                                                                                            ", new object[] { Proposer, Proxyer, startTime, endTime });
            if (result == 0)
            {
                Infrastructure.ServiceImplementation.ServiceHelper.Gate.ExecuteNonQuery(@"INSERT INTO bd_Users_Proxy(UserName,ProxyName,BeginDate,EndDate,Flag,Spec,AcceptDate)
                                                                                                VALUES
                                                                                                 (
                                                                                                      @UserName,@ProxyName,
                                                                                                      @StartTime,@EndTime,'False',@Spec,NULL
                                                                                                 )", new object[] { Proposer, Proxyer, startTime, endTime, Spec });
                return true;
            }
            else
            {
                Msg = "代理人在这段时间内己有相关代理/申请人己申请";
                return false;
            }
        }
        /// <summary>
        /// 接受权限转交服务
        /// </summary>
        /// <returns></returns>
        public bool UserProxyAccept(string Proposer, string Proxyer, DateTime startTime, DateTime endTime, out string Msg)
        {
            Msg = "";
            int result = Infrastructure.ServiceImplementation.ServiceHelper.Gate.SelectScalar<int>(@"SELECT Count(*)
                                                                                            FROM bd_Users_Proxy
                                                                                            WHERE (UserName =@UserName  AND  ProxyName =@ProxyName)
                                                                                             AND  BeginDate = @B
                                                                                             AND  EndDate = @E
                                                                                             AND  (Flag ='False' OR Flag = 'True')", new object[] { Proposer, Proxyer, startTime, endTime });
            if (result == 1)
            {
                Infrastructure.ServiceImplementation.ServiceHelper.Gate.ExecuteNonQuery(@"UPDATE bd_Users_Proxy
                                                                                SET Flag ='True',
                                                                                    AcceptDate = GETDATE()
                                                                                WHERE UserName =@UserName 
                                                                                  AND ProxyName =@ProxyName
                                                                                  AND BeginDate = @B
                                                                                  AND EndDate = @E
                                                                                ", new object[] { Proposer, Proxyer, startTime, endTime });
                return true;
            }
            else
            {
                Msg = "该代理不存在/己接受该代理";
                return false;
            }
        }

        /// <summary>
        /// 取消权限转交服务
        /// </summary>
        /// <returns></returns>
        public bool UserProxyCancel(string Proposer, string Proxyer, DateTime startTime, DateTime endTime, out string Msg)
        {
            Msg = "";
            int result = Infrastructure.ServiceImplementation.ServiceHelper.Gate.SelectScalar<int>(@"SELECT Count(*)
                                                                                            FROM bd_Users_Proxy
                                                                                            WHERE (UserName =@UserName  AND  ProxyName =@ProxyName)
                                                                                             AND  BeginDate = @B
                                                                                             AND  EndDate = @E
                                                                                          ", new object[] { Proposer, Proxyer, startTime, endTime });
            if (result == 1)
            {
                Infrastructure.ServiceImplementation.ServiceHelper.Gate.ExecuteNonQuery(@"UPDATE bd_Users_Proxy
                                                                                SET Flag ='False',
                                                                                    CancelDate = GETDATE()
                                                                                WHERE UserName =@UserName 
                                                                                  AND ProxyName =@ProxyName
                                                                                  AND BeginDate = @B
                                                                                  AND EndDate = @E
                                                                                ", new object[] { Proposer, Proxyer, startTime, endTime });
                return true;
            }
            else
            {
                Msg = "该代理不存在!";
                return false;
            }
        }

        #endregion
    }
}
