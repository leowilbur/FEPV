namespace FEPV.Views
{
    partial class XD03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XD03));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btSerchBarCode = new DevComponents.DotNetBar.ButtonItem();
            this.btEditBarCode = new DevComponents.DotNetBar.ButtonItem();
            this.btRePrint = new DevComponents.DotNetBar.ButtonItem();
            this.btDeleteBarCode = new DevComponents.DotNetBar.ButtonItem();
            this.btSave = new DevComponents.DotNetBar.ButtonItem();
            this.btMoreGoods = new DevComponents.DotNetBar.ButtonItem();
            this.btReturn = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.msg = new System.Windows.Forms.Label();
            this.WorkSpace = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btSerchBarCode,
            this.btEditBarCode,
            this.btRePrint,
            this.btDeleteBarCode,
            this.btSave,
            this.btMoreGoods,
            this.btReturn});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(789, 24);
            this.bar1.Stretch = true;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btSerchBarCode
            // 
            this.btSerchBarCode.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btSerchBarCode.Image = ((System.Drawing.Image)(resources.GetObject("btSerchBarCode.Image")));
            this.btSerchBarCode.ImagePaddingHorizontal = 8;
            this.btSerchBarCode.Name = "btSerchBarCode";
            this.btSerchBarCode.Text = "Search";
            // 
            // btEditBarCode
            // 
            this.btEditBarCode.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btEditBarCode.Image = ((System.Drawing.Image)(resources.GetObject("btEditBarCode.Image")));
            this.btEditBarCode.ImagePaddingHorizontal = 8;
            this.btEditBarCode.Name = "btEditBarCode";
            this.btEditBarCode.Text = "Edit";
            // 
            // btRePrint
            // 
            this.btRePrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btRePrint.Image = ((System.Drawing.Image)(resources.GetObject("btRePrint.Image")));
            this.btRePrint.ImagePaddingHorizontal = 8;
            this.btRePrint.Name = "btRePrint";
            this.btRePrint.Text = "Print";
            // 
            // btDeleteBarCode
            // 
            this.btDeleteBarCode.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btDeleteBarCode.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteBarCode.Image")));
            this.btDeleteBarCode.ImagePaddingHorizontal = 8;
            this.btDeleteBarCode.Name = "btDeleteBarCode";
            this.btDeleteBarCode.Text = "Delete";
            // 
            // btSave
            // 
            this.btSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImagePaddingHorizontal = 8;
            this.btSave.Name = "btSave";
            this.btSave.Text = "Update";
            // 
            // btMoreGoods
            // 
            this.btMoreGoods.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btMoreGoods.Image = ((System.Drawing.Image)(resources.GetObject("btMoreGoods.Image")));
            this.btMoreGoods.ImagePaddingHorizontal = 8;
            this.btMoreGoods.Name = "btMoreGoods";
            this.btMoreGoods.Text = "More...";
            // 
            // btReturn
            // 
            this.btReturn.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btReturn.Image = ((System.Drawing.Image)(resources.GetObject("btReturn.Image")));
            this.btReturn.ImagePaddingHorizontal = 8;
            this.btReturn.Name = "btReturn";
            this.btReturn.Text = "Return";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.WorkSpace, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(789, 416);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.msg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 12);
            this.panel1.TabIndex = 1;
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Location = new System.Drawing.Point(3, 0);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(0, 13);
            this.msg.TabIndex = 0;
            // 
            // WorkSpace
            // 
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.Location = new System.Drawing.Point(6, 3);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.Size = new System.Drawing.Size(773, 392);
            this.WorkSpace.TabIndex = 0;
            this.WorkSpace.Text = "deckWorkspace1";
            // 
            // XD03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 443);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("SimSun", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XD03";
            this.TabText = "XD03";
            this.Text = "XD03";
            this.Load += new System.EventHandler(this.XD03_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btSerchBarCode;
        private DevComponents.DotNetBar.ButtonItem btEditBarCode;
        private DevComponents.DotNetBar.ButtonItem btRePrint;
        private DevComponents.DotNetBar.ButtonItem btDeleteBarCode;
        private DevComponents.DotNetBar.ButtonItem btSave;
        private DevComponents.DotNetBar.ButtonItem btMoreGoods;
        private DevComponents.DotNetBar.ButtonItem btReturn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label msg;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace WorkSpace;

    }
}