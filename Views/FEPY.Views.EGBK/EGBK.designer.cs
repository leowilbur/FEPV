namespace FEPV.Views
{
    partial class EGBK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EGBK));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGuest = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGuest = new System.Windows.Forms.TableLayoutPanel();
            this.barTruck = new System.Windows.Forms.ToolStrip();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnWeight1Back = new System.Windows.Forms.ToolStripButton();
            this.btnWeight2Back = new System.Windows.Forms.ToolStripButton();
            this.btnPrintBack = new System.Windows.Forms.ToolStripButton();
            this.deckWorkspaceTruck = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.panel1 = new System.Windows.Forms.Panel();
            this._txtMsg = new System.Windows.Forms.Label();
            this.btnAlterTkno = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPageGuest.SuspendLayout();
            this.tableLayoutPanelGuest.SuspendLayout();
            this.barTruck.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageGuest);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 463);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPageGuest
            // 
            this.tabPageGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tabPageGuest.Controls.Add(this.tableLayoutPanelGuest);
            this.tabPageGuest.Location = new System.Drawing.Point(4, 22);
            this.tabPageGuest.Name = "tabPageGuest";
            this.tabPageGuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGuest.Size = new System.Drawing.Size(742, 437);
            this.tabPageGuest.TabIndex = 1;
            this.tabPageGuest.Text = "[车辆计划冲销]";
            this.tabPageGuest.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanelGuest.Size = new System.Drawing.Size(736, 431);
            this.tableLayoutPanelGuest.TabIndex = 20;
            // 
            // barTruck
            // 
            this.barTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barTruck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.btnWeight1Back,
            this.btnWeight2Back,
            this.btnPrintBack,
            this.btnAlterTkno});
            this.barTruck.Location = new System.Drawing.Point(0, 0);
            this.barTruck.Name = "barTruck";
            this.barTruck.Size = new System.Drawing.Size(736, 28);
            this.barTruck.TabIndex = 193;
            this.barTruck.Text = "toolStrip1";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 25);
            this.btnSearch.Text = "查询";
            // 
            // btnWeight1Back
            // 
            this.btnWeight1Back.Image = ((System.Drawing.Image)(resources.GetObject("btnWeight1Back.Image")));
            this.btnWeight1Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeight1Back.Name = "btnWeight1Back";
            this.btnWeight1Back.Size = new System.Drawing.Size(76, 25);
            this.btnWeight1Back.Text = "一磅冲销";
            // 
            // btnWeight2Back
            // 
            this.btnWeight2Back.Image = ((System.Drawing.Image)(resources.GetObject("btnWeight2Back.Image")));
            this.btnWeight2Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeight2Back.Name = "btnWeight2Back";
            this.btnWeight2Back.Size = new System.Drawing.Size(76, 25);
            this.btnWeight2Back.Text = "二磅冲销";
            // 
            // btnPrintBack
            // 
            this.btnPrintBack.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintBack.Image")));
            this.btnPrintBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintBack.Name = "btnPrintBack";
            this.btnPrintBack.Size = new System.Drawing.Size(100, 25);
            this.btnPrintBack.Text = "打印磅单冲销";
            // 
            // deckWorkspaceTruck
            // 
            this.deckWorkspaceTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceTruck.Location = new System.Drawing.Point(3, 31);
            this.deckWorkspaceTruck.Name = "deckWorkspaceTruck";
            this.deckWorkspaceTruck.Size = new System.Drawing.Size(730, 397);
            this.deckWorkspaceTruck.TabIndex = 192;
            this.deckWorkspaceTruck.Text = "deckWorkspace1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._txtMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 21);
            this.panel1.TabIndex = 22;
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
            // btnAlterTkno
            // 
            this.btnAlterTkno.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterTkno.Image")));
            this.btnAlterTkno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterTkno.Name = "btnAlterTkno";
            this.btnAlterTkno.Size = new System.Drawing.Size(76, 25);
            this.btnAlterTkno.Text = "修改车号";
            // 
            // EGBK
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(750, 487);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "EGBK";
            this.TabText = "EGATE";
            this.Text = "EGATE";
            this.tabControl1.ResumeLayout(false);
            this.tabPageGuest.ResumeLayout(false);
            this.tableLayoutPanelGuest.ResumeLayout(false);
            this.tableLayoutPanelGuest.PerformLayout();
            this.barTruck.ResumeLayout(false);
            this.barTruck.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonItem buttonItem10;
        private DevComponents.DotNetBar.ButtonItem buttonItem11;
        private DevComponents.DotNetBar.ButtonItem buttonItem12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGuest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGuest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _txtMsg;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceTruck;
        private System.Windows.Forms.ToolStrip barTruck;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnWeight1Back;
        private System.Windows.Forms.ToolStripButton btnWeight2Back;
        private System.Windows.Forms.ToolStripButton btnPrintBack;
        private System.Windows.Forms.ToolStripButton btnAlterTkno;
    }
}