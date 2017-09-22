using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicLanuage;
using MIS.Utility;

namespace FEPY.Views.Demo
{
    public partial class GuestInfo : UserControl
    {

        GateInfo gateInfo = new GateInfo();
          
        public GuestInfo()
        {
            InitializeComponent();
            MyLanguage.Language = "CN";
            CultureLanuage.ApplyResourcesFrom(this, "Demo",  "GuestInfo");
            DataTable griddate = new DataTable();
            DataTable dt = CultureLanuage.LanguageDataSet.Tables["gvItemGrid"];
            Console.WriteLine(JsonConvert.SerializeObject(dt));
            foreach (DataRow row in dt.Rows)
            {
                griddate.Columns.Add(row["ID"].ToString());
            }
            this.gcGuest.DataSource = griddate;
            gvItemGrid.BestFitColumns();
            CultureLanuage.GridResourcesFrom(gvItemGrid, "gvItemGrid");
        }
        private void button3_Click(object sender, EventArgs e)
        {

            DataTable guests = gateInfo.GetGuests(new string[] { "GuestName", "InOrOut", "Mac" }, new object[] { "", "", "" }, "");
            this.gcGuest.DataSource = guests;

            gvItemGrid.BestFitColumns();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyLanguage.Language = "CN";
  
            CultureLanuage.ApplyResourcesFrom(this, "Demo", "GuestInfo");
            CultureLanuage.GridResourcesFrom(gvItemGrid, "gvItemGrid");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyLanguage.Language = "EN";

            CultureLanuage.ApplyResourcesFrom(this, "Demo", "GuestInfo");
            CultureLanuage.GridResourcesFrom(gvItemGrid, "gvItemGrid");
        }

      
    }
}
