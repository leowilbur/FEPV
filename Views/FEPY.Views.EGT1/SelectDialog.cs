using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FEPV.BLL;
using BasicLanuage;
using MIS.Utility;

namespace FEPV.Views
{
    public partial class SelectDialog : Infrastructure.StyleForm
    {
        public SelectDialog()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "EGT1", this.Name);
            dtListDeskClerk = rep.GetMISReport("WF_MIS_AC_PermissionDeskClerk",
                new string[] { "Language" }, new object[] { MyLanguage.Language }).Tables[0];
        }

        ReportBiz rep = new ReportBiz();

        bool rValue = false;
        private void btYes_Click(object sender, EventArgs e)
        {
            rValue = true;
            if (!string.IsNullOrEmpty(UnloadingPoint.Text.Trim()))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select the unloading point!");
            }
        }

        private void btNO_Click(object sender, EventArgs e)
        {
            rValue = false;
            this.Close();
        }

        public string Discharge
        {
            get { return UnloadingPoint.SelectedValue.ToString(); }
        }

        public bool RValue { get { return rValue; } }

        public DataTable dtListDeskClerk
        {
            set
            {
                UnloadingPoint.DataSource = value;
                UnloadingPoint.DisplayMember = "UnloadingPoint";
                UnloadingPoint.ValueMember = "ID";
            }
        }
    }
}
