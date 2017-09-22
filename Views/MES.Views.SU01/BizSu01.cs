using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CredentialsManager;

namespace MES.Views
{
    public class BizSu01
    {
        ICommonUserView _ICommonUserView;
        public ICommonUserView ICommonUserView
        {
            get { return _ICommonUserView; }
            set { _ICommonUserView = value; }
        }

        ISu01View _ISu01View;
        public ISu01View ISu01View
        {
            get { return _ISu01View; }
            set { _ISu01View = value; }
        }

        IAdminView _IAdminView;
        public IAdminView IAdminView
        {
            get { return _IAdminView; }
            set { _IAdminView = value; }
        }

        public void ModifyPwd()
        {
            ISu01View.Msg = "";
            string msg = string.Empty;
            IPasswordManager proxy = Shawoo.Core.ProxyHelper<IPasswordManager>.GetService();

            switch (ISu01View.Role)
            {
                case "CommonUser":
                    if (ICommonUserView.IsReady)
                    {
                        proxy.ChangePasswordWithAnswer("MES", ICommonUserView.UserName, ICommonUserView.OldPwd, ICommonUserView.NewPwd1);
                        msg = "Ordinary user to change the password is successful!";
                        Shawoo.Common.Token.PWD = ICommonUserView.NewPwd1;
                        ICommonUserView.Cleartxt = true;
                    }
                    else
                        ISu01View.Msg = ICommonUserView.ErrorMsg;
                    break;

                case "Admin":
                    if (IAdminView.IsReady)
                    {
                        ISu01View.Msg = "proxy.ChangePassword(IAdminView.UserName,IAdminView.Pwd)";
                        proxy.ChangePassword("MES", IAdminView.UserName, IAdminView.Pwd);
                        msg = "The administrator changed the password successfully!";

                        if (Shawoo.Common.Token.UID == IAdminView.UserName)
                            Shawoo.Common.Token.PWD = IAdminView.Pwd;
                        IAdminView.Cleartxt = true;
                    }
                    else
                        ISu01View.Msg = IAdminView.ErrorMsg;
                    break;
            }
            ISu01View.Msg = msg;
        }
    }
}
