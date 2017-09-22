namespace FEPY.Views.Demo
{
    partial class ViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btRole = new System.Windows.Forms.ToolStripLabel();
            this._Role = new System.Windows.Forms.ToolStripTextBox();
            this.btTCode = new System.Windows.Forms.ToolStripButton();
            this.btFunction = new System.Windows.Forms.ToolStripButton();
            this.BtExcel = new System.Windows.Forms.ToolStripButton();
            this.btBack = new System.Windows.Forms.ToolStripButton();
            this.butCN = new System.Windows.Forms.ToolStripButton();
            this.butEN = new System.Windows.Forms.ToolStripButton();
            this.butChinese = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._ParameterPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtGrid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.butCreate = new System.Windows.Forms.Button();
            this.txtForm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTcode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Invoke = new System.Windows.Forms.Button();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbTruck = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbCard = new System.Windows.Forms.Label();
            this.gcItemGrid = new DevExpress.XtraGrid.GridControl();
            this.gvItemGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._ParameterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btRole,
            this._Role,
            this.btTCode,
            this.btFunction,
            this.BtExcel,
            this.btBack,
            this.butCN,
            this.butEN,
            this.butChinese});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(707, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btRole
            // 
            this.btRole.Name = "btRole";
            this.btRole.Size = new System.Drawing.Size(32, 22);
            this.btRole.Text = "角色";
            // 
            // _Role
            // 
            this._Role.Name = "_Role";
            this._Role.Size = new System.Drawing.Size(100, 25);
            // 
            // btTCode
            // 
            this.btTCode.Image = ((System.Drawing.Image)(resources.GetObject("btTCode.Image")));
            this.btTCode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btTCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTCode.Name = "btTCode";
            this.btTCode.Size = new System.Drawing.Size(66, 22);
            this.btTCode.Text = "TCode";
            this.btTCode.Click += new System.EventHandler(this.btTCode_Click);
            // 
            // btFunction
            // 
            this.btFunction.Image = ((System.Drawing.Image)(resources.GetObject("btFunction.Image")));
            this.btFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFunction.Name = "btFunction";
            this.btFunction.Size = new System.Drawing.Size(76, 22);
            this.btFunction.Text = "Function";
            this.btFunction.Click += new System.EventHandler(this.btFunction_Click);
            // 
            // BtExcel
            // 
            this.BtExcel.Image = ((System.Drawing.Image)(resources.GetObject("BtExcel.Image")));
            this.BtExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtExcel.Name = "BtExcel";
            this.BtExcel.Size = new System.Drawing.Size(64, 22);
            this.BtExcel.Text = "EXCEL";
            this.BtExcel.Click += new System.EventHandler(this.BtExcel_Click);
            // 
            // btBack
            // 
            this.btBack.Image = ((System.Drawing.Image)(resources.GetObject("btBack.Image")));
            this.btBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(52, 22);
            this.btBack.Text = "后退";
            // 
            // butCN
            // 
            this.butCN.Image = ((System.Drawing.Image)(resources.GetObject("butCN.Image")));
            this.butCN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butCN.Name = "butCN";
            this.butCN.Size = new System.Drawing.Size(120, 22);
            this.butCN.Text = "生存GridHeader";
            this.butCN.Click += new System.EventHandler(this.butCN_Click);
            // 
            // butEN
            // 
            this.butEN.Image = ((System.Drawing.Image)(resources.GetObject("butEN.Image")));
            this.butEN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butEN.Name = "butEN";
            this.butEN.Size = new System.Drawing.Size(45, 22);
            this.butEN.Text = "EN";
            this.butEN.Click += new System.EventHandler(this.butEN_Click);
            // 
            // butChinese
            // 
            this.butChinese.Image = ((System.Drawing.Image)(resources.GetObject("butChinese.Image")));
            this.butChinese.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butChinese.Name = "butChinese";
            this.butChinese.Size = new System.Drawing.Size(46, 22);
            this.butChinese.Text = "CN";
            this.butChinese.Click += new System.EventHandler(this.butChinese_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._ParameterPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gcItemGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.27506F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.72494F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 389);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // _ParameterPanel
            // 
            this._ParameterPanel.BackColor = System.Drawing.Color.Transparent;
            this._ParameterPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ParameterPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ParameterPanel.Controls.Add(this.txtGrid);
            this._ParameterPanel.Controls.Add(this.butCreate);
            this._ParameterPanel.Controls.Add(this.txtForm);
            this._ParameterPanel.Controls.Add(this.txtTcode);
            this._ParameterPanel.Controls.Add(this.Invoke);
            this._ParameterPanel.Controls.Add(this.textBoxX1);
            this._ParameterPanel.Controls.Add(this.txtCar);
            this._ParameterPanel.Controls.Add(this.panel9);
            this._ParameterPanel.Controls.Add(this.lbTruck);
            this._ParameterPanel.Controls.Add(this.panel5);
            this._ParameterPanel.Controls.Add(this.lbCard);
            this._ParameterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ParameterPanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._ParameterPanel.Location = new System.Drawing.Point(3, 3);
            this._ParameterPanel.Name = "_ParameterPanel";
            this._ParameterPanel.Size = new System.Drawing.Size(701, 138);
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
            this._ParameterPanel.TabIndex = 207;
            this._ParameterPanel.Text = "[参数信息]";
            // 
            // txtGrid
            // 
            this.txtGrid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtGrid.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.txtGrid.Location = new System.Drawing.Point(435, 83);
            this.txtGrid.Name = "txtGrid";
            this.txtGrid.Size = new System.Drawing.Size(138, 28);
            this.txtGrid.TabIndex = 316;
            this.txtGrid.WatermarkColor = System.Drawing.Color.Silver;
            this.txtGrid.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(21, 86);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(75, 23);
            this.butCreate.TabIndex = 315;
            this.butCreate.Text = "生成XML";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // txtForm
            // 
            this.txtForm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtForm.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.txtForm.Location = new System.Drawing.Point(291, 83);
            this.txtForm.Name = "txtForm";
            this.txtForm.Size = new System.Drawing.Size(138, 28);
            this.txtForm.TabIndex = 314;
            this.txtForm.WatermarkColor = System.Drawing.Color.Silver;
            this.txtForm.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            // 
            // txtTcode
            // 
            this.txtTcode.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTcode.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.txtTcode.Location = new System.Drawing.Point(147, 83);
            this.txtTcode.Name = "txtTcode";
            this.txtTcode.Size = new System.Drawing.Size(138, 28);
            this.txtTcode.TabIndex = 313;
            this.txtTcode.WatermarkColor = System.Drawing.Color.Silver;
            this.txtTcode.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            // 
            // Invoke
            // 
            this.Invoke.Location = new System.Drawing.Point(340, 33);
            this.Invoke.Name = "Invoke";
            this.Invoke.Size = new System.Drawing.Size(75, 23);
            this.Invoke.TabIndex = 312;
            this.Invoke.Text = "butInvoke";
            this.Invoke.UseVisualStyleBackColor = true;
            this.Invoke.Click += new System.EventHandler(this.Invoke_Click);
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.textBoxX1.Border.Class = "RibbonGalleryContainer";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.textBoxX1.Border.PaddingTop = 2;
            this.textBoxX1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.textBoxX1.Location = new System.Drawing.Point(123, -1);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.ReadOnly = true;
            this.textBoxX1.Size = new System.Drawing.Size(138, 28);
            this.textBoxX1.TabIndex = 311;
            this.textBoxX1.WatermarkColor = System.Drawing.Color.Silver;
            this.textBoxX1.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            // 
            // txtCar
            // 
            this.txtCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCar.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.txtCar.Location = new System.Drawing.Point(123, 29);
            this.txtCar.Name = "txtCar";
            this.txtCar.ReadOnly = true;
            this.txtCar.Size = new System.Drawing.Size(138, 28);
            this.txtCar.TabIndex = 259;
            this.txtCar.WatermarkColor = System.Drawing.Color.Silver;
            this.txtCar.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.Window;
            this.panel9.Location = new System.Drawing.Point(21, 55);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(105, 1);
            this.panel9.TabIndex = 260;
            // 
            // lbTruck
            // 
            this.lbTruck.AutoSize = true;
            this.lbTruck.BackColor = System.Drawing.Color.Transparent;
            this.lbTruck.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.lbTruck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbTruck.Location = new System.Drawing.Point(17, 35);
            this.lbTruck.Name = "lbTruck";
            this.lbTruck.Size = new System.Drawing.Size(49, 20);
            this.lbTruck.TabIndex = 258;
            this.lbTruck.Text = "车   号";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Location = new System.Drawing.Point(21, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(105, 1);
            this.panel5.TabIndex = 204;
            // 
            // lbCard
            // 
            this.lbCard.AutoSize = true;
            this.lbCard.BackColor = System.Drawing.Color.Transparent;
            this.lbCard.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.lbCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbCard.Location = new System.Drawing.Point(17, 7);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(65, 20);
            this.lbCard.TabIndex = 202;
            this.lbCard.Text = "卡       号";
            // 
            // gcItemGrid
            // 
            this.gcItemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItemGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcItemGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcItemGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcItemGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcItemGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcItemGrid.Location = new System.Drawing.Point(3, 147);
            this.gcItemGrid.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.gcItemGrid.MainView = this.gvItemGrid;
            this.gcItemGrid.Name = "gcItemGrid";
            this.gcItemGrid.Padding = new System.Windows.Forms.Padding(1);
            this.gcItemGrid.Size = new System.Drawing.Size(701, 239);
            this.gcItemGrid.TabIndex = 186;
            this.gcItemGrid.UseEmbeddedNavigator = true;
            this.gcItemGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItemGrid});
            this.gcItemGrid.DoubleClick += new System.EventHandler(this.gcItemGrid_DoubleClick);
            // 
            // gvItemGrid
            // 
            this.gvItemGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvItemGrid.CustomizationFormBounds = new System.Drawing.Rectangle(589, 377, 216, 187);
            this.gvItemGrid.FixedLineWidth = 1;
            this.gvItemGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvItemGrid.GridControl = this.gcItemGrid;
            this.gvItemGrid.GroupFormat = " [#image]{1} {2}";
            this.gvItemGrid.Name = "gvItemGrid";
            this.gvItemGrid.OptionsBehavior.Editable = false;
            this.gvItemGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvItemGrid.OptionsSelection.MultiSelect = true;
            this.gvItemGrid.OptionsView.ColumnAutoWidth = false;
            this.gvItemGrid.OptionsView.RowAutoHeight = true;
            this.gvItemGrid.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "eeeeee";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 414);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this._ParameterPanel.ResumeLayout(false);
            this._ParameterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel btRole;
        private System.Windows.Forms.ToolStripTextBox _Role;
        private System.Windows.Forms.ToolStripButton btTCode;
        private System.Windows.Forms.ToolStripButton btFunction;
        private System.Windows.Forms.ToolStripButton BtExcel;
        private System.Windows.Forms.ToolStripButton btBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public DevExpress.XtraGrid.GridControl gcItemGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItemGrid;
        private DevComponents.DotNetBar.Controls.GroupPanel _ParameterPanel;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbTruck;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbCard;
        private System.Windows.Forms.ToolStripButton butCN;
        private System.Windows.Forms.ToolStripButton butEN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ToolStripButton butChinese;
        private System.Windows.Forms.Button Invoke;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGrid;
        private System.Windows.Forms.Button butCreate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtForm;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTcode;
    }
}