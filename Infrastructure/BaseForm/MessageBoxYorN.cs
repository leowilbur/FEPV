using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIS.Utility;

namespace Infrastructure
{
    public partial class ConfirmBox : StyleForm
    {
        public ConfirmBox(string caption, string message,float  fontsize,Color foreColor)
        {

            InitializeComponent();
            Text = caption;
            label1.Text = message;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", fontsize);
            this.label1.ForeColor = foreColor;
            this.btYes.Text = BasicLanuage.CultureLanuage.GetTranslation("YES");

            this.btNo.Text = BasicLanuage.CultureLanuage.GetTranslation("NO");
        }

        public ConfirmBox(string caption,string message)
        {
            InitializeComponent();
            Text = caption;
            string language = MyLanguage.Language;

            this.btYes.Text = BasicLanuage.CultureLanuage.GetTranslation("YES");

            //char[] chars = message.ToCharArray();

            //message = string.Empty;
            //int c = 0;
            //string t = string.Empty;
            //foreach (var i in chars)
            //{
            //    if (i == (char)10)
            //    {
            //        message = message + Format(t.TrimEnd((char)13));
            //        c = 0;
            //        t = string.Empty;
            //        continue;
            //    }
            //    //
            //    if (IsChineseLetter(i.ToString()))
            //        c += 2;
            //    else
            //        c += 1;
            //    //
            //    t = t+i.ToString();
            //    //
            //    if(c>=34)
            //    {
            //        message = message + Format(t);
            //        c = 0;
            //        t = string.Empty;
            //    }
            //}


            //if (c < 17)
            //    message = message + Format(t);

            ////
            label1.Text = message;

        }

        protected bool IsChineseLetter(string input)
        {
            int code = 0;
            int chfrom = Convert.ToInt32("4e00", 16);    //范围（0x4e00～0x9fff）转换成int（chfrom～chend）
            int chend = Convert.ToInt32("9fff", 16);
            if (input != "")
            {
                code = Char.ConvertToUtf32(input, 0);    //获得字符串input中指定索引index处字符unicode编码

                if (code >= chfrom && code <= chend)
                {
                    return true;     //当code在中文范围内返回true

                }
                else
                {
                    return false;    //当code不在中文范围内返回false
                }
            }
            return false;
        }


        public static string Format(string str)
        {
            return string.Format(@"                          {0}
", str);
        }
        public static bool Show(string caption, string message, float fontsize, Color foreColor)
        {
            ConfirmBox msg = new ConfirmBox(caption, message, fontsize, foreColor);
            return msg.ShowDialog() == DialogResult.Yes;
        }

        public static bool Show(string caption,string message)
        {
            ConfirmBox msg = new ConfirmBox(caption, message);
            return msg.ShowDialog() == DialogResult.Yes;
        }

        private void btYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
