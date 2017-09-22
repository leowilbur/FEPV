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
    public partial class QueryVoucherStep : UserControl, IQueryVoucherView
    {
        public QueryVoucherStep()
        {
            InitializeComponent();
            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "MFBF", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.gridControlMaster.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }
            gridData = CultureLanuage.GridHeader(dsgrid, "gridView2");
            if (gridData != null)
            {
                this.gridControlDetail.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView2, "gridView2", dsgrid);
                gridView2.BestFitColumns();
            }
            #endregion 
        }

        decimal _SelectTotalNum;
        #region IQueryVoucherView Members

        public DataTable Master
        {
            set
            {
                //this.gridView1.Columns.Clear();
                this.gridControlMaster.DataSource = value;
                gridView1.BestFitColumns();
            }
        }

        public DataTable Detail
        {
            set
            {
                //this.gridView2.Columns.Clear();
                this.gridControlDetail.DataSource = value;
                gridView2.BestFitColumns();
            }
        }

        public string[] SelectGoods
        {
            get
            {
                return GetSelectedGoods();
            }
        }

        public string SelectVoucherID
        {
            get
            {
                return GetSelectedVoucherID();
            }
        }

        public decimal SelectTotalNum
        {
            get { return _SelectTotalNum; }
        }

        #endregion

        public string GetSelectedVoucherID()
        {
            List<string> barcodes = new List<string>();
            ArrayList rows = new ArrayList();

            // Add the selected rows to the list.
            int rowCount = gridView1.SelectedRowsCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (gridView1.GetSelectedRows()[i] >= 0)
                    rows.Add(gridView1.GetDataRow(gridView1.GetSelectedRows()[i]));
            }
            ///
            string voucherID = string.Empty;
            foreach (DataRow r in rows)
            {
                voucherID = (string)r[0];
            }
            return voucherID;
        }

        public string[] GetSelectedGoods()
        {
            List<string> barcodes = new List<string>();
            _SelectTotalNum = 0m;
            ArrayList rows = new ArrayList();

            // Add the selected rows to the list.
            int rowCount = gridView2.SelectedRowsCount;
            if (rowCount <= 0)
                return barcodes.ToArray();

            for (int i = 0; i < rowCount; i++)
            {
                if (gridView2.GetSelectedRows()[i] >= 0)
                    rows.Add(gridView2.GetDataRow(gridView2.GetSelectedRows()[i]));
            }
            ///
            foreach (DataRow r in rows)
            {
                barcodes.Add((string)r["BarCode"]);
                _SelectTotalNum += (decimal)r["Num"];
            }
            return barcodes.ToArray();
        }




    }
}
