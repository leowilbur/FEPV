using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace FEPV.Views
{
    public partial class RepForGuest : DevExpress.XtraReports.UI.XtraReport
    {
        public RepForGuest()
        {
            InitializeComponent();
            bindingSource1.DataSource = listpb;
        }

        List<ModelForGuestRep> listpb = new List<ModelForGuestRep>();

        public void InitializeValues(DataTable dt)
        {
            ModelForGuestRep _ModelForGuestRep;

            foreach (DataRow row in dt.Rows)
            {
                _ModelForGuestRep = new ModelForGuestRep();
                _ModelForGuestRep._VoucherID = row["VoucherID"].ToString();
                _ModelForGuestRep._人员类型 = row["GuestType"].ToString();
                _ModelForGuestRep._姓名 = row["GuestName"].ToString();
                _ModelForGuestRep._证件号码 = row["IdCard"].ToString();
                _ModelForGuestRep._工作单位 = row["Enterprise"].ToString();
                _ModelForGuestRep._事由 = row["Content"].ToString();
                _ModelForGuestRep._访问区域 = row["Region"].ToString();
                _ModelForGuestRep._卡号 = row["CardNO"].ToString();
                _ModelForGuestRep._受访人姓名 = row["RespondentsName"].ToString();
                _ModelForGuestRep._进厂时间 = row["InTime"].ToString();
                _ModelForGuestRep._出厂时间 = row["OutTime"].ToString();

                MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                Image image = Image.FromStream(ms, true);                
                _ModelForGuestRep._照片 = image;

                listpb.Add(_ModelForGuestRep);
            }
        }

        public string[] Values
        {
            set
            {
                lblDate.Text = value[0];//日期
            }
        }
    }

    public class ModelForGuestRep
    {
        public string _VoucherID { get; set; }
        public string _人员类型 { get; set; }
        public string _姓名 { get; set; }
        public string _证件号码 { get; set; }
        public string _工作单位 { get; set; }
        public string _事由 { get; set; }
        public string _卡号 { get; set; }
        public string _受访人姓名 { get; set; }
        public string _访问区域 { get; set; }
        public string _进厂时间 { get; set; }
        public string _出厂时间 { get; set; }
        public Image _照片 { get; set; }
    }
}
