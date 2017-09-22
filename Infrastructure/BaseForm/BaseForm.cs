using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using WeifenLuo.WinFormsUI.Docking;
namespace Infrastructure
{
    public delegate void VoidDelegate();

    public partial class BaseForm : DockContent,IDisposable
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Down Up
        /// </summary>
        public void EnableKeyTab()
        {
            if(this.components == null)
                this.components = new System.ComponentModel.Container();

            this.keyTab = new KeyTab(this.components);
            this.keyTab.NextK = Keys.Down;
            this.keyTab.PreviousK = Keys.Up;
        }
        //optional
        public void EnableKeyTab(Keys nextK,Keys previousK)
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
        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        const int WM_NCHITTEST = 0x0084;


        protected override void WndProc(ref   System.Windows.Forms.Message m)
        {
            base.WndProc(ref   m);
            if (this.DockPanel != null)
                return;

            if (m.Msg == WM_NCHITTEST)
            {
                if (m.Result == new IntPtr(HTCLIENT))
                    m.Result = new IntPtr(HTCAPTION);
                return;
            }
        }
        #endregion

        protected override void  OnClosed(EventArgs e)
        {
            //Visible = false;
            //Hide();
            //e.Cancel = true;
            //Singleton<BaseForm>.Instance = null;
            base.OnClosed(e);
        }

        public override void OnHotKey(Keys key)
        {

        }

        //public string Skin
        //{
        //    get
        //    {
        //        return skinEngine.SkinFile;
        //    }
        //    set
        //    {
        //        skinEngine.SkinFile = @".\Skin\"+value;
        //    }
        //}

        public void HideTips()
        {
            this.BeginInvoke(new VoidDelegate(delegate()
            {
                superTooltip.HideHint();
            }));
        }
        public void WriteTips(int duration,string message,Color color)
        {
            this.BeginInvoke(new VoidDelegate(delegate()
            {
                superTooltip.AutoPopDelay = duration;
                superTooltip.Appearance.BackColor = color;
                superTooltip.Appearance.Options.UseBackColor = true;
                superTooltip.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
                if (this.DockPanel != null)
                {
                    superTooltip.ShowHint(message, ToolTipLocation.LeftBottom, PointToScreen(new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 - 20 }));

                }
                else
                {
                    superTooltip.ShowHint(message, ToolTipLocation.LeftBottom,
                     new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
                     );


                }

                //
                //  superTooltip.ToolTipLocation.Width = this.Width - 20;

                // superTooltip.SuperTooltipControl.Text = message;
                //  superTooltip.SuperTooltipControl.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);

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
                //   superTooltip.TooltipDuration = duration;
                if (this.DockPanel != null)
                {
                    //superTooltip.ShowTooltip(this,
                    //    PointToScreen(new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 - 20 })
                    //    );
                    superTooltip.ShowHint(message, ToolTipLocation.LeftBottom, PointToScreen(new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 - 20 }));
                }
                else
                {
                    //superTooltip.ShowTooltip(this,
                    // new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
                    // );
                    superTooltip.ShowHint(message, ToolTipLocation.LeftBottom,
                   new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
                   );
                }

                //
                //    superTooltip.SuperTooltipControl.Width = this.Width - 20;
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
                Console.WriteLine("new writeTip");
                superTooltip.Appearance.Options.UseBackColor = true;
                superTooltip.Appearance.BackColor = Color.Red;
                superTooltip.Appearance.ForeColor = Color.Black;
                superTooltip.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
                // superTooltip.TooltipDuration = duration;
                if (this.DockPanel != null)
                {
                    //superTooltip.ShowTooltip(this,
                    //    PointToScreen(new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 - 20 })
                    //    );
                    superTooltip.ShowHint("^_^£º" + message, ToolTipLocation.LeftBottom, PointToScreen(new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 - 20 }));
                }
                else
                {
                    //superTooltip.ShowTooltip(this,
                    // new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
                    // );
                    superTooltip.ShowHint(message, ToolTipLocation.LeftBottom,
                   new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 }
                   );
                }

                //superTooltip.SuperTooltipControl.Width = this.Width - 20;

                //superTooltip.SuperTooltipControl.Text = message;
                //superTooltip.SuperTooltipControl.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
                //superTooltip.SuperTooltipControl.PredefinedColor = DevComponents.DotNetBar.eTooltipColor.Red;
            }));
        }

    }
}