using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using BasicLanuage;

namespace MES.Views
{
    [SmartPart]
    public partial class CommonUserView : UserControl, ICommonUserView
    {
        public CommonUserView()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "SU01", this.Name);
            txtUserName.Enabled = false;
            txtUserName.Text = Shawoo.Common.Token.UID;
        }

        #region ICommonUserView Members
        public bool Cleartxt
        {
            set
            {
                if (value)
                {
                    txtOldPwd.Text = "";
                    txtNewPwd.Text = "";
                    txtNewPwd2.Text = "";
                }
            }
        }
        public string UserName
        {
            get
            {
                return txtUserName.Text.Trim();
            }
        }
        public string OldPwd
        {
            get { return txtOldPwd.Text.Trim(); }
        }

        public string NewPwd1
        {
            get { return txtNewPwd.Text.Trim(); }
        }

        public string NewPwd2
        {
            get { return txtNewPwd2.Text.Trim(); }
        }

        string msg = string.Empty;
        public bool IsReady
        {
            get
            {
                StringBuilder Msg = new StringBuilder();
                if (txtUserName.Text.Trim() == "")
                    Msg.Append("Username can not be empty/");
                if (txtNewPwd2.Text.Trim().Length < 6 || txtNewPwd2.Text.Trim().Length > 12)
                    Msg.Append("The new password must be 6-12 digits/");
                if (txtNewPwd.Text.Trim() != txtNewPwd2.Text.Trim())
                    Msg.Append("The new password entered twice must be the same.");

                msg = Msg.ToString();

                if (string.IsNullOrEmpty(Msg.ToString()))
                    return true;
                else
                    return false;
            }
        }

        public string ErrorMsg
        {
            get { return msg; }
        }
        #endregion
    }
}
