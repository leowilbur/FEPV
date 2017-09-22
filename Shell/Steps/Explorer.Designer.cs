namespace Shell.Steps
{
    partial class Explorer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.cmdTree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lcExp = new UI.Controls.LoadingCircle();
            this.bgwLoadTree = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // cmdTree
            // 
            this.cmdTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.cmdTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdTree.ImageIndex = 0;
            this.cmdTree.ImageList = this.imageList;
            this.cmdTree.Location = new System.Drawing.Point(0, 0);
            this.cmdTree.Name = "cmdTree";
            this.cmdTree.SelectedImageIndex = 0;
            this.cmdTree.Size = new System.Drawing.Size(219, 432);
            this.cmdTree.TabIndex = 2;
            this.cmdTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.cmdTree_NodeMouseDoubleClick);
            this.cmdTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.cmdTree_AfterCollapse);
            this.cmdTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.cmdTree_AfterExpand);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "FC.jpg");
            this.imageList.Images.SetKeyName(1, "NF.jpg");
            this.imageList.Images.SetKeyName(2, "FO.jpg");
            // 
            // lcExp
            // 
            this.lcExp.Active = true;
            this.lcExp.BackColor = System.Drawing.Color.Transparent;
            this.lcExp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lcExp.BackgroundImage")));
            this.lcExp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lcExp.Color = System.Drawing.Color.Fuchsia;
            this.lcExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcExp.InnerCircleRadius = 5;
            this.lcExp.Location = new System.Drawing.Point(0, 0);
            this.lcExp.Name = "lcExp";
            this.lcExp.NumberSpoke = 12;
            this.lcExp.OuterCircleRadius = 11;
            this.lcExp.RotationSpeed = 100;
            this.lcExp.Size = new System.Drawing.Size(219, 432);
            this.lcExp.SpokeThickness = 2;
            this.lcExp.StylePreset = UI.Controls.LoadingCircle.StylePresets.MacOSX;
            this.lcExp.TabIndex = 3;
            this.lcExp.Visible = false;
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(219, 432);
            this.CloseButton = false;
            this.Controls.Add(this.lcExp);
            this.Controls.Add(this.cmdTree);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Explorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "Explorer";
            this.Text = "Explorer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView cmdTree;
        private System.Windows.Forms.ImageList imageList;
        private UI.Controls.LoadingCircle lcExp;
        private System.ComponentModel.BackgroundWorker bgwLoadTree;

    }
}