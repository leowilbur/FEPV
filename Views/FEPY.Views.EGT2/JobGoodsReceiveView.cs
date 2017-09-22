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
    public partial class JobGoodsReceiveView : UserControl
    {
        public JobGoodsReceiveView()
        {
            InitializeComponent();
            //CultureLanuage.ApplyResourcesFrom(this, "EGT2", this.Name);
            _GoodsName.TextChanged += new EventHandler(_GoodsName_TextChanged);
            btnAddGB.Click += new EventHandler(btnAddGB_Click);
            dtGoodsBackItemsInit();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGT2", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView7");
            if (gridData != null)
            {
                this.gcGoodsBackDetails.DataSource = gridData;
                gridView7.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridView7, "gridView7", dsgrid);
            }
            #endregion
        }

        void _GoodsName_TextChanged(object sender, EventArgs e)
        {
            //todo 加载数量等
            DataTable dt = new DataTable();
            dt = rep.GetMISReport("GD_AC_GetGoodsBackCountByGoodsName", 
                new string[] { "VoucherID", "GoodsName", "Language" }, 
                new object[] { _VoucherID.Text, _GoodsName.Text, MyLanguage.Language }).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                _OutAmount.Text = row["OutAmount"].ToString();
                _BackedAmount.Text = row["BackedAmount"].ToString();
                _Unit.Text = row["Unit"].ToString();
                _UnitRemark.Text = row["UnitRemark"].ToString();
            }
            GoodsAmount = "0";
            btnAddGB.Enabled = true;
            btnAddGB.ForeColor = Color.Red;
        }

        public DataTable dtGoodsBack = new DataTable();
        public void dtGoodsBackItemsInit()
        {
            dtGoodsBack.Columns.Add("GoodsName");
            dtGoodsBack.Columns.Add("GoodsAmount");
            dtGoodsBack.Columns.Add("Unit");
            dtGoodsBack.Columns.Add("UnitRemark");          
        }

        private void btnAddGB_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_GoodsName.Text))
            {
                if (Convert.ToInt32(_GoodsAmount.Text.TrimEnd('.')) <= 0)
                {
                    MessageBox.Show("Be back to the amount of plant<=0");
                    return;
                }

                if (GetSumAddGoods4GoodsName(_GoodsName.Text)>0)
                {
                    MessageBox.Show("Repeat to add items！");
                    return;
                }

                if (GetSumAddGoods4GoodsName(_GoodsName.Text) + Convert.ToInt32(_GoodsAmount.Text.TrimEnd('.')) + Convert.ToInt32(_BackedAmount.Text) <= Convert.ToInt32(_OutAmount.Text))
                {
                    DataRow row = dtGoodsBack.NewRow();
                    row["GoodsName"] = _GoodsName.Text;
                    row["GoodsAmount"] = _GoodsAmount.Text.TrimEnd('.');
                    row["Unit"] = _Unit.Text;
                    row["UnitRemark"] = _UnitRemark.Text;
                    dtGoodsBack.Rows.Add(row);

                    dtGoodsBackItems = dtGoodsBack;

                    btnAddGB.Enabled = false;
                    btnAddGB.ForeColor = Color.Gray;
                }
                else
                {
                    MessageBox.Show("Back to the factory and the number is greater than the number of the factory");
                }
            }
            else
            {
                MessageBox.Show("Select the name of the object");
            }
        }
        /// <summary>
        /// get sum added amount
        /// </summary>
        /// <param name="goodsName"></param>
        /// <returns></returns>
        private int GetSumAddGoods4GoodsName(string goodsName)
        {
            DataTable dt = dtGoodsBack;
            int sumcount = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["GoodsName"].ToString() == goodsName)
                    {
                        sumcount += Convert.ToInt32(row["GoodsAmount"]);
                    }
                }
            }
           
            return sumcount;
        }

        ReportBiz rep = new ReportBiz();

        public Dictionary<string, object> Paras
        {
            set
            {
                _VoucherID.Text = (string)value["VoucherID"];
                _Remark.Text = value["Remark"].ToString();
            }
        }

        public DataTable dtGoodsBackItems
        {
            set
            {
                gcGoodsBackDetails.DataSource = value;
                gridView7.BestFitColumns();
            }
        }

        public DataTable dtListGoodsName
        {
            set
            {
                _GoodsName.DataSource = value;
                _GoodsName.DisplayMember = "GoodsName";
                _GoodsName.ValueMember = "GoodsName";
            }
        }

        public string GoodsAmount
        {
            set 
            {
                _GoodsAmount.Text = value;
            }
        }
        public string GoodsBackAmount
        {
            set
            {
                _OutAmount.Text = value;
                _BackedAmount.Text = value;
            }
        }
    }
}
