using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace FEPV.Views
{
    [SmartPart]
    public partial class ShowVoucherView : UserControl, IShowVoucherView
    {
        public ShowVoucherView()
        {
            InitializeComponent();
        }

        #region IShowVoucherView Members

        public DataTable dtVoucher
        {
            set
            {
                gridView1.Columns.Clear();
                this.VouList.DataSource = value;
                gridView1.BestFitColumns();
            }
        }

        #endregion
    }
}
