using BasicLanuage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MES.Views
{
    public partial class SU01View : Infrastructure.BaseForm, ISu01View
    {
        public SU01View()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "SU01", this.Name);
            biz.ISu01View = this;
            biz.ICommonUserView = cuv;
            biz.IAdminView = av;
        }

        string _role = string.Empty;
        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                switch (_role)
                {
                    case "Admin":
                        Console.WriteLine("Admin");
                        workSpace.Show(av);
                        break;
                    case "CommonUser":
                        Console.WriteLine("CommonUser");
                        workSpace.Show(cuv);
                        break;
                }
            }
        }

        public string Msg { set { txtMsg.Text = value; } }

        BizSu01 biz = new BizSu01();
        CommonUserView cuv = new CommonUserView();
        AdminView av = new AdminView();
        private void btModify_Click(object sender, EventArgs e)
        {
            biz.ModifyPwd();
        }
    }
}
