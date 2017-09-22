namespace FEPV.Views
{
    partial class EGUL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EGUL));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTruck = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.deckWorkspaceTruck = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.tabPageGuest = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.deckWorkspaceGuest = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.tabPageContractor = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.deckWorkspaceContractor = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.panel1 = new System.Windows.Forms.Panel();
            this._txtMsg = new System.Windows.Forms.Label();
            this.barTruck = new System.Windows.Forms.ToolStrip();
            this.btnSearchTruck = new System.Windows.Forms.ToolStripButton();
            this.btExcelTruck = new System.Windows.Forms.ToolStripButton();
            this.btnUnlockTruck = new System.Windows.Forms.ToolStripButton();
            this.barGuest = new System.Windows.Forms.ToolStrip();
            this.btnSearchGuest = new System.Windows.Forms.ToolStripButton();
            this.btExcelGuest = new System.Windows.Forms.ToolStripButton();
            this.btnUnlockGuest = new System.Windows.Forms.ToolStripButton();
            this.barContractor = new System.Windows.Forms.ToolStrip();
            this.btnSearchContractor = new System.Windows.Forms.ToolStripButton();
            this.btExcelContractor = new System.Windows.Forms.ToolStripButton();
            this.btnUnlockContractor = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPageTruck.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageGuest.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPageContractor.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.barTruck.SuspendLayout();
            this.barGuest.SuspendLayout();
            this.barContractor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageTruck);
            this.tabControl1.Controls.Add(this.tabPageGuest);
            this.tabControl1.Controls.Add(this.tabPageContractor);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTruck
            // 
            this.tabPageTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tabPageTruck.Controls.Add(this.tableLayoutPanel1);
            this.tabPageTruck.Location = new System.Drawing.Point(4, 22);
            this.tabPageTruck.Name = "tabPageTruck";
            this.tabPageTruck.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTruck.Size = new System.Drawing.Size(812, 401);
            this.tabPageTruck.TabIndex = 0;
            this.tabPageTruck.Text = "[车辆解锁界面]";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.barTruck, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.deckWorkspaceTruck, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 395);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // deckWorkspaceTruck
            // 
            this.deckWorkspaceTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceTruck.Location = new System.Drawing.Point(3, 29);
            this.deckWorkspaceTruck.Name = "deckWorkspaceTruck";
            this.deckWorkspaceTruck.Size = new System.Drawing.Size(800, 363);
            this.deckWorkspaceTruck.TabIndex = 193;
            this.deckWorkspaceTruck.Text = "deckWorkspace1";
            // 
            // tabPageGuest
            // 
            this.tabPageGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tabPageGuest.Controls.Add(this.tableLayoutPanel2);
            this.tabPageGuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageGuest.Name = "tabPageGuest";
            this.tabPageGuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGuest.Size = new System.Drawing.Size(812, 401);
            this.tabPageGuest.TabIndex = 1;
            this.tabPageGuest.Text = "[访客解锁界面]";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.barGuest, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.deckWorkspaceGuest, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(806, 395);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // deckWorkspaceGuest
            // 
            this.deckWorkspaceGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceGuest.Location = new System.Drawing.Point(3, 29);
            this.deckWorkspaceGuest.Name = "deckWorkspaceGuest";
            this.deckWorkspaceGuest.Size = new System.Drawing.Size(800, 363);
            this.deckWorkspaceGuest.TabIndex = 193;
            this.deckWorkspaceGuest.Text = "deckWorkspace1";
            // 
            // tabPageContractor
            // 
            this.tabPageContractor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tabPageContractor.Controls.Add(this.tableLayoutPanel3);
            this.tabPageContractor.Location = new System.Drawing.Point(4, 22);
            this.tabPageContractor.Name = "tabPageContractor";
            this.tabPageContractor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContractor.Size = new System.Drawing.Size(812, 401);
            this.tabPageContractor.TabIndex = 2;
            this.tabPageContractor.Text = "[包商解锁界面]";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.barContractor, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.deckWorkspaceContractor, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(806, 395);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // deckWorkspaceContractor
            // 
            this.deckWorkspaceContractor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceContractor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceContractor.Location = new System.Drawing.Point(3, 29);
            this.deckWorkspaceContractor.Name = "deckWorkspaceContractor";
            this.deckWorkspaceContractor.Size = new System.Drawing.Size(800, 363);
            this.deckWorkspaceContractor.TabIndex = 193;
            this.deckWorkspaceContractor.Text = "deckWorkspace1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._txtMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 19);
            this.panel1.TabIndex = 23;
            // 
            // _txtMsg
            // 
            this._txtMsg.AutoSize = true;
            this._txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtMsg.Location = new System.Drawing.Point(0, 0);
            this._txtMsg.Name = "_txtMsg";
            this._txtMsg.Size = new System.Drawing.Size(23, 12);
            this._txtMsg.TabIndex = 0;
            this._txtMsg.Text = "*_*";
            // 
            // barTruck
            // 
            this.barTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barTruck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchTruck,
            this.btExcelTruck,
            this.btnUnlockTruck});
            this.barTruck.Location = new System.Drawing.Point(0, 0);
            this.barTruck.Name = "barTruck";
            this.barTruck.Size = new System.Drawing.Size(806, 26);
            this.barTruck.TabIndex = 22;
            this.barTruck.Text = "toolStrip2";
            // 
            // btnSearchTruck
            // 
            this.btnSearchTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchTruck.Image")));
            this.btnSearchTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchTruck.Name = "btnSearchTruck";
            this.btnSearchTruck.Size = new System.Drawing.Size(52, 23);
            this.btnSearchTruck.Text = "查询";
            // 
            // btExcelTruck
            // 
            this.btExcelTruck.Image = ((System.Drawing.Image)(resources.GetObject("btExcelTruck.Image")));
            this.btExcelTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcelTruck.Name = "btExcelTruck";
            this.btExcelTruck.Size = new System.Drawing.Size(57, 23);
            this.btExcelTruck.Text = "Excel";
            // 
            // btnUnlockTruck
            // 
            this.btnUnlockTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlockTruck.Image")));
            this.btnUnlockTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnlockTruck.Name = "btnUnlockTruck";
            this.btnUnlockTruck.Size = new System.Drawing.Size(76, 23);
            this.btnUnlockTruck.Text = "车辆解锁";
            // 
            // barGuest
            // 
            this.barGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barGuest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchGuest,
            this.btExcelGuest,
            this.btnUnlockGuest});
            this.barGuest.Location = new System.Drawing.Point(0, 0);
            this.barGuest.Name = "barGuest";
            this.barGuest.Size = new System.Drawing.Size(806, 26);
            this.barGuest.TabIndex = 24;
            this.barGuest.Text = "toolStrip4";
            // 
            // btnSearchGuest
            // 
            this.btnSearchGuest.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchGuest.Image")));
            this.btnSearchGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchGuest.Name = "btnSearchGuest";
            this.btnSearchGuest.Size = new System.Drawing.Size(52, 23);
            this.btnSearchGuest.Text = "查询";
            // 
            // btExcelGuest
            // 
            this.btExcelGuest.Image = ((System.Drawing.Image)(resources.GetObject("btExcelGuest.Image")));
            this.btExcelGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcelGuest.Name = "btExcelGuest";
            this.btExcelGuest.Size = new System.Drawing.Size(57, 23);
            this.btExcelGuest.Text = "Excel";
            // 
            // btnUnlockGuest
            // 
            this.btnUnlockGuest.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlockGuest.Image")));
            this.btnUnlockGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnlockGuest.Name = "btnUnlockGuest";
            this.btnUnlockGuest.Size = new System.Drawing.Size(76, 23);
            this.btnUnlockGuest.Text = "访客解锁";
            // 
            // barContractor
            // 
            this.barContractor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barContractor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchContractor,
            this.btExcelContractor,
            this.btnUnlockContractor});
            this.barContractor.Location = new System.Drawing.Point(0, 0);
            this.barContractor.Name = "barContractor";
            this.barContractor.Size = new System.Drawing.Size(806, 26);
            this.barContractor.TabIndex = 23;
            this.barContractor.Text = "toolStrip3";
            // 
            // btnSearchContractor
            // 
            this.btnSearchContractor.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchContractor.Image")));
            this.btnSearchContractor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchContractor.Name = "btnSearchContractor";
            this.btnSearchContractor.Size = new System.Drawing.Size(52, 23);
            this.btnSearchContractor.Text = "查询";
            // 
            // btExcelContractor
            // 
            this.btExcelContractor.Image = ((System.Drawing.Image)(resources.GetObject("btExcelContractor.Image")));
            this.btExcelContractor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcelContractor.Name = "btExcelContractor";
            this.btExcelContractor.Size = new System.Drawing.Size(57, 23);
            this.btExcelContractor.Text = "Excel";
            // 
            // btnUnlockContractor
            // 
            this.btnUnlockContractor.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlockContractor.Image")));
            this.btnUnlockContractor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnlockContractor.Name = "btnUnlockContractor";
            this.btnUnlockContractor.Size = new System.Drawing.Size(76, 23);
            this.btnUnlockContractor.Text = "包商解锁";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MainForm";
            this.TabText = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPageTruck.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageGuest.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPageContractor.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.barTruck.ResumeLayout(false);
            this.barTruck.PerformLayout();
            this.barGuest.ResumeLayout(false);
            this.barGuest.PerformLayout();
            this.barContractor.ResumeLayout(false);
            this.barContractor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTruck;
        private System.Windows.Forms.TabPage tabPageGuest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _txtMsg;
        private System.Windows.Forms.TabPage tabPageContractor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceTruck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceGuest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceContractor;
        private System.Windows.Forms.ToolStrip barTruck;
        private System.Windows.Forms.ToolStripButton btnSearchTruck;
        private System.Windows.Forms.ToolStripButton btExcelTruck;
        private System.Windows.Forms.ToolStripButton btnUnlockTruck;
        private System.Windows.Forms.ToolStrip barGuest;
        private System.Windows.Forms.ToolStripButton btnSearchGuest;
        private System.Windows.Forms.ToolStripButton btExcelGuest;
        private System.Windows.Forms.ToolStripButton btnUnlockGuest;
        private System.Windows.Forms.ToolStrip barContractor;
        private System.Windows.Forms.ToolStripButton btnSearchContractor;
        private System.Windows.Forms.ToolStripButton btExcelContractor;
        private System.Windows.Forms.ToolStripButton btnUnlockContractor;

    }
}