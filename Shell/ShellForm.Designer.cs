namespace Shell
{
    partial class ShellForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellForm));
            this.Workspace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this._mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._COM = new System.Windows.Forms.ToolStripSplitButton();
            this._IP = new System.Windows.Forms.ToolStripStatusLabel();
            this._mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.btTCode = new System.Windows.Forms.ToolStripButton();
            this.TCODE = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btLogOff = new System.Windows.Forms.ToolStripButton();
            this.btCalendar = new System.Windows.Forms.ToolStripButton();
            this.btIM = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btCapture = new System.Windows.Forms.ToolStripButton();
            this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this._mainStatusStrip.SuspendLayout();
            this._mainToolStrip.SuspendLayout();
            this._mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Workspace
            // 
            this.Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Workspace.Location = new System.Drawing.Point(0, 54);
            this.Workspace.Name = "Workspace";
            this.Workspace.Size = new System.Drawing.Size(784, 488);
            this.Workspace.TabIndex = 14;
            this.Workspace.Text = "deckWorkspace1";
            // 
            // _mainStatusStrip
            // 
            this._mainStatusStrip.AutoSize = false;
            this._mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel,
            this._COM,
            this._IP});
            this._mainStatusStrip.Location = new System.Drawing.Point(0, 542);
            this._mainStatusStrip.Name = "_mainStatusStrip";
            this._mainStatusStrip.Size = new System.Drawing.Size(784, 22);
            this._mainStatusStrip.TabIndex = 13;
            this._mainStatusStrip.Text = "_mainStatusStrip";
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(58, 17);
            this._statusLabel.Text = " ^_^ -_- ";
            // 
            // _COM
            // 
            this._COM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._COM.Image = ((System.Drawing.Image)(resources.GetObject("_COM.Image")));
            this._COM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._COM.Name = "_COM";
            this._COM.Size = new System.Drawing.Size(32, 20);
            this._COM.Text = "toolStripSplitButton1";
            // 
            // _IP
            // 
            this._IP.Name = "_IP";
            this._IP.Size = new System.Drawing.Size(11, 17);
            this._IP.Text = ":";
            // 
            // _mainToolStrip
            // 
            this._mainToolStrip.AutoSize = false;
            this._mainToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this._mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btTCode,
            this.TCODE,
            this.toolStripSeparator1,
            this.btLogOff,
            this.btCalendar,
            this.btIM,
            this.toolStripSeparator2,
            this.btCapture});
            this._mainToolStrip.Location = new System.Drawing.Point(0, 24);
            this._mainToolStrip.Name = "_mainToolStrip";
            this._mainToolStrip.Size = new System.Drawing.Size(784, 30);
            this._mainToolStrip.TabIndex = 12;
            this._mainToolStrip.Text = "_mainToolStrip";
            // 
            // btTCode
            // 
            this.btTCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btTCode.Enabled = false;
            this.btTCode.Image = ((System.Drawing.Image)(resources.GetObject("btTCode.Image")));
            this.btTCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTCode.Name = "btTCode";
            this.btTCode.Size = new System.Drawing.Size(23, 27);
            this.btTCode.Text = "Enter";
            // 
            // TCODE
            // 
            this.TCODE.BackColor = System.Drawing.Color.White;
            this.TCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TCODE.Enabled = false;
            this.TCODE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.TCODE.MaxLength = 10;
            this.TCODE.Name = "TCODE";
            this.TCODE.Size = new System.Drawing.Size(100, 30);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // btLogOff
            // 
            this.btLogOff.Enabled = false;
            this.btLogOff.Image = ((System.Drawing.Image)(resources.GetObject("btLogOff.Image")));
            this.btLogOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLogOff.Name = "btLogOff";
            this.btLogOff.Size = new System.Drawing.Size(70, 27);
            this.btLogOff.Text = "Log off";
            // 
            // btCalendar
            // 
            this.btCalendar.Enabled = false;
            this.btCalendar.Image = ((System.Drawing.Image)(resources.GetObject("btCalendar.Image")));
            this.btCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCalendar.Name = "btCalendar";
            this.btCalendar.Size = new System.Drawing.Size(79, 27);
            this.btCalendar.Text = "Program";
            // 
            // btIM
            // 
            this.btIM.Enabled = false;
            this.btIM.Image = ((System.Drawing.Image)(resources.GetObject("btIM.Image")));
            this.btIM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btIM.Name = "btIM";
            this.btIM.Size = new System.Drawing.Size(93, 27);
            this.btIM.Text = "Messenger";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btCapture
            // 
            this.btCapture.Image = ((System.Drawing.Image)(resources.GetObject("btCapture.Image")));
            this.btCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCapture.Name = "btCapture";
            this.btCapture.Size = new System.Drawing.Size(74, 27);
            this.btCapture.Text = "Caputre";
            // 
            // _mainMenuStrip
            // 
            this._mainMenuStrip.AutoSize = false;
            this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.查看VToolStripMenuItem,
            this.帮助HToolStripMenuItem,
            this.MenUpdate});
            this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this._mainMenuStrip.Name = "_mainMenuStrip";
            this._mainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this._mainMenuStrip.TabIndex = 11;
            this._mainMenuStrip.Text = "_mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "File(&F)";
            // 
            // 查看VToolStripMenuItem
            // 
            this.查看VToolStripMenuItem.Name = "查看VToolStripMenuItem";
            this.查看VToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.查看VToolStripMenuItem.Text = "View(&V)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.帮助HToolStripMenuItem.Text = "Help(&H)";
            // 
            // MenUpdate
            // 
            this.MenUpdate.Name = "MenUpdate";
            this.MenUpdate.Size = new System.Drawing.Size(80, 20);
            this.MenUpdate.Text = "Update(&U)";
            // 
            // ShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.Workspace);
            this.Controls.Add(this._mainStatusStrip);
            this.Controls.Add(this._mainToolStrip);
            this.Controls.Add(this._mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShellForm_FormClosing);
            this.Load += new System.EventHandler(this.ShellForm_Load);
            this._mainStatusStrip.ResumeLayout(false);
            this._mainStatusStrip.PerformLayout();
            this._mainToolStrip.ResumeLayout(false);
            this._mainToolStrip.PerformLayout();
            this._mainMenuStrip.ResumeLayout(false);
            this._mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace Workspace;
        private System.Windows.Forms.StatusStrip _mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
        private System.Windows.Forms.ToolStripSplitButton _COM;
        private System.Windows.Forms.ToolStripStatusLabel _IP;
        private System.Windows.Forms.ToolStrip _mainToolStrip;
        private System.Windows.Forms.ToolStripButton btTCode;
        private System.Windows.Forms.ToolStripTextBox TCODE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btLogOff;
        private System.Windows.Forms.ToolStripButton btCalendar;
        private System.Windows.Forms.ToolStripButton btIM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btCapture;
        private System.Windows.Forms.MenuStrip _mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenUpdate;


    }
}

