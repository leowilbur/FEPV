using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BasicLanuage;

namespace FEPY.Views.Demo
{
    public partial class SU01View : Infrastructure.BaseForm
    {
        public SU01View()
        {
            InitializeComponent();
            CultureLanuage.LangData = TestData.CreateDataTable();
            CultureLanuage.ApplyResources(this, "EN");
        }

     

        public string Msg { set { txtMsg.Text = value; } }


        CommonUserView comview = new CommonUserView();
        private void SU01View_Load(object sender, EventArgs e)
        {
            workSpace.Show(comview);
           
           
        }

      

      

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
          
            //biz.ModifyPwd();
            Infrastructure.ConfirmBox.Show("test", "Test");
           
        }
    
    }
}
