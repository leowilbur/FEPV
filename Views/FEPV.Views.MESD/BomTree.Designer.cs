namespace FEPV.Views
{
    partial class BomTree
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("V001 版本描述V001");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("V002 版本描述V002");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("SN-8432", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("V001 版本描述V001", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("V002 版本描述V002");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("CB602", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("V003 版本描述V003");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("V004 版本描述V004");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("CB603", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.CheckBoxes = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "Node7";
            treeNode1.Text = "V001 版本描述V001";
            treeNode2.Name = "Node8";
            treeNode2.Text = "V002 版本描述V002";
            treeNode3.Name = "Node6";
            treeNode3.Text = "SN-8432";
            treeNode4.Name = "Node2";
            treeNode4.Text = "V001 版本描述V001";
            treeNode5.Name = "Node3";
            treeNode5.Text = "V002 版本描述V002";
            treeNode6.Name = "Node0";
            treeNode6.Text = "CB602";
            treeNode7.Name = "Node4";
            treeNode7.Text = "V003 版本描述V003";
            treeNode8.Name = "Node5";
            treeNode8.Text = "V004 版本描述V004";
            treeNode9.Name = "Node1";
            treeNode9.Text = "CB603";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9});
            this.treeView.Size = new System.Drawing.Size(265, 150);
            this.treeView.TabIndex = 0;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            // 
            // BomTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.Controls.Add(this.treeView);
            this.Name = "BomTree";
            this.Size = new System.Drawing.Size(265, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
    }
}
