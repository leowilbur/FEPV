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

namespace FEPV.Views.POLY
{
    [SmartPart]
    public partial class UnsettledJobsParamentersView : UserControl, IUnsettledJobsParamenters
    {
        public UnsettledJobsParamentersView()
        {
            InitializeComponent();
            this.deVoufd.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01");
            CultureLanuage.ApplyResourcesFrom(this, "MFBF", this.Name);
        }

        #region IUnsettledJobsParamenters Members

        public string[] Paramenters
        {
            get { return new string[] { "MaterialNO", "Plant", "Loc", "Batch", "B", "E" }; }
        }

        public DateTime? Begin
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(deVoufd.Text);
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
                    return Convert.ToDateTime(deVoutd.Text);
                }
                catch
                {
                    return null;
                }
            }
        }

        public object[] Values
        {
            get
            {
                return new object[] {
                                     txtMaterialNO.Text.Trim().ToUpper(),
                                     txtPlant.Text.Trim().ToUpper(),                                     
                                     txtLoc.Text.Trim().ToUpper(),
                                     txtBatch.Text.Trim().ToUpper(),
                                     Begin,
                                     End,
                                     };
            }
        }

        #endregion


    }
}
