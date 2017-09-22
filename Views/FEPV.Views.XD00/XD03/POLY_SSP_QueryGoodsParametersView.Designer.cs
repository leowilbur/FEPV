namespace FEPV.Views
{
    partial class POLY_SSP_QueryGoodsParametersView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbMaterial = new DevExpress.XtraEditors.LookUpEdit();
            this.lb_Datefrom = new System.Windows.Forms.Label();
            this.lbBatch = new System.Windows.Forms.Label();
            this.txtVoucherID = new DevExpress.XtraEditors.TextEdit();
            this.lb_Dateto = new System.Windows.Forms.Label();
            this.lbMaterial = new System.Windows.Forms.Label();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.deEndTime = new DevExpress.XtraEditors.DateEdit();
            this.lbPackNo = new System.Windows.Forms.Label();
            this.lbBarcode = new System.Windows.Forms.Label();
            this.cbBatch = new DevExpress.XtraEditors.LookUpEdit();
            this.deStartTime = new DevExpress.XtraEditors.DateEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cbMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMaterial
            // 
            this.cbMaterial.Location = new System.Drawing.Point(205, 49);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMaterial.Properties.NullText = "";
            this.cbMaterial.Properties.PopupWidth = 300;
            this.cbMaterial.Properties.ShowFooter = false;
            this.cbMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbMaterial.Size = new System.Drawing.Size(145, 20);
            this.cbMaterial.TabIndex = 123;
            this.cbMaterial.EditValueChanged += new System.EventHandler(this.cbMaterial_EditValueChanged);
            // 
            // lb_Datefrom
            // 
            this.lb_Datefrom.AutoSize = true;
            this.lb_Datefrom.BackColor = System.Drawing.Color.Transparent;
            this.lb_Datefrom.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lb_Datefrom.Location = new System.Drawing.Point(33, 20);
            this.lb_Datefrom.Name = "lb_Datefrom";
            this.lb_Datefrom.Size = new System.Drawing.Size(162, 18);
            this.lb_Datefrom.TabIndex = 115;
            this.lb_Datefrom.Text = "Production Date From:";
            // 
            // lbBatch
            // 
            this.lbBatch.AutoSize = true;
            this.lbBatch.BackColor = System.Drawing.Color.Transparent;
            this.lbBatch.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lbBatch.Location = new System.Drawing.Point(367, 48);
            this.lbBatch.Name = "lbBatch";
            this.lbBatch.Size = new System.Drawing.Size(52, 18);
            this.lbBatch.TabIndex = 114;
            this.lbBatch.Text = "Batch:";
            // 
            // txtVoucherID
            // 
            this.txtVoucherID.Location = new System.Drawing.Point(205, 78);
            this.txtVoucherID.Name = "txtVoucherID";
            this.txtVoucherID.Size = new System.Drawing.Size(145, 20);
            this.txtVoucherID.TabIndex = 110;
            // 
            // lb_Dateto
            // 
            this.lb_Dateto.AutoSize = true;
            this.lb_Dateto.BackColor = System.Drawing.Color.Transparent;
            this.lb_Dateto.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lb_Dateto.Location = new System.Drawing.Point(367, 20);
            this.lb_Dateto.Name = "lb_Dateto";
            this.lb_Dateto.Size = new System.Drawing.Size(30, 18);
            this.lb_Dateto.TabIndex = 117;
            this.lb_Dateto.Text = "To:";
            // 
            // lbMaterial
            // 
            this.lbMaterial.AutoSize = true;
            this.lbMaterial.BackColor = System.Drawing.Color.Transparent;
            this.lbMaterial.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lbMaterial.Location = new System.Drawing.Point(33, 48);
            this.lbMaterial.Name = "lbMaterial";
            this.lbMaterial.Size = new System.Drawing.Size(69, 18);
            this.lbMaterial.TabIndex = 118;
            this.lbMaterial.Text = "Material:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(466, 78);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(162, 20);
            this.txtBarcode.TabIndex = 113;
            // 
            // deEndTime
            // 
            this.deEndTime.EditValue = null;
            this.deEndTime.Location = new System.Drawing.Point(466, 21);
            this.deEndTime.Name = "deEndTime";
            this.deEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss ";
            this.deEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deEndTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss ";
            this.deEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deEndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss ";
            this.deEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEndTime.Size = new System.Drawing.Size(162, 20);
            this.deEndTime.TabIndex = 109;
            // 
            // lbPackNo
            // 
            this.lbPackNo.AutoSize = true;
            this.lbPackNo.BackColor = System.Drawing.Color.Transparent;
            this.lbPackNo.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lbPackNo.Location = new System.Drawing.Point(367, 77);
            this.lbPackNo.Name = "lbPackNo";
            this.lbPackNo.Size = new System.Drawing.Size(92, 18);
            this.lbPackNo.TabIndex = 120;
            this.lbPackNo.Text = "Package No:";
            // 
            // lbBarcode
            // 
            this.lbBarcode.AutoSize = true;
            this.lbBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lbBarcode.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lbBarcode.Location = new System.Drawing.Point(33, 77);
            this.lbBarcode.Name = "lbBarcode";
            this.lbBarcode.Size = new System.Drawing.Size(67, 18);
            this.lbBarcode.TabIndex = 121;
            this.lbBarcode.Text = "Barcode:";
            // 
            // cbBatch
            // 
            this.cbBatch.Location = new System.Drawing.Point(466, 49);
            this.cbBatch.Name = "cbBatch";
            this.cbBatch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBatch.Properties.NullText = "";
            this.cbBatch.Properties.PopupWidth = 300;
            this.cbBatch.Properties.ShowFooter = false;
            this.cbBatch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbBatch.Size = new System.Drawing.Size(162, 20);
            this.cbBatch.TabIndex = 124;
            // 
            // deStartTime
            // 
            this.deStartTime.EditValue = null;
            this.deStartTime.Location = new System.Drawing.Point(205, 20);
            this.deStartTime.Name = "deStartTime";
            this.deStartTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.deStartTime.Properties.Appearance.Options.UseFont = true;
            this.deStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStartTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss ";
            this.deStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deStartTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss ";
            this.deStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deStartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss ";
            this.deStartTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deStartTime.Size = new System.Drawing.Size(145, 22);
            this.deStartTime.TabIndex = 108;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(36, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 1);
            this.panel3.TabIndex = 147;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(36, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 1);
            this.panel1.TabIndex = 148;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(36, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 1);
            this.panel2.TabIndex = 149;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(370, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 1);
            this.panel4.TabIndex = 150;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(370, 68);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(100, 1);
            this.panel5.TabIndex = 151;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(370, 97);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(100, 1);
            this.panel6.TabIndex = 152;
            // 
            // POLY_SSP_QueryGoodsParametersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cbBatch);
            this.Controls.Add(this.cbMaterial);
            this.Controls.Add(this.lb_Datefrom);
            this.Controls.Add(this.lbBatch);
            this.Controls.Add(this.txtVoucherID);
            this.Controls.Add(this.lb_Dateto);
            this.Controls.Add(this.lbMaterial);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.deEndTime);
            this.Controls.Add(this.lbPackNo);
            this.Controls.Add(this.deStartTime);
            this.Controls.Add(this.lbBarcode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "POLY_SSP_QueryGoodsParametersView";
            this.Size = new System.Drawing.Size(669, 123);
            ((System.ComponentModel.ISupportInitialize)(this.cbMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucherID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbMaterial;
        private System.Windows.Forms.Label lb_Datefrom;
        private System.Windows.Forms.Label lbBatch;
        private DevExpress.XtraEditors.TextEdit txtVoucherID;
        private System.Windows.Forms.Label lb_Dateto;
        private System.Windows.Forms.Label lbMaterial;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraEditors.DateEdit deEndTime;
        private System.Windows.Forms.Label lbPackNo;
        private System.Windows.Forms.Label lbBarcode;
        private DevExpress.XtraEditors.LookUpEdit cbBatch;
        private DevExpress.XtraEditors.DateEdit deStartTime;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel panel6;

    }
}
