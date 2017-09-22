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
namespace FEPV.Views
{
    public partial class ParameterView : UserControl
    {
        public ParameterView()
        {
            InitializeComponent();
            Init();
            CultureLanuage.ApplyResourcesFrom(this, "MB51", this.Name);
            dtListCostCenter = report.GetMISReport("Q_ListCostCenter", new string[] { }, new object[] { }).Tables[0];
        }
        void Init()
        {
            double hours = DateTime.Today.Hour;
            double minutes = DateTime.Today.Minute;
            double seconds = DateTime.Today.Second;
            dateEditB.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00");
            dateEditE.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 23:59:59");
        }

        UIReporting report = new UIReporting();
        
        public string[] Parameter
        {
            get { return new string[] { "BeginDate", "EndDate", "CenterID", "MaterialNO", "plant", "Batch", "ReqUserID", "ALL", "pageIndex", "pageSize" }; }
        }

        public object[] Values
        {
            get { return new object[] { begindate, enddate, CenterID, MaterialNO, Plant, Batch, UserID, ALL, 1, 500 }; }
        }

        public DateTime? begindate
        {
            get
            {
                if (this.dateEditB.Text.Trim() == "")
                    return null;
                else
                    return Convert.ToDateTime(this.dateEditB.Text);
            }
        }
        // End date
        public DateTime? enddate
        {
            get
            {
                if (this.dateEditE.Text.Trim() == "")
                    return null;
                else
                    return Convert.ToDateTime(this.dateEditE.Text);
            }
        }
        // All 
        public bool ALL
        {
            get
            {
                if (this.chkAll.Checked)
                    return true;
                else return false;
            }
        }
        // CenterID
        public string CenterID
        {
            get
            {
                if (this.cbCostcenter.Text.Trim() == "")
                    return "";
                else
                    return cbCostcenter.SelectedValue.ToString();
            }
        }

        public string MaterialNO
        {
            get
            {
                if (txtMaterials.Text.Trim() == "")
                    return "";
                else
                    return txtMaterials.Text.Trim();
            }
        }

        public string Plant
        {
            get
            {
                if (txtPlant.Text.Trim() == "")
                    return "";
                else
                    return txtPlant.Text.Trim();
            }
        }
        
        public string Batch
        {
            get
            {
                if (txtBatch.Text.Trim() == "")
                    return "";
                else
                    return txtBatch.Text.Trim();
            }
        }

        public string UserID
        {
            get
            {
                if (this.txtUserID.Text.Trim() == "")
                    return "";
                else
                    return txtUserID.Text.Trim();
            }
        }

        public DataTable dtListCostCenter
        {
            set
            {
                cbCostcenter.DataSource = value;
                cbCostcenter.DisplayMember = "Name";
                cbCostcenter.ValueMember = "CenterID";
            }
        }
    }
}
