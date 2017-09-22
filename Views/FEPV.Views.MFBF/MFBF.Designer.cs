namespace FEPV.Views
{
    partial class MFBF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFBF));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btQueryUnsettled = new DevComponents.DotNetBar.ButtonItem();
            this.btSearchBatch = new DevComponents.DotNetBar.ButtonItem();
            this.btNewVoucher = new DevComponents.DotNetBar.ButtonItem();
            this.btUnPick = new DevComponents.DotNetBar.ButtonItem();
            this.btDeleteVoucher = new DevComponents.DotNetBar.ButtonItem();
            this.btCommit2Flow = new DevComponents.DotNetBar.ButtonItem();
            this.btPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btReturn = new DevComponents.DotNetBar.ButtonItem();
            this.btComplete = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WorkSpace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this._MSG = new System.Windows.Forms.Label();
            this.trDosomething = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btQueryUnsettled,
            this.btSearchBatch,
            this.btNewVoucher,
            this.btUnPick,
            this.btDeleteVoucher,
            this.btCommit2Flow,
            this.btPrint,
            this.btReturn,
            this.btComplete});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(792, 24);
            this.bar1.Stretch = true;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btQueryUnsettled
            // 
            this.btQueryUnsettled.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btQueryUnsettled.Image = ((System.Drawing.Image)(resources.GetObject("btQueryUnsettled.Image")));
            this.btQueryUnsettled.ImagePaddingHorizontal = 8;
            this.btQueryUnsettled.Name = "btQueryUnsettled";
            this.btQueryUnsettled.Text = "Search";
            // 
            // btSearchBatch
            // 
            this.btSearchBatch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btSearchBatch.ImagePaddingHorizontal = 8;
            this.btSearchBatch.Name = "btSearchBatch";
            this.btSearchBatch.Text = "Batch";
            // 
            // btNewVoucher
            // 
            this.btNewVoucher.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btNewVoucher.Image = ((System.Drawing.Image)(resources.GetObject("btNewVoucher.Image")));
            this.btNewVoucher.ImagePaddingHorizontal = 8;
            this.btNewVoucher.Name = "btNewVoucher";
            this.btNewVoucher.Text = "New";
            // 
            // btUnPick
            // 
            this.btUnPick.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btUnPick.Image = ((System.Drawing.Image)(resources.GetObject("btUnPick.Image")));
            this.btUnPick.ImagePaddingHorizontal = 8;
            this.btUnPick.Name = "btUnPick";
            this.btUnPick.Text = "UnPick";
            // 
            // btDeleteVoucher
            // 
            this.btDeleteVoucher.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btDeleteVoucher.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteVoucher.Image")));
            this.btDeleteVoucher.ImagePaddingHorizontal = 8;
            this.btDeleteVoucher.Name = "btDeleteVoucher";
            this.btDeleteVoucher.Text = "Delete";
            // 
            // btCommit2Flow
            // 
            this.btCommit2Flow.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btCommit2Flow.Image = ((System.Drawing.Image)(resources.GetObject("btCommit2Flow.Image")));
            this.btCommit2Flow.ImagePaddingHorizontal = 8;
            this.btCommit2Flow.Name = "btCommit2Flow";
            this.btCommit2Flow.Text = "Commit2Flow";
            // 
            // btPrint
            // 
            this.btPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btPrint.Image = ((System.Drawing.Image)(resources.GetObject("btPrint.Image")));
            this.btPrint.ImagePaddingHorizontal = 8;
            this.btPrint.Name = "btPrint";
            this.btPrint.Text = "Print";
            // 
            // btReturn
            // 
            this.btReturn.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btReturn.Image = ((System.Drawing.Image)(resources.GetObject("btReturn.Image")));
            this.btReturn.ImagePaddingHorizontal = 8;
            this.btReturn.Name = "btReturn";
            this.btReturn.Text = "Return";
            // 
            // btComplete
            // 
            this.btComplete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btComplete.Image = ((System.Drawing.Image)(resources.GetObject("btComplete.Image")));
            this.btComplete.ImagePaddingHorizontal = 8;
            this.btComplete.Name = "btComplete";
            this.btComplete.Text = "Complete";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.Controls.Add(this.WorkSpace, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._MSG, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 391);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // WorkSpace
            // 
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.Location = new System.Drawing.Point(5, 5);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.Size = new System.Drawing.Size(778, 370);
            this.WorkSpace.TabIndex = 1;
            this.WorkSpace.Text = "deckWorkspace1";
            // 
            // _MSG
            // 
            this._MSG.AutoSize = true;
            this._MSG.Font = new System.Drawing.Font("SimSun", 8.75F);
            this._MSG.Location = new System.Drawing.Point(5, 378);
            this._MSG.Name = "_MSG";
            this._MSG.Size = new System.Drawing.Size(23, 12);
            this._MSG.TabIndex = 2;
            this._MSG.Text = "*_*";
            // 
            // trDosomething
            // 
            this.trDosomething.Interval = 500;
            // 
            // MFBF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 415);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bar1);
            this.Font = new System.Drawing.Font("SimSun", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MFBF";
            this.TabText = "MFBF";
            this.Text = "MFBF";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonItem btQueryUnsettled;
        private DevComponents.DotNetBar.ButtonItem btSearchBatch;
        private DevComponents.DotNetBar.ButtonItem btNewVoucher;
        private DevComponents.DotNetBar.ButtonItem btDeleteVoucher;
        private DevComponents.DotNetBar.ButtonItem btCommit2Flow;
        private DevComponents.DotNetBar.ButtonItem btUnPick;
        private DevComponents.DotNetBar.ButtonItem btPrint;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace WorkSpace;
        private System.Windows.Forms.Label _MSG;
        private DevComponents.DotNetBar.ButtonItem btReturn;
        private DevComponents.DotNetBar.ButtonItem btComplete;
        private System.Windows.Forms.Timer trDosomething;



    }
}