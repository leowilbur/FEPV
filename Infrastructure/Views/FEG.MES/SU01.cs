using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CredentialsManager;

namespace FEG.MES
{
    public partial class SU01 : Infrastructure.BaseForm
    {
        public SU01()
        {
            InitializeComponent();
        }

        private void SU01_Load(object sender, EventArgs e)
        {
            IRoleManager RoleProxy = Shawoo.Core.ServiceFactory.Create<IRoleManager>();
            {
                foreach(var i in RoleProxy.GetAllRoles("MES"))
                {
                    MessageBox.Show(i);
                }
            }
        }
    }
}
