using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FEPV.BLL;
using BasicLanuage;
using MIS.Utility;

namespace FEPV.Views
{
    public partial class MISRemark : Infrastructure.StyleForm
    {
        public MISRemark()
        {
            InitializeComponent();
            btYes.Click+=btYes_Click;
            btNO.Click+=btNO_Click;
        }

        bool rValue = false;

        private void btYes_Click(object sender, EventArgs e)
        {
            rValue = true;
            this.Close();
        }

        private void btNO_Click(object sender, EventArgs e)
        {
        
            rValue = false;
            this.Close();
        }

        public string Msg
        {
            get
            {
                return txtMsg.Text.Trim();
            }
            set 
            { 
                txtMsg.Text = value; 
            }
        }

        public bool RValue
        {
            get
            {
                if (string.IsNullOrEmpty(txtMsg.Text.Trim()))
                    rValue = false;
                return rValue;
            }
        }
    }
}
