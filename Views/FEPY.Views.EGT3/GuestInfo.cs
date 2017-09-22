using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;
using FEPV.Model;
using BasicLanuage;
using MIS.Utility;
using System.Collections;

namespace FEPV.Views
{
    public partial class GuestInfo : UserControl
    {
        public GuestInfo()
        {
            InitializeComponent();
            dtListGuestState = rep.GetMISReport("Q_AC_State", new string[] { "Ctype", "Language" }
                , new object[] { "Guest", MyLanguage.Language }).Tables[0];
            gridViewGuest1.DoubleClick += new EventHandler(gridViewGuest1_DoubleClick);
            gridViewGuest1.Click += new EventHandler(gridViewGuest1_Click);
            txtName.KeyDown += new KeyEventHandler(txtName_KeyDown);
            tbMac.KeyDown += new KeyEventHandler(tbMac_KeyDown);

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGT3", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewGuest1");
            if (gridData != null)
            {
                this.gcGuest.DataSource = gridData;
                gridViewGuest1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewGuest1, "gridViewGuest1", dsgrid);
            }
            #endregion
        }

        ReportBiz rep = new ReportBiz();
        public event EventHandler eventBtnQueryPlanTrip;
        void tbMac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                eventBtnQueryPlanTrip(this, EventArgs.Empty);
        }

        public event EventHandler eventBtnQueryPlan;
        void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                eventBtnQueryPlan(this, EventArgs.Empty);
        }

        public event EventHandler eventShowGuestBar;
        void gridViewGuest1_Click(object sender, EventArgs e)
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

            if (eventShowGuestBar != null)
            {
                eventShowGuestBar(this, new FEPV.Views.EGATE3.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public event EventHandler eventShowGuestView;
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

            if (eventShowGuestView != null)
            {
                eventShowGuestView(this, new FEPV.Views.EGATE3.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "GuestName", "InOrOut", "Mac", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { txtName.Text.Trim(), InOutState, CardNO, MyLanguage.Language }; }
        }

        string InOutState
        {
            get 
            {
                return cbInOrOut.Text.Trim().Split('-')[0];
            }
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
                gcGuest.DataSource = value;
                gridViewGuest1.BestFitColumns();
            }
        }

        public DataTable dtListGuestState
        {
            set
            {
                cbInOrOut.DataSource = value;
                cbInOrOut.DisplayMember = "State";
                cbInOrOut.ValueMember = "State";
            }
        }

        public ArrayList SelectedRows 
        {
            get 
            {
                ArrayList rows = new ArrayList();

                int rowCount = gridViewGuest1.SelectedRowsCount;
                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (gridViewGuest1.GetSelectedRows()[i] >= 0)
                            rows.Add(gridViewGuest1.GetDataRow(gridViewGuest1.GetSelectedRows()[i]));
                    }
                }
                return rows;
            }
        }
    }
}
