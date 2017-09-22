namespace Infrastructure
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.superTooltip = new DevExpress.Utils.ToolTipController();
            this.SuspendLayout();
            // 
            // superTooltip
            // 
            this.superTooltip.AllowHtmlText = true;
            this.superTooltip.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.superTooltip.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.superTooltip.Appearance.Options.UseBackColor = true;
            this.superTooltip.ImageIndex = 1;
            this.superTooltip.Rounded = true;
            this.superTooltip.ToolTipStyle = DevExpress.Utils.ToolTipStyle.WindowsXP;
            this.superTooltip.ToolTipType = DevExpress.Utils.ToolTipType.Standard;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("ËÎÌו", 9.95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController superTooltip;

    }
}