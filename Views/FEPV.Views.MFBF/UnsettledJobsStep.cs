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
    public partial class UnsettledJobsStep : UserControl, IUnsettledJobsView
    {
        public UnsettledJobsStep()
        {
            InitializeComponent();
            gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);

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

        #region IUnsettledJobsView Members

        public DataTable tbJobs
        {
            set
            {
                //gridView1.Columns.Clear();
                this.gridControl1.DataSource = value;
                gridView1.BestFitColumns();

            }
        }

        IUnsettledJobsParamenters _paramentersView;

        public IUnsettledJobsParamenters ParamentersView
        {
            get
            {
                return _paramentersView;
            }
            set
            {
                _paramentersView = value;
                this.WorkSpace.Show(_paramentersView);
            }
        }

        public event EventHandler eventVoucherSelected;
        #endregion

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            SearchVoucher();
        }

        private void SearchVoucher()
        {
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

            DataRow row = (DataRow)rows[0];

            string voucherID = (string)row[0];

            if (eventVoucherSelected != null)
                eventVoucherSelected(this, new Voucher4SearchArgs { VoucherID = voucherID });
        }
    }
}
