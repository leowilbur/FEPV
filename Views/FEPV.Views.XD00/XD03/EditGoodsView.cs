using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class EditGoodsView : UserControl, IEditGoodsView
    {
        public EditGoodsView()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "XD00", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.gcEGoodslist.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }
            #endregion
        }

        IEditGoodsParametersView _EditGoodsParametersView;

        #region IEditGoodsView Members

        public DataTable dtSelectGoods
        {
            get
            {
                return new DataTable();
            }
            set
            {
                //gridView1.Columns.Clear();
                gcEGoodslist.DataSource = value;
                gridView1.ClearSelection();
                gridView1.BestFitColumns();
            }
        }
        

        public IEditGoodsParametersView EditGoodsParametersView
        {
            set
            {
                _EditGoodsParametersView = value;
                WorkSpaceEidtGoodsParameters.Show(_EditGoodsParametersView);

                WorkSpaceEidtGoodsParameters.Refresh();
            }
            get
            {
                return _EditGoodsParametersView;
            }
        }

        #endregion

    }
}
