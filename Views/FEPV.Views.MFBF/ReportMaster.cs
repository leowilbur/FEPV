using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace FEPV.Views
{
    public partial class ReportMaster : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportMaster()
        {
            InitializeComponent();

            bs.DataSource = listvoucher;
        }

        List<MasterElements> listvoucher = new List<MasterElements>();
        #region IRepSource Members

        public List<MasterElements> dataSource
        {
            set
            {
                listvoucher.Clear();
                foreach (MasterElements v in value)
                {
                    listvoucher.Add(v);
                }
            }
        }

        #endregion
    }

    public class MasterElements
    {
        public string M_ID { get; set; }
        public string M_VouNo { get; set; }
        public string M_MaterialNO { get; set; }
        public string M_ProdSpec { get; set; }
        //public string 工厂 { get; set; }
        public string M_CenterID { get; set; }
        public string M_Batch { get; set; }
        public string M_AccDate { get; set; }
        public string M_Version0 { get; set; }
        public string M_Version { get; set; }
        public int M_TotalCount { get; set; }
        public decimal M_TotalNum { get; set; }
        public List<DetailElements> Goodses { get; set; }
    }

    public class DetailElements
    {
        public string _BarCode { get; set; }
        public decimal _Num { get; set; }
        public decimal _GWT { get; set; }
    }

    public class RTSElements
    {
        public int _ID { get; set; }
        public string _VouNo { get; set; }
        public string _Spec { get; set; }
        public string _MaterialNo { get; set; }
        public string _Batch { get; set; }
        public string _Unit { get; set; }
        public string _TotalNum { get; set; }
        public string _TotalPackage { get; set; }
        public string _CenterID { get; set; }
        public string _TakeUnit { get; set; }
        public string _PickDate { get; set; }
    }
}
