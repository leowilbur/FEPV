namespace FEPY.Views.Demo
{
    partial class EGATETest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EGATETest));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTruck = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGuest = new System.Windows.Forms.TableLayoutPanel();
            this.barTruck = new System.Windows.Forms.ToolStrip();
            this.deckWorkspaceTruck = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.tabPageGuest = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.barGuest = new System.Windows.Forms.ToolStrip();
            this.deckWorkspaceGuest = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.tabPageGoods = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.barGoods = new System.Windows.Forms.ToolStrip();
            this.deckWorkspaceGoods = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.btnSearchTruck = new System.Windows.Forms.ToolStripButton();
            this.btExcelTruck = new System.Windows.Forms.ToolStripButton();
            this.btnSearchGuest = new System.Windows.Forms.ToolStripButton();
            this.btExcelGuest = new System.Windows.Forms.ToolStripButton();
            this.btnDetailsGuest = new System.Windows.Forms.ToolStripButton();
            this.btnRepGuest = new System.Windows.Forms.ToolStripButton();
            this.btnSearchGoods = new System.Windows.Forms.ToolStripButton();
            this.btExcelGoods = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPageTruck.SuspendLayout();
            this.tableLayoutPanelGuest.SuspendLayout();
            this.barTruck.SuspendLayout();
            this.tabPageGuest.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.barGuest.SuspendLayout();
            this.tabPageGoods.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.barGoods.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTruck);
            this.tabControl1.Controls.Add(this.tabPageGuest);
            this.tabControl1.Controls.Add(this.tabPageGoods);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 487);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPageTruck
            // 
            this.tabPageTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tabPageTruck.Controls.Add(this.tableLayoutPanelGuest);
            this.tabPageTruck.Location = new System.Drawing.Point(4, 22);
            this.tabPageTruck.Name = "tabPageTruck";
            this.tabPageTruck.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTruck.Size = new System.Drawing.Size(742, 461);
            this.tabPageTruck.TabIndex = 1;
            this.tabPageTruck.Text = "[车辆计划查询]";
            this.tabPageTruck.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGuest
            // 
            this.tableLayoutPanelGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tableLayoutPanelGuest.ColumnCount = 1;
            this.tableLayoutPanelGuest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGuest.Controls.Add(this.barTruck, 0, 0);
            this.tableLayoutPanelGuest.Controls.Add(this.deckWorkspaceTruck, 0, 1);
            this.tableLayoutPanelGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGuest.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGuest.Name = "tableLayoutPanelGuest";
            this.tableLayoutPanelGuest.RowCount = 2;
            this.tableLayoutPanelGuest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelGuest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGuest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGuest.Size = new System.Drawing.Size(736, 455);
            this.tableLayoutPanelGuest.TabIndex = 20;
            // 
            // barTruck
            // 
            this.barTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barTruck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchTruck,
            this.btExcelTruck});
            this.barTruck.Location = new System.Drawing.Point(0, 0);
            this.barTruck.Name = "barTruck";
            this.barTruck.Size = new System.Drawing.Size(736, 28);
            this.barTruck.TabIndex = 22;
            this.barTruck.Text = "toolStrip2";
            // 
            // deckWorkspaceTruck
            // 
            this.deckWorkspaceTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceTruck.Location = new System.Drawing.Point(3, 31);
            this.deckWorkspaceTruck.Name = "deckWorkspaceTruck";
            this.deckWorkspaceTruck.Size = new System.Drawing.Size(730, 421);
            this.deckWorkspaceTruck.TabIndex = 192;
            this.deckWorkspaceTruck.Text = "deckWorkspace1";
            // 
            // tabPageGuest
            // 
            this.tabPageGuest.Controls.Add(this.tableLayoutPanel2);
            this.tabPageGuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageGuest.Name = "tabPageGuest";
            this.tabPageGuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGuest.Size = new System.Drawing.Size(742, 461);
            this.tabPageGuest.TabIndex = 2;
            this.tabPageGuest.Text = "[访客计划查询]";
            this.tabPageGuest.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.barGuest, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.deckWorkspaceGuest, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(736, 455);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // barGuest
            // 
            this.barGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barGuest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchGuest,
            this.btExcelGuest,
            this.btnDetailsGuest,
            this.btnRepGuest});
            this.barGuest.Location = new System.Drawing.Point(0, 0);
            this.barGuest.Name = "barGuest";
            this.barGuest.Size = new System.Drawing.Size(736, 28);
            this.barGuest.TabIndex = 23;
            this.barGuest.Text = "toolStrip3";
            // 
            // deckWorkspaceGuest
            // 
            this.deckWorkspaceGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceGuest.Location = new System.Drawing.Point(3, 31);
            this.deckWorkspaceGuest.Name = "deckWorkspaceGuest";
            this.deckWorkspaceGuest.Size = new System.Drawing.Size(730, 421);
            this.deckWorkspaceGuest.TabIndex = 192;
            this.deckWorkspaceGuest.Text = "deckWorkspace1";
            // 
            // tabPageGoods
            // 
            this.tabPageGoods.Controls.Add(this.tableLayoutPanel3);
            this.tabPageGoods.Location = new System.Drawing.Point(4, 22);
            this.tabPageGoods.Name = "tabPageGoods";
            this.tabPageGoods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGoods.Size = new System.Drawing.Size(742, 461);
            this.tabPageGoods.TabIndex = 3;
            this.tabPageGoods.Text = "[物品计划查询]";
            this.tabPageGoods.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.barGoods, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.deckWorkspaceGoods, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(736, 455);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // barGoods
            // 
            this.barGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barGoods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchGoods,
            this.btExcelGoods});
            this.barGoods.Location = new System.Drawing.Point(0, 0);
            this.barGoods.Name = "barGoods";
            this.barGoods.Size = new System.Drawing.Size(736, 28);
            this.barGoods.TabIndex = 24;
            this.barGoods.Text = "toolStrip4";
            // 
            // deckWorkspaceGoods
            // 
            this.deckWorkspaceGoods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceGoods.Location = new System.Drawing.Point(3, 31);
            this.deckWorkspaceGoods.Name = "deckWorkspaceGoods";
            this.deckWorkspaceGoods.Size = new System.Drawing.Size(730, 421);
            this.deckWorkspaceGoods.TabIndex = 192;
            this.deckWorkspaceGoods.Text = "deckWorkspace1";
            // 
            // btnSearchTruck
            // 
            this.btnSearchTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchTruck.Image")));
            this.btnSearchTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchTruck.Name = "btnSearchTruck";
            this.btnSearchTruck.Size = new System.Drawing.Size(60, 25);
            this.btnSearchTruck.Text = "查  询";
            // 
            // btExcelTruck
            // 
            this.btExcelTruck.Image = ((System.Drawing.Image)(resources.GetObject("btExcelTruck.Image")));
            this.btExcelTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcelTruck.Name = "btExcelTruck";
            this.btExcelTruck.Size = new System.Drawing.Size(64, 25);
            this.btExcelTruck.Text = "EXCEL";
            // 
            // btnSearchGuest
            // 
            this.btnSearchGuest.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchGuest.Image")));
            this.btnSearchGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchGuest.Name = "btnSearchGuest";
            this.btnSearchGuest.Size = new System.Drawing.Size(60, 25);
            this.btnSearchGuest.Text = "查  询";
            // 
            // btExcelGuest
            // 
            this.btExcelGuest.Image = ((System.Drawing.Image)(resources.GetObject("btExcelGuest.Image")));
            this.btExcelGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcelGuest.Name = "btExcelGuest";
            this.btExcelGuest.Size = new System.Drawing.Size(64, 25);
            this.btExcelGuest.Text = "EXCEL";
            // 
            // btnDetailsGuest
            // 
            this.btnDetailsGuest.Image = ((System.Drawing.Image)(resources.GetObject("btnDetailsGuest.Image")));
            this.btnDetailsGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDetailsGuest.Name = "btnDetailsGuest";
            this.btnDetailsGuest.Size = new System.Drawing.Size(76, 25);
            this.btnDetailsGuest.Text = "人员明细";
            // 
            // btnRepGuest
            // 
            this.btnRepGuest.Image = ((System.Drawing.Image)(resources.GetObject("btnRepGuest.Image")));
            this.btnRepGuest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRepGuest.Name = "btnRepGuest";
            this.btnRepGuest.Size = new System.Drawing.Size(76, 25);
            this.btnRepGuest.Text = "打印预览";
            // 
            // btnSearchGoods
            // 
            this.btnSearchGoods.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchGoods.Image")));
            this.btnSearchGoods.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchGoods.Name = "btnSearchGoods";
            this.btnSearchGoods.Size = new System.Drawing.Size(60, 25);
            this.btnSearchGoods.Text = "查  询";
            // 
            // btExcelGoods
            // 
            this.btExcelGoods.Image = ((System.Drawing.Image)(resources.GetObject("btExcelGoods.Image")));
            this.btExcelGoods.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExcelGoods.Name = "btExcelGoods";
            this.btExcelGoods.Size = new System.Drawing.Size(64, 25);
            this.btExcelGoods.Text = "EXCEL";
            // 
            // EGATETest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 487);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "EGATETest";
            this.Text = "EGATETest";
            this.Load += new System.EventHandler(this.EGATETest_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTruck.ResumeLayout(false);
            this.tableLayoutPanelGuest.ResumeLayout(false);
            this.tableLayoutPanelGuest.PerformLayout();
            this.barTruck.ResumeLayout(false);
            this.barTruck.PerformLayout();
            this.tabPageGuest.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.barGuest.ResumeLayout(false);
            this.barGuest.PerformLayout();
            this.tabPageGoods.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.barGoods.ResumeLayout(false);
            this.barGoods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTruck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGuest;
        private System.Windows.Forms.ToolStrip barTruck;
        private System.Windows.Forms.ToolStripButton btnSearchTruck;
        private System.Windows.Forms.ToolStripButton btExcelTruck;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceTruck;
        private System.Windows.Forms.TabPage tabPageGuest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip barGuest;
        private System.Windows.Forms.ToolStripButton btnSearchGuest;
        private System.Windows.Forms.ToolStripButton btExcelGuest;
        private System.Windows.Forms.ToolStripButton btnDetailsGuest;
        private System.Windows.Forms.ToolStripButton btnRepGuest;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceGuest;
        private System.Windows.Forms.TabPage tabPageGoods;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStrip barGoods;
        private System.Windows.Forms.ToolStripButton btnSearchGoods;
        private System.Windows.Forms.ToolStripButton btExcelGoods;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceGoods;
    }
}