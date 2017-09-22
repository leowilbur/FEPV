namespace FEPV.Views
{
    partial class MasterShow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.VouListDetails = new DevExpress.XtraGrid.GridControl();
            this.gridDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VouListMaster = new DevExpress.XtraGrid.GridControl();
            this.gridMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VouListDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VouListMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.VouListMaster, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.VouListDetails, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.91304F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.08696F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 463);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // VouListDetails
            // 
            this.VouListDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VouListDetails.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.VouListDetails.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.VouListDetails.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.VouListDetails.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.VouListDetails.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.VouListDetails.Location = new System.Drawing.Point(3, 160);
            this.VouListDetails.MainView = this.gridDetails;
            this.VouListDetails.Name = "VouListDetails";
            this.VouListDetails.Size = new System.Drawing.Size(803, 300);
            this.VouListDetails.TabIndex = 5;
            this.VouListDetails.UseEmbeddedNavigator = true;
            this.VouListDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDetails});
            // 
            // gridDetails
            // 
            this.gridDetails.FixedLineWidth = 1;
            this.gridDetails.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridDetails.GridControl = this.VouListDetails;
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.OptionsBehavior.Editable = false;
            this.gridDetails.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridDetails.OptionsSelection.MultiSelect = true;
            this.gridDetails.OptionsView.ColumnAutoWidth = false;
            this.gridDetails.OptionsView.RowAutoHeight = true;
            this.gridDetails.OptionsView.ShowGroupPanel = false;
            // 
            // VouListMaster
            // 
            this.VouListMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VouListMaster.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.VouListMaster.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.VouListMaster.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.VouListMaster.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.VouListMaster.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.VouListMaster.Location = new System.Drawing.Point(3, 3);
            this.VouListMaster.MainView = this.gridMaster;
            this.VouListMaster.Name = "VouListMaster";
            this.VouListMaster.Size = new System.Drawing.Size(803, 151);
            this.VouListMaster.TabIndex = 4;
            this.VouListMaster.UseEmbeddedNavigator = true;
            this.VouListMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMaster});
            // 
            // gridMaster
            // 
            this.gridMaster.FixedLineWidth = 1;
            this.gridMaster.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridMaster.GridControl = this.VouListMaster;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.OptionsBehavior.Editable = false;
            this.gridMaster.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridMaster.OptionsSelection.MultiSelect = true;
            this.gridMaster.OptionsView.ColumnAutoWidth = false;
            this.gridMaster.OptionsView.RowAutoHeight = true;
            this.gridMaster.OptionsView.ShowGroupPanel = false;
            // 
            // MasterShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MasterShow";
            this.Size = new System.Drawing.Size(809, 463);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VouListDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VouListMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public DevExpress.XtraGrid.GridControl VouListDetails;
        public DevExpress.XtraGrid.GridControl VouListMaster;
        public DevExpress.XtraGrid.Views.Grid.GridView gridDetails;
        public DevExpress.XtraGrid.Views.Grid.GridView gridMaster;
    }
}