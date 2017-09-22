namespace FEPV.Views
{
    partial class EditGoodsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGoodsView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._ShowgoodsPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gcEGoodslist = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._ParameterPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.WorkSpaceEidtGoodsParameters = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.tableLayoutPanel1.SuspendLayout();
            this._ShowgoodsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEGoodslist)).BeginInit();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.27539F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.72461F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _ShowgoodsPanel
            // 
            this._ShowgoodsPanel.BackColor = System.Drawing.Color.Transparent;
            this._ShowgoodsPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ShowgoodsPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ShowgoodsPanel.Controls.Add(this.gcEGoodslist);
            this._ShowgoodsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ShowgoodsPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._ShowgoodsPanel.Location = new System.Drawing.Point(3, 207);
            this._ShowgoodsPanel.Name = "_ShowgoodsPanel";
            this._ShowgoodsPanel.Size = new System.Drawing.Size(780, 233);
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
            this._ShowgoodsPanel.TabIndex = 197;
            this._ShowgoodsPanel.Text = "[Goods Information]";
            this._ShowgoodsPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ShowgoodsPanel.TitleImage")));
            // 
            // gcEGoodslist
            // 
            this.gcEGoodslist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEGoodslist.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcEGoodslist.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcEGoodslist.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcEGoodslist.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcEGoodslist.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcEGoodslist.Location = new System.Drawing.Point(0, 0);
            this.gcEGoodslist.MainView = this.gridView1;
            this.gcEGoodslist.Name = "gcEGoodslist";
            this.gcEGoodslist.Size = new System.Drawing.Size(774, 211);
            this.gcEGoodslist.TabIndex = 195;
            this.gcEGoodslist.UseEmbeddedNavigator = true;
            this.gcEGoodslist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gcEGoodslist;
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
            this._ParameterPanel.Controls.Add(this.WorkSpaceEidtGoodsParameters);
            this._ParameterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ParameterPanel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this._ParameterPanel.Location = new System.Drawing.Point(3, 3);
            this._ParameterPanel.Name = "_ParameterPanel";
            this._ParameterPanel.Size = new System.Drawing.Size(780, 198);
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
            this._ParameterPanel.TabIndex = 193;
            this._ParameterPanel.Text = "[Parameter]";
            this._ParameterPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ParameterPanel.TitleImage")));
            // 
            // WorkSpaceEidtGoodsParameters
            // 
            this.WorkSpaceEidtGoodsParameters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.WorkSpaceEidtGoodsParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpaceEidtGoodsParameters.Location = new System.Drawing.Point(0, 0);
            this.WorkSpaceEidtGoodsParameters.Name = "WorkSpaceEidtGoodsParameters";
            this.WorkSpaceEidtGoodsParameters.Size = new System.Drawing.Size(774, 176);
            this.WorkSpaceEidtGoodsParameters.TabIndex = 1;
            this.WorkSpaceEidtGoodsParameters.Text = "deckWorkspace1";
            // 
            // EditGoodsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("SimSun", 9.75F);
            this.Name = "EditGoodsView";
            this.Size = new System.Drawing.Size(786, 443);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._ShowgoodsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEGoodslist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this._ParameterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel _ParameterPanel;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace WorkSpaceEidtGoodsParameters;
        private DevComponents.DotNetBar.Controls.GroupPanel _ShowgoodsPanel;
        private DevExpress.XtraGrid.GridControl gcEGoodslist;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;



    }
}
