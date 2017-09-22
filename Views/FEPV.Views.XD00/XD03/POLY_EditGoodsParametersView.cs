using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;
using FEPV.Model;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class POLY_EditGoodsParametersView : UserControl, IEditGoodsParametersView
    {
        public POLY_EditGoodsParametersView()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "XD00", this.Name);
            RegisterEvent();

        }
        
        #region Check Event

        void RegisterEvent()
        {
            this.ceMaterial.CheckStateChanged += new EventHandler(ceMaterial_CheckStateChanged);
            this.ceLine.CheckedChanged += new EventHandler(ceLine_CheckedChanged);
            this.ceGrade.CheckedChanged += new EventHandler(ceGrade_CheckedChanged);
            this.ceGrades.CheckedChanged += new EventHandler(ceGrades_CheckedChanged);
            this.ceNum.CheckedChanged += new EventHandler(ceNum_CheckedChanged);
            this.ceGwt.CheckedChanged += new EventHandler(ceGwt_CheckedChanged);
            this.ceChip.CheckedChanged += new EventHandler(ceChip_CheckedChanged);
        }

        void ceChip_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCheck(this.ceChip.CheckState))
                this.txtEdRChip.Enabled = true;
            else
            {
                this.txtEdRChip.Enabled = false;
                this.txtEdRChip.Text = "";
            }
        }
        void ceGwt_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCheck(this.ceGwt.CheckState))
                this.peEdRGwt.Enabled = true;
            else
            {
                this.peEdRGwt.Enabled = false;
                this.peEdRGwt.Text = "0";
            }
        }

        void ceNum_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCheck(this.ceNum.CheckState))
                this.peEdRNum.Enabled = true;
            else
            {
                this.peEdRNum.Enabled = false;
                this.peEdRNum.Text = "";
            }
        }

        void ceGrades_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCheck(this.ceGrades.CheckState))
                this.txtEdRGradeS.Enabled = true;
            else
            {
                this.txtEdRGradeS.Enabled = false;
                this.txtEdRGradeS.Text = "";
            }
        }

        void ceGrade_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCheck(this.ceGrade.CheckState))
                this.cbEdRGrade.Enabled = true;
            else
            {
                this.cbEdRGrade.Enabled = false;
                this.cbEdRGrade.Text = "";
            }
        }

        void ceLine_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCheck(this.ceLine.CheckState))
                this.txtEdRLine.Enabled = true;
            else
            {
                this.txtEdRLine.Enabled = false;
                this.txtEdRLine.Text = "";
            }
        }

        void ceMaterial_CheckStateChanged(object sender, EventArgs e)
        {
            if (IsCheck(this.ceMaterial.CheckState))
                this.cbEdRMaterial.Enabled = true;
            else
            {
                this.cbEdRMaterial.Enabled = false;
                this.cbEdRMaterial.ItemIndex = 0;
            }
        }

        #endregion

        string MaterialNO
        {
            get
            {
                if (cbEdRMaterial.Text == "")
                {
                    return cbEdMaterial.Text;
                }
                else
                {
                    return cbEdRMaterial.Text;
                }
            }
        }

        string Grade
        {
            get
            {
                if (cbEdRGrade.Text.Trim().ToUpper() == "")
                {
                    return cbEdGrade.Text.Trim().ToUpper();
                }
                else
                {
                    return cbEdRGrade.Text.Trim().ToUpper();
                }

            }
        }

        string GradeS
        {
            get
            {
                if (txtEdRGradeS.Text.Trim().ToUpper() == "")
                {
                    return txtEdGradeS.Text.Trim().ToUpper();
                }
                else
                {
                    return txtEdRGradeS.Text.Trim().ToUpper();
                }
            }
        }

        string Chip
        {
            get
            {
                if (txtEdRChip.Text.Trim().ToUpper() == "")
                {
                    return txtEdChip.Text.Trim().ToUpper();
                }
                else
                {
                    return txtEdRChip.Text.Trim().ToUpper();
                }
            }
        }

        string Line
        {
            get
            {
                if (txtEdRLine.Text.Trim().ToUpper() == "")
                {
                    return txtEdLine.Text.Trim().ToUpper();
                }
                else
                {
                    return txtEdRLine.Text.Trim().ToUpper();
                }
            }
        }

        #region IEditGoodsParametersView Members
        public DataTable listMaterial
        {
            set
            {
                cbEdRMaterial.Properties.DataSource = value;
                cbEdRMaterial.Properties.Columns.Clear();
                cbEdRMaterial.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialNO", 20));
                cbEdRMaterial.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProdSpec", 40));
                cbEdRMaterial.Properties.DisplayMember = "MaterialNO";
                cbEdRMaterial.Properties.ValueMember = "MaterialNO";
            }
        }
        GoodsBiz gbiz = new GoodsBiz();
        public List<UIGoods> rEditGoods
        {
            get
            {
                List<UIGoods> list = new List<UIGoods>();

                foreach (DataRow row in ParametersValue.Rows)
                {
                    POLY goods = (POLY)gbiz.GetInfo(row["BarCode"].ToString());

                    goods.MaterialNO = MaterialNO;
                    goods.Grade = Grade;
                    goods.GradeS = GradeS;
                    goods.Line = Line;
                    goods.Chip = Chip;

                    if (ceGwt.Checked)
                        goods.GrossWeight = Convert.ToDecimal(peEdRGwt.Text);
                    if (ceNum.Checked)
                        goods.Num = Convert.ToDecimal(peEdRNum.Text);

                    list.Add(goods);
                }
                return list;
            }
        }

        DataTable _ParametersValue = new DataTable();

        public DataTable ParametersValue
        {

            set
            {
                _ParametersValue = value;
                cbEdMaterial.Text = (string)_ParametersValue.Rows[0]["MaterialNO"];
                cbEdGrade.Text = (string)_ParametersValue.Rows[0]["Grade"];
                txtEdGradeS.Text = (string)_ParametersValue.Rows[0]["Grades"];
                txtEdLine.Text = (string)_ParametersValue.Rows[0]["Line"];
                txtEdChip.Text = (string)_ParametersValue.Rows[0]["Chip"];
                if (_ParametersValue.Rows.Count == 1)
                {
                    peEdNum.Text = (string)_ParametersValue.Rows[0]["Num"];
                    // peEdRwt.Text = (string)_ParametersValue.Rows[0]["实际重量"];
                    peEdGwt.Text = (string)_ParametersValue.Rows[0]["GWT"];
                }
                else
                {
                    peEdNum.Text = "0";
                    //  peEdRwt.Text = "0";
                    peEdNum.Text = "0";
                }

            }
            get { return _ParametersValue; }
        }

        public bool IsReady
        {
            get
            {
                if (
                    string.IsNullOrEmpty(cbEdRMaterial.Text.Trim().ToUpper()) &&
                    string.IsNullOrEmpty(cbEdRGrade.Text.Trim().ToUpper()) &&
                    string.IsNullOrEmpty(txtEdRGradeS.Text.Trim().ToUpper()) &&
                    string.IsNullOrEmpty(txtEdRLine.Text.Trim().ToUpper()) &&
                    string.IsNullOrEmpty(txtEdRChip.Text.Trim().ToUpper()) &&
                    //   Convert.ToDecimal(peEdRRwt.Text.Trim()) <= 0 &&
                    Convert.ToDecimal(peEdRNum.Text.Trim()) <= 0 &&
                    Convert.ToDecimal(peEdRGwt.Text.Trim()) <= 0
                    )
                    return false;
                else
                    return true;

            }
        }


        #endregion

        bool IsCheck(CheckState state)
        {
            switch (state)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Unchecked:
                    return false;
            }
            return false;
        }

        private void STAPEditGoodsParametersView_Load(object sender, EventArgs e)
        {
            cbEdRMaterial.Enabled = false;
            cbEdRGrade.Enabled = false;
            txtEdRGradeS.Enabled = false;
            txtEdRLine.Enabled = false;
            peEdRNum.Enabled = false;
            peEdRGwt.Enabled = false;
            txtEdRChip.Enabled = false;
            //  peEdRRwt.Enabled = false;


        }

        #region IEditGoodsParametersView Members


        public bool DefaltCheckState
        {
            set
            {
                ceMaterial.Checked = false;
                ceGrade.Checked = false;
                ceGrades.Checked = false;
                ceLine.Checked = false;
                ceChip.Checked = false;
                ceGwt.Checked = false;
                ceNum.Checked = false;
            }
        }

        #endregion


    }
}
