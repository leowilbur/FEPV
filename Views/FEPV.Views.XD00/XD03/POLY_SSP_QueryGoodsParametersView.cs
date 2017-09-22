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
    public partial class POLY_SSP_QueryGoodsParametersView : UserControl, IQueryGoodsParametersView
    {
        public POLY_SSP_QueryGoodsParametersView()
        {
            InitializeComponent();
            deStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            deEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            CultureLanuage.ApplyResourcesFrom(this, "XD00", this.Name);
        }

        private void cbMaterial_EditValueChanged(object sender, EventArgs e)
        {
            eventGetBatch(this, new GetBatchArgs { Start = Start, End = End, MaterialNO = cbMaterial.Text, Plant = txtVoucherID.Text });
        }

        DateTime? Start
        {
            get
            {
                if (deStartTime.Text == "")
                    return null;
                else
                    return Convert.ToDateTime(deStartTime.Text);
            }
        }

        DateTime? End
        {
            get
            {
                if (deEndTime.Text == "")
                    return null;
                else
                    return Convert.ToDateTime(deEndTime.Text);
            }
        }

        #region IQueryGoodsParametersView Members

        public bool IsReady
        {
            get
            {
                if (string.IsNullOrEmpty(cbMaterial.Text) || string.IsNullOrEmpty(cbBatch.Text))
                    return false;
                else
                    return true;
            }
        }

        public DataTable listMaterial
        {
            set
            {
                cbMaterial.Properties.DataSource = value;
                cbMaterial.Properties.Columns.Clear();
                cbMaterial.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialNO", 20));
                cbMaterial.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProdSpec", 40));
                cbMaterial.Properties.DisplayMember = "MaterialNO";
                cbMaterial.Properties.ValueMember = "MaterialNO";
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "B", "E", "MaterialNO", "VoucherID", "Batch", "BarCode" }; }
        }

        public object[] Values
        {
            get { return new object[] { Start, End, cbMaterial.Text, txtVoucherID.Text.Trim(), cbBatch.Text, txtBarcode.Text }; }
        }

        public DataTable listBatch
        {
            set
            {
                cbBatch.Properties.DataSource = value;
                cbBatch.Properties.Columns.Clear();
                cbBatch.Properties.DisplayMember = "批次";
                cbBatch.Properties.ValueMember = "批次";
            }
        }

        public event EventHandler eventGetBatch;

        #endregion
    }
}
