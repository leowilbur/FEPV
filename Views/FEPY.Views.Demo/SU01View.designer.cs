namespace FEPY.Views.Demo
{
    partial class SU01View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SU01View));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.workSpace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMsg = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btRole = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel1.Controls.Add(this.workSpace, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 448);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // workSpace
            // 
            this.workSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workSpace.Font = new System.Drawing.Font("宋体", 9.75F);
            this.workSpace.Location = new System.Drawing.Point(6, 3);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(776, 422);
            this.workSpace.TabIndex = 0;
            this.workSpace.Text = "deckWorkspace1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 14);
            this.panel1.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(7, 0);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(0, 14);
            this.txtMsg.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btRole});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btRole
            // 
            this.btRole.Image = ((System.Drawing.Image)(resources.GetObject("btRole.Image")));
            this.btRole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRole.Name = "btRole";
            this.btRole.Size = new System.Drawing.Size(76, 22);
            this.btRole.Text = "确认修改";
            this.btRole.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // SU01View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9.75F);
            this.Name = "SU01View";
            this.TabText = "SU01View";
            this.Text = "SU01View";
            this.Load += new System.EventHandler(this.SU01View_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace workSpace;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl txtMsg;
        //private DevComponents.DotNetBar.ButtonItem buttonItem1;
        //private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        //private DevComponents.DotNetBar.ButtonItem btModify11;
        private System.Windows.Forms.ToolStripButton btRole;
    }
}