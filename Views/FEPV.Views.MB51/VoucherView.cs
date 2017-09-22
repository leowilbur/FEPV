using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FEPV.BLL;
using BasicLanuage;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace FEPV.Views
{
    public partial class VoucherView : UserControl
    {
       
        public VoucherView()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "MB51", this.Name);
            DataTable gvData = CultureLanuage.GridHeader(dsgrid, "gridData");
            if (gvData != null)
            {
                this.VouListData.DataSource = gvData;
                gridData.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridData, "gridData", dsgrid);
            }
            #endregion
        }
      
        public DataTable StockTable
        {
            set
            {
                VouListData.DataSource = value;
            }
        }
    }
}
