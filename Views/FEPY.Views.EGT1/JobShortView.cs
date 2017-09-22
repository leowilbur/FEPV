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

namespace FEPV.Views
{
    public partial class JobShortView : UserControl
    {
        public JobShortView()
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

            btnRePrint.Click += new EventHandler(btnRePrint_Click);
        }
        //TODO 成品短驳 补印磅单
        void btnRePrint_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Print the pound list again?", "Prompt information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
            {
                if (_State.Text == "D1")
                {
                    //打印磅单
                    Print(VoucherID + ItemID, "ST1", true);
                }
                else if (_State.Text == "D2")
                {
                    //打印磅单
                    Print(VoucherID + ItemID, "ST2", true);
                }
                else
                {
                    MessageBox.Show("Document number[" + VoucherID + "]Status is[" + _State.Text + "],Is not allowed to print the pound list", "Prompt information");
                }
            }
        }

        /// <summary>
        /// 打印磅单
        /// </summary>
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
                _ShippingOrder.Text = (string)value["ShippingOrder"];
                _VehicleType.Text = (string)value["VehicleType"];
                _VehicleNO.Text = (string)value["VehicleNO"];
                _MaterielType.Text = value["MaterielType"].ToString();
                _Driver.Text = value["Driver"].ToString();
                _Manufacturer.Text = value["Manufacturer"].ToString();
                _Remark.Text = value["Remark"].ToString();
                _UserID.Text = value["UserID"].ToString();
            }
        }
        string _msg = string.Empty;
        public string MsgTruck
        {
            get { return _msg; }
            set { _msg = value; }
        }

        /// <summary>
        /// 检查在厂车辆唯一
        /// </summary>
        public bool IsReady4VehicleNO
        {
            get
            {
                DataTable tb = rep.GetMISReport("A_Q_VehicleNO_Validate_Short", new string[] { "VehicleNO" }, new object[] { VehicleNO }).Tables[0];
                _msg = tb.Rows[0][0].ToString();

                if (_msg == "")
                    return true;
                else
                    return false;
            }
        }
        //状态
        public string State
        {
            get { return _State.Text; }
            set { _State.Text = value; }
        }
        //计划单号
        public string VoucherID
        {
            get { return _VoucherID.Text.Trim(); }
            set { _VoucherID.Text = value; }
        }//计划项号
        public string ItemID
        {
            get { return _ShippingOrder.Text.Trim(); }
            set { _ShippingOrder.Text = value; }
        }
        //车号
        public string VehicleNO
        {
            get { return _VehicleNO.Text.Trim(); }
            set { _VehicleNO.Text = value; }
        }
        //创建人
        public string CreateUserID
        {
            get { return _UserID.Text.Trim(); }
            set { _UserID.Text = value; }
        }

        ReportBiz rep = new ReportBiz();
        public void WeightRefresh(string VoucherID)
        {
            DataTable dt = rep.GetMISReport("A_Q_PlanData4ShortDetails", new string[] { "VoucherID", "ItemID", "State" }, new object[] { VoucherID, ItemID, _State.Text }).Tables[0];
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

        public DataTable PlanDetail4TruckTable
        {
            set
            {
                gridControl1.DataSource = value;
                gridView1.BestFitColumns();
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

        public string Setting4Print { get; set; }
    }
}
