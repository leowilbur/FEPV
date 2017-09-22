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
    public partial class DataCardRep1 : DevExpress.XtraReports.UI.XtraReport
    {
        public DataCardRep1()
        {
            InitializeComponent();
            bindingSource1.DataSource = listpb;
        }

        FEPV.BLL.ReportBiz rep = new FEPV.BLL.ReportBiz();
        List<ModelConPrint> listpb = new List<ModelConPrint>();
        
        public bool InitializeValues(ArrayList SelectedRows, string bgcolor)
        {
            ModelConPrint _ModelConPrint;

            foreach (DataRow row in SelectedRows)
            {
                _ModelConPrint = new ModelConPrint();
                _ModelConPrint._CardNO = row["CNO"].ToString();
                _ModelConPrint._Name = row["Remark"].ToString();

                // Valid date minus 0000000
                _ModelConPrint._ValidTo = "Valid: " + row["ValidTo"].ToString().Substring(0,row["ValidTo"].ToString().Length - 8);
             
                string CardType=_ModelConPrint._CardNO.Substring(0, 1);

                //default background
                _ModelConPrint._Picture1 = Resource1.bluevn1;
                _ModelConPrint._Picture2 = Resource1.bluevn2;
                
                //Contractor -->Show message and not print
                if (CardType == "C")
                {
                    System.Windows.Forms.MessageBox.Show("Card NO: " + row["CNO"].ToString() + " is Contractor Card, It will not print");
                    continue;
                }
                //Visitor --> Green
                if (CardType == "V")
                {
                    _ModelConPrint._CardNoGreen = row["CNO"].ToString();
                    _ModelConPrint._Name = "";
                    _ModelConPrint._CardNO = "";
                    _ModelConPrint._ValidTo="";
                    _ModelConPrint._Picture1 = Resource1.greenvn1_1;
                    _ModelConPrint._Picture2 = Resource1.greenvn2;
                }
                //Guard and Temporary --> Yellow
                if (CardType == "G" || CardType == "T")
                {
                    _ModelConPrint._Name = "";
                    _ModelConPrint._CardNO = "";
                    _ModelConPrint._ValidTo = "";
                    _ModelConPrint._Picture1 = Resource1.yellowvn1;
                    _ModelConPrint._Picture2 = Resource1.yellowvn2;
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
    }

    public class ModelConPrint
    {
        public string _Name { get; set; }
        public string _CardNO { get; set; }
        public string _Employer { get; set; }
        public string _ValidTo { get; set; }
        public string _CardNoGreen { get; set; }

        public Image _Picture1 { get; set; }
        public Image _Picture2 { get; set; }
        
    }
}
