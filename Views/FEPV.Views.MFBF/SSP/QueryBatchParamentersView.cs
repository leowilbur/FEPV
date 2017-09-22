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
namespace FEPV.Views.SSP
{
    [SmartPart]
    public partial class QueryBatchParamentersView : UserControl, IQueryBatchParamenters
    {
        public QueryBatchParamentersView()
        {
            InitializeComponent();
            deBStartTime.Text = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
            deBEndTime.Text = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyy-MM-dd HH:mm:ss");
            CultureLanuage.ApplyResourcesFrom(this, "MFBF", this.Name);
        }

        #region IQueryBatchParamenters Members
        public DataTable dtPlant
        {
            get
            {
                return new DataTable();
            }
            set
            {
            }
        }

        public DataTable dtGrade
        {
            set { }
        }

        public string[] Paramenters
        {
            get { return new string[] { "B", "E", "MaterialNO", "Plant", "Loc", "Batch", "VoucherID", "BarCode" }; }
        }

        public DateTime? Begin
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(deBStartTime.Text);
                }
                catch
                {
                    return null;
                }
            }
        }

        public DateTime? End
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(deBEndTime.Text);
                }
                catch
                {
                    return null;
                }
            }
        }

        public string Batch
        {
            get
            {
                string _batch = string.Empty;
                StringBuilder batch = new StringBuilder();
                if (cbBGrade.Text == "" && txtBGrades.Text == "" && txtLine.Text == "")
                {
                    return _batch;
                }
                else
                {
                    if (cbBGrade.Text != "")
                        batch.Append(cbBGrade.Text.Trim().ToUpper().PadRight(2, '-'));
                    else
                        batch.Append("__");

                    if (txtBGrades.Text != "")
                        batch.Append(txtBGrades.Text.Trim().ToUpper().PadRight(2, '-'));
                    else
                        batch.Append("__");

                    if (txtLine.Text != "")
                        batch.Append(txtLine.Text.Trim().ToUpper().PadRight(2, '-'));
                    else
                        batch.Append("__");
                }
                _batch = batch + "--";
                Console.WriteLine(_batch);
                return _batch;
            }
        }

        public object[] Values
        {

            get
            {
                return new object[] {
                                     Begin,
                                     End,
                                     cbBMaterial.Text.Trim().ToUpper(),
                                     cbBPlant.Text.Trim().ToUpper(),                                    
                                     txtLoc.Text.Trim(),
                                     Batch,
                                     txtBVoucher.Text.Trim().ToUpper(),
                                     txtBarCode.Text.Trim().ToUpper()
                                     };
            }
        }

        #endregion

        #region IQueryBatchParamenters Members

        public string VouID
        {
            get { return txtBVoucher.Text.Trim(); }
        }

        #endregion

    }
}
