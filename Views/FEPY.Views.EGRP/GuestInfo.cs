using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.BLL;
using MIS.Utility;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class GuestInfo : UserControl
    {
        ReportBiz rep = new ReportBiz();
        public GuestInfo()
        {
            InitializeComponent();
            dateEditB.Text = DateTime.Today.ToString("yyyy-MM-dd");
            dateEditE.Text = DateTime.Today.ToString("yyyy-MM-dd");
            dtListGuestState = rep.GetMISReport("Q_Logs_Guest_State", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            dtListGuestType = rep.GetMISReport("Q_Logs_Guest_Type", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            //gridViewGuest1.DoubleClick += new EventHandler(gridViewGuest1_DoubleClick);
            
            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGRP", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewGuest1");
            if (gridData != null)
            {
                this.gcGuest.DataSource = gridData;
                gridViewGuest1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewGuest1, "gridViewGuest1", dsgrid);
            }
            #endregion
        }

        public event EventHandler eventShowGuestProcess;
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

            if (eventShowGuestProcess != null)
            {
                eventShowGuestProcess(this, new FEPV.Views.EgateArgs { EgateDictionary = paramenters });
            }
        }

        public string[] Parameters
        {
            get { return new string[] { "B", "E", "GuestState", "GuestName", "Company", "GuestType", "Mac", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { B, E, GuestState, _访客姓名.Text.Trim(), _客户单位.Text.Trim(), GuestType, CardNO, MyLanguage.Language }; }
        }

        DateTime? B
        {
            get
            {
                if (string.IsNullOrEmpty(dateEditB.Text))
                {
                    return DateTime.Today;
                }
                return Convert.ToDateTime(dateEditB.Text);
            }
        }

        DateTime? E
        {
            get
            {
                if (string.IsNullOrEmpty(dateEditE.Text))
                {
                    return DateTime.Today;
                }
                return Convert.ToDateTime(dateEditE.Text);
            }
        }

        string GuestState
        {
            get
            {
                return _状态.Text.Trim().Split('-')[0];
            }
        }

        string GuestType
        {
            get 
            {
                return _人员类型.Text.Trim().Split('-')[0]; 
            }
        }

        public string CardNO
        {
            get { return _卡号.Text.Trim(); }
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
                _状态.DataSource = value;
                _状态.DisplayMember = "State";
                _状态.ValueMember = "State";
            }
        }

        public DataTable dtListGuestType
        {
            set
            {
                _人员类型.DataSource = value;
                _人员类型.DisplayMember = "TypeName";
                _人员类型.ValueMember = "TypeName";
            }
        }

        public void GuestExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel(*.xls)|*.xls";
            sfd.Title = "ToExcel";
            sfd.FileName = "Personnel Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridViewGuest1.ExportToXls(sfd.FileName);
                MessageBox.Show(@"Success" + "Personnel Statistics" + DateTime.Now.ToString("yyyyMMdd") + ".xls", "Prompt information");
            }
        }

        internal void GuestGetDetails()
        {
            int rowCount = gridViewGuest1.SelectedRowsCount;
            if (rowCount != 1)
            {
                MessageBox.Show("Please choose and try again");
                return;
            }

            DataRow row = gridViewGuest1.GetDataRow(gridViewGuest1.GetSelectedRows()[0]);

            string voucherId = row["VoucherID"].ToString();
            string id = row["ID"].ToString();
            string flag = row["Types"].ToString();
            string idcard = row["IdCard"].ToString();
            string employer = row["Enterprise"].ToString();
            DataTable dtDetails = new DataTable();

            dtDetails = rep.GetMISReport("Q_Logs_Guest_Details",
                new string[] { "VoucherID", "ID", "Flag", "IdCard", "Employer" },
                new object[] { voucherId, id, flag, idcard, employer }).Tables[0];

            if (dtDetails.Rows.Count > 0)
            {
                DataRow row2 = dtDetails.Rows[0];
                DetailsInfo dinfo = new DetailsInfo();
                dinfo.SetInfo(row2);
                dinfo.ShowDialog();
            } 
        }
    }
}
