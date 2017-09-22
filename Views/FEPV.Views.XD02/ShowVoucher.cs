using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicLanuage;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace FEPV.Views.XD02
{
    [SmartPart]
    public partial class ShowVoucher : UserControl
    {
        public ShowVoucher()
        {
            InitializeComponent();
            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "XD02", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.VouList.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }
            #endregion
        }
        public DataTable StockTable
        {
            set
            {
                VouList.DataSource = value;
                gridView1.BestFitColumns();
            }
        }
    }
}
