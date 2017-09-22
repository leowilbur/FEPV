using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using FEPV.Model;
using BasicLanuage;

namespace FEPV.Views.SSP
{
    [SmartPart]
    public partial class SihVoucherView : UserControl, IVoucherView
    {
        public SihVoucherView()
        {
            InitializeComponent();
            this.cbBarPlant.EditValueChanged += new EventHandler(cbBarPlant_EditValueChanged);
            CultureLanuage.ApplyResourcesFrom(this, "MFBF", this.Name);

        }

        string _Loc = string.Empty;

        string _msg = string.Empty;

        string Batch = string.Empty;

        string CenterID = string.Empty;


        DataTable dtPlants = new DataTable();
        public string BOM { get; set; }

        public string Batch131
        {
            get { return Batch; }
            set { Batch = value; }
        }

        #region IVoucherView Members

        public string ProdType { get; set; }
        public int TotalCount
        {
            set { this.seTotalCount.Text = value.ToString(); }
        }

        public decimal TotalWeight
        {
            set { this.seTotalWeight.Text = value.ToString(); }
        }

        public string IsimmobilityPlantAndLoc { set { } }

        public bool IsConvertMaterialno
        {
            set { }
        }
        public DataTable _Plant { set { } }

        public DataTable dtCenterID
        {
            set { }
        }

        public FEPV.Model.Voucher Voucher2Request
        {
            get
            {
                return new SSP_SIH()
                {
                    MaterialNO = txtBMaterial.Text.Trim().ToUpper(),
                    Plant = cbBarPlant.Text.Trim(),
                    Batch = Batch,
                    AccDate = DateTime.Now,
                    Grade = txtGrade.Text.Trim().ToUpper(),
                    GradeS = txtGradeS.Text.Trim().ToUpper(),
                    Line = txtLine.Text.Trim().ToUpper(),
                    Version0 = txtTver.Text.Trim().ToUpper(),
                    Loc = txtLoc.Text.Trim(),
                    Version = bomTree1.VER,
                    CenterID = CenterID

                };

            }
        }

        public Dictionary<string, object> VoucherParamenters
        {
            set
            {
                txtBMaterial.Text = (string)value["MaterialNo"];
                txtGrade.Text = ((string)value["Batch"]).Substring(0, 2).Trim('-');
                txtGradeS.Text = ((string)value["Batch"]).Substring(2, 2).TrimEnd('-');
                txtLine.Text = ((string)value["Batch"]).Substring(4, 2).Trim('-');
                MaterialNO = (string)value["MaterialNo"];
                Batch = (string)value["Batch"];
                CenterID = (string)value["CenterID"];

                object[] ToObject = new object[]
                {
                 (string)value["StartDate"],
                 (string)value["EndDate"],
                 (string)value["MaterialNo"],
                 (string)value["Plant"],
                 (string)value["Loc"],
                 (string)value["Batch"], 
                 (string)value["VoucherID"],
                 (string)value["CenterID"],
                 (string)value["Version"],
                 (string)value["PreVersion"],
                 (string)value["Packing"]
                };

                SelectParameters = ToObject;
            }

        }

        public object[] SelectParameters { get; set; }

        public string MaterialNO { get; set; }

        public DataTable Plants
        {
            set
            {
                dtPlants.Clear();
                DataRow row = dtPlants.NewRow();
                dtPlants.Rows.Add(row);
                dtPlants.Merge(value);
                this.cbBarPlant.Properties.DataSource = dtPlants;
                this.cbBarPlant.Properties.DisplayMember = "Plant";//
                this.cbBarPlant.Properties.ValueMember = ".";
                this.cbBarPlant.ItemIndex = 0;
            }
            get
            {
                return dtPlants;
            }
        }

        public bool IsReady
        {
            get
            {
                StringBuilder msg = new StringBuilder();
                if (string.IsNullOrEmpty(txtBMaterial.Text))
                    msg.Append("Material is Empty!");
                if (string.IsNullOrEmpty(txtGrade.Text))
                    msg.Append("Grade is Empty!");
                if (string.IsNullOrEmpty(txtGradeS.Text))
                    msg.Append("Grades is Empty!");
                if (string.IsNullOrEmpty(txtLine.Text))
                    msg.Append("Line is Empty!");
                if (string.IsNullOrEmpty(cbBarPlant.Text))
                    msg.Append("Plant is not pick!");
                if (string.IsNullOrEmpty(txtLoc.Text))
                    msg.Append("Loc is Empty!");
                if (string.IsNullOrEmpty(txtTver.Text))
                    msg.Append("Version is Empty!");

                _msg = "" + msg;

                if (_msg == "")
                    return true;
                else
                    return false;
            }
        }

        public string TransID
        {
            set { txtTransID.Text = value; }
        }

        public string Msg
        {
            get { return _msg; }
        }

        public string[] Version
        {
            get { return new string[] { txtTver.Text.Trim().ToUpper(), bomTree1.VER }; }
        }

        #endregion



        void GetVer()
        {
            var selectrow =
                   from p in dtPlants.AsEnumerable()
                   where p.Field<string>(".") == cbBarPlant.EditValue.ToString()
                   select p;

            string verSpec = string.Empty;
            string NO = string.Empty;
            if (selectrow.Count() > 0)
            {
                txtLoc.Text = selectrow.ToList()[0]["STLOC"].ToString();
                txtTver.Text = selectrow.ToList()[0]["VER"].ToString();
                verSpec = selectrow.ToList()[0]["VerSpec"].ToString();
                NO = selectrow.ToList()[0]["NO."].ToString();
            }
            else
            {
                txtLoc.Text = "";
                txtTver.Text = "";
            }

            bomTree1.ListVersions(
                                  txtBMaterial.Text,
                                  cbBarPlant.Text,
                                  txtTver.Text, verSpec,
                                  NO
                                  );

            this.Refresh();
        }

        private void cbBarPlant_EditValueChanged(object sender, EventArgs e)
        {
            GetVer();
        }

        #region IVoucherView Members


        public DataTable dtGrade
        {
            set { }
        }

        public DataTable dtLine
        {
            set { }
        }

        #endregion
    }
}
