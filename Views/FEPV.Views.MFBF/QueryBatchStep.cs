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
    public partial class QueryBatchStep : UserControl, IQueryBatchView
    {
        public QueryBatchStep()
        {
            InitializeComponent();

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

        IQueryBatchParamenters _IQueryBatchParamenters;

        #region IQueryBatchView Members

        public DataTable tbBatches
        {
            set
            {
                gridControl1.DataSource = value;
                gridView1.Columns["StartDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["StartDate"].DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
                gridView1.Columns["EndDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["EndDate"].DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
                gridView1.BestFitColumns();
            }
        }

        public IQueryBatchParamenters ParamentersView
        {
            get
            {
                return _IQueryBatchParamenters;
            }
            set
            {
                _IQueryBatchParamenters = value;
                WorkSpace.Show(_IQueryBatchParamenters);
            }
        }

        public event EventHandler eventBatchSelected;
        #endregion

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            SearchGoods();
        }

        private void SearchGoods()
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            ArrayList rows = new ArrayList();

            // Add the selected rows to the list.
            int rowCount = gridView1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            for (int i = 0; i < rowCount; i++)
            {
                if (gridView1.GetSelectedRows()[i] >= 0)
                    rows.Add(gridView1.GetDataRow(gridView1.GetSelectedRows()[i]));
            }
            ///
            DataRow row = (DataRow)rows[0];
            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }
            paramenters.Add("VoucherID", ParamentersView.VouID);
            ///
            if (eventBatchSelected != null)
                eventBatchSelected(this, new Batch4VoucherArgs { Paramenters = paramenters });
        }

    }
}
