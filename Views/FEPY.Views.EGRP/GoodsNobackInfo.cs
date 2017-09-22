using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class GoodsNobackInfo : UserControl
    {
        public GoodsNobackInfo()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGRP", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewGoods1");
            if (gridData != null)
            {
                this.gcGoods.DataSource = gridData;
                gridViewGoods1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewGoods1, "gridViewGoods1", dsgrid);
            }
            #endregion
        }

        public DataTable Plan4GoodsTable
        {
            set
            {
                gcGoods.DataSource = value;
                gridViewGoods1.BestFitColumns();
            }
        }

        public void GoodsExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "ToExcel";
            sfd.FileName = "No Back Items Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridViewGoods1.ExportToXls(sfd.FileName);
                MessageBox.Show(@"Success" + "No Back Items Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls", "Prompt information");
            }
        }
    }
}
