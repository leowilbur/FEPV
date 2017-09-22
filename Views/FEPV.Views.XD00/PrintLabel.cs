using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using MIS.Utility;
using System.Globalization;

namespace FEPV.Views
{
    public class PrintLabel
    {
        PrintDocument pDoc = new PrintDocument();
        public void PrintStart()
        {
            PaperSize ps = new PaperSize("Custom Size 1", 1169, 780);
            pDoc.DefaultPageSettings.Landscape = true;
            pDoc.DefaultPageSettings.PaperSize = ps;
            pDoc.Print();
        }
        public string content;
        public PrintLabel()
        {

            this.pDoc.PrintPage += new PrintPageEventHandler(PrintContent);

        }
        public void PrintContent(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Font font = new Font("Times New Roman", 12, FontStyle.Bold);
            Font font = new Font("SimSun", 12, FontStyle.Regular);
            e.Graphics.DrawString(content,       font, Brushes.Black, 0, 0);
            e.HasMorePages = false;

        }


    }
}
