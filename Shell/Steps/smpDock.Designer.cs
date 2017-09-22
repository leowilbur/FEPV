namespace Shell.Steps
{
    partial class smpDock
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
            this.DockArea = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.SuspendLayout();
            // 
            // DockArea
            // 
            this.DockArea.ActiveAutoHideContent = null;
            this.DockArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DockArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockArea.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.DockArea.Location = new System.Drawing.Point(0, 0);
            this.DockArea.Name = "DockArea";
            this.DockArea.ShowDocumentIcon = true;
            this.DockArea.Size = new System.Drawing.Size(613, 371);
            this.DockArea.TabIndex = 2;
            // 
            // smpDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DockArea);
            this.Name = "smpDock";
            this.Size = new System.Drawing.Size(613, 371);
            this.ResumeLayout(false);

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel DockArea;

    }
}
