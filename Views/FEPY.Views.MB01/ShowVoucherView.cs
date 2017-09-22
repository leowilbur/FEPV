using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using BasicLanuage;

namespace FEPV.Views
{
    [SmartPart]
    public partial class ShowVoucherView : UserControl
    {
        public ShowVoucherView()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "MB01", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.VouList.DataSource = gridData;
                gridView1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
            }
            #endregion
        }
        public DataTable StockTable
        {
            set
            {
                //gridView1.Columns.Clear();
                VouList.DataSource = value;
                gridView1.BestFitColumns();
            }
        }
    }
}
