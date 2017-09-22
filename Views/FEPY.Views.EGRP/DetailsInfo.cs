using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class DetailsInfo : Infrastructure.StyleForm
    {
        public DetailsInfo()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "EGRP", this.Name);

            btClose.Click += new EventHandler(btClose_Click);
        }

        void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetInfo(DataRow row)
        {
            lblVoucherId.Text = row["VoucherID"].ToString();
            lblName.Text = row["GuestName"].ToString();
            lblIdCard.Text = row["IdCard"].ToString();
            lblCardNO.Text = row["CardNO"].ToString();

            //相片
            //MemoryStream ms = new MemoryStream((byte[])row["Image"]);
            //Image image = Image.FromStream(ms, true);
            //pictureBox1.Image = image;

            if (Convert.ToString(row["Image"]) != "")
            {
                MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                Image image = Image.FromStream(ms, true);
                pictureBox1.Image = image;
            }
            else
            {
                pictureBox1.Image = pictureBox1.InitialImage;
            }
        }

        private void DetailsInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
