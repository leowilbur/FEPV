namespace FEPV.Views
{
    partial class VoucherDetailsView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtVoucherDetails = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dtMaster = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVoucherDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dtVoucherDetails, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtMaster, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.95652F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.04348F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 460);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtVoucherDetails
            // 
            this.dtVoucherDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVoucherDetails.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dtVoucherDetails.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dtVoucherDetails.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dtVoucherDetails.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dtVoucherDetails.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dtVoucherDetails.Location = new System.Drawing.Point(3, 126);
            this.dtVoucherDetails.MainView = this.gridView1;
            this.dtVoucherDetails.Name = "dtVoucherDetails";
            this.dtVoucherDetails.Size = new System.Drawing.Size(770, 331);
            this.dtVoucherDetails.TabIndex = 4;
            this.dtVoucherDetails.UseEmbeddedNavigator = true;
            this.dtVoucherDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.dtVoucherDetails;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // dtMaster
            // 
            this.dtMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtMaster.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.dtMaster.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dtMaster.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dtMaster.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dtMaster.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dtMaster.Location = new System.Drawing.Point(3, 3);
            this.dtMaster.MainView = this.gridView2;
            this.dtMaster.Name = "dtMaster";
            this.dtMaster.Size = new System.Drawing.Size(770, 117);
            this.dtMaster.TabIndex = 3;
            this.dtMaster.UseEmbeddedNavigator = true;
            this.dtMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.FixedLineWidth = 1;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.dtMaster;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // VoucherDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VoucherDetailsView";
            this.Size = new System.Drawing.Size(776, 460);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtVoucherDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl dtMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl dtVoucherDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;

    }
}
