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

namespace FEPV.Views.SSP
{
    [SmartPart]
    public partial class RphVoucherView : UserControl, IVoucherView
    {
        public RphVoucherView()
        {
            InitializeComponent();
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

        public Voucher Voucher2Request
        {
            get
            {
                return new SSP_RPH()
                {
                    MaterialNO = txtBMaterial.Text.Trim().ToUpper(),
                    Plant = txtPlant.Text.Trim(),
                    Batch = Batch,
                    AccDate = DateTime.Now,
                    Grade = txtGrade.Text.Trim().ToUpper(),
                    GradeS = txtGradeS.Text.Trim().ToUpper(),
                    Line = txtLine.Text.Trim().ToUpper(),
                    Version0 = txtVersion0.Text.Trim().ToUpper(),
                    Loc = txtLoc.Text.Trim(),
                    Version = txtVersion.Text.Trim().ToUpper(),
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
                txtLoc.Text = (string)value["Loc"];
                txtVersion0.Text = (string)value["Version"];
                txtVersion.Text = (string)value["PreVersion"];
                MaterialNO = (string)value["MaterialNo"];
                Batch = (string)value["Batch"];
                txtPlant.Text = (string)value["Plant"];
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
                    msg.Append("/Grade is Empty");
                if (string.IsNullOrEmpty(txtGradeS.Text))
                    msg.Append("//GradeS is Empty");
                if (string.IsNullOrEmpty(txtLine.Text))
                    msg.Append("/Line is Empty");
                if (string.IsNullOrEmpty(txtPlant.Text))
                    msg.Append("/Plant is Empty");
                if (string.IsNullOrEmpty(txtLoc.Text))
                    msg.Append("/Location is Empty");
                if (string.IsNullOrEmpty(txtVersion0.Text))
                    msg.Append("/Version is Empty");

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
            get { return new string[] { txtVersion0.Text.Trim().ToUpper(), txtVersion.Text }; }
        }

        #endregion

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
