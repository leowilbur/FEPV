using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using BasicLanuage;


namespace FEPY.Views.Demo
{
    [SmartPart]
    public partial class CommonUserView : UserControl
    {
        public CommonUserView()
        {
            InitializeComponent();
            CultureLanuage.LangData = TestData.CreateDataTable();
            CultureLanuage.ApplyResources(this, "EN");
        }
            
          

    
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
                   Msg.Append("用户名不能为空/");
               if (txtNewPwd2.Text.Trim().Length < 6 || txtNewPwd2.Text.Trim().Length > 12)
                   Msg.Append("新密码必须是6-12位/");
               if (txtNewPwd.Text.Trim() != txtNewPwd2.Text.Trim())
                   Msg.Append("二次输入的新密码不一致.");

               msg = Msg.ToString();
               
               if(string.IsNullOrEmpty(Msg.ToString()))
                   return true;
               else
                   return false;
            }
        }

        public string ErrorMsg
        {
            get { return msg; }
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
       
        }
    
   
    }
}
