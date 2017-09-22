using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;

namespace TESTFORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolTipController1.AutoPopDelay = 1000;
            Console.WriteLine("new writeTip");

            toolTipController1.Appearance.BackColor = Color.Red;

            toolTipController1.Appearance.ForeColor = Color.Black;
            toolTipController1.Appearance.Options.UseBackColor = true;
            toolTipController1.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            // superTooltip.TooltipDuration = duration;
            toolTipController1.ShowHint("^_^：你是我的小苹果", ToolTipLocation.LeftBottom, PointToScreen(new Point { X = this.Location.X + 10, Y = this.Location.Y + this.Height - 40 - 20 }));
        }
    }
}
