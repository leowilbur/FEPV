using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace FEPV.Views
{
    public partial class ReportRTS : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportRTS()
        {
            InitializeComponent();
            xrLabel5.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BS.DataSource = rts;
        }

        List<RTSElements> rts = new List<RTSElements>();
        public List<RTSElements> dataSource
        {
            set
            {
                rts.Clear();
                foreach (RTSElements r in value)
                {
                    rts.Add(r);
                }
            }
        }

    }
}
