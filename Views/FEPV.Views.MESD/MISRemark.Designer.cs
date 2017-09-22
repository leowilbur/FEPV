namespace FEPV.Views
{
    partial class MISRemark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MISRemark));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbReason = new System.Windows.Forms.Label();
            this.btNO = new DevExpress.XtraEditors.SimpleButton();
            this.btYes = new DevExpress.XtraEditors.SimpleButton();
            this.txtMsg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 280;
            this.pictureBox1.TabStop = false;
            // 
            // lbReason
            // 
            this.lbReason.AutoSize = true;
            this.lbReason.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbReason.Location = new System.Drawing.Point(54, 55);
            this.lbReason.Name = "lbReason";
            this.lbReason.Size = new System.Drawing.Size(199, 13);
            this.lbReason.TabIndex = 281;
            this.lbReason.Text = "Please enter the reason:";
            // 
            // btNO
            // 
            this.btNO.Location = new System.Drawing.Point(275, 170);
            this.btNO.Name = "btNO";
            this.btNO.Size = new System.Drawing.Size(67, 25);
            this.btNO.TabIndex = 283;
            this.btNO.Text = "Cancel";
            // 
            // btYes
            // 
            this.btYes.Location = new System.Drawing.Point(209, 170);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(60, 25);
            this.btYes.TabIndex = 282;
            this.btYes.Text = "Confirm";
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.Location = new System.Drawing.Point(81, 84);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(261, 80);
            this.txtMsg.TabIndex = 285;
            // 
            // MISRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.btNO);
            this.Controls.Add(this.btYes);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbReason);
            this.MinimumSize = new System.Drawing.Size(400, 180);
            this.Name = "MISRemark";
            this.Text = "SelectDialog";
            this.Controls.SetChildIndex(this.lbReason, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.txtMsg, 0);
            this.Controls.SetChildIndex(this.btYes, 0);
            this.Controls.SetChildIndex(this.btNO, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbReason;
        private DevExpress.XtraEditors.SimpleButton btNO;
        private DevExpress.XtraEditors.SimpleButton btYes;
        private System.Windows.Forms.TextBox txtMsg;
    }
}