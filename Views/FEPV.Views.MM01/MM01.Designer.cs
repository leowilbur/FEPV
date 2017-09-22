namespace FEPV.Views
{
    partial class MM01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MM01));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._MSG = new DevExpress.XtraEditors.LabelControl();
            this._InformationPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gridMaterials = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btSearch = new DevComponents.DotNetBar.ButtonItem();
            this.btDown = new DevComponents.DotNetBar.ButtonItem();
            this._ParameterPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this._dateFrom = new DevExpress.XtraEditors.DateEdit();
            this._iPlant = new DevExpress.XtraEditors.TextEdit();
            this._iMaterialNo = new DevExpress.XtraEditors.TextEdit();
            this.bindingSourceMaterial = new System.Windows.Forms.BindingSource();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPlant = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this._InformationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this._ParameterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._iPlant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._iMaterialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._MSG, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this._InformationPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bar1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._ParameterPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _MSG
            // 
            this._MSG.Location = new System.Drawing.Point(3, 444);
            this._MSG.Name = "_MSG";
            this._MSG.Size = new System.Drawing.Size(46, 13);
            this._MSG.TabIndex = 198;
            this._MSG.Text = "Message:";
            // 
            // _InformationPanel
            // 
            this._InformationPanel.BackColor = System.Drawing.Color.Transparent;
            this._InformationPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._InformationPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._InformationPanel.Controls.Add(this.gridMaterials);
            this._InformationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._InformationPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._InformationPanel.Location = new System.Drawing.Point(3, 95);
            this._InformationPanel.Name = "_InformationPanel";
            this._InformationPanel.Size = new System.Drawing.Size(727, 343);
            // 
            // 
            // 
            this._InformationPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._InformationPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._InformationPanel.Style.BackColorGradientAngle = 90;
            this._InformationPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._InformationPanel.Style.BorderBottomWidth = 1;
            this._InformationPanel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._InformationPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._InformationPanel.Style.BorderLeftWidth = 1;
            this._InformationPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._InformationPanel.Style.BorderRightWidth = 1;
            this._InformationPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._InformationPanel.Style.BorderTopWidth = 1;
            this._InformationPanel.Style.CornerDiameter = 4;
            this._InformationPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this._InformationPanel.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this._InformationPanel.TabIndex = 197;
            this._InformationPanel.Text = "[Information]";
            this._InformationPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_InformationPanel.TitleImage")));
            // 
            // gridMaterials
            // 
            this.gridMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaterials.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridMaterials.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridMaterials.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridMaterials.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridMaterials.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridMaterials.Location = new System.Drawing.Point(0, 0);
            this.gridMaterials.MainView = this.gridView1;
            this.gridMaterials.Name = "gridMaterials";
            this.gridMaterials.Size = new System.Drawing.Size(721, 321);
            this.gridMaterials.TabIndex = 0;
            this.gridMaterials.TabStop = false;
            this.gridMaterials.UseEmbeddedNavigator = true;
            this.gridMaterials.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridMaterials;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // bar1
            // 
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btSearch,
            this.btDown});
            this.bar1.Location = new System.Drawing.Point(3, 3);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(727, 24);
            this.bar1.Stretch = true;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btSearch
            // 
            this.btSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btSearch.Image = ((System.Drawing.Image)(resources.GetObject("btSearch.Image")));
            this.btSearch.ImagePaddingHorizontal = 8;
            this.btSearch.Name = "btSearch";
            this.btSearch.Text = "Search";
            // 
            // btDown
            // 
            this.btDown.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btDown.Image = ((System.Drawing.Image)(resources.GetObject("btDown.Image")));
            this.btDown.ImagePaddingHorizontal = 8;
            this.btDown.Name = "btDown";
            this.btDown.Text = "Down";
            // 
            // _ParameterPanel
            // 
            this._ParameterPanel.BackColor = System.Drawing.Color.Transparent;
            this._ParameterPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ParameterPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ParameterPanel.Controls.Add(this._iPlant);
            this._ParameterPanel.Controls.Add(this._iMaterialNo);
            this._ParameterPanel.Controls.Add(this._dateFrom);
            this._ParameterPanel.Controls.Add(this.panel2);
            this._ParameterPanel.Controls.Add(this.lblPlant);
            this._ParameterPanel.Controls.Add(this.panel1);
            this._ParameterPanel.Controls.Add(this.lblMaterial);
            this._ParameterPanel.Controls.Add(this.panel6);
            this._ParameterPanel.Controls.Add(this.lblDateFrom);
            this._ParameterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ParameterPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._ParameterPanel.Location = new System.Drawing.Point(3, 33);
            this._ParameterPanel.Name = "_ParameterPanel";
            this._ParameterPanel.Size = new System.Drawing.Size(727, 56);
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
            this._ParameterPanel.TabIndex = 196;
            this._ParameterPanel.Text = "[Parameters]";
            this._ParameterPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ParameterPanel.TitleImage")));
            // 
            // _dateFrom
            // 
            this._dateFrom.EditValue = null;
            this._dateFrom.Location = new System.Drawing.Point(103, 6);
            this._dateFrom.Name = "_dateFrom";
            this._dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._dateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this._dateFrom.Size = new System.Drawing.Size(143, 20);
            this._dateFrom.TabIndex = 0;
            // 
            // _iPlant
            // 
            this._iPlant.EditValue = "";
            this._iPlant.Location = new System.Drawing.Point(590, 6);
            this._iPlant.Name = "_iPlant";
            this._iPlant.Properties.NullText = "PLANT";
            this._iPlant.Size = new System.Drawing.Size(101, 20);
            this._iPlant.TabIndex = 2;
            // 
            // _iMaterialNo
            // 
            this._iMaterialNo.Location = new System.Drawing.Point(349, 6);
            this._iMaterialNo.Name = "_iMaterialNo";
            this._iMaterialNo.Size = new System.Drawing.Size(143, 20);
            this._iMaterialNo.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Location = new System.Drawing.Point(19, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(150, 1);
            this.panel6.TabIndex = 295;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblDateFrom.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblDateFrom.ForeColor = System.Drawing.Color.Black;
            this.lblDateFrom.Location = new System.Drawing.Point(15, 6);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(85, 18);
            this.lblDateFrom.TabIndex = 296;
            this.lblDateFrom.Text = "Date From:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(272, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 1);
            this.panel1.TabIndex = 297;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.BackColor = System.Drawing.Color.Transparent;
            this.lblMaterial.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblMaterial.ForeColor = System.Drawing.Color.Black;
            this.lblMaterial.Location = new System.Drawing.Point(268, 6);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(69, 18);
            this.lblMaterial.TabIndex = 298;
            this.lblMaterial.Text = "Material:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(511, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 1);
            this.panel2.TabIndex = 299;
            // 
            // lblPlant
            // 
            this.lblPlant.AutoSize = true;
            this.lblPlant.BackColor = System.Drawing.Color.Transparent;
            this.lblPlant.Font = new System.Drawing.Font("Georgia", 11.25F);
            this.lblPlant.ForeColor = System.Drawing.Color.Black;
            this.lblPlant.Location = new System.Drawing.Point(507, 6);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(48, 18);
            this.lblPlant.TabIndex = 300;
            this.lblPlant.Text = "Plant:";
            // 
            // MM01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MM01";
            this.Text = "MM01";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._InformationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this._ParameterPanel.ResumeLayout(false);
            this._ParameterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._iPlant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._iMaterialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btSearch;
        private DevComponents.DotNetBar.ButtonItem btDown;
        private DevComponents.DotNetBar.Controls.GroupPanel _InformationPanel;
        private DevComponents.DotNetBar.Controls.GroupPanel _ParameterPanel;
        private DevExpress.XtraEditors.DateEdit _dateFrom;
        private DevExpress.XtraEditors.TextEdit _iPlant;
        private DevExpress.XtraEditors.TextEdit _iMaterialNo;
        private DevExpress.XtraEditors.LabelControl _MSG;
        private System.Windows.Forms.BindingSource bindingSourceMaterial;
        private DevExpress.XtraGrid.GridControl gridMaterials;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPlant;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblDateFrom;

    }
}