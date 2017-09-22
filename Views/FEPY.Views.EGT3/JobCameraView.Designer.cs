namespace FEPV.Views
{
    partial class JobCameraView
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
            this.ribbonClientPanel2 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this._ParameterPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pictureBoxShow = new System.Windows.Forms.PictureBox();
            this.ribbonClientPanel2.SuspendLayout();
            this._ParameterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonClientPanel2
            // 
            this.ribbonClientPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel2.Controls.Add(this._ParameterPanel);
            this.ribbonClientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel2.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel2.Name = "ribbonClientPanel2";
            this.ribbonClientPanel2.ShowFocusRectangle = true;
            this.ribbonClientPanel2.Size = new System.Drawing.Size(696, 522);
            // 
            // 
            // 
            this.ribbonClientPanel2.Style.BackColor = System.Drawing.Color.Transparent;
            this.ribbonClientPanel2.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.ribbonClientPanel2.Style.BackColorGradientAngle = 90;
            this.ribbonClientPanel2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.ribbonClientPanel2.Style.BorderBottomWidth = 1;
            this.ribbonClientPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ribbonClientPanel2.Style.BorderLeftWidth = 1;
            this.ribbonClientPanel2.Style.BorderRightWidth = 1;
            this.ribbonClientPanel2.Style.BorderTopWidth = 1;
            this.ribbonClientPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ribbonClientPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.ribbonClientPanel2.TabIndex = 23;
            // 
            // _ParameterPanel
            // 
            this._ParameterPanel.BackColor = System.Drawing.Color.Transparent;
            this._ParameterPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ParameterPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ParameterPanel.Controls.Add(this.pictureBoxShow);
            this._ParameterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ParameterPanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._ParameterPanel.Location = new System.Drawing.Point(0, 0);
            this._ParameterPanel.Name = "_ParameterPanel";
            this._ParameterPanel.Size = new System.Drawing.Size(696, 522);
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
            this._ParameterPanel.TabIndex = 180;
            this._ParameterPanel.Text = "[视频显示区]";
            // 
            // pictureBoxShow
            // 
            this.pictureBoxShow.Location = new System.Drawing.Point(16, 3);
            this.pictureBoxShow.Name = "pictureBoxShow";
            this.pictureBoxShow.Size = new System.Drawing.Size(321, 389);
            this.pictureBoxShow.TabIndex = 250;
            this.pictureBoxShow.TabStop = false;
            // 
            // JobCameraView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.Controls.Add(this.ribbonClientPanel2);
            this.Name = "JobCameraView";
            this.Size = new System.Drawing.Size(696, 522);
            this.ribbonClientPanel2.ResumeLayout(false);
            this._ParameterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel _ParameterPanel;
        private System.Windows.Forms.PictureBox pictureBoxShow;
    }
}
