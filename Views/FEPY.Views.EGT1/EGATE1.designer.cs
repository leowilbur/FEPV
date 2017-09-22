namespace FEPV.Views
{
    partial class EGATE1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EGATE1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTruck = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTruck = new System.Windows.Forms.TableLayoutPanel();
            this.barTruck = new System.Windows.Forms.ToolStrip();
            this.btnSearchTruck = new System.Windows.Forms.ToolStripButton();
            this.btnInTruck = new System.Windows.Forms.ToolStripButton();
            this.btnOutTruck = new System.Windows.Forms.ToolStripButton();
            this.btnWeightTruck = new System.Windows.Forms.ToolStripButton();
            this.btnUpWeightTruck = new System.Windows.Forms.ToolStripButton();
            this.btnPrintTruck = new System.Windows.Forms.ToolStripButton();
            this.btnBackTruck = new System.Windows.Forms.ToolStripButton();
            this.deckWorkspaceTruck = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtHandWeight = new System.Windows.Forms.TextBox();
            this.ledStationID = new UI.LxLedControl();
            this.lc1 = new UI.Controls.LoadingCircle();
            this.led1 = new UI.LxLedControl();
            this.tabPageShort = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelShort = new System.Windows.Forms.TableLayoutPanel();
            this.deckWorkspaceShort = new Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtHandWeight3 = new System.Windows.Forms.TextBox();
            this.ledStationID3 = new UI.LxLedControl();
            this.lc3 = new UI.Controls.LoadingCircle();
            this.led3 = new UI.LxLedControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.barShort = new System.Windows.Forms.ToolStrip();
            this.btnSearchShort = new System.Windows.Forms.ToolStripButton();
            this.btnInShort = new System.Windows.Forms.ToolStripButton();
            this.btnOutShort = new System.Windows.Forms.ToolStripButton();
            this.btnWeightShort = new System.Windows.Forms.ToolStripButton();
            this.btnUpWeightShort = new System.Windows.Forms.ToolStripButton();
            this.btnPrintShort = new System.Windows.Forms.ToolStripButton();
            this.btnBackShort = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this._txtMsg = new System.Windows.Forms.Label();
            this.timer4ComMonitor = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageTruck.SuspendLayout();
            this.tableLayoutPanelTruck.SuspendLayout();
            this.barTruck.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledStationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            this.tabPageShort.SuspendLayout();
            this.tableLayoutPanelShort.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledStationID3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).BeginInit();
            this.panel5.SuspendLayout();
            this.barShort.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTruck);
            this.tabControl1.Controls.Add(this.tabPageShort);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 487);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPageTruck
            // 
            this.tabPageTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tabPageTruck.Controls.Add(this.tableLayoutPanelTruck);
            this.tabPageTruck.Location = new System.Drawing.Point(4, 22);
            this.tabPageTruck.Name = "tabPageTruck";
            this.tabPageTruck.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTruck.Size = new System.Drawing.Size(1023, 461);
            this.tabPageTruck.TabIndex = 0;
            this.tabPageTruck.Text = "[车辆计划]";
            this.tabPageTruck.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTruck
            // 
            this.tableLayoutPanelTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tableLayoutPanelTruck.ColumnCount = 1;
            this.tableLayoutPanelTruck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTruck.Controls.Add(this.barTruck, 0, 0);
            this.tableLayoutPanelTruck.Controls.Add(this.deckWorkspaceTruck, 0, 2);
            this.tableLayoutPanelTruck.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanelTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTruck.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTruck.Name = "tableLayoutPanelTruck";
            this.tableLayoutPanelTruck.RowCount = 3;
            this.tableLayoutPanelTruck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelTruck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelTruck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTruck.Size = new System.Drawing.Size(1017, 455);
            this.tableLayoutPanelTruck.TabIndex = 21;
            // 
            // barTruck
            // 
            this.barTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barTruck.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barTruck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchTruck,
            this.btnInTruck,
            this.btnOutTruck,
            this.btnWeightTruck,
            this.btnUpWeightTruck,
            this.btnPrintTruck,
            this.btnBackTruck});
            this.barTruck.Location = new System.Drawing.Point(0, 0);
            this.barTruck.Name = "barTruck";
            this.barTruck.Size = new System.Drawing.Size(1017, 60);
            this.barTruck.TabIndex = 23;
            this.barTruck.Text = "toolStrip2";
            // 
            // btnSearchTruck
            // 
            this.btnSearchTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchTruck.Image")));
            this.btnSearchTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchTruck.Name = "btnSearchTruck";
            this.btnSearchTruck.Size = new System.Drawing.Size(110, 57);
            this.btnSearchTruck.Text = "查询";
            // 
            // btnInTruck
            // 
            this.btnInTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnInTruck.Image")));
            this.btnInTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInTruck.Name = "btnInTruck";
            this.btnInTruck.Size = new System.Drawing.Size(110, 57);
            this.btnInTruck.Text = "登记";
            // 
            // btnOutTruck
            // 
            this.btnOutTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnOutTruck.Image")));
            this.btnOutTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutTruck.Name = "btnOutTruck";
            this.btnOutTruck.Size = new System.Drawing.Size(110, 57);
            this.btnOutTruck.Text = "放行";
            // 
            // btnWeightTruck
            // 
            this.btnWeightTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnWeightTruck.Image")));
            this.btnWeightTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeightTruck.Name = "btnWeightTruck";
            this.btnWeightTruck.Size = new System.Drawing.Size(180, 57);
            this.btnWeightTruck.Text = "记忆称重";
            // 
            // btnUpWeightTruck
            // 
            this.btnUpWeightTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnUpWeightTruck.Image")));
            this.btnUpWeightTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpWeightTruck.Name = "btnUpWeightTruck";
            this.btnUpWeightTruck.Size = new System.Drawing.Size(180, 57);
            this.btnUpWeightTruck.Text = "重量上传";
            // 
            // btnPrintTruck
            // 
            this.btnPrintTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintTruck.Image")));
            this.btnPrintTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintTruck.Name = "btnPrintTruck";
            this.btnPrintTruck.Size = new System.Drawing.Size(180, 57);
            this.btnPrintTruck.Text = "打印磅单";
            // 
            // btnBackTruck
            // 
            this.btnBackTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnBackTruck.Image")));
            this.btnBackTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackTruck.Name = "btnBackTruck";
            this.btnBackTruck.Size = new System.Drawing.Size(110, 57);
            this.btnBackTruck.Text = "后退";
            // 
            // deckWorkspaceTruck
            // 
            this.deckWorkspaceTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceTruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceTruck.Location = new System.Drawing.Point(3, 123);
            this.deckWorkspaceTruck.Name = "deckWorkspaceTruck";
            this.deckWorkspaceTruck.Size = new System.Drawing.Size(1011, 329);
            this.deckWorkspaceTruck.TabIndex = 191;
            this.deckWorkspaceTruck.Text = "deckWorkspace1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtHandWeight);
            this.panel2.Controls.Add(this.ledStationID);
            this.panel2.Controls.Add(this.lc1);
            this.panel2.Controls.Add(this.led1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1011, 54);
            this.panel2.TabIndex = 192;
            // 
            // txtHandWeight
            // 
            this.txtHandWeight.Location = new System.Drawing.Point(325, 20);
            this.txtHandWeight.Name = "txtHandWeight";
            this.txtHandWeight.Size = new System.Drawing.Size(100, 21);
            this.txtHandWeight.TabIndex = 26;
            // 
            // ledStationID
            // 
            this.ledStationID.BackColor = System.Drawing.Color.Transparent;
            this.ledStationID.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID.BevelRate = 0.5F;
            this.ledStationID.BorderColor = System.Drawing.Color.Transparent;
            this.ledStationID.Dock = System.Windows.Forms.DockStyle.Right;
            this.ledStationID.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID.ForeColor = System.Drawing.Color.White;
            this.ledStationID.HighlightOpaque = ((byte)(50));
            this.ledStationID.Location = new System.Drawing.Point(919, 0);
            this.ledStationID.Name = "ledStationID";
            this.ledStationID.Size = new System.Drawing.Size(92, 54);
            this.ledStationID.TabIndex = 25;
            this.ledStationID.Text = "201";
            this.ledStationID.TotalCharCount = 3;
            // 
            // lc1
            // 
            this.lc1.Active = true;
            this.lc1.Color = System.Drawing.Color.Red;
            this.lc1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lc1.InnerCircleRadius = 8;
            this.lc1.Location = new System.Drawing.Point(225, 0);
            this.lc1.Name = "lc1";
            this.lc1.NumberSpoke = 24;
            this.lc1.OuterCircleRadius = 9;
            this.lc1.RotationSpeed = 100;
            this.lc1.Size = new System.Drawing.Size(41, 54);
            this.lc1.SpokeThickness = 4;
            this.lc1.StylePreset = UI.Controls.LoadingCircle.StylePresets.IE7;
            this.lc1.TabIndex = 22;
            this.lc1.Text = "lcFirst";
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.Transparent;
            this.led1.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.led1.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.led1.BevelRate = 0.5F;
            this.led1.BorderColor = System.Drawing.Color.Transparent;
            this.led1.Dock = System.Windows.Forms.DockStyle.Left;
            this.led1.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.led1.ForeColor = System.Drawing.Color.Yellow;
            this.led1.HighlightOpaque = ((byte)(50));
            this.led1.Location = new System.Drawing.Point(0, 0);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(225, 54);
            this.led1.TabIndex = 21;
            this.led1.Text = "     0.0";
            this.led1.TotalCharCount = 8;
            // 
            // tabPageShort
            // 
            this.tabPageShort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.tabPageShort.Controls.Add(this.tableLayoutPanelShort);
            this.tabPageShort.Location = new System.Drawing.Point(4, 22);
            this.tabPageShort.Name = "tabPageShort";
            this.tabPageShort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShort.Size = new System.Drawing.Size(1023, 461);
            this.tabPageShort.TabIndex = 2;
            this.tabPageShort.Text = "[短驳计划]";
            // 
            // tableLayoutPanelShort
            // 
            this.tableLayoutPanelShort.ColumnCount = 1;
            this.tableLayoutPanelShort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelShort.Controls.Add(this.deckWorkspaceShort, 0, 2);
            this.tableLayoutPanelShort.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanelShort.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanelShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelShort.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelShort.Name = "tableLayoutPanelShort";
            this.tableLayoutPanelShort.RowCount = 3;
            this.tableLayoutPanelShort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelShort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelShort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelShort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelShort.Size = new System.Drawing.Size(1017, 455);
            this.tableLayoutPanelShort.TabIndex = 0;
            // 
            // deckWorkspaceShort
            // 
            this.deckWorkspaceShort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.deckWorkspaceShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckWorkspaceShort.Location = new System.Drawing.Point(3, 123);
            this.deckWorkspaceShort.Name = "deckWorkspaceShort";
            this.deckWorkspaceShort.Size = new System.Drawing.Size(1011, 329);
            this.deckWorkspaceShort.TabIndex = 194;
            this.deckWorkspaceShort.Text = "deckWorkspace1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.panel4.Controls.Add(this.txtHandWeight3);
            this.panel4.Controls.Add(this.ledStationID3);
            this.panel4.Controls.Add(this.lc3);
            this.panel4.Controls.Add(this.led3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1011, 54);
            this.panel4.TabIndex = 193;
            // 
            // txtHandWeight3
            // 
            this.txtHandWeight3.Location = new System.Drawing.Point(329, 20);
            this.txtHandWeight3.Name = "txtHandWeight3";
            this.txtHandWeight3.Size = new System.Drawing.Size(100, 21);
            this.txtHandWeight3.TabIndex = 26;
            // 
            // ledStationID3
            // 
            this.ledStationID3.BackColor = System.Drawing.Color.Transparent;
            this.ledStationID3.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID3.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID3.BevelRate = 0.5F;
            this.ledStationID3.BorderColor = System.Drawing.Color.Transparent;
            this.ledStationID3.Dock = System.Windows.Forms.DockStyle.Right;
            this.ledStationID3.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID3.ForeColor = System.Drawing.Color.White;
            this.ledStationID3.HighlightOpaque = ((byte)(50));
            this.ledStationID3.Location = new System.Drawing.Point(919, 0);
            this.ledStationID3.Name = "ledStationID3";
            this.ledStationID3.Size = new System.Drawing.Size(92, 54);
            this.ledStationID3.TabIndex = 25;
            this.ledStationID3.Text = "201";
            this.ledStationID3.TotalCharCount = 3;
            // 
            // lc3
            // 
            this.lc3.Active = true;
            this.lc3.Color = System.Drawing.Color.Red;
            this.lc3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lc3.InnerCircleRadius = 8;
            this.lc3.Location = new System.Drawing.Point(225, 0);
            this.lc3.Name = "lc3";
            this.lc3.NumberSpoke = 24;
            this.lc3.OuterCircleRadius = 9;
            this.lc3.RotationSpeed = 100;
            this.lc3.Size = new System.Drawing.Size(41, 54);
            this.lc3.SpokeThickness = 4;
            this.lc3.StylePreset = UI.Controls.LoadingCircle.StylePresets.IE7;
            this.lc3.TabIndex = 22;
            this.lc3.Text = "lcFirst";
            // 
            // led3
            // 
            this.led3.BackColor = System.Drawing.Color.Transparent;
            this.led3.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.led3.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.led3.BevelRate = 0.5F;
            this.led3.BorderColor = System.Drawing.Color.Transparent;
            this.led3.Dock = System.Windows.Forms.DockStyle.Left;
            this.led3.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.led3.ForeColor = System.Drawing.Color.Yellow;
            this.led3.HighlightOpaque = ((byte)(50));
            this.led3.Location = new System.Drawing.Point(0, 0);
            this.led3.Name = "led3";
            this.led3.Size = new System.Drawing.Size(225, 54);
            this.led3.TabIndex = 21;
            this.led3.Text = "     0.0";
            this.led3.TotalCharCount = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.panel5.Controls.Add(this.barShort);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1011, 54);
            this.panel5.TabIndex = 195;
            // 
            // barShort
            // 
            this.barShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barShort.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barShort.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchShort,
            this.btnInShort,
            this.btnOutShort,
            this.btnWeightShort,
            this.btnUpWeightShort,
            this.btnPrintShort,
            this.btnBackShort});
            this.barShort.Location = new System.Drawing.Point(0, 0);
            this.barShort.Name = "barShort";
            this.barShort.Size = new System.Drawing.Size(1011, 54);
            this.barShort.TabIndex = 24;
            this.barShort.Text = "toolStrip2";
            // 
            // btnSearchShort
            // 
            this.btnSearchShort.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchShort.Image")));
            this.btnSearchShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchShort.Name = "btnSearchShort";
            this.btnSearchShort.Size = new System.Drawing.Size(110, 51);
            this.btnSearchShort.Text = "查询";
            // 
            // btnInShort
            // 
            this.btnInShort.Image = ((System.Drawing.Image)(resources.GetObject("btnInShort.Image")));
            this.btnInShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInShort.Name = "btnInShort";
            this.btnInShort.Size = new System.Drawing.Size(110, 51);
            this.btnInShort.Text = "登记";
            // 
            // btnOutShort
            // 
            this.btnOutShort.Image = ((System.Drawing.Image)(resources.GetObject("btnOutShort.Image")));
            this.btnOutShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutShort.Name = "btnOutShort";
            this.btnOutShort.Size = new System.Drawing.Size(110, 51);
            this.btnOutShort.Text = "放行";
            // 
            // btnWeightShort
            // 
            this.btnWeightShort.Image = ((System.Drawing.Image)(resources.GetObject("btnWeightShort.Image")));
            this.btnWeightShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeightShort.Name = "btnWeightShort";
            this.btnWeightShort.Size = new System.Drawing.Size(180, 51);
            this.btnWeightShort.Text = "记忆称重";
            // 
            // btnUpWeightShort
            // 
            this.btnUpWeightShort.Image = ((System.Drawing.Image)(resources.GetObject("btnUpWeightShort.Image")));
            this.btnUpWeightShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpWeightShort.Name = "btnUpWeightShort";
            this.btnUpWeightShort.Size = new System.Drawing.Size(180, 51);
            this.btnUpWeightShort.Text = "重量上传";
            // 
            // btnPrintShort
            // 
            this.btnPrintShort.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintShort.Image")));
            this.btnPrintShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintShort.Name = "btnPrintShort";
            this.btnPrintShort.Size = new System.Drawing.Size(180, 51);
            this.btnPrintShort.Text = "打印磅单";
            // 
            // btnBackShort
            // 
            this.btnBackShort.Image = ((System.Drawing.Image)(resources.GetObject("btnBackShort.Image")));
            this.btnBackShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackShort.Name = "btnBackShort";
            this.btnBackShort.Size = new System.Drawing.Size(110, 51);
            this.btnBackShort.Text = "后退";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._txtMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 21);
            this.panel1.TabIndex = 22;
            // 
            // _txtMsg
            // 
            this._txtMsg.AutoSize = true;
            this._txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtMsg.Location = new System.Drawing.Point(0, 0);
            this._txtMsg.Name = "_txtMsg";
            this._txtMsg.Size = new System.Drawing.Size(23, 12);
            this._txtMsg.TabIndex = 0;
            this._txtMsg.Text = "*_*";
            // 
            // timer4ComMonitor
            // 
            this.timer4ComMonitor.Enabled = true;
            this.timer4ComMonitor.Interval = 500;
            this.timer4ComMonitor.Tick += new System.EventHandler(this.timer4ComMonitor_Tick);
            // 
            // EGATE1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "EGATE1";
            this.TabText = "EGATE";
            this.Text = "EGATE";
            this.tabControl1.ResumeLayout(false);
            this.tabPageTruck.ResumeLayout(false);
            this.tableLayoutPanelTruck.ResumeLayout(false);
            this.tableLayoutPanelTruck.PerformLayout();
            this.barTruck.ResumeLayout(false);
            this.barTruck.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledStationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            this.tabPageShort.ResumeLayout(false);
            this.tableLayoutPanelShort.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledStationID3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.barShort.ResumeLayout(false);
            this.barShort.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTruck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTruck;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceTruck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _txtMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer4ComMonitor;
        private UI.LxLedControl led1;
        private UI.Controls.LoadingCircle lc1;
        private UI.LxLedControl ledStationID;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox txtHandWeight;
        private System.Windows.Forms.TabPage tabPageShort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelShort;
        private Microsoft.Practices.CompositeUI.WinForms.DeckWorkspace deckWorkspaceShort;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtHandWeight3;
        private UI.LxLedControl ledStationID3;
        private UI.Controls.LoadingCircle lc3;
        private UI.LxLedControl led3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip barTruck;
        private System.Windows.Forms.ToolStripButton btnSearchTruck;
        private System.Windows.Forms.ToolStripButton btnInTruck;
        private System.Windows.Forms.ToolStripButton btnOutTruck;
        private System.Windows.Forms.ToolStripButton btnWeightTruck;
        private System.Windows.Forms.ToolStripButton btnUpWeightTruck;
        private System.Windows.Forms.ToolStripButton btnPrintTruck;
        private System.Windows.Forms.ToolStripButton btnBackTruck;
        private System.Windows.Forms.ToolStrip barShort;
        private System.Windows.Forms.ToolStripButton btnSearchShort;
        private System.Windows.Forms.ToolStripButton btnInShort;
        private System.Windows.Forms.ToolStripButton btnOutShort;
        private System.Windows.Forms.ToolStripButton btnWeightShort;
        private System.Windows.Forms.ToolStripButton btnUpWeightShort;
        private System.Windows.Forms.ToolStripButton btnPrintShort;
        private System.Windows.Forms.ToolStripButton btnBackShort;
    }
}