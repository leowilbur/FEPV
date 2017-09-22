using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class MainForm : Infrastructure.BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            foreach (Control c in ribbonClientPanel1.Controls)
            {
                c.MouseHover += new EventHandler(c_MouseHover);
                c.Click += new EventHandler(c_Click);
                c.Enabled = false;
                c.Visible = false;
                c.Tag = string.Empty;
            }

            //L1 = "dd";
            //L4 = "dd";
            //L5 = "dd";
            //L8 = "dd";
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            //base.OnClosing(e);
            Console.WriteLine("OnClosing");
        }
       
        void c_MouseHover(object sender, EventArgs e)
        {
            //WriteTips(1,
            //          ((PictureBox)sender).Tag.ToString(),
            //          DevComponents.DotNetBar.eTooltipColor.Blue);
        }

        string Path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"L\";
        public string L1 { set { pb1.Tag = value; pb1.Image = new Bitmap(Path + "1.jpg"); pb1.Visible = true; pb1.Enabled = !string.IsNullOrEmpty(value); } }
        public string L2 { set { pb2.Tag = value; pb2.Image = new Bitmap(Path + "2.jpg"); pb2.Visible = true; pb2.Enabled = !string.IsNullOrEmpty(value); } }
        public string L3 { set { pb3.Tag = value; pb3.Image = new Bitmap(Path + "3.jpg"); pb3.Visible = true; pb3.Enabled = !string.IsNullOrEmpty(value); } }
        public string L4 { set { pb4.Tag = value; pb4.Image = new Bitmap(Path + "4.jpg"); pb4.Visible = true; pb4.Enabled = !string.IsNullOrEmpty(value); } }
        public string L5 { set { pb5.Tag = value; pb5.Image = new Bitmap(Path + "5.jpg"); pb5.Visible = true; pb5.Enabled = !string.IsNullOrEmpty(value); } }
        public string L6 { set { pb6.Tag = value; pb6.Image = new Bitmap(Path + "6.jpg"); pb6.Visible = true; pb6.Enabled = !string.IsNullOrEmpty(value); } }
        public string L7 { set { pb7.Tag = value; pb7.Image = new Bitmap(Path + "7.jpg"); pb7.Visible = true; pb7.Enabled = !string.IsNullOrEmpty(value); } }
        public string L8 { set { pb8.Tag = value; pb8.Image = new Bitmap(Path + "8.jpg"); pb8.Visible = true; pb8.Enabled = !string.IsNullOrEmpty(value); } }
        public string L9 { set { pb9.Tag = value; pb9.Image = new Bitmap(Path + "9.jpg"); pb9.Visible = true; pb9.Enabled = !string.IsNullOrEmpty(value); } }
        public string L10 { set { pb10.Tag = value; pb10.Image = new Bitmap(Path + "10.jpg"); pb10.Visible = true; pb10.Enabled = !string.IsNullOrEmpty(value); } }
        void c_Click(object sender, EventArgs e)
        {
            Infrastructure.CmdBridge.RunCode(((PictureBox)sender).Tag.ToString());
            //WriteTips(1, 
            //          ((PictureBox)sender).Tag.ToString(), 
            //          DevComponents.DotNetBar.eTooltipColor.Red);
        }
    }
}
