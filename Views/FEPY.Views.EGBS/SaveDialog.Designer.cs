namespace FEPV.Views
{
    partial class SaveDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveDialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbMac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbFilePath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btImgUpdate = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 240;
            this.pictureBox1.TabStop = false;
            // 
            // tbMac
            // 
            this.tbMac.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbMac.Border.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.tbMac.Border.Class = "RibbonGalleryContainer";
            this.tbMac.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.tbMac.Border.PaddingTop = 2;
            this.tbMac.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbMac.Location = new System.Drawing.Point(193, 66);
            this.tbMac.Name = "tbMac";
            this.tbMac.Size = new System.Drawing.Size(191, 23);
            this.tbMac.TabIndex = 241;
            this.tbMac.WatermarkColor = System.Drawing.Color.Silver;
            this.tbMac.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbMac.WatermarkText = "请刷射频卡... ...";
            this.tbMac.WordWrap = false;
            // 
            // tbFilePath
            // 
            this.tbFilePath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbFilePath.Border.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.tbFilePath.Border.Class = "RibbonGalleryContainer";
            this.tbFilePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.tbFilePath.Border.PaddingTop = 2;
            this.tbFilePath.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbFilePath.Location = new System.Drawing.Point(193, 127);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(191, 23);
            this.tbFilePath.TabIndex = 247;
            this.tbFilePath.WatermarkColor = System.Drawing.Color.Silver;
            this.tbFilePath.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbFilePath.WatermarkText = "点击浏览本地图片...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(193, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 248;
            this.label5.Text = "射频卡号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(193, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 249;
            this.label1.Text = "相片路径";
            // 
            // btImgUpdate
            // 
            this.btImgUpdate.ForeColor = System.Drawing.Color.Red;
            this.btImgUpdate.Location = new System.Drawing.Point(197, 211);
            this.btImgUpdate.Name = "btImgUpdate";
            this.btImgUpdate.Size = new System.Drawing.Size(75, 23);
            this.btImgUpdate.TabIndex = 258;
            this.btImgUpdate.Text = "保  存";
            this.btImgUpdate.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.ForeColor = System.Drawing.Color.Blue;
            this.btCancel.Location = new System.Drawing.Point(307, 211);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 259;
            this.btCancel.Text = "取  消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // SaveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btImgUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.tbMac);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SaveDialog";
            this.Text = "SaveDialog";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tbMac, 0);
            this.Controls.SetChildIndex(this.tbFilePath, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btImgUpdate, 0);
            this.Controls.SetChildIndex(this.btCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMac;
        private DevComponents.DotNetBar.Controls.TextBoxX tbFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btImgUpdate;
        private System.Windows.Forms.Button btCancel;
    }
}