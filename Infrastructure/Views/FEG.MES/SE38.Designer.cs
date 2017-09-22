namespace FEG.MES
{
    partial class SE38
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SE38));
            this.ToolBar = new DevComponents.DotNetBar.Bar();
            this.btSearch = new DevComponents.DotNetBar.ButtonItem();
            this._iSpec = new DevExpress.XtraEditors.GroupControl();
            this._iEnabled = new DevExpress.XtraEditors.CheckEdit();
            this._iScript = new ICSharpCode.TextEditor.TextEditorControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this._ParameterPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btScriptAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btScriptChange = new DevExpress.XtraEditors.SimpleButton();
            this.btScriptDelete = new DevExpress.XtraEditors.SimpleButton();
            this._iTCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lcExp = new UI.Controls.LoadingCircle();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmdTree = new System.Windows.Forms.TreeView();
            this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddNote = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditNote = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelNote = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwLoadTree = new System.ComponentModel.BackgroundWorker();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.bsTCodes = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._iSpec)).BeginInit();
            this._iSpec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._iEnabled.Properties)).BeginInit();
            this._ParameterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._iTCode.Properties)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.treeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTCodes)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btSearch});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(878, 26);
            this.ToolBar.Stretch = true;
            this.ToolBar.TabIndex = 0;
            this.ToolBar.TabStop = false;
            this.ToolBar.Text = "bar1";
            // 
            // btSearch
            // 
            this.btSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btSearch.Image = ((System.Drawing.Image)(resources.GetObject("btSearch.Image")));
            this.btSearch.ImagePaddingHorizontal = 8;
            this.btSearch.Name = "btSearch";
            this.btSearch.Text = "Search(&S)";
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // _iSpec
            // 
            this._iSpec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._iSpec.Controls.Add(this._iEnabled);
            this._iSpec.Controls.Add(this._iScript);
            this._iSpec.Location = new System.Drawing.Point(207, 142);
            this._iSpec.Name = "_iSpec";
            this._iSpec.Size = new System.Drawing.Size(660, 304);
            this._iSpec.TabIndex = 1;
            // 
            // _iEnabled
            // 
            this._iEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._iEnabled.Location = new System.Drawing.Point(429, 1);
            this._iEnabled.Name = "_iEnabled";
            this._iEnabled.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this._iEnabled.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this._iEnabled.Properties.Appearance.Options.UseBackColor = true;
            this._iEnabled.Properties.Appearance.Options.UseForeColor = true;
            this._iEnabled.Properties.Caption = "Enabled";
            this._iEnabled.Size = new System.Drawing.Size(135, 19);
            this._iEnabled.TabIndex = 7;
            this._iEnabled.Click += new System.EventHandler(this._iEnabledChanged);
            // 
            // _iScript
            // 
            this._iScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this._iScript.IsReadOnly = false;
            this._iScript.Location = new System.Drawing.Point(2, 22);
            this._iScript.Name = "_iScript";
            this._iScript.ShowSpaces = true;
            this._iScript.ShowTabs = true;
            this._iScript.Size = new System.Drawing.Size(656, 280);
            this._iScript.TabIndex = 177;
            this._iScript.Text = "hello = \"Hello VSX!!!\"\r\n\r\nif not True:\r\n    print 1;\r\n    print 2;\r\nelse:\r\n    pr" +
    "int 3;\r\n    print 4;\r\nprint 5;\r\n\r\nprint hello";
            this._iScript.TextChanged += new System.EventHandler(this._iScript_TextChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "FC.jpg");
            this.imageList.Images.SetKeyName(1, "NF.jpg");
            this.imageList.Images.SetKeyName(2, "FO.jpg");
            // 
            // _ParameterPanel
            // 
            this._ParameterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ParameterPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this._ParameterPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this._ParameterPanel.Controls.Add(this.btScriptAdd);
            this._ParameterPanel.Controls.Add(this.btScriptChange);
            this._ParameterPanel.Controls.Add(this.btScriptDelete);
            this._ParameterPanel.Controls.Add(this._iTCode);
            this._ParameterPanel.Controls.Add(this.lcExp);
            this._ParameterPanel.Controls.Add(this.labelControl1);
            this._ParameterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this._ParameterPanel.Location = new System.Drawing.Point(207, 28);
            this._ParameterPanel.Name = "_ParameterPanel";
            this._ParameterPanel.Size = new System.Drawing.Size(660, 109);
            // 
            // 
            // 
            this._ParameterPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
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
            this._ParameterPanel.TabIndex = 4;
            this._ParameterPanel.Text = "[Application]";
            this._ParameterPanel.TitleImage = ((System.Drawing.Image)(resources.GetObject("_ParameterPanel.TitleImage")));
            // 
            // btScriptAdd
            // 
            this.btScriptAdd.Location = new System.Drawing.Point(79, 50);
            this.btScriptAdd.Name = "btScriptAdd";
            this.btScriptAdd.Size = new System.Drawing.Size(64, 21);
            this.btScriptAdd.TabIndex = 10;
            this.btScriptAdd.Text = "Create";
            // 
            // btScriptChange
            // 
            this.btScriptChange.Location = new System.Drawing.Point(166, 50);
            this.btScriptChange.Name = "btScriptChange";
            this.btScriptChange.Size = new System.Drawing.Size(64, 21);
            this.btScriptChange.TabIndex = 9;
            this.btScriptChange.Text = "Change";
            this.btScriptChange.Click += new System.EventHandler(this.btScriptChange_Click);
            // 
            // btScriptDelete
            // 
            this.btScriptDelete.Location = new System.Drawing.Point(254, 50);
            this.btScriptDelete.Name = "btScriptDelete";
            this.btScriptDelete.Size = new System.Drawing.Size(64, 21);
            this.btScriptDelete.TabIndex = 8;
            this.btScriptDelete.Text = "Delete";
            this.btScriptDelete.Click += new System.EventHandler(this.btScriptDelete_Click);
            // 
            // _iTCode
            // 
            this._iTCode.Location = new System.Drawing.Point(79, 13);
            this._iTCode.Name = "_iTCode";
            this._iTCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._iTCode.Properties.NullText = "";
            this._iTCode.Properties.ShowFooter = false;
            this._iTCode.Properties.ShowHeader = false;
            this._iTCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this._iTCode.Size = new System.Drawing.Size(239, 20);
            this._iTCode.TabIndex = 6;
            // 
            // lcExp
            // 
            this.lcExp.Active = true;
            this.lcExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lcExp.BackColor = System.Drawing.Color.Transparent;
            this.lcExp.Color = System.Drawing.Color.Blue;
            this.lcExp.InnerCircleRadius = 5;
            this.lcExp.Location = new System.Drawing.Point(605, 12);
            this.lcExp.Name = "lcExp";
            this.lcExp.NumberSpoke = 12;
            this.lcExp.OuterCircleRadius = 11;
            this.lcExp.RotationSpeed = 100;
            this.lcExp.Size = new System.Drawing.Size(42, 21);
            this.lcExp.SpokeThickness = 2;
            this.lcExp.StylePreset = UI.Controls.LoadingCircle.StylePresets.MacOSX;
            this.lcExp.TabIndex = 5;
            this.lcExp.Text = "loadingCircle1";
            this.lcExp.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Program";
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.groupPanel1.Controls.Add(this.cmdTree);
            this.groupPanel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(5, 28);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(199, 419);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "[System directory]";
            this.groupPanel1.TitleImage = ((System.Drawing.Image)(resources.GetObject("groupPanel1.TitleImage")));
            // 
            // cmdTree
            // 
            this.cmdTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.cmdTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmdTree.ContextMenuStrip = this.treeMenu;
            this.cmdTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdTree.ImageIndex = 0;
            this.cmdTree.ImageList = this.imageList;
            this.cmdTree.Location = new System.Drawing.Point(0, 0);
            this.cmdTree.Name = "cmdTree";
            this.cmdTree.SelectedImageIndex = 0;
            this.cmdTree.Size = new System.Drawing.Size(193, 395);
            this.cmdTree.TabIndex = 4;
            this.cmdTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.cmdTree_AfterCollapse);
            this.cmdTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.cmdTree_AfterExpand);
            this.cmdTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdTree_MouseDown);
            // 
            // treeMenu
            // 
            this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddNote,
            this.menuEditNote,
            this.menuDelNote});
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(114, 70);
            // 
            // menuAddNote
            // 
            this.menuAddNote.Name = "menuAddNote";
            this.menuAddNote.Size = new System.Drawing.Size(113, 22);
            this.menuAddNote.Text = "Add";
            this.menuAddNote.Click += new System.EventHandler(this.menuAddNote_Click);
            // 
            // menuEditNote
            // 
            this.menuEditNote.Image = ((System.Drawing.Image)(resources.GetObject("menuEditNote.Image")));
            this.menuEditNote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuEditNote.Name = "menuEditNote";
            this.menuEditNote.Size = new System.Drawing.Size(113, 22);
            this.menuEditNote.Text = "Edit";
            this.menuEditNote.Click += new System.EventHandler(this.menuEditNote_Click);
            // 
            // menuDelNote
            // 
            this.menuDelNote.Name = "menuDelNote";
            this.menuDelNote.Size = new System.Drawing.Size(113, 22);
            this.menuDelNote.Text = "Delete";
            this.menuDelNote.Click += new System.EventHandler(this.menuDelNote_Click);
            // 
            // bgwLoadTree
            // 
            this.bgwLoadTree.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadTree_DoWork);
            this.bgwLoadTree.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadTree_RunWorkerCompleted);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = null;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // SE38
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 458);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this._ParameterPanel);
            this.Controls.Add(this._iSpec);
            this.Controls.Add(this.ToolBar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SE38";
            this.TabText = "SE38";
            this.Text = "SE38";
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._iSpec)).EndInit();
            this._iSpec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._iEnabled.Properties)).EndInit();
            this._ParameterPanel.ResumeLayout(false);
            this._ParameterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._iTCode.Properties)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.treeMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsTCodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar ToolBar;
        private DevExpress.XtraEditors.GroupControl _iSpec;
        private System.Windows.Forms.ImageList imageList;
        private DevComponents.DotNetBar.ButtonItem btSearch;
        private DevComponents.DotNetBar.Controls.GroupPanel _ParameterPanel;
        private UI.Controls.LoadingCircle lcExp;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit _iTCode;
        private DevExpress.XtraEditors.CheckEdit _iEnabled;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.TreeView cmdTree;
        private DevExpress.XtraEditors.SimpleButton btScriptDelete;
        private DevExpress.XtraEditors.SimpleButton btScriptAdd;
        private DevExpress.XtraEditors.SimpleButton btScriptChange;
        private System.ComponentModel.BackgroundWorker bgwLoadTree;
        private System.Windows.Forms.BindingSource bsTCodes;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private System.Windows.Forms.ContextMenuStrip treeMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAddNote;
        private System.Windows.Forms.ToolStripMenuItem menuEditNote;
        private System.Windows.Forms.ToolStripMenuItem menuDelNote;
        private ICSharpCode.TextEditor.TextEditorControl _iScript;
    }
}