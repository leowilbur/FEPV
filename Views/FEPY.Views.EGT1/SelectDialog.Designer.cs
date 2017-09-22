namespace FEPV.Views
{
    partial class SelectDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDialog));
            this.label2 = new System.Windows.Forms.Label();
            this.UnloadingPoint = new System.Windows.Forms.ComboBox();
            this.btNO = new DevExpress.XtraEditors.SimpleButton();
            this.btYes = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(50, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 283;
            this.label2.Text = "卸货点:";
            // 
            // UnloadingPoint
            // 
            this.UnloadingPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.UnloadingPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnloadingPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UnloadingPoint.Font = new System.Drawing.Font("Tahoma", 8F);
            this.UnloadingPoint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.UnloadingPoint.FormattingEnabled = true;
            this.UnloadingPoint.Items.AddRange(new object[] {
            "申请进厂",
            "申请出厂"});
            this.UnloadingPoint.Location = new System.Drawing.Point(149, 90);
            this.UnloadingPoint.Name = "UnloadingPoint";
            this.UnloadingPoint.Size = new System.Drawing.Size(140, 21);
            this.UnloadingPoint.TabIndex = 282;
            this.UnloadingPoint.Tag = "";
            // 
            // btNO
            // 
            this.btNO.Location = new System.Drawing.Point(237, 154);
            this.btNO.Name = "btNO";
            this.btNO.Size = new System.Drawing.Size(52, 23);
            this.btNO.TabIndex = 279;
            this.btNO.Text = "取消";
            this.btNO.Click += new System.EventHandler(this.btNO_Click);
            // 
            // btYes
            // 
            this.btYes.Location = new System.Drawing.Point(149, 154);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(52, 23);
            this.btYes.TabIndex = 278;
            this.btYes.Text = "确认";
            this.btYes.Click += new System.EventHandler(this.btYes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 280;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(50, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 281;
            this.label1.Text = "请选择卸货点";
            // 
            // SelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UnloadingPoint);
            this.Controls.Add(this.btNO);
            this.Controls.Add(this.btYes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "SelectDialog";
            this.Text = "SelectDialog";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.btYes, 0);
            this.Controls.SetChildIndex(this.btNO, 0);
            this.Controls.SetChildIndex(this.UnloadingPoint, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox UnloadingPoint;
        private DevExpress.XtraEditors.SimpleButton btNO;
        private DevExpress.XtraEditors.SimpleButton btYes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}