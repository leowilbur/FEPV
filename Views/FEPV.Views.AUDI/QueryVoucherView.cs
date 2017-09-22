using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class QueryVoucherView : UserControl, IQueryVoucherView
    {
        public QueryVoucherView()
        {
            InitializeComponent();
            this.idatebegin.Text = DateTime.Now.ToString("yyyy-MM-01");
            dtVoucher.DoubleClick += new System.EventHandler(this.dtVoucher_DoubleClick);
            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "AUDI", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.dtVoucher.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }
            #endregion

        }



        #region IQueryVoucherView Members

        DateTime? StartTime
        {
            get
            {
                if (string.IsNullOrEmpty(idatebegin.Text))
                    return null;
                else
                    return Convert.ToDateTime(idatebegin.Text);
            }
        }

        DateTime? EndTime
        {
            get
            {
                if (string.IsNullOrEmpty(this.idateEnd.Text))
                    return null;
                else
                    return Convert.ToDateTime(idateEnd.Text);
            }
        }
        public string[] Parameters
        {

            get { return new string[] { "MT", "MaterialNO", "Plant", "Batch", "B", "E" }; }
        }

        public object[] Values
        {

            get { return new object[] { iMT.Text.Trim().ToUpper(), iSMaterial.Text.Trim().ToUpper(), iSplant.Text.Trim().ToUpper(), iSbatch.Text.Trim().ToUpper(), StartTime, EndTime }; }
        }

        public DataTable listVoucher
        {
            set
            {
                //gridView1.Columns.Clear();
                dtVoucher.DataSource = value;
                gridView1.BestFitColumns();
            }
        }

        public event EventHandler eventGetSelectVoucher;

        public string selectVoucher
        {
            get
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
                return ((DataRow)rows[0])[0].ToString();
            }
        }

        #endregion

        private void dtVoucher_DoubleClick(object sender, EventArgs e)
        {
            eventGetSelectVoucher(this, EventArgs.Empty);
        }
    }
}
