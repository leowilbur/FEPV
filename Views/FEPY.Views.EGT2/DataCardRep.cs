using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.IO;

namespace FEPV.Views
{
    public partial class DataCardRep : DevExpress.XtraReports.UI.XtraReport
    {
        public DataCardRep()
        {
            InitializeComponent();
        }

        FEPV.BLL.ReportBiz rep = new FEPV.BLL.ReportBiz();
        //Guest
        public bool InitializeValues(Guid ID)
        {
            #region 
            DataRow row = rep.GetMISReport("FK_AC_GuestItem_Image", new string[] { "ID" }, new object[] { ID }).Tables[0].Rows[0];
            lblName.Text = row["GuestName"].ToString(); //
            lblCompany.Text = row["Enterprise"].ToString(); //
            lblDepartment.Text = row["Specification"].ToString(); //

            if (Convert.ToString(row["Image"]) != "")
            {
                MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                Image image = Image.FromStream(ms, true);
                xrPictureBox1.Image = image;
                return true;
            }
            else
            {
                return false;
            }

            #endregion
        }
        //Contractor
        public bool InitializeValues(string KeyValue)
        {
            #region Grab the photo
            DataRow row = rep.GetMISReport("Q_Contractor_Image", new string[] { "VoucherID" }, new object[] { KeyValue }).Tables[0].Rows[0];
            lblName.Text = row["Name"].ToString(); //Name
            lblCompany.Text = row["Enterprise"].ToString(); //Enterprise
            lblDepartment.Text = row["EffectiveTo"].ToString(); //Valid

            if (Convert.ToString(row["Image"]) != "")
            {
                MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                Image image = Image.FromStream(ms, true);
                xrPictureBox1.Image = image;
                return true;
            }
            else
            {
                return false;
            }

            #endregion
        }

        //Ann-loop system of contractor
        public bool InitializeValues(string IDCard, string Enterprise)
        {
            #region Grab the photo
            DataRow row = rep.GetMISReport("HS_Q_Contractor_Image", new string[] { "IdCard", "Employer" }, new object[] { IDCard, Enterprise }).Tables[0].Rows[0];
            lblName.Text = row["Name"].ToString(); //Name
            lblCompany.Text = row["Employer"].ToString(); //
            lblDepartment.Text = "Valid:" + row["ValidTo"].ToString(); //Valid

            if (Convert.ToString(row["Image"]) != "")
            {
                MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                Image image = Image.FromStream(ms, true);
                xrPictureBox1.Image = image;
                return true;
            }
            else
            {
                return false;
            }

            #endregion
        }
    }
}
