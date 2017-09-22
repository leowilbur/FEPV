using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;

namespace Infrastructure
{
    public partial class StyleForm : Form
    {
        public StyleForm()
        {
            InitializeComponent();

            TEXT.DataBindings.Add("Text", this,"Text");
        }

        /// <summary>
        /// Down Up
        /// </summary>
        public void EnableKeyTab()
        {
            if (this.components == null)
                this.components = new System.ComponentModel.Container();

            this.keyTab = new KeyTab(this.components);
            this.keyTab.NextK = Keys.Down;
            this.keyTab.PreviousK = Keys.Up;
        }
        //optional
        public void EnableKeyTab(Keys nextK, Keys previousK)
        {
            if (this.components == null)
                this.components = new System.ComponentModel.Container();

            this.keyTab = new KeyTab(this.components);
            this.keyTab.NextK = nextK;
            this.keyTab.PreviousK = previousK;
        }

        public void SetKeyTab(Component control)
        {
            if (keyTab == null)
                //EnableKeyTab();
                throw new Exception("Enable KeyTab First");

            this.keyTab.SetAllowKeyTab(control, true);
        }

        private KeyTab keyTab;

        #region -----drage-----
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCAPTION = 0x0002;
        protected override void WndProc(ref  System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    m.Result = (IntPtr)HTCAPTION;
                    break;
                default:
                    base.WndProc(ref  m);
                    break;
            }
        }

        /*
        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        const int WM_NCHITTEST = 0x0084;


        protected override void WndProc(ref   System.Windows.Forms.Message m)
        {
            base.WndProc(ref   m);
            if (m.Msg == WM_NCHITTEST)
            {
                if (m.Result == new IntPtr(HTCLIENT))
                    m.Result = new IntPtr(HTCAPTION);
                return;
            }
        }*/
        #endregion

        private void CLOSE_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StyleForm_Deactivate(object sender, EventArgs e)
        {
            TEXT.ForeColor = Color.Gray;
        }

        private void StyleForm_Activated(object sender, EventArgs e)
        {
            TEXT.ForeColor = Color.White;
        }

        private void TopArea_MouseDown(object sender, MouseEventArgs e)
        {
            StartResize(Win32.HT.HTCAPTION, 0);
        }

        private void StartResize(int ht, int lparam)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(Handle, Win32.WM.WM_NCLBUTTONDOWN, ht, lparam);
        }

        public void HideTips()
        {
            this.BeginInvoke(new VoidDelegate(delegate()
            {
                superTooltip.HideHint();
            }));
        }
        public void WriteTips(int duration, string message, Color color)
        {
            this.BeginInvoke(new VoidDelegate(delegate()
            {
          superTooltip.AutoPopDelay = duration;

               superTooltip.Appearance.ForeColor = color;
               superTooltip.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
               superTooltip.ShowHint(message, ToolTipLocation.LeftBottom, new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 });
            //    superTooltip.TooltipDuration = duration;
            //    superTooltip.ShowTooltip(this,
            //     new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
            //     );

            //    //
            //    superTooltip.SuperTooltipControl.Width = this.Width - 20;

            //    superTooltip.SuperTooltipControl.Text = message;
            //    superTooltip.SuperTooltipControl.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            //    superTooltip.SuperTooltipControl.PredefinedColor = color;
            }));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="message"></param>
        /// <param name="color">DevComponents.DotNetBar.eTooltipColor</param>
        /// <param name="size">14F</param>
        public void WriteTips(int duration, string message, Color color,float size)
        {
            this.BeginInvoke(new VoidDelegate(delegate()
            {
                superTooltip.AutoPopDelay = duration;


                superTooltip.Appearance.BackColor = color;
                superTooltip.Appearance.Options.UseBackColor = true;
                superTooltip.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
                superTooltip.ShowHint(message, ToolTipLocation.LeftBottom, new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 });
                //superTooltip.TooltipDuration = duration;
                //superTooltip.ShowTooltip(this,
                // new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
                // );

                ////
                //superTooltip.SuperTooltipControl.Width = this.Width - 20;

                //superTooltip.SuperTooltipControl.Text = message;
                //superTooltip.SuperTooltipControl.Font = new System.Drawing.Font("Microsoft YaHei", size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
                //superTooltip.SuperTooltipControl.PredefinedColor = color;
            }));
        }

        public void WriteTips(int duration, string message)
        {
            this.BeginInvoke(new VoidDelegate(delegate()
            {
                superTooltip.AutoPopDelay = duration;
                superTooltip.Appearance.BackColor = Color.Red;
                superTooltip.Appearance.Options.UseBackColor = true;
                superTooltip.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
                superTooltip.ShowHint(message, ToolTipLocation.LeftBottom, new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 });
                //superTooltip.TooltipDuration = duration;

                //superTooltip.ShowTooltip(this,
                // new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
                // );

                //superTooltip.SuperTooltipControl.Width = this.Width - 20;

                //superTooltip.SuperTooltipControl.Text = message;
                //superTooltip.SuperTooltipControl.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
                //superTooltip.SuperTooltipControl.PredefinedColor = DevComponents.DotNetBar.eTooltipColor.Red;
            }));
        }
    }
}