namespace FEPV.Views
{
    partial class AUDI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AUDI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.txtMsg = new System.Windows.Forms.Label();
            this.WorkSpace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btReturn = new DevComponents.DotNetBar.ButtonItem();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btQueryUnsettled = new DevComponents.DotNetBar.ButtonItem();
            this.btQPass = new DevComponents.DotNetBar.ButtonItem();
            this.btUntread = new DevComponents.DotNetBar.ButtonItem();
            this.timerQuery = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pBar);
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 11);
            this.panel1.TabIndex = 0;
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(493, 0);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(126, 11);
            this.pBar.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.AutoSize = true;
            this.txtMsg.Font = new System.Drawing.Font("SimSun", 9F);
            this.txtMsg.Location = new System.Drawing.Point(7, 0);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(0, 12);
            this.txtMsg.TabIndex = 0;
            // 
            // WorkSpace
            // 
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.Location = new System.Drawing.Point(6, 3);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.Size = new System.Drawing.Size(663, 425);
            this.WorkSpace.TabIndex = 1;
            this.WorkSpace.Text = "deckWorkspace1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.WorkSpace, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 448);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btReturn
            // 
            this.btReturn.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btReturn.Image = ((System.Drawing.Image)(resources.GetObject("btReturn.Image")));
            this.btReturn.ImagePaddingHorizontal = 8;
            this.btReturn.Name = "btReturn";
            this.btReturn.Text = "Return";
            // 
            // bar2
            // 
            this.bar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btQueryUnsettled,
            this.btQPass,
            this.btUntread,
            this.btReturn});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(679, 25);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar2.TabIndex = 3;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btQueryUnsettled
            // 
            this.btQueryUnsettled.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btQueryUnsettled.Image = ((System.Drawing.Image)(resources.GetObject("btQueryUnsettled.Image")));
            this.btQueryUnsettled.ImagePaddingHorizontal = 8;
            this.btQueryUnsettled.Name = "btQueryUnsettled";
            this.btQueryUnsettled.Text = "Search";
            // 
            // btQPass
            // 
            this.btQPass.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btQPass.Image = ((System.Drawing.Image)(resources.GetObject("btQPass.Image")));
            this.btQPass.ImagePaddingHorizontal = 8;
            this.btQPass.Name = "btQPass";
            this.btQPass.Text = "QPass";
            // 
            // btUntread
            // 
            this.btUntread.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btUntread.Image = ((System.Drawing.Image)(resources.GetObject("btUntread.Image")));
            this.btUntread.ImagePaddingHorizontal = 8;
            this.btUntread.Name = "btUntread";
            this.btUntread.Text = "UnTreat";
            // 
            // timerQuery
            // 
            this.timerQuery.Interval = 500;
            // 
            // AUDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bar2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AUDI";
            this.Text = "AUDI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label txtMsg;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace WorkSpace;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonItem btReturn;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btQueryUnsettled;
        private DevComponents.DotNetBar.ButtonItem btQPass;
        private DevComponents.DotNetBar.ButtonItem btUntread;
        private System.Windows.Forms.Timer timerQuery;
    }
}