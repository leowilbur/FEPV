using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace FEPV.Views
{
    public partial class DataCardRep : DevExpress.XtraReports.UI.XtraReport
    {
        public DataCardRep()
        {
            InitializeComponent();
            bindingSource1.DataSource = listpb;
        }

        FEPV.BLL.ReportBiz rep = new FEPV.BLL.ReportBiz();
        List<ModelConPrint> listpb = new List<ModelConPrint>();
        //Contractor
        public bool InitializeValues(ArrayList SelectedRows, string bgcolor)
        {
            ModelConPrint _ModelConPrint;

            foreach (DataRow row in SelectedRows)
            {
                string _IdCard = row["IdCard"].ToString(); //IdCard
                string _Employer = row["Enterprise"].ToString(); //Employer
                //
                DataRow row0 = rep.GetMISReport("HS_Q_Contractor_Image",
                    new string[] { "IdCard", "Employer" }, new object[] { _IdCard, _Employer }).Tables[0].Rows[0];
                //
                _ModelConPrint = new ModelConPrint();
                
                //Max length is 20
                int i = 25;
                _ModelConPrint._Name = row0["Name"].ToString();

                if (row0["Employer"].ToString().Length > i)
                    _ModelConPrint._Employer = row0["Employer"].ToString().Substring(0, i);
                else
                    _ModelConPrint._Employer = row0["Employer"].ToString();

                _ModelConPrint._ValidTo = row0["ValidTo"].ToString();
                if (Convert.ToString(row0["Image"]) != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])row0["Image"]);
                    Image image = Image.FromStream(ms, true);
                    _ModelConPrint._Image = image;
                    //background color
                    setBackgroundColor(bgcolor);
                }
                else
                {
                    return false;
                }
                listpb.Add(_ModelConPrint);
            }
            return true;
        }

        //Ann-loop system of contractor
        //public bool InitializeValues(string IDCard, string Enterprise, string bgcolor)
        //{
        //    #region Grab the photo
        //    DataRow row = rep.GetMISReport("HS_Q_Contractor_Image", new string[] { "IdCard", "Employer" }, new object[] { IDCard, Enterprise }).Tables[0].Rows[0];
        //    lblName.Text = row["Name"].ToString(); //Name
        //    lblCompany.Text = row["Employer"].ToString(); //
        //    lblDepartment.Text = "Valid:" + row["ValidTo"].ToString(); //Valid

        //    if (Convert.ToString(row["Image"]) != "")
        //    {
        //        MemoryStream ms = new MemoryStream((byte[])row["Image"]);
        //        Image image = Image.FromStream(ms, true);
        //        xrPictureBox1.Image = image;
        //        //background color
        //        setBackgroundColor(bgcolor);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    #endregion
        //}

        public void setBackgroundColor(string bgcolor)
        {
            switch (bgcolor)
            {
                case "blue":
                    xrPictureBox2.Image = Resource1.blue1;
                    xrPictureBox3.Image = Resource1.blue2;
                    break;
                case "red":
                    xrPictureBox2.Image = Resource1.red1;
                    xrPictureBox3.Image = Resource1.red2;
                    break;
                case "green":
                    xrPictureBox2.Image = Resource1.green1;
                    xrPictureBox3.Image = Resource1.green2;
                    break;
                case "bluevn":
                    xrPictureBox2.Image = Resource1.bluevn1;
                    xrPictureBox3.Image = Resource1.bluevn2;
                    break;
                default:
                    xrPictureBox2.Image = Resource1.blue1;
                    xrPictureBox3.Image = Resource1.blue2;
                    break;
            }
        }
    }

    public class ModelConPrint
    {
        public string _Name { get; set; }
        public string _Employer { get; set; }
        public string _ValidTo { get; set; }
        public Image _Image { get; set; }
    }
}
