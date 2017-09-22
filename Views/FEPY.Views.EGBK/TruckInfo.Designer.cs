namespace FEPV.Views
{
    partial class TruckInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TruckInfo));
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gcTruck = new DevExpress.XtraGrid.GridControl();
            this.gridViewTruck1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this._VehicleNO = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._State = new System.Windows.Forms.Label();
            this._Flag = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.Label();
            this.txtVoucherID = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbInOrOut = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVehicleNO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ribbonClientPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTruck1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.groupPanel2);
            this.ribbonClientPanel1.Controls.Add(this.groupPanel1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.ShowFocusRectangle = true;
            this.ribbonClientPanel1.Size = new System.Drawing.Size(792, 449);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.BackColor = System.Drawing.Color.Transparent;
            this.ribbonClientPanel1.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.ribbonClientPanel1.Style.BackColorGradientAngle = 90;
            this.ribbonClientPanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.ribbonClientPanel1.Style.BorderBottomWidth = 1;
            this.ribbonClientPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ribbonClientPanel1.Style.BorderLeftWidth = 1;
            this.ribbonClientPanel1.Style.BorderRightWidth = 1;
            this.ribbonClientPanel1.Style.BorderTopWidth = 1;
            this.ribbonClientPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ribbonClientPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ribbonClientPanel1.TabIndex = 189;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.groupPanel2.Controls.Add(this.gcTruck);
            this.groupPanel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel2.Location = new System.Drawing.Point(3, 139);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(776, 295);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.groupPanel2.TabIndex = 192;
            this.groupPanel2.Text = "[车辆信息]";
            this.groupPanel2.TitleImage = ((System.Drawing.Image)(resources.GetObject("groupPanel2.TitleImage")));
            // 
            // gcTruck
            // 
            this.gcTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTruck.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcTruck.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcTruck.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcTruck.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcTruck.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcTruck.Location = new System.Drawing.Point(0, 0);
            this.gcTruck.MainView = this.gridViewTruck1;
            this.gcTruck.Name = "gcTruck";
            this.gcTruck.Size = new System.Drawing.Size(770, 271);
            this.gcTruck.TabIndex = 1;
            this.gcTruck.UseEmbeddedNavigator = true;
            this.gcTruck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTruck1});
            // 
            // gridViewTruck1
            // 
            this.gridViewTruck1.FixedLineWidth = 1;
            this.gridViewTruck1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewTruck1.GridControl = this.gcTruck;
            this.gridViewTruck1.Name = "gridViewTruck1";
            this.gridViewTruck1.OptionsBehavior.Editable = false;
            this.gridViewTruck1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewTruck1.OptionsSelection.MultiSelect = true;
            this.gridViewTruck1.OptionsView.ColumnAutoWidth = false;
            this.gridViewTruck1.OptionsView.RowAutoHeight = true;
            this.gridViewTruck1.OptionsView.ShowGroupPanel = false;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.groupPanel1.Controls.Add(this._VehicleNO);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this._State);
            this.groupPanel1.Controls.Add(this._Flag);
            this.groupPanel1.Controls.Add(this.txtItemID);
            this.groupPanel1.Controls.Add(this.txtVoucherID);
            this.groupPanel1.Controls.Add(this.cbType);
            this.groupPanel1.Controls.Add(this.panel3);
            this.groupPanel1.Controls.Add(this.cbInOrOut);
            this.groupPanel1.Controls.Add(this.panel2);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.Controls.Add(this.txtVehicleNO);
            this.groupPanel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(3, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(773, 117);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.groupPanel1.TabIndex = 191;
            this.groupPanel1.Text = "[查询条件]";
            this.groupPanel1.TitleImage = ((System.Drawing.Image)(resources.GetObject("groupPanel1.TitleImage")));
            // 
            // _VehicleNO
            // 
            this._VehicleNO.AutoSize = true;
            this._VehicleNO.BackColor = System.Drawing.Color.Transparent;
            this._VehicleNO.Font = new System.Drawing.Font("Tahoma", 9F);
            this._VehicleNO.ForeColor = System.Drawing.Color.Black;
            this._VehicleNO.Location = new System.Drawing.Point(543, 61);
            this._VehicleNO.Name = "_VehicleNO";
            this._VehicleNO.Size = new System.Drawing.Size(70, 14);
            this._VehicleNO.TabIndex = 285;
            this._VehicleNO.Text = "_VehicleNO";
            this._VehicleNO.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(78, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 284;
            this.label6.Text = "类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(78, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 283;
            this.label5.Text = "状态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(78, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 282;
            this.label4.Text = "车号";
            // 
            // _State
            // 
            this._State.AutoSize = true;
            this._State.BackColor = System.Drawing.Color.Transparent;
            this._State.Font = new System.Drawing.Font("Tahoma", 9F);
            this._State.ForeColor = System.Drawing.Color.Black;
            this._State.Location = new System.Drawing.Point(469, 61);
            this._State.Name = "_State";
            this._State.Size = new System.Drawing.Size(44, 14);
            this._State.TabIndex = 281;
            this._State.Text = "_State";
            this._State.Visible = false;
            // 
            // _Flag
            // 
            this._Flag.AutoSize = true;
            this._Flag.BackColor = System.Drawing.Color.Transparent;
            this._Flag.Font = new System.Drawing.Font("Tahoma", 9F);
            this._Flag.ForeColor = System.Drawing.Color.Black;
            this._Flag.Location = new System.Drawing.Point(469, 34);
            this._Flag.Name = "_Flag";
            this._Flag.Size = new System.Drawing.Size(35, 14);
            this._Flag.TabIndex = 280;
            this._Flag.Text = "_Flag";
            this._Flag.Visible = false;
            // 
            // txtItemID
            // 
            this.txtItemID.AutoSize = true;
            this.txtItemID.BackColor = System.Drawing.Color.Transparent;
            this.txtItemID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtItemID.ForeColor = System.Drawing.Color.Black;
            this.txtItemID.Location = new System.Drawing.Point(380, 61);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(52, 14);
            this.txtItemID.TabIndex = 279;
            this.txtItemID.Text = "_ItemID";
            this.txtItemID.Visible = false;
            // 
            // txtVoucherID
            // 
            this.txtVoucherID.AutoSize = true;
            this.txtVoucherID.BackColor = System.Drawing.Color.Transparent;
            this.txtVoucherID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtVoucherID.ForeColor = System.Drawing.Color.Black;
            this.txtVoucherID.Location = new System.Drawing.Point(380, 34);
            this.txtVoucherID.Name = "txtVoucherID";
            this.txtVoucherID.Size = new System.Drawing.Size(72, 14);
            this.txtVoucherID.TabIndex = 278;
            this.txtVoucherID.Text = "_VoucherID";
            this.txtVoucherID.Visible = false;
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.White;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbType.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cbType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "A-其他车辆",
            "B-多次过磅车辆"});
            this.cbType.Location = new System.Drawing.Point(187, 59);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(127, 21);
            this.cbType.TabIndex = 277;
            this.cbType.Tag = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Location = new System.Drawing.Point(82, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 1);
            this.panel3.TabIndex = 276;
            // 
            // cbInOrOut
            // 
            this.cbInOrOut.BackColor = System.Drawing.Color.White;
            this.cbInOrOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInOrOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbInOrOut.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cbInOrOut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbInOrOut.FormattingEnabled = true;
            this.cbInOrOut.Items.AddRange(new object[] {
            "申请进厂",
            "申请出厂"});
            this.cbInOrOut.Location = new System.Drawing.Point(187, 32);
            this.cbInOrOut.Name = "cbInOrOut";
            this.cbInOrOut.Size = new System.Drawing.Size(127, 21);
            this.cbInOrOut.TabIndex = 274;
            this.cbInOrOut.Tag = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(82, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 1);
            this.panel2.TabIndex = 257;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(82, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 1);
            this.panel1.TabIndex = 254;
            // 
            // txtVehicleNO
            // 
            this.txtVehicleNO.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtVehicleNO.Border.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.txtVehicleNO.Border.Class = "RibbonGalleryContainer";
            this.txtVehicleNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal;
            this.txtVehicleNO.Border.PaddingTop = 2;
            this.txtVehicleNO.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.txtVehicleNO.Location = new System.Drawing.Point(187, 6);
            this.txtVehicleNO.Name = "txtVehicleNO";
            this.txtVehicleNO.Size = new System.Drawing.Size(127, 21);
            this.txtVehicleNO.TabIndex = 252;
            this.txtVehicleNO.WatermarkColor = System.Drawing.Color.Silver;
            this.txtVehicleNO.WatermarkFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.txtVehicleNO.WordWrap = false;
            // 
            // TruckInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.Controls.Add(this.ribbonClientPanel1);
            this.Name = "TruckInfo";
            this.Size = new System.Drawing.Size(792, 449);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTruck1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ComboBox cbInOrOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtVehicleNO;
        private DevExpress.XtraGrid.GridControl gcTruck;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTruck1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtItemID;
        private System.Windows.Forms.Label txtVoucherID;
        private System.Windows.Forms.Label _State;
        private System.Windows.Forms.Label _Flag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _VehicleNO;
    }
}
