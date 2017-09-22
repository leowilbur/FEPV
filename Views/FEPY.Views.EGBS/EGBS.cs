using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.Ports;
using FEPV.BLL;

namespace FEPV.Views
{
    public partial class EGBS : Infrastructure.BaseForm
    {
        public EGBS()
        {
            InitializeComponent();
            btnSearchGuest.Click += btnSearchGuest_Click;
            gridViewGuest1.DoubleClick += new EventHandler(gridViewGuest1_DoubleClick);
            
        }        

        AcBiz ab = new AcBiz();
        public string ManageCOM { get; set; }//办证COM串口

        void btnSearchGuest_Click(object sender, EventArgs e)
        {
            GuestQueryPlan();
        }
        /// <summary>
        /// 访客计划查询
        /// </summary>
        private void GuestQueryPlan()
        {
            Plan4GuestTable = ab.GetGuests(Parameters, Values, "Guard"); 
        }

        public string[] Parameters
        {
            get { return new string[] { "GuestName", "InOrOut", "Mac" }; }
        }

        public object[] Values
        {
            get { return new object[] { txtName.Text.Trim(), "In", CardNO }; }
        }

        public string CardNO
        {
            get { return tbMac.Text.Trim(); }
            set { tbMac.Text = value; }
        }

        public DataTable Plan4GuestTable
        {
            set
            {
                gridViewGuest1.Columns.Clear();
                gcGuest.DataSource = value;
                gridViewGuest1.BestFitColumns();
            }
        }

        void gridViewGuest1_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, object> paramenters = new Dictionary<string, object>();

            int rowCount = gridViewGuest1.SelectedRowsCount;
            if (rowCount != 1)
                return;

            DataRow row = gridViewGuest1.GetDataRow(gridViewGuest1.GetSelectedRows()[0]);
            foreach (DataColumn c in row.Table.Columns)
            {
                paramenters.Add(c.ColumnName, row[c.ColumnName]);
            }

            SaveDialog sd = new SaveDialog();
            sd.Paras = paramenters;
            sd.ManageCOM = ManageCOM;
            sd.ShowDialog();
            if (sd.RValue)
            {
                GuestQueryPlan();
            }
        }
    }
}
