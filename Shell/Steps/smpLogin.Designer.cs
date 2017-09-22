namespace Shell.Steps
{
    partial class smpLogin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(smpLogin));
            this._loginPanel = new System.Windows.Forms.Panel();
            this.vistaCalendar1 = new UI.Controls.VistaCalendar();
            this.vistaClock = new UI.Controls.VistaClock();
            this._loginGroupPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this._IQ = new System.Windows.Forms.RichTextBox();
            this._Msg = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._Language = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._PassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._User = new DevComponents.DotNetBar.Controls.TextBoxX();
            this._Client = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.loadingCircle = new UI.Controls.LoadingCircle();
            this.label5 = new System.Windows.Forms.Label();
            this._loginPanel.SuspendLayout();
            this._loginGroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _loginPanel
            // 
            this._loginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this._loginPanel.Controls.Add(this.label5);
            this._loginPanel.Controls.Add(this.vistaCalendar1);
            this._loginPanel.Controls.Add(this.vistaClock);
            this._loginPanel.Controls.Add(this._loginGroupPanel);
            this._loginPanel.Controls.Add(this._Msg);
            this._loginPanel.Controls.Add(this.panel4);
            this._loginPanel.Controls.Add(this.panel3);
            this._loginPanel.Controls.Add(this.label4);
            this._loginPanel.Controls.Add(this.label3);
            this._loginPanel.Controls.Add(this.label2);
            this._loginPanel.Controls.Add(this.panel2);
            this._loginPanel.Controls.Add(this.panel1);
            this._loginPanel.Controls.Add(this.label1);
            this._loginPanel.Controls.Add(this._Language);
            this._loginPanel.Controls.Add(this._PassWord);
            this._loginPanel.Controls.Add(this._User);
            this._loginPanel.Controls.Add(this._Client);
            this._loginPanel.Controls.Add(this.loadingCircle);
            this._loginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loginPanel.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._loginPanel.Location = new System.Drawing.Point(0, 0);
            this._loginPanel.Name = "_loginPanel";
            this._loginPanel.Size = new System.Drawing.Size(613, 371);
            this._loginPanel.TabIndex = 1;
            this._loginPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._loginPanel_MouseDown);
            // 
            // vistaCalendar1
            // 
            this.vistaCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vistaCalendar1.BackColor = System.Drawing.Color.Transparent;
            this.vistaCalendar1.Location = new System.Drawing.Point(326, 220);
            this.vistaCalendar1.Name = "vistaCalendar1";
            this.vistaCalendar1.Size = new System.Drawing.Size(135, 150);
            this.vistaCalendar1.Style = UI.Controls.VistaCalendar.VistaCalendarStyle.Gray;
            this.vistaCalendar1.TabIndex = 16;
            // 
            // vistaClock
            // 
            this.vistaClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vistaClock.BackColor = System.Drawing.Color.Transparent;
            this.vistaClock.Location = new System.Drawing.Point(461, 226);
            this.vistaClock.Name = "vistaClock";
            this.vistaClock.PositionRect = ((UI.Controls.CustomRectangle2)(resources.GetObject("vistaClock.PositionRect")));
            this.vistaClock.SecondSpring = true;
            this.vistaClock.ShowSecond = true;
            this.vistaClock.Size = new System.Drawing.Size(134, 150);
            this.vistaClock.Style = UI.Controls.VistaClock.VistaClockStyle.花瓣;
            this.vistaClock.TabIndex = 14;
            // 
            // _loginGroupPanel
            // 
            this._loginGroupPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._loginGroupPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._loginGroupPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._loginGroupPanel.Controls.Add(this._IQ);
            this._loginGroupPanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._loginGroupPanel.Location = new System.Drawing.Point(42, 226);
            this._loginGroupPanel.Name = "_loginGroupPanel";
            this._loginGroupPanel.Size = new System.Drawing.Size(278, 141);
            // 
            // 
            // 
            this._loginGroupPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._loginGroupPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._loginGroupPanel.Style.BackColorGradientAngle = 90;
            this._loginGroupPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._loginGroupPanel.Style.BorderBottomWidth = 1;
            this._loginGroupPanel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._loginGroupPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._loginGroupPanel.Style.BorderLeftWidth = 1;
            this._loginGroupPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._loginGroupPanel.Style.BorderRightWidth = 1;
            this._loginGroupPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._loginGroupPanel.Style.BorderTopWidth = 1;
            this._loginGroupPanel.Style.CornerDiameter = 4;
            this._loginGroupPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this._loginGroupPanel.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this._loginGroupPanel.TabIndex = 0;
            this._loginGroupPanel.Text = "[Information]";
            this._loginGroupPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_loginGroupPanel.TitleImage")));
            // 
            // _IQ
            // 
            this._IQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._IQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._IQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this._IQ.Location = new System.Drawing.Point(0, 0);
            this._IQ.Name = "_IQ";
            this._IQ.ReadOnly = true;
            this._IQ.Size = new System.Drawing.Size(272, 119);
            this._IQ.TabIndex = 0;
            this._IQ.Text = "";
            // 
            // _Msg
            // 
            this._Msg.AutoSize = true;
            this._Msg.BackColor = System.Drawing.Color.Transparent;
            this._Msg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._Msg.Location = new System.Drawing.Point(45, 226);
            this._Msg.Name = "_Msg";
            this._Msg.Size = new System.Drawing.Size(0, 13);
            this._Msg.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Location = new System.Drawing.Point(45, 187);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(105, 1);
            this.panel4.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Location = new System.Drawing.Point(45, 128);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 1);
            this.panel3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Language";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "User";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(45, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 1);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(45, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 1);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Client";
            // 
            // _Language
            // 
            // 
            // 
            // 
            this._Language.Border.Class = "TextBoxBorder";
            this._Language.Location = new System.Drawing.Point(150, 168);
            this._Language.MaxLength = 2;
            this._Language.Name = "_Language";
            this._Language.Size = new System.Drawing.Size(22, 21);
            this._Language.TabIndex = 4;
            this._Language.Text = "VN";
            // 
            // _PassWord
            // 
            // 
            // 
            // 
            this._PassWord.Border.Class = "TextBoxBorder";
            this._PassWord.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this._PassWord.Location = new System.Drawing.Point(150, 109);
            this._PassWord.MaxLength = 12;
            this._PassWord.Name = "_PassWord";
            this._PassWord.PasswordChar = '*';
            this._PassWord.Size = new System.Drawing.Size(99, 21);
            this._PassWord.TabIndex = 3;
            this._PassWord.WatermarkColor = System.Drawing.Color.Red;
            this._PassWord.WatermarkText = "************";
            // 
            // _User
            // 
            // 
            // 
            // 
            this._User.Border.Class = "TextBoxBorder";
            this._User.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this._User.Location = new System.Drawing.Point(150, 82);
            this._User.MaxLength = 16;
            this._User.Name = "_User";
            this._User.Size = new System.Drawing.Size(132, 21);
            this._User.TabIndex = 2;
            // 
            // _Client
            // 
            // 
            // 
            // 
            this._Client.Border.Class = "TextBoxBorder";
            this._Client.Location = new System.Drawing.Point(150, 44);
            this._Client.MaxLength = 4;
            this._Client.Name = "_Client";
            this._Client.Size = new System.Drawing.Size(34, 21);
            this._Client.TabIndex = 1;
            this._Client.Text = "8800";
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.Color = System.Drawing.Color.Yellow;
            this.loadingCircle.InnerCircleRadius = 8;
            this.loadingCircle.Location = new System.Drawing.Point(246, 109);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 24;
            this.loadingCircle.OuterCircleRadius = 9;
            this.loadingCircle.RotationSpeed = 50;
            this.loadingCircle.Size = new System.Drawing.Size(39, 23);
            this.loadingCircle.SpokeThickness = 4;
            this.loadingCircle.StylePreset = UI.Controls.LoadingCircle.StylePresets.IE7;
            this.loadingCircle.TabIndex = 15;
            this.loadingCircle.Text = "loadingCircle1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(178, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "*(VN-tiếng việt,CN-中文简体,EN-English,TW-中文繁體)";
            //this.label5.Visible = false;
            // 
            // smpLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._loginPanel);
            this.Name = "smpLogin";
            this.Size = new System.Drawing.Size(613, 371);
            this._loginPanel.ResumeLayout(false);
            this._loginPanel.PerformLayout();
            this._loginGroupPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _loginPanel;
        private UI.Controls.VistaCalendar vistaCalendar1;
        private UI.Controls.VistaClock vistaClock;
        private DevComponents.DotNetBar.Controls.GroupPanel _loginGroupPanel;
        private System.Windows.Forms.Label _Msg;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX _Language;
        private DevComponents.DotNetBar.Controls.TextBoxX _PassWord;
        private DevComponents.DotNetBar.Controls.TextBoxX _User;
        private DevComponents.DotNetBar.Controls.TextBoxX _Client;
        private UI.Controls.LoadingCircle loadingCircle;
        public System.Windows.Forms.RichTextBox _IQ;
        private System.Windows.Forms.Label label5;
    }
}
