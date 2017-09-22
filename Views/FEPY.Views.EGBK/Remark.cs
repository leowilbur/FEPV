using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class Remark : Infrastructure.StyleForm
    {
        public Remark()
        {
            InitializeComponent();
        }

        bool rValue = false;
        public bool RValue
        {
            get
            {
                if (string.IsNullOrEmpty(richTextBox1.Text.Trim()))
                {
                    rValue = false;
                }
                return rValue;
            }
        }

        public string TitleText 
        {
            set { this.Text = value; } 
        }

        public string Msg
        {
            get { return richTextBox1.Text.Trim(); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            rValue = true;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            rValue = false;
            this.Close();
        }
    }
}
