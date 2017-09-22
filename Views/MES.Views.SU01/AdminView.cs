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
    public partial class AdminView : UserControl, IAdminView
    {
        public AdminView()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "SU01", this.Name);
        }

        #region ICommonUserView Members
        public bool Cleartxt
        {
            set
            {
                if (value)
                {
                    txtPwd.Text = "";
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
        public string Pwd
        {
            get { return txtPwd.Text.Trim(); }
        }

        string msg = string.Empty;
        public bool IsReady
        {
            get
            {
                StringBuilder Msg = new StringBuilder();
                if (txtUserName.Text.Trim() == "")
                    Msg.Append("Username can not be empty/");

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
