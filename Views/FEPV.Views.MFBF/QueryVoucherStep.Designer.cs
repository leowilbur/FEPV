namespace FEPV.Views
{
    partial class QueryVoucherStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryVoucherStep));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._ShowgoodsPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._ShowgoodsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 467);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._ShowgoodsPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControlDetail, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.7156F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.2844F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 467);
            this.tableLayoutPanel1.TabIndex = 197;
            // 
            // _ShowgoodsPanel
            // 
            this._ShowgoodsPanel.BackColor = System.Drawing.Color.Transparent;
            this._ShowgoodsPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ShowgoodsPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ShowgoodsPanel.Controls.Add(this.gridControlMaster);
            this._ShowgoodsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ShowgoodsPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._ShowgoodsPanel.Location = new System.Drawing.Point(3, 3);
            this._ShowgoodsPanel.Name = "_ShowgoodsPanel";
            this._ShowgoodsPanel.Size = new System.Drawing.Size(780, 151);
            // 
            // 
            // 
            this._ShowgoodsPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._ShowgoodsPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this._ShowgoodsPanel.Style.BackColorGradientAngle = 90;
            this._ShowgoodsPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ShowgoodsPanel.Style.BorderBottomWidth = 1;
            this._ShowgoodsPanel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._ShowgoodsPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ShowgoodsPanel.Style.BorderLeftWidth = 1;
            this._ShowgoodsPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ShowgoodsPanel.Style.BorderRightWidth = 1;
            this._ShowgoodsPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this._ShowgoodsPanel.Style.BorderTopWidth = 1;
            this._ShowgoodsPanel.Style.CornerDiameter = 4;
            this._ShowgoodsPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this._ShowgoodsPanel.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this._ShowgoodsPanel.TabIndex = 196;
            this._ShowgoodsPanel.Text = "[Voucher Information]";
            this._ShowgoodsPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ShowgoodsPanel.TitleImage")));
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridView1;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.Size = new System.Drawing.Size(774, 129);
            this.gridControlMaster.TabIndex = 2;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridControlMaster;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControlDetail.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlDetail.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlDetail.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlDetail.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControlDetail.Location = new System.Drawing.Point(3, 160);
            this.gridControlDetail.MainView = this.gridView2;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(780, 304);
            this.gridControlDetail.TabIndex = 3;
            this.gridControlDetail.UseEmbeddedNavigator = true;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.FixedLineWidth = 1;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridControlDetail;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // QueryVoucherStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "QueryVoucherStep";
            this.Size = new System.Drawing.Size(786, 467);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._ShowgoodsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gridControlMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel _ShowgoodsPanel;
    }
}
