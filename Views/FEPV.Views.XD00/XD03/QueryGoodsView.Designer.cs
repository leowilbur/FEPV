namespace FEPV.Views
{
    partial class QueryGoodsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryGoodsView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._ShowgoodsPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gcGoodslist = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.deckWorkspace1 = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this._ParameterPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.WorkSpaceParameters = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.tableLayoutPanel1.SuspendLayout();
            this._ShowgoodsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGoodslist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this._ParameterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._ShowgoodsPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._ParameterPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.73138F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.26862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 443);
            this.tableLayoutPanel1.TabIndex = 10000;
            // 
            // _ShowgoodsPanel
            // 
            this._ShowgoodsPanel.BackColor = System.Drawing.Color.Transparent;
            this._ShowgoodsPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ShowgoodsPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ShowgoodsPanel.Controls.Add(this.gcGoodslist);
            this._ShowgoodsPanel.Controls.Add(this.deckWorkspace1);
            this._ShowgoodsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ShowgoodsPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._ShowgoodsPanel.Location = new System.Drawing.Point(3, 148);
            this._ShowgoodsPanel.Name = "_ShowgoodsPanel";
            this._ShowgoodsPanel.Size = new System.Drawing.Size(780, 292);
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
            this._ShowgoodsPanel.TabIndex = 195;
            this._ShowgoodsPanel.Text = "[Goods Information]";
            this._ShowgoodsPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ShowgoodsPanel.TitleImage")));
            // 
            // gcGoodslist
            // 
            this.gcGoodslist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGoodslist.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcGoodslist.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcGoodslist.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcGoodslist.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcGoodslist.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcGoodslist.Location = new System.Drawing.Point(0, 0);
            this.gcGoodslist.MainView = this.gridView1;
            this.gcGoodslist.Name = "gcGoodslist";
            this.gcGoodslist.Size = new System.Drawing.Size(774, 270);
            this.gcGoodslist.TabIndex = 7;
            this.gcGoodslist.UseEmbeddedNavigator = true;
            this.gcGoodslist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gcGoodslist;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // deckWorkspace1
            // 
            this.deckWorkspace1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.deckWorkspace1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspace1.Location = new System.Drawing.Point(0, 0);
            this.deckWorkspace1.Name = "deckWorkspace1";
            this.deckWorkspace1.Size = new System.Drawing.Size(774, 270);
            this.deckWorkspace1.TabIndex = 0;
            this.deckWorkspace1.Text = "deckWorkspace1";
            // 
            // _ParameterPanel
            // 
            this._ParameterPanel.BackColor = System.Drawing.Color.Transparent;
            this._ParameterPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ParameterPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ParameterPanel.Controls.Add(this.WorkSpaceParameters);
            this._ParameterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ParameterPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._ParameterPanel.Location = new System.Drawing.Point(3, 3);
            this._ParameterPanel.Name = "_ParameterPanel";
            this._ParameterPanel.Size = new System.Drawing.Size(780, 139);
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
            this._ParameterPanel.TabIndex = 192;
            this._ParameterPanel.Text = "[Parameters]";
            this._ParameterPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ParameterPanel.TitleImage")));
            // 
            // WorkSpaceParameters
            // 
            this.WorkSpaceParameters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.WorkSpaceParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpaceParameters.Location = new System.Drawing.Point(0, 0);
            this.WorkSpaceParameters.Name = "WorkSpaceParameters";
            this.WorkSpaceParameters.Size = new System.Drawing.Size(774, 117);
            this.WorkSpaceParameters.TabIndex = 0;
            this.WorkSpaceParameters.Text = "deckWorkspace1";
            // 
            // QueryGoodsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("SimSun", 9.75F);
            this.Name = "QueryGoodsView";
            this.Size = new System.Drawing.Size(786, 443);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._ShowgoodsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGoodslist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this._ParameterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel _ParameterPanel;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace WorkSpaceParameters;
        private DevComponents.DotNetBar.Controls.GroupPanel _ShowgoodsPanel;
        private DevExpress.XtraGrid.GridControl gcGoodslist;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspace1;

    }
}
