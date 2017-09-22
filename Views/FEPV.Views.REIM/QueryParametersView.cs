using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;

namespace FEPV.Views
{
    public partial class QueryParametersView : UserControl, IQueryParametersView
    {
        public QueryParametersView()
        {
            InitializeComponent();
            this.idatebegin.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cbCenterID.EditValueChanged += new System.EventHandler(this.cbCenterID_EditValueChanged);
        }

        #region IQueryParametersView Members

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
        public string[] Parameters
        {
            get { return new string[] { "ADate", "CostCenter", "MaterialNO", "Plant", "Batch" }; }
        }

        public object[] Values
        {
            get { return new object[] { StartTime, this.cbCenterID.Text.Trim(), this.iSMaterial.Text.Trim().ToUpper(), this.iSplant.Text.Trim().ToUpper(), this.iSbatch.Text.Trim().ToUpper() }; }
        }

        #endregion

        #region IQueryParametersView Members
        public DataTable dtCenterID
        {
            set
            {

                cbCenterID.Properties.DataSource = value;
                cbCenterID.Properties.DisplayMember = "CenterID";
                cbCenterID.Properties.ValueMember = "CenterID";
            }
        }
        #endregion

        UIReporting report = new UIReporting();
        private void cbCenterID_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            dt.Merge(report.GetMISReport("Q_GetMaterialFORCenterID", new string[] { "CenterID" }, new object[] { cbCenterID.Text }).Tables[0]);

            iSMaterial.Properties.DataSource = dt;
            iSMaterial.Properties.DisplayMember = "MaterialNO";
            iSMaterial.Properties.ValueMember = "MaterialNO";
        }
    }
}
