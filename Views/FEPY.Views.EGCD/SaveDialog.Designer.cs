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
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbCardID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbCardType = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.deValidTo = new DevExpress.XtraEditors.DateEdit();
            this.tbCNO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.deValidTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deValidTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.ForeColor = System.Drawing.Color.Red;
            this.btSave.Location = new System.Drawing.Point(221, 229);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 25);
            this.btSave.TabIndex = 258;
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.ForeColor = System.Drawing.Color.Blue;
            this.btCancel.Location = new System.Drawing.Point(307, 229);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 25);
            this.btCancel.TabIndex = 259;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(17, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 290;
            this.label1.Text = "卡片状态";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(21, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 1);
            this.panel2.TabIndex = 289;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(17, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 288;
            this.label2.Text = "卡片类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(17, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 287;
            this.label3.Text = "卡号";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Location = new System.Drawing.Point(21, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 1);
            this.panel5.TabIndex = 286;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(21, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 1);
            this.panel1.TabIndex = 285;
            // 
            // tbCardID
            // 
            this.tbCardID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.tbCardID.Border.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.tbCardID.Border.Class = "RibbonGalleryContainer";
            this.tbCardID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.tbCardID.Border.PaddingTop = 2;
            this.tbCardID.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbCardID.Location = new System.Drawing.Point(236, 41);
            this.tbCardID.Name = "tbCardID";
            this.tbCardID.Size = new System.Drawing.Size(144, 25);
            this.tbCardID.TabIndex = 292;
            this.tbCardID.WatermarkColor = System.Drawing.Color.Silver;
            this.tbCardID.WatermarkFont = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbCardID.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(17, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 295;
            this.label4.Text = "有效期";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Location = new System.Drawing.Point(21, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 1);
            this.panel3.TabIndex = 294;
            // 
            // tbRemark
            // 
            this.tbRemark.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbRemark.Border.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.tbRemark.Border.Class = "RibbonGalleryContainer";
            this.tbRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.tbRemark.Border.PaddingTop = 2;
            this.tbRemark.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbRemark.Location = new System.Drawing.Point(236, 181);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(144, 23);
            this.tbRemark.TabIndex = 299;
            this.tbRemark.WatermarkColor = System.Drawing.Color.Silver;
            this.tbRemark.WatermarkFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRemark.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(17, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 298;
            this.label5.Text = "备注";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Location = new System.Drawing.Point(21, 199);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 1);
            this.panel4.TabIndex = 297;
            // 
            // cbCardType
            // 
            this.cbCardType.BackColor = System.Drawing.Color.White;
            this.cbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCardType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbCardType.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cbCardType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbCardType.FormattingEnabled = true;
            this.cbCardType.Items.AddRange(new object[] {
            "",
            "申请进厂",
            "申请出厂"});
            this.cbCardType.Location = new System.Drawing.Point(237, 100);
            this.cbCardType.Name = "cbCardType";
            this.cbCardType.Size = new System.Drawing.Size(143, 21);
            this.cbCardType.TabIndex = 301;
            this.cbCardType.Tag = "";
            this.cbCardType.SelectedIndexChanged += new System.EventHandler(this.cbCardType_SelectedIndexChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.White;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbStatus.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cbStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "",
            "申请进厂",
            "申请出厂"});
            this.cbStatus.Location = new System.Drawing.Point(237, 128);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(143, 21);
            this.cbStatus.TabIndex = 302;
            this.cbStatus.Tag = "";
            // 
            // deValidTo
            // 
            this.deValidTo.EditValue = new System.DateTime(((long)(0)));
            this.deValidTo.Location = new System.Drawing.Point(236, 155);
            this.deValidTo.Name = "deValidTo";
            this.deValidTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deValidTo.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.deValidTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deValidTo.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.deValidTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deValidTo.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.deValidTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deValidTo.Size = new System.Drawing.Size(144, 20);
            this.deValidTo.TabIndex = 303;
            // 
            // tbCNO
            // 
            this.tbCNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.tbCNO.Border.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.tbCNO.Border.Class = "RibbonGalleryContainer";
            this.tbCNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.tbCNO.Border.PaddingTop = 2;
            this.tbCNO.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbCNO.Location = new System.Drawing.Point(236, 70);
            this.tbCNO.Name = "tbCNO";
            this.tbCNO.Size = new System.Drawing.Size(144, 25);
            this.tbCNO.TabIndex = 306;
            this.tbCNO.WatermarkColor = System.Drawing.Color.Silver;
            this.tbCNO.WatermarkFont = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tbCNO.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(17, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 305;
            this.label6.Text = "编号";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Location = new System.Drawing.Point(21, 92);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(275, 1);
            this.panel6.TabIndex = 304;
            // 
            // SaveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 294);
            this.Controls.Add(this.tbCNO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.deValidTo);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbCardType);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tbCardID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.MinimumSize = new System.Drawing.Size(400, 294);
            this.Name = "SaveDialog";
            this.Text = "SaveDialog";
            this.Controls.SetChildIndex(this.btSave, 0);
            this.Controls.SetChildIndex(this.btCancel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbCardID, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbRemark, 0);
            this.Controls.SetChildIndex(this.cbCardType, 0);
            this.Controls.SetChildIndex(this.cbStatus, 0);
            this.Controls.SetChildIndex(this.deValidTo, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbCNO, 0);
            ((System.ComponentModel.ISupportInitialize)(this.deValidTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deValidTo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCardID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbCardType;
        private System.Windows.Forms.ComboBox cbStatus;
        private DevExpress.XtraEditors.DateEdit deValidTo;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCNO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
    }
}