using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.Model;

using Microsoft.Practices.CompositeUI.SmartParts;
using BasicLanuage;


namespace FEPV.Views
{
    [SmartPart]
    public partial class POLYView : UserControl, IGoodsView
    {
        public POLYView()
        {
            InitializeComponent();
            MaterialSetup();
            CultureLanuage.ApplyResourcesFrom(this, "XD00", this.Name);
        }

        private void POLYView_Load(object sender, EventArgs e)
        {
            this.cbCProdDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        string _msg = string.Empty;

        DataTable dtMaterials;

        void MaterialSetup()
        {
            dtMaterials = new DataTable();
            cbCMaterial.Properties.DataSource = dtMaterials;
            cbCMaterial.Properties.DisplayMember = "MaterialNO";
            cbCMaterial.Properties.ValueMember = "MaterialNO";
            cbCMaterial.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialNO", 20));
            cbCMaterial.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProdSpec", 40));
        }

        #region IGoodsView Members

        public bool IsReady
        {
            get
            {
                StringBuilder msg = new StringBuilder();
                if (string.IsNullOrEmpty(this.cbCMaterial.Text.Trim()))
                    msg.Append("Material can not empty!");
                if (string.IsNullOrEmpty(this.cbCGrade.Text.Trim()))
                    msg.Append("Grade can not empty!");
                if (string.IsNullOrEmpty(this.txtCGrades.Text.Trim()))
                    msg.Append("Grades can not empty!");
                if (string.IsNullOrEmpty(this.txtChips.Text.Trim()))
                    msg.Append("Chip can not empty!");
                if (string.IsNullOrEmpty(this.cbCLine.Text.Trim()))
                    msg.Append("Line can not empty!");
                if (int.Parse(this.seCCount.Text.Trim()) <= 0)
                    msg.Append("Count must be greater than 0");
                if (string.IsNullOrEmpty(this.cbCBager.Text.Trim()))
                    msg.Append("PackID can not empty!");
                if (string.IsNullOrEmpty(this.cbCCheckID.Text.Trim()))
                    msg.Append("CheckID can not empty!");

                if (msg.Length == 0)
                {
                    return true;
                }
                else
                {
                    _msg = msg.ToString();
                    return false;
                }
            }
        }

        public string ErrorMessage
        {
            get { return _msg; }
        }

        public int Count
        {
            get
            {
                return int.Parse(this.seCCount.Text);
            }
            set
            {
                this.seCCount.Text = value.ToString();
            }
        }

        public int Flow
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }

        public UIGoods Goods2Produce
        {
            get
            {
                var selectrow =
        from p in dtMaterials.AsEnumerable()
        where p.Field<string>("MaterialNO") == cbCMaterial.Text
        select p;

                return new POLY()
                {
                    MaterialNO = this.cbCMaterial.Text.Trim(),
                    ProdSpec = selectrow.ToList()[0]["ProdSpec"].ToString(),
                    ProdDate = Convert.ToDateTime(this.cbCProdDate.Text),
                    Grade = this.cbCGrade.Text.Trim().ToUpper(),
                    GradeS = this.txtCGrades.Text.Trim().ToUpper(),
                    Line = this.cbCLine.Text.Trim().ToUpper(),
                    // Chip = txtChips.Text.Trim().ToUpper().PadRight(2,'-'),//
                    Chip = txtChips.Text.Trim().ToUpper(),
                    Num = Convert.ToDecimal(this.seCNum.Text.Trim()),
                    GrossWeight = Convert.ToDecimal(this.seCGwt.Text.Trim()) + Convert.ToDecimal(this.seCNum.Text.Trim()),
                    CheckID = this.cbCCheckID.Text.Trim(),
                    PackID = this.cbCBager.Text.Trim()
                };
            }
        }

        public DataTable dtMaterial
        {
            set
            {
                if (value != null)
                    dtMaterials.Merge(value);
            }
        }

        public DataTable dtLine
        {
            set
            {
                cbCLine.Properties.DataSource = value;
                cbCLine.Properties.DisplayMember = "Line";
                cbCLine.Properties.ValueMember = "Line";
                cbCLine.Properties.Columns.Clear();
                cbCLine.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Line", 5));
            }
        }

        #endregion
    }
}
