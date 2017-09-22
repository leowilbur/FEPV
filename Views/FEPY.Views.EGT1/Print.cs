using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using FEPV.BLL;
using BasicLanuage;
using MIS.Utility;
using System.Globalization;

namespace FEPV.Views
{
    public class Print
    {
        PrintDocument pDoc = new PrintDocument();
        public void PrintBill(bool isPaperPrint)
        {
            //isPaperPrint = true : Printing
            if (!isPaperPrint)
                return;

            if ((string)_Setting[0] == "H")
                pDoc.DefaultPageSettings.Landscape = true;

            pDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size 1", Convert.ToInt32(_Setting[2].Trim()), Convert.ToInt32(_Setting[1].Trim()));
            pDoc.Print();
        }

        string _PonderationID = string.Empty;
        string _Type = string.Empty;
        DataRow row = null;

        private string[] _Setting;
        //Setting="Paper Type; Paper Height; Paper Weight; IsPrintFrame; FrameX; FrameY; OrginX; OrginY";
        public string Setting
        {
            set 
            { 
                _Setting = value.Split(';'); 
            }
        }

        public Print(string PonderationID, string Type)
        {
            _PonderationID = PonderationID;
            _Type = Type;

            //According to vehicle type printing
            ReportBiz report = new ReportBiz();
            DataRow rowsql = report.GetMISReport("Q_PonderationPrint4FEIS", new string[] { "VoucherID", "Type", "Language" }, new object[] { _PonderationID, _Type, MyLanguage.Language }).Tables[0].Rows[0];
            row = rowsql;

            this.pDoc.PrintPage += new PrintPageEventHandler(PrintWeightBill_FEPV);

        }
        public void PrintWeightBill_FEPV(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            row["MaterielType"].ToString();//货品名称
            row["Manufacturer"].ToString();//厂商
            row["Discharge"].ToString();//卸货点
            row["VehicleNO"].ToString();//车号
            row["VoucherID"].ToString();//
            row["PonderationID"].ToString();//磅单号
            row["FirstWeight"].ToString();//总重
            row["SecondWeight"].ToString();//空重
            row["TotalWeight"].ToString();//净重
            row["FirstTime"].ToString();//进厂过磅时间
            row["SecondTime"].ToString();//出厂过磅时间
            row["CupboardNO"].ToString();//柜号
            row["Weigher"].ToString();//过磅员
            row["Remark"].ToString();//备注
            row["ShippingOrder"].ToString();//订单号
            row["WeightDifference"].ToString();//磅差

            //Print Frame 
            if (Convert.ToBoolean(_Setting[3].Trim()))
                e.Graphics.DrawImage(Resource.Bill, Convert.ToInt32(_Setting[4].Trim()), Convert.ToInt32(_Setting[5].Trim()));

            Font font = new Font("Times New Roman", 12, FontStyle.Bold);
            Font fonttime = new Font("Times New Roman", 10, FontStyle.Bold);

            int x = Convert.ToInt32(_Setting[6].Trim()),
                y = Convert.ToInt32(_Setting[7].Trim());
            for (int i = 0; i < 3; i++)
            {
                e.Graphics.DrawString(row["PonderationID"].ToString(),
                    font, Brushes.Black, x, y - 28);
                e.Graphics.DrawString(row["FirstTime"].ToString(),
                    fonttime, Brushes.Black, x, y + 10);
                e.Graphics.DrawString(row["SecondTime"].ToString(),
                    fonttime, Brushes.Black, x, y + 40);
                e.Graphics.DrawString(row["VehicleNO"].ToString(),
                    font, Brushes.Black, x - 30, y + 65);

                string Manufacturer_Name = row["Manufacturer"].ToString();
                int Manufacturer_Length = 0, MaxCharIn1Line = 0;
                for (int m = 0; m < Manufacturer_Name.Length; m++)
                {
                    UnicodeCategory cat = char.GetUnicodeCategory(Manufacturer_Name[m]);
                    if (cat == UnicodeCategory.OtherLetter)
                    {
                        Manufacturer_Length += 2; //Chinese charater
                    }
                    else
                    {
                        Manufacturer_Length += 1; //English charater
                    }
                    MaxCharIn1Line += 1;
                    if (Manufacturer_Length >= 16)
                        break;
                }
                if (Manufacturer_Length < 16)
                    e.Graphics.DrawString(Manufacturer_Name.Substring(0, MaxCharIn1Line),
                        fonttime, Brushes.Black, x - 30, y + 113);
                else
                {
                    int lastspace_index = Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" ") == -1 ? MaxCharIn1Line : (Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" "));
                    e.Graphics.DrawString(Manufacturer_Name.Substring(0, lastspace_index),
        fonttime, Brushes.Black, x - 30, y + 100);
                    e.Graphics.DrawString(Manufacturer_Name.Substring(lastspace_index + 1),
        fonttime, Brushes.Black, x - 30, y + 125);

                }
                //
                Manufacturer_Name = row["MaterielType"].ToString();
                Manufacturer_Length = 0;
                MaxCharIn1Line = 0;
                for (int m = 0; m < Manufacturer_Name.Length; m++)
                {
                    UnicodeCategory cat = char.GetUnicodeCategory(Manufacturer_Name[m]);
                    if (cat == UnicodeCategory.OtherLetter)
                    {
                        Manufacturer_Length += 2; //Chinese charater
                    }
                    else
                    {
                        Manufacturer_Length += 1; //English charater
                    }
                    MaxCharIn1Line += 1;
                    if (Manufacturer_Length >= 16)
                        break;
                }
                if (Manufacturer_Length < 16)
                    e.Graphics.DrawString(Manufacturer_Name.Substring(0, MaxCharIn1Line),
                        fonttime, Brushes.Black, x - 30, y + 175);
                else
                {
                    int lastspace_index = Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" ") == -1 ? MaxCharIn1Line : (Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" "));
                    e.Graphics.DrawString(Manufacturer_Name.Substring(0, lastspace_index),
        fonttime, Brushes.Black, x - 30, y + 165);
                    e.Graphics.DrawString(Manufacturer_Name.Substring(lastspace_index + 1),
        fonttime, Brushes.Black, x - 30, y + 185);

                }
                //
                //e.Graphics.DrawString(row["MaterielType"].ToString(),font, Brushes.Black, x - 30, y + 175);
                e.Graphics.DrawString(row["FirstWeight"].ToString() + " Kg",
                    font, Brushes.Black, x + 22, y + 230);
                e.Graphics.DrawString(row["SecondWeight"].ToString() + " Kg",
                    font, Brushes.Black, x + 22, y + 260);
                e.Graphics.DrawString(row["TotalWeight"].ToString() + " Kg",
                    font, Brushes.Black, x + 22, y + 290);
                e.Graphics.DrawString(row["Weigher"].ToString().ToUpper(),
                    font, Brushes.Black, x - 20, y + 335);
                x += 286;
            }
            e.HasMorePages = false;

        }
    }
}
