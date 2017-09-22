namespace Infrastructure
{
    partial class StyleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleForm));
            this.TopArea = new System.Windows.Forms.Panel();
            this.TEXT = new System.Windows.Forms.Label();
            this.CLOSE = new System.Windows.Forms.Label();
            this.RIGHT = new System.Windows.Forms.Label();
            this.LEFT = new System.Windows.Forms.Label();
            this.panelLft = new System.Windows.Forms.Panel();
            this.panelBtt = new System.Windows.Forms.Panel();
            this.panelRgt = new System.Windows.Forms.Panel();
            this.superTooltip = new DevExpress.Utils.ToolTipController();
            this.TopArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopArea
            // 
            this.TopArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(198)))));
            this.TopArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TopArea.BackgroundImage")));
            this.TopArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopArea.Controls.Add(this.TEXT);
            this.TopArea.Controls.Add(this.CLOSE);
            this.TopArea.Controls.Add(this.RIGHT);
            this.TopArea.Controls.Add(this.LEFT);
            this.TopArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopArea.Location = new System.Drawing.Point(0, 0);
            this.TopArea.MinimumSize = new System.Drawing.Size(100, 21);
            this.TopArea.Name = "TopArea";
            this.TopArea.Size = new System.Drawing.Size(400, 24);
            this.TopArea.TabIndex = 0;
            this.TopArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopArea_MouseDown);
            // 
            // TEXT
            // 
            this.TEXT.AutoSize = true;
            this.TEXT.BackColor = System.Drawing.Color.Transparent;
            this.TEXT.Font = new System.Drawing.Font("ËÎÌו", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TEXT.ForeColor = System.Drawing.Color.White;
            this.TEXT.Location = new System.Drawing.Point(25, 5);
            this.TEXT.Name = "TEXT";
            this.TEXT.Size = new System.Drawing.Size(29, 12);
            this.TEXT.TabIndex = 3;
            this.TEXT.Text = "FEIT";
            // 
            // CLOSE
            // 
            this.CLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CLOSE.BackColor = System.Drawing.Color.Transparent;
            this.CLOSE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CLOSE.Image = ((System.Drawing.Image)(resources.GetObject("CLOSE.Image")));
            this.CLOSE.Location = new System.Drawing.Point(361, -2);
            this.CLOSE.Name = "CLOSE";
            this.CLOSE.Size = new System.Drawing.Size(20, 23);
            this.CLOSE.TabIndex = 2;
            this.CLOSE.Click += new System.EventHandler(this.CLOSE_Click);
            // 
            // RIGHT
            // 
            this.RIGHT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RIGHT.BackColor = System.Drawing.Color.Transparent;
            this.RIGHT.Image = ((System.Drawing.Image)(resources.GetObject("RIGHT.Image")));
            this.RIGHT.Location = new System.Drawing.Point(375, 0);
            this.RIGHT.Name = "RIGHT";
            this.RIGHT.Size = new System.Drawing.Size(25, 22);
            this.RIGHT.TabIndex = 1;
            // 
            // LEFT
            // 
            this.LEFT.BackColor = System.Drawing.Color.Transparent;
            this.LEFT.Image = ((System.Drawing.Image)(resources.GetObject("LEFT.Image")));
            this.LEFT.Location = new System.Drawing.Point(0, 0);
            this.LEFT.Name = "LEFT";
            this.LEFT.Size = new System.Drawing.Size(25, 22);
            this.LEFT.TabIndex = 0;
            // 
            // panelLft
            // 
            this.panelLft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelLft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLft.Location = new System.Drawing.Point(0, 24);
            this.panelLft.Name = "panelLft";
            this.panelLft.Size = new System.Drawing.Size(1, 226);
            this.panelLft.TabIndex = 1;
            // 
            // panelBtt
            // 
            this.panelBtt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBtt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtt.Location = new System.Drawing.Point(1, 249);
            this.panelBtt.Name = "panelBtt";
            this.panelBtt.Size = new System.Drawing.Size(399, 1);
            this.panelBtt.TabIndex = 1;
            // 
            // panelRgt
            // 
            this.panelRgt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRgt.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRgt.Location = new System.Drawing.Point(399, 24);
            this.panelRgt.Name = "panelRgt";
            this.panelRgt.Size = new System.Drawing.Size(1, 225);
            this.panelRgt.TabIndex = 3;
            // 
            // superTooltip
            // 
            this.superTooltip.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.superTooltip.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.superTooltip.Appearance.Options.UseBackColor = true;
            this.superTooltip.Rounded = true;
            this.superTooltip.ToolTipStyle = DevExpress.Utils.ToolTipStyle.WindowsXP;
            // 
            // StyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.panelRgt);
            this.Controls.Add(this.panelBtt);
            this.Controls.Add(this.panelLft);
            this.Controls.Add(this.TopArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "StyleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Activated += new System.EventHandler(this.StyleForm_Activated);
            this.Deactivate += new System.EventHandler(this.StyleForm_Deactivate);
            this.TopArea.ResumeLayout(false);
            this.TopArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopArea;
        private System.Windows.Forms.Label RIGHT;
        private System.Windows.Forms.Label LEFT;
        private System.Windows.Forms.Label CLOSE;
        private System.Windows.Forms.Label TEXT;
        private System.Windows.Forms.Panel panelLft;
        private System.Windows.Forms.Panel panelBtt;
        private System.Windows.Forms.Panel panelRgt;
        private DevExpress.Utils.ToolTipController superTooltip;
    }
}