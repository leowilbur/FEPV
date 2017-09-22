using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class UpdateTKForm : Infrastructure.StyleForm
    {
        public UpdateTKForm()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "EGBK", "UpdateTKForm");
            btnOK.Click += new EventHandler(btnOK_Click); 
            btnNo.Click += new EventHandler(btnNo_Click); 
        }

        bool rValue = false;
        public bool RValue
        {
            get
            {
                if (string.IsNullOrEmpty(richTextBox1.Text.Trim()) || string.IsNullOrEmpty(txtVehicleNONew.Text.Trim()))
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

        public string TKNO
        {
            set { txtVehicleNO.Text = value; }
        }

        public string TKNONEW
        {
            get { return txtVehicleNONew.Text.Trim(); }
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
