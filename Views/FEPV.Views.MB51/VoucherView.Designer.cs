namespace FEPV.Views
{
    partial class VoucherView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoucherView));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VouListData = new DevExpress.XtraGrid.GridControl();
            this.gridData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VouListData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.VouListData;
            this.gridView1.Name = "gridView1";
            // 
            // VouListData
            // 
            this.VouListData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VouListData.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.VouListData.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.VouListData.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.VouListData.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.VouListData.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.VouListData.Location = new System.Drawing.Point(0, 0);
            this.VouListData.MainView = this.gridData;
            this.VouListData.Name = "VouListData";
            this.VouListData.Size = new System.Drawing.Size(731, 373);
            this.VouListData.TabIndex = 3;
            this.VouListData.UseEmbeddedNavigator = true;
            this.VouListData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridData,
            this.gridView1,
            this.gridView2});
            // 
            // gridData
            // 
            this.gridData.FixedLineWidth = 1;
            this.gridData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridData.GridControl = this.VouListData;
            this.gridData.Name = "gridData";
            this.gridData.OptionsBehavior.Editable = false;
            this.gridData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridData.OptionsSelection.MultiSelect = true;
            this.gridData.OptionsView.ColumnAutoWidth = false;
            this.gridData.OptionsView.RowAutoHeight = true;
            this.gridData.OptionsView.ShowGroupPanel = false;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.VouListData);
            this.xtraTabPage1.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(731, 373);
            this.xtraTabPage1.Text = "Data list";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.VouListData;
            this.gridView2.Name = "gridView2";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(737, 401);
            this.xtraTabControl1.TabIndex = 16;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // VoucherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "VoucherView";
            this.Size = new System.Drawing.Size(737, 401);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VouListData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraGrid.GridControl VouListData;
        public DevExpress.XtraGrid.Views.Grid.GridView gridData;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        public DevExpress.XtraTab.XtraTabControl xtraTabControl1;

    }
}