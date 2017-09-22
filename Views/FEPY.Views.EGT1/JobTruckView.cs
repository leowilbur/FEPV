using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;
using BasicLanuage;
using MIS.Utility;

namespace FEPV.Views
{
    public partial class JobTruckView : UserControl
    {
        public JobTruckView()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGT1", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.gridControl1.DataSource = gridData;
                gridView1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
            }
            #endregion

            dtListDeskClerk = rep.GetMISReport("WF_MIS_AC_PermissionDeskClerk",
                new string[] { "Language" }, new object[] { MyLanguage.Language }).Tables[0];
            btnRePrint.Click += new EventHandler(btnRePrint_Click);
        }

        void btnRePrint_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Print the pound list again?", "Prompt information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
            {
                if (Flag == "PE")
                {
                    //打印磅单
                    Print(VoucherID, "PE", true);
                }
                else
                {
                    //打印磅单
                    Print(VoucherID, "XT", true);
                }
            }
        }

        private void Print(string VoucherID, string Type, bool isPaperPrint)
        {
            Print doc = new Print(VoucherID, Type);
            doc.Setting = Setting4Print;
            doc.PrintBill(isPaperPrint);
        }

        public Dictionary<string, object> ParasPtaEg
        {
            set
            {
                _VoucherID.Text = (string)value["VoucherID"];
                _ItemID.Text = value["ItemID"].ToString();
                _ShippingOrder.Text = (string)value["ShippingOrder"];
                _VehicleType.Text = (string)value["VehicleType"];
                _VehicleNO.Text = (string)value["VehicleNO"];
                _MaterielType.Text = value["MaterielType"].ToString();
                _Driver.Text = value["Driver"].ToString();
                _Manufacturer.Text = value["Manufacturer"].ToString();
                _Remark.Text = value["Remark"].ToString();
                _CupboardNO.Text = value["CupboardNO"].ToString();
                _Discharge.SelectedValue = value["Discharge"].ToString();
                _ReferWeight.Text = value["ReferWeight"].ToString();
                CreateUserID = value["UserID"].ToString();
            }
        }
        string _msg = string.Empty;
        public string MsgTruck
        {
            get { return _msg; }
            set { _msg = value; }
        }
        /// <summary>
        /// 检查数据完整性
        /// </summary>
        public bool IsReady
        {
            get
            {
                StringBuilder msg = new StringBuilder();
                if (_MaterielType.Text == "EG" && (_ReferWeight.Text.TrimEnd('.') == "0" || _ReferWeight.Text.Trim() == "0.00"))
                    msg.Append("Reference weight cannot be equal to 0");
                if (string.IsNullOrEmpty(_Discharge.Text))
                    msg.Append("/The unloading point can not be empty");

                _msg = "" + msg;

                if (_msg == "")
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// 检查厂内车辆是否存在
        /// </summary>
        public bool IsReady4VehicleNO
        {
            get
            {
                DataTable tb = ab.QueryVehicleNoState(VehicleNO);                
                _msg = tb.Rows[0][0].ToString();

                if (_msg == "")
                    return true;
                else
                    return false;
            }
        }
        //标识
        public string Flag
        {
            get { return _Flag.Text; }
            set { _Flag.Text = value; }
        }
        //状态
        public string State
        {
            get { return _State.Text; }
            set { _State.Text = value; }
        }
        //柜号
        public string CupboardNO
        {
            get { return _CupboardNO.Text.Trim(); }
            set { _CupboardNO.Text = value; }
        }
        //卸货点
        public string Discharge
        {
            get { return _Discharge.SelectedValue.ToString(); }
        }
        //备注
        public string TruckRemark
        {
            get { return _Remark.Text.Trim(); }
            set { _Remark.Text = value; }
        }
        //参考重量
        public decimal ReferWeight
        {
            get { return Convert.ToDecimal(_ReferWeight.Text.TrimEnd('.')); }
            set { _ReferWeight.Text = value.ToString(); }
        }
        //计划单号
        public string VoucherID
        {
            get { return _VoucherID.Text; }
            set { _VoucherID.Text = value; }
        }
        //计划项次号
        public string ItemID
        {
            get { return _ItemID.Text; }
            set { _ItemID.Text = value; }
        }
        //车号
        public string VehicleNO
        {
            get { return _VehicleNO.Text; }
            set { _VehicleNO.Text = value; }
        }
        //创建人
        public string CreateUserID { get; set; }
        //通知单号
        public string ShippingOrder
        {
            get { return _ShippingOrder.Text; }
            set { _ShippingOrder.Text = value; }
        }

        ReportBiz rep = new ReportBiz();
        AcBiz ab = new AcBiz();

        public void WeightRefresh(string VoucherID)
        {
            DataTable dt = ab.QueryPlanData4TruckDetails(VoucherID, MyLanguage.Language);
            if (dt.Rows.Count != 0)
            {
                DataRow row = dt.Rows[0];
                _FirstWeight.Text = row["FirstWeight"].ToString();
                _FirstTime.Text = row["FirstTime"].ToString();
                _SecondWeight.Text = row["SecondWeight"].ToString();
                _SecondTime.Text = row["SecondTime"].ToString();
                _TotalWeight.Text = row["TotalWeight"].ToString();
            }
            else
            {
                _FirstWeight.Text = "";
                _FirstTime.Text = "";
                _SecondWeight.Text = "";
                _SecondTime.Text = "";
                _TotalWeight.Text = "";
            }
        }

        public decimal FirstWeight
        {
            get 
            {
                if (string.IsNullOrEmpty(_FirstWeight.Text))
                    return 0;
                return Convert.ToDecimal(_FirstWeight.Text); 
            }
            set { _FirstWeight.Text = value.ToString(); }
        }

        public string FirstTime
        {
            get
            {
                return _FirstTime.Text.ToString();
            }
            set { _FirstTime.Text = value; }
        }

        public decimal SecondWeight
        {
            get
            {
                if (string.IsNullOrEmpty(_SecondWeight.Text))
                    return 0;
                return Convert.ToDecimal(_SecondWeight.Text);
            }
            set { _SecondWeight.Text = value.ToString(); }
        }

        public string SecondTime
        {
            get
            {
                return _SecondTime.Text.ToString();
            }
            set { _SecondTime.Text = value; }
        }

        public decimal TotalWeight
        {
            get
            {
                if (string.IsNullOrEmpty(_TotalWeight.Text))
                    return 0;
                return Convert.ToDecimal(_TotalWeight.Text);
            }
            set { _TotalWeight.Text = value.ToString(); }
        }

        public DataTable PlanDetail4TruckTable
        {
            set
            {
                gridControl1.DataSource = value;
                gridView1.BestFitColumns();
            }
        }

        public DataTable dtListDeskClerk
        {
            set
            {
                _Discharge.DataSource = value;
                _Discharge.DisplayMember = "UnloadingPoint";
                _Discharge.ValueMember = "ID";
            }
        }

        public bool CupboardNO_Enable
        {
            set
            {
                labelControl17.Visible = value;
                _CupboardNO.Visible = value;
                labelControl12.Visible = value;
                _Discharge.Visible = value;
                labelControl13.Visible = value;
                _ReferWeight.Visible = value;
            }
        }

        public string Setting4Print { get; set; }
    }
}
