namespace FEG.MES
{
    partial class NodeEditer
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
            this.group = new DevExpress.XtraEditors.GroupControl();
            this.btCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iTCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this._iSpec = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this._iTitle = new DevExpress.XtraEditors.TextEdit();
            this._iFullPath = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.group)).BeginInit();
            this.group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._iSpec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._iTitle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // group
            // 
            this.group.Controls.Add(this.btCancle);
            this.group.Controls.Add(this.btOK);
            this.group.Controls.Add(this.labelControl3);
            this.group.Controls.Add(this.iTCode);
            this.group.Controls.Add(this.labelControl2);
            this.group.Controls.Add(this._iSpec);
            this.group.Controls.Add(this.labelControl1);
            this.group.Controls.Add(this._iTitle);
            this.group.Controls.Add(this._iFullPath);
            this.group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group.Location = new System.Drawing.Point(0, 0);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(510, 244);
            this.group.TabIndex = 0;
            this.group.Text = "NodeEditer";
            // 
            // btCancle
            // 
            this.btCancle.Location = new System.Drawing.Point(283, 170);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(87, 27);
            this.btCancle.TabIndex = 8;
            this.btCancle.Text = "Cancel";
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(110, 170);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(87, 27);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "Confirm";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(39, 119);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "TCode";
            // 
            // iTCode
            // 
            this.iTCode.Location = new System.Drawing.Point(110, 117);
            this.iTCode.Name = "iTCode";
            this.iTCode.Size = new System.Drawing.Size(117, 20);
            this.iTCode.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Description";
            // 
            // _iSpec
            // 
            this._iSpec.Location = new System.Drawing.Point(110, 85);
            this._iSpec.Name = "_iSpec";
            this._iSpec.Size = new System.Drawing.Size(327, 20);
            this._iSpec.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Name";
            // 
            // _iTitle
            // 
            this._iTitle.Location = new System.Drawing.Point(110, 54);
            this._iTitle.Name = "_iTitle";
            this._iTitle.Size = new System.Drawing.Size(152, 20);
            this._iTitle.TabIndex = 1;
            // 
            // _iFullPath
            // 
            this._iFullPath.Dock = System.Windows.Forms.DockStyle.Top;
            this._iFullPath.Location = new System.Drawing.Point(2, 22);
            this._iFullPath.Name = "_iFullPath";
            this._iFullPath.Size = new System.Drawing.Size(0, 14);
            this._iFullPath.TabIndex = 0;
            // 
            // NodeEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 244);
            this.Controls.Add(this.group);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NodeEditer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NodeEditer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NodeEditer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group)).EndInit();
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._iSpec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._iTitle.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl group;
        private DevExpress.XtraEditors.SimpleButton btCancle;
        private DevExpress.XtraEditors.SimpleButton btOK;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iTCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit _iSpec;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit _iTitle;
        private DevExpress.XtraEditors.LabelControl _iFullPath;
    }
}