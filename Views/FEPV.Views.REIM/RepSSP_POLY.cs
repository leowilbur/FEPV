using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Data;

namespace FEPV.Views
{
    public partial class RepSSP_POLY : DevExpress.XtraReports.UI.XtraReport, IReportSource
    {
        public RepSSP_POLY()
        {
            InitializeComponent();

            bs.DataSource = list;
        }

        List<CollectElements> list = new List<CollectElements>();

        #region IReportSource Members

        public DataTable dataSource
        {
            set
            {
                foreach (DataRow row in value.Rows)
                {

                    list.Add(new CollectElements()
                    {
                        _MaterialNO = (string)row["MaterialNO"],
                        _ProdSpec = Convert.ToString(row["ProdSpec"]) ,
                        _CenterID = (string)row["CenterID"],
                        _Plant = (string)row["Plant"],
                        _Batch = (string)row["Batch"],
                        _BeginDate = (decimal)row["BeginDate"],
                        _PayInMonthWH = (decimal)row["PayInMonthWH"],
                        _PayInDayWH = (decimal)row["PayInDayWH"],
                        _TransferInMonth = (decimal)row["TransferInMonth"],
                        _DispatchInDay = (decimal)row["DispatchInDay"],
                        _PayOutInMonth = (decimal)row["PayOutInMonth"],
                        _PayOutInDay = (decimal)row["PayOutInDay"],
                        _DumpInMonth = (decimal)row["DumpInMonth"],
                        _DumpInDay = (decimal)row["DumpInDay"],
                        _Total = (decimal)row["Total"],
                        _Grade = row["Batch"].ToString().Substring(0, 2).TrimEnd('-'),
                        _Line = row["Batch"].ToString().Substring(4, 2).TrimEnd('-'),
                        _Grades = row["Batch"].ToString().Substring(2, 2).TrimEnd('-'),
                        _Chip = row["Batch"].ToString().Substring(6, 2).Trim()
                    });
                }
            }

        #endregion
        }

        public string CenterID
        {
            set
            {
                iCenter.Text = value;
            }
        }

        public string Date
        {
            set
            {
                IbDate.Text = value;
            }
        }
    }
}
