using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class VoucherDetailsView : UserControl, IVoucherDetailsView
    {
        public VoucherDetailsView()
        {
            InitializeComponent();
            #region language
            //dtVoucherDetails
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "AUDI", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.dtVoucherDetails.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }
            //dtMaster
            gridData = CultureLanuage.GridHeader(dsgrid, "gridView2");
            if (gridData != null)
            {
                this.dtMaster.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView2, "gridView2", dsgrid);
                gridView2.BestFitColumns();
            }
            #endregion
        }

        #region IVoucherDetailsView Members

        public DataTable listVoucherDetails
        {
            set
            {
                //gridView1.Columns.Clear();
                dtVoucherDetails.DataSource = value;
                gridView1.BestFitColumns();
            }
        }

        public DataTable listMaster
        {
            set
            {
                //gridView2.Columns.Clear();
                dtMaster.DataSource = value;
                gridView2.BestFitColumns();
            }
        }

        #endregion
    }
}
