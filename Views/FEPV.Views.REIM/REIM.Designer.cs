namespace FEPV.Views
{
    partial class REIM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REIM));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WorkSpace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.Bar1 = new DevComponents.DotNetBar.Bar();
            this.btSearch = new DevComponents.DotNetBar.ButtonItem();
            this.btMaster = new DevComponents.DotNetBar.ButtonItem();
            this.BtExcel = new DevComponents.DotNetBar.ButtonItem();
            this.btPrev = new DevComponents.DotNetBar.ButtonItem();
            this.txtMsg = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 663F));
            this.tableLayoutPanel1.Controls.Add(this.WorkSpace, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Bar1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMsg, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 381);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // WorkSpace
            // 
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.Location = new System.Drawing.Point(3, 33);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.Size = new System.Drawing.Size(684, 325);
            this.WorkSpace.TabIndex = 9;
            this.WorkSpace.Text = "deckWorkspace1";
            // 
            // Bar1
            // 
            this.Bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.Bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.Bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btSearch,
            this.btMaster,
            this.BtExcel,
            this.btPrev});
            this.Bar1.Location = new System.Drawing.Point(3, 3);
            this.Bar1.Name = "Bar1";
            this.Bar1.Size = new System.Drawing.Size(684, 24);
            this.Bar1.Stretch = true;
            this.Bar1.TabIndex = 8;
            this.Bar1.TabStop = false;
            this.Bar1.Text = "更多";
            // 
            // btSearch
            // 
            this.btSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btSearch.Image = ((System.Drawing.Image)(resources.GetObject("btSearch.Image")));
            this.btSearch.ImagePaddingHorizontal = 8;
            this.btSearch.Name = "btSearch";
            this.btSearch.Text = "Search";
            // 
            // btMaster
            // 
            this.btMaster.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btMaster.Image = ((System.Drawing.Image)(resources.GetObject("btMaster.Image")));
            this.btMaster.ImagePaddingHorizontal = 8;
            this.btMaster.Name = "btMaster";
            this.btMaster.Text = "Report";
            // 
            // BtExcel
            // 
            this.BtExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.BtExcel.Image = ((System.Drawing.Image)(resources.GetObject("BtExcel.Image")));
            this.BtExcel.ImagePaddingHorizontal = 8;
            this.BtExcel.Name = "BtExcel";
            this.BtExcel.Text = "EXCEL";
            // 
            // btPrev
            // 
            this.btPrev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btPrev.Image = ((System.Drawing.Image)(resources.GetObject("btPrev.Image")));
            this.btPrev.ImagePaddingHorizontal = 8;
            this.btPrev.Name = "btPrev";
            this.btPrev.Text = "Return";
            // 
            // txtMsg
            // 
            this.txtMsg.AutoSize = true;
            this.txtMsg.Location = new System.Drawing.Point(3, 361);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(16, 13);
            this.txtMsg.TabIndex = 10;
            this.txtMsg.Text = ":3";
            // 
            // REIM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 381);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "REIM";
            this.Text = "REIM";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace WorkSpace;
        private DevComponents.DotNetBar.Bar Bar1;
        private DevComponents.DotNetBar.ButtonItem btSearch;
        private DevComponents.DotNetBar.ButtonItem btMaster;
        public DevComponents.DotNetBar.ButtonItem BtExcel;
        private DevComponents.DotNetBar.ButtonItem btPrev;
        private System.Windows.Forms.Label txtMsg;

    }
}