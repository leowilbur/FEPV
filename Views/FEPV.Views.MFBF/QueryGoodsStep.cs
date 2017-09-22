using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using System.Collections;
using BasicLanuage;

namespace FEPV.Views
{
    [SmartPart]
    public partial class QueryGoodsStep : UserControl, IQueryGoodsView
    {
        public QueryGoodsStep()
        {
            InitializeComponent();

            gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(gridView1_SelectionChanged);
            gridView1.CustomDrawCell += GridView1_CustomDrawCell;

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "MFBF", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.gridControl1.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }
            #endregion 
        }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridView1.IsRowSelected(e.RowHandle))
            {
                e.Appearance.Options.UseForeColor = true;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.BackColor = Color.DeepSkyBlue;
            }
        }

        void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            string[] BarCodes = GetSelectedGoodsBarCodes();
            ShowSelectGoodsInformation(this, new ShowSelectGoodsInformationArgs { TotalCount = BarCodes.Count(), TotalWeight = TOTAL });
        }

        IVoucherView _IVoucherView;
        #region IQueryGoodsView Members
        public event EventHandler ShowSelectGoodsInformation;

        public DataTable tbGoods
        {
            set
            {
                if (value != null)
                {
                    gridControl1.DataSource = value;
                    gridView1.BestFitColumns();
                    //gridView1.ClearSelection();
                }

            }
        }

        public IVoucherView ParamentersView
        {
            get
            {
                return _IVoucherView;
            }
            set
            {
                _IVoucherView = value;
                WorkSpace.Show(_IVoucherView);
            }
        }

        public string[] BarCode2Pick
        {
            get
            {
                return GetSelectedGoodsBarCodes();
            }
        }

        public decimal TotalNum
        {
            get { return TOTAL; }
        }

        #endregion

        decimal TOTAL = 0m;

        public string[] GetSelectedGoodsBarCodes()
        {
            List<string> barcodes = new List<string>();
            TOTAL = 0m;
            ArrayList rows = new ArrayList();

            // Add the selected rows to the list.
            int rowCount = gridView1.SelectedRowsCount;
            if (rowCount <= 0)
                return barcodes.ToArray();

            for (int i = 0; i < rowCount; i++)
            {
                if (gridView1.GetSelectedRows()[i] >= 0)
                    rows.Add(gridView1.GetDataRow(gridView1.GetSelectedRows()[i]));
            }
            ///
            foreach (DataRow r in rows)
            {
                barcodes.Add((string)r[0]);
                TOTAL += (decimal)r["Num"];
            }
            return barcodes.ToArray();
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.gridView1.ClearSelection();
                this.gridControl1.Refresh();
            }
        }

    }
}

