using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using XPTable.Models;

namespace FEG.MES
{
    public partial class FEIS : Infrastructure.BaseForm
    {
        public FEIS()
        {
            InitializeComponent();
            foreach (Control c in panel1.Controls)
            {
                c.Click += new EventHandler(c_Click);
                c.Tag = string.Empty;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
        }

        public override void OnHotKey(Keys key)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            #region Task Table 初始化
            /*
            TaskTable.BeginUpdate();

            TextColumn titleColumn = new TextColumn();
            titleColumn.Alignment = XPTable.Models.ColumnAlignment.Center;
            titleColumn.Text = "标题";
            titleColumn.ToolTipText = "标题";
            titleColumn.Width = 60;
            titleColumn.Editable = false;


            TextColumn contentColumn = new TextColumn();
            contentColumn.Alignment = XPTable.Models.ColumnAlignment.Left;
            contentColumn.Editable = false;
            contentColumn.Text = "内容";
            contentColumn.ToolTipText = "内容";
            contentColumn.Width = 600;


            this.TaskTable.ColumnModel = new ColumnModel(new Column[] {titleColumn,
																	  contentColumn});

            this.TaskTable.TableModel = new TableModel(new Row[] {	new Row(new Cell[] { new Cell("NO 1"),
																					     new Cell("刘子歌夺得中国游泳队第一金")}),
                                                                    new Row(new Cell[] { new Cell("NO 2"),
																					     new Cell("杨威夺得北京奥运个人第二金 ")}),
                                                                    new Row(new Cell[] { new Cell("NO 3"),
																					     new Cell("杜丽连续两届奥运均有金牌斩获")}),
                                                                   new Row(new Cell[] {  new Cell("NO 4"),
																					     new Cell("水立方见证菲尔普斯神话")}),
																    new Row(new Cell[] { new Cell("NO 5"),
																						 new Cell("张娟娟历史性夺得女子射箭首金")})
                                                                 });

            this.TaskTable.HeaderRenderer = new XPTable.Renderers.GradientHeaderRenderer();
            this.TaskTable.TableModel.RowHeight += 3;
            this.TaskTable.FullRowSelect = true;

            this.TaskTable.EndUpdate();
             */
            #endregion
        }

        public string L0 { set { label0.Tag = value; } }
        public string L1 { set { label1.Tag = value; } }
        public string L2 { set { label2.Tag = value; } }
        public string L3 { set { label3.Tag = value; } }
        public string L4 { set { label4.Tag = value; } }
        public string L5 { set { label5.Tag = value; } }
        public string L6 { set { label6.Tag = value; } }
        public string L7 { set { label7.Tag = value; } }
        public string L8 { set { label8.Tag = value; } }
        public string L9 { set { label9.Tag = value; } }
        public string L10 { set { label10.Tag = value; } }
        public string L11 { set { label11.Tag = value; } }
        public string L12 { set { label12.Tag = value; } }
        public string L12_1 { set { label12_1.Tag = value; } }
        public string L13 { set { label13.Tag = value; } }
        public string L14 { set { label14.Tag = value; } }
        public string L15 { set { label15.Tag = value; } }
        public string L16 { set { label16.Tag = value; } }
        public string L17 { set { label17.Tag = value; } }
        public string L18 { set { label18.Tag = value; } }
        public string L19 { set { label19.Tag = value; } }
        public string L20 { set { label20.Tag = value; } }
        public string L21 { set { label21.Tag = value; } }
        public string L22 { set { label22.Tag = value; } }
        public string L23 { set { label23.Tag = value; } }
        public string L24 { set { label24.Tag = value; } }
        public string L25 { set { label25.Tag = value; } }
        public string L26 { set { label26.Tag = value; } }
        public string L27 { set { label27.Tag = value; } }
        public string L28 { set { label28.Tag = value; } }
        public string L29 { set { label29.Tag = value; } }
        public string L30 { set { label30.Tag = value; } }
        public string L31 { set { label31.Tag = value; } }
        public string L32 { set { label32.Tag = value; } }

        void c_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Infrastructure.CmdBridge.RunCode(((Label)sender).Tag.ToString());
            }
        }
    }
}
