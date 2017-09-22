namespace FEPV.Views
{
    partial class QueryVoucherView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryVoucherView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtVoucher = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._ParameterPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iUser = new DevExpress.XtraEditors.TextEdit();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.iMT = new DevExpress.XtraEditors.TextEdit();
            this.lblMovetype = new DevExpress.XtraEditors.LabelControl();
            this.lblDateTo = new DevExpress.XtraEditors.LabelControl();
            this.iSplant = new DevExpress.XtraEditors.TextEdit();
            this.lblPlant = new DevExpress.XtraEditors.LabelControl();
            this.iSMaterial = new DevExpress.XtraEditors.TextEdit();
            this.lblMaterial = new DevExpress.XtraEditors.LabelControl();
            this.iSbatch = new DevExpress.XtraEditors.TextEdit();
            this.lblBatch = new DevExpress.XtraEditors.LabelControl();
            this.idateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblDateFrom = new DevExpress.XtraEditors.LabelControl();
            this.idatebegin = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this._ParameterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSplant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSbatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatebegin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatebegin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtVoucher, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._ParameterPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 460);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // dtVoucher
            // 
            this.dtVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVoucher.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dtVoucher.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dtVoucher.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dtVoucher.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dtVoucher.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dtVoucher.Location = new System.Drawing.Point(3, 201);
            this.dtVoucher.MainView = this.gridView1;
            this.dtVoucher.Name = "dtVoucher";
            this.dtVoucher.Size = new System.Drawing.Size(770, 256);
            this.dtVoucher.TabIndex = 11;
            this.dtVoucher.UseEmbeddedNavigator = true;
            this.dtVoucher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.dtVoucher;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // _ParameterPanel
            // 
            this._ParameterPanel.BackColor = System.Drawing.Color.Transparent;
            this._ParameterPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ParameterPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ParameterPanel.Controls.Add(this.panel1);
            this._ParameterPanel.Controls.Add(this.iUser);
            this._ParameterPanel.Controls.Add(this.lblUser);
            this._ParameterPanel.Controls.Add(this.panel6);
            this._ParameterPanel.Controls.Add(this.panel14);
            this._ParameterPanel.Controls.Add(this.panel5);
            this._ParameterPanel.Controls.Add(this.panel4);
            this._ParameterPanel.Controls.Add(this.panel3);
            this._ParameterPanel.Controls.Add(this.panel13);
            this._ParameterPanel.Controls.Add(this.iMT);
            this._ParameterPanel.Controls.Add(this.lblMovetype);
            this._ParameterPanel.Controls.Add(this.lblDateTo);
            this._ParameterPanel.Controls.Add(this.iSplant);
            this._ParameterPanel.Controls.Add(this.lblPlant);
            this._ParameterPanel.Controls.Add(this.iSMaterial);
            this._ParameterPanel.Controls.Add(this.lblMaterial);
            this._ParameterPanel.Controls.Add(this.iSbatch);
            this._ParameterPanel.Controls.Add(this.lblBatch);
            this._ParameterPanel.Controls.Add(this.idateEnd);
            this._ParameterPanel.Controls.Add(this.lblDateFrom);
            this._ParameterPanel.Controls.Add(this.idatebegin);
            this._ParameterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ParameterPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._ParameterPanel.Location = new System.Drawing.Point(3, 3);
            this._ParameterPanel.Name = "_ParameterPanel";
            this._ParameterPanel.Size = new System.Drawing.Size(770, 192);
            // 
            // 
            // 
            this._ParameterPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._ParameterPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._ParameterPanel.Style.BackColorGradientAngle = 90;
            this._ParameterPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ParameterPanel.Style.BorderBottomWidth = 1;
            this._ParameterPanel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._ParameterPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ParameterPanel.Style.BorderLeftWidth = 1;
            this._ParameterPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ParameterPanel.Style.BorderRightWidth = 1;
            this._ParameterPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ParameterPanel.Style.BorderTopWidth = 1;
            this._ParameterPanel.Style.CornerDiameter = 4;
            this._ParameterPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this._ParameterPanel.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this._ParameterPanel.TabIndex = 199;
            this._ParameterPanel.Text = "[Parameters]";
            this._ParameterPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ParameterPanel.TitleImage")));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(38, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 1);
            this.panel1.TabIndex = 210;
            // 
            // iUser
            // 
            this.iUser.EnterMoveNextControl = true;
            this.iUser.Location = new System.Drawing.Point(186, 132);
            this.iUser.Name = "iUser";
            this.iUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.iUser.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iUser.Properties.MaxLength = 10;
            this.iUser.Size = new System.Drawing.Size(143, 18);
            this.iUser.TabIndex = 208;
            // 
            // lblUser
            // 
            this.lblUser.Appearance.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblUser.Location = new System.Drawing.Point(38, 131);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(36, 18);
            this.lblUser.TabIndex = 209;
            this.lblUser.Text = "User:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(38, 125);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(148, 1);
            this.panel6.TabIndex = 207;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Location = new System.Drawing.Point(393, 25);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(60, 1);
            this.panel14.TabIndex = 206;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(38, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(148, 1);
            this.panel5.TabIndex = 205;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(38, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(148, 1);
            this.panel4.TabIndex = 204;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(38, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(148, 1);
            this.panel3.TabIndex = 203;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Location = new System.Drawing.Point(38, 25);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(148, 1);
            this.panel13.TabIndex = 202;
            // 
            // iMT
            // 
            this.iMT.EnterMoveNextControl = true;
            this.iMT.Location = new System.Drawing.Point(186, 107);
            this.iMT.Name = "iMT";
            this.iMT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.iMT.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iMT.Properties.MaxLength = 10;
            this.iMT.Size = new System.Drawing.Size(143, 18);
            this.iMT.TabIndex = 193;
            // 
            // lblMovetype
            // 
            this.lblMovetype.Appearance.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblMovetype.Location = new System.Drawing.Point(38, 106);
            this.lblMovetype.Name = "lblMovetype";
            this.lblMovetype.Size = new System.Drawing.Size(74, 18);
            this.lblMovetype.TabIndex = 201;
            this.lblMovetype.Text = "MoveType:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.Appearance.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblDateTo.Location = new System.Drawing.Point(393, 6);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(22, 18);
            this.lblDateTo.TabIndex = 200;
            this.lblDateTo.Text = "To:";
            // 
            // iSplant
            // 
            this.iSplant.EnterMoveNextControl = true;
            this.iSplant.Location = new System.Drawing.Point(186, 57);
            this.iSplant.Name = "iSplant";
            this.iSplant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.iSplant.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iSplant.Properties.MaxLength = 10;
            this.iSplant.Size = new System.Drawing.Size(63, 18);
            this.iSplant.TabIndex = 191;
            // 
            // lblPlant
            // 
            this.lblPlant.Appearance.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblPlant.Location = new System.Drawing.Point(38, 56);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(40, 18);
            this.lblPlant.TabIndex = 199;
            this.lblPlant.Text = "Plant:";
            // 
            // iSMaterial
            // 
            this.iSMaterial.EnterMoveNextControl = true;
            this.iSMaterial.Location = new System.Drawing.Point(186, 32);
            this.iSMaterial.Name = "iSMaterial";
            this.iSMaterial.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.iSMaterial.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iSMaterial.Properties.MaxLength = 20;
            this.iSMaterial.Size = new System.Drawing.Size(143, 18);
            this.iSMaterial.TabIndex = 190;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Appearance.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblMaterial.Location = new System.Drawing.Point(38, 31);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(61, 18);
            this.lblMaterial.TabIndex = 198;
            this.lblMaterial.Text = "Material:";
            // 
            // iSbatch
            // 
            this.iSbatch.EnterMoveNextControl = true;
            this.iSbatch.Location = new System.Drawing.Point(186, 82);
            this.iSbatch.Name = "iSbatch";
            this.iSbatch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.iSbatch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iSbatch.Properties.MaxLength = 30;
            this.iSbatch.Size = new System.Drawing.Size(143, 18);
            this.iSbatch.TabIndex = 192;
            // 
            // lblBatch
            // 
            this.lblBatch.Appearance.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblBatch.Location = new System.Drawing.Point(38, 81);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(44, 18);
            this.lblBatch.TabIndex = 197;
            this.lblBatch.Text = "Batch:";
            // 
            // idateEnd
            // 
            this.idateEnd.EditValue = null;
            this.idateEnd.EnterMoveNextControl = true;
            this.idateEnd.Location = new System.Drawing.Point(450, 7);
            this.idateEnd.Name = "idateEnd";
            this.idateEnd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.idateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd hh:mm";
            this.idateEnd.Properties.Mask.BeepOnError = true;
            this.idateEnd.Properties.Mask.EditMask = "yyyy-MM-dd hh:mm";
            this.idateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.idateEnd.Size = new System.Drawing.Size(141, 18);
            this.idateEnd.TabIndex = 195;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Appearance.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblDateFrom.Location = new System.Drawing.Point(38, 6);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(77, 18);
            this.lblDateFrom.TabIndex = 196;
            this.lblDateFrom.Text = "From Date:";
            // 
            // idatebegin
            // 
            this.idatebegin.EditValue = null;
            this.idatebegin.EnterMoveNextControl = true;
            this.idatebegin.Location = new System.Drawing.Point(186, 7);
            this.idatebegin.Name = "idatebegin";
            this.idatebegin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.idatebegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idatebegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm";
            this.idatebegin.Properties.EditFormat.FormatString = "yyyy-MM-dd hh:mm";
            this.idatebegin.Properties.Mask.EditMask = "yyyy-MM-dd hh:mm";
            this.idatebegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.idatebegin.Size = new System.Drawing.Size(143, 18);
            this.idatebegin.TabIndex = 194;
            // 
            // QueryVoucherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QueryVoucherView";
            this.Size = new System.Drawing.Size(776, 460);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this._ParameterPanel.ResumeLayout(false);
            this._ParameterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSplant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSbatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatebegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatebegin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl dtVoucher;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevComponents.DotNetBar.Controls.GroupPanel _ParameterPanel;
        public System.Windows.Forms.Panel panel1;
        public DevExpress.XtraEditors.TextEdit iUser;
        public DevExpress.XtraEditors.LabelControl lblUser;
        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Panel panel14;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel13;
        public DevExpress.XtraEditors.TextEdit iMT;
        public DevExpress.XtraEditors.LabelControl lblMovetype;
        public DevExpress.XtraEditors.LabelControl lblDateTo;
        public DevExpress.XtraEditors.TextEdit iSplant;
        public DevExpress.XtraEditors.LabelControl lblPlant;
        public DevExpress.XtraEditors.TextEdit iSMaterial;
        public DevExpress.XtraEditors.LabelControl lblMaterial;
        public DevExpress.XtraEditors.TextEdit iSbatch;
        public DevExpress.XtraEditors.LabelControl lblBatch;
        public DevExpress.XtraEditors.DateEdit idateEnd;
        public DevExpress.XtraEditors.LabelControl lblDateFrom;
        public DevExpress.XtraEditors.DateEdit idatebegin;
    }
}
