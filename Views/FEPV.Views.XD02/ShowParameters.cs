using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MIS.Utility;
using BasicLanuage;
using FEPV.BLL;
using System.IO;
using FEPV.Views.XD02;

namespace FEPV.Views
{
    public partial class ShowParameters : UserControl
    {
        public ShowParameters()
        {
            InitializeComponent();
            #region Languages
            CultureLanuage.ApplyResourcesFrom(this, "XD02", this.Name);
            #endregion
            Init();

            //Get list
            dtListCostCenter = queryAc.ExeProcedureUI("Q_ListCostCenter", new string[] { }, new object[] { });
            dtListState = queryAc.ExeProcedureUI("Q_State4GoodsList", new string[] { }, new object[] { });
        }

        void Init()
        {
            double hours = DateTime.Today.Hour;
            double minutes = DateTime.Today.Minute;
            double seconds = DateTime.Today.Second;
            dateEditB.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 00:00:00");
            dateEditE.Text = DateTime.Now.Date.ToString("yyyy-MM-dd 23:59:59");
        }

        GoodsBiz queryAc = new GoodsBiz();

        ReportBiz rp = new ReportBiz();

        string _msg = string.Empty;

        public string Msg
        {
            get { return _msg; }
        }

        public bool IsReady
        {
            get
            {
                StringBuilder msg = new StringBuilder();
                if (string.IsNullOrEmpty(dateEditB.Text.Trim()))
                    msg.Append("生产起始日期不能为空");
                if (string.IsNullOrEmpty(dateEditE.Text.Trim()))
                    msg.Append("/生产截至日期不能为空");
                if (string.IsNullOrEmpty(cbCostcenter.Text.Trim()))
                    msg.Append("/成本中心不能为空");

                _msg = "" + msg;

                if (_msg == "")
                    return true;
                else
                    return false;
            }
        }

        public string[] Parameter
        {
            get { return new string[] { "BeginDate", "EndDate", "CenterID", "MaterialNO", "plant", "Batch", "State", "BarCode", "repUserID", "pageIndex", "pageSize" }; }
        }

        public object[] Values
        {
            get { return new object[] { B, E, CenterID, MaterialNO, plant, Batch, State, BarCode, User, null, null, null }; }
        }

        public DateTime? B
        {
            get
            {
                if (string.IsNullOrEmpty(dateEditB.Text))
                    return null;
                return Convert.ToDateTime(dateEditB.Text);
            }
        }

        public DateTime? E
        {
            get
            {
                if (string.IsNullOrEmpty(dateEditE.Text))
                    return null;
                return Convert.ToDateTime(dateEditE.Text);
            }
        }

        public string CenterID
        {
            get
            {
                if (string.IsNullOrEmpty(cbCostcenter.Text.Trim()))
                    return null;
                return cbCostcenter.SelectedValue.ToString();
            }
        }

        public string MaterialNO
        {
            get
            {
                if (string.IsNullOrEmpty(txtMaterials.Text.Trim()))
                    return null;
                return txtMaterials.Text;
            }
        }

        public string plant
        {
            get
            {
                if (string.IsNullOrEmpty(txtPlant.Text.Trim()))
                    return null;
                return txtPlant.Text;
            }
        }

        public string Batch
        {
            get
            {
                if (string.IsNullOrEmpty(txtBatch.Text.Trim()))
                    return null;
                return txtBatch.Text;
            }
        }

        public string State
        {
            get
            {
                if (string.IsNullOrEmpty(cbStatus.Text.Trim()))
                    return null;
                return cbStatus.SelectedValue.ToString();
            }
        }

        public string BarCode
        {
            get
            {
                if (string.IsNullOrEmpty(txtBarcode.Text.Trim()))
                    return null;
                return txtBarcode.Text;
            }
        }

        public string User
        {
            get
            {
                if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
                    return null;
                return txtUserID.Text;
            }
        }

        // Biding data to compobox CostCenter
        public string UserId { get; set; }

        public DataTable dtListCostCenter
        {
            set
            {
                cbCostcenter.DataSource = value;
                cbCostcenter.DisplayMember = "Name";
                cbCostcenter.ValueMember = "CenterID";
            }
        }

        // Biding data to compobox ListState
        public DataTable dtListState
        {
            set
            {
                cbStatus.DataSource = value;
                cbStatus.DisplayMember = "说明";
                cbStatus.ValueMember = "状态";
            }
        }
    }
}
