using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicLanuage;
using FEPV.BLL;
using MIS.Utility;

namespace FEPY.Views.Demo
{
    public partial class EGATETest :  Infrastructure.BaseForm
    {
        ReportBiz rep = new ReportBiz();
        public EGATETest()
        {
            InitializeComponent();
            MyLanguage.Language = "EN";

            // CultureLanuage.LangData  = rep.GetMISReport("B_GetBasicSetting", new string[] { "Tcode", "FormName" }, new object[] { "Demo", "EGATE" }).Tables[0];
            //_TruckInfo.Plan4TruckTable = dtTruck;
        }

        GuestInfo comview = new GuestInfo();

        private void EGATETest_Load(object sender, EventArgs e)
        {
            deckWorkspaceTruck.Show(comview);

            CultureLanuage.ApplyResourcesFrom(this, "Demo",  "EGATE");
        }
    }
}
