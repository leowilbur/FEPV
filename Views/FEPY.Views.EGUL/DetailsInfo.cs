using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class DetailsInfo : Infrastructure.StyleForm
    {
        public DetailsInfo()
        {
            InitializeComponent();
        }

        public DataTable Plan4Table
        {
            set
            {
                gridView1.Columns.Clear();
                gridControl1.DataSource = value;
                gridView1.BestFitColumns();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "Excel export data";
            sfd.FileName = DateTime.Now.ToString("Log scheduleyyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(sfd.FileName);
                MessageBox.Show(@"To export successfully " + DateTime.Now.ToString("Log scheduleyyyyMMdd") + ".xls", "提示信息");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
