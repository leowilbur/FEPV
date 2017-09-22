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
using MIS.Utility;
using BasicLanuage;
using System.Collections;//Leo

namespace FEPV.Views
{
    public partial class EGCD : Infrastructure.BaseForm
    {
        public EGCD()
        {
            InitializeComponent();

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGCD", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridViewGuest1");
            if (gridData != null)
            {
                this.gcGuest.DataSource = gridData;
                gridViewGuest1.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridViewGuest1, "gridViewTruck1", dsgrid);
            }
            #endregion

            dtListCardState = rep.GetMISReport("EGCD_Query_CardData_State", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            dtListCardType = rep.GetMISReport("EGCD_Query_CardData_Type", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            btnQuery.Click += btnQuery_Click;
            btnNew.Click += btnNew_Click;
            btnPrint.Click += btnPrint_Click;
            gridViewGuest1.DoubleClick += new EventHandler(gridViewGuest1_DoubleClick);
            this.Load += new EventHandler(EGCD_Load);
            
        }
        void EGCD_Load(object sender, EventArgs e)
        {
            //办证串口
            try
            {
                porisManage = new Poris(ManageCOM);
                porisManage.eventPassportScaned += new EventHandler(porisManage_eventPassportScaned);
            }
            catch (Exception exc)
            {
                MessageBox.Show("PorisManage Card reader failure:" + exc.Message, "Prompt information");
            }
        }

        public delegate void CardIDelegate(string cardid);
        Poris porisManage = null;
        string rData = string.Empty;
        void porisManage_eventPassportScaned(object sender, EventArgs e)
        {
            rData = (string)sender;
            MyInvoke(rData);
            rData = string.Empty;
        }
        public void MyInvoke(string cardid)
        {
            try
            {
                CardIDelegate mygate = new CardIDelegate(ReadCardIdByporisManage);
                this.Invoke(mygate, new object[] { cardid });
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void ReadCardIdByporisManage(string cardid)
        {
            tbCardID.Text = cardid;
            QueryCardData();
        }


        void btnPrint_Click(object sender, EventArgs e)
        {
           PrintCard();//Add by Leo 20170410
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
            QueryCardData();
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            SaveDialog sd = new SaveDialog();

            sd.Edit_or_New = "new";//Leo-For change select card type
            
            sd.ClearData();
            sd.ManageCOM = ManageCOM;

            sd.ValidTo = DateTime.Today.AddYears(1);//Leo-add valid upto 1 year from today

            sd.CNO = sd.NewCard(); //Leo-Add function NewCard
            
            porisManage.Dispose();
            sd.ShowDialog();
            porisManage.Open();

            if (sd.RValue)
            {
                QueryCardData();
            }

        }

        ReportBiz rep = new ReportBiz();
        public string ManageCOM { get; set; }//办证COM串口

        /// <summary>
        /// 卡片查询
        /// </summary>
        //private void QueryCardData()
        public void QueryCardData() //Leo: private -->public 20170411
        {
            CardDataTable = rep.GetMISReport("EGCD_QueryCardData", Parameters, Values).Tables[0];
        }

        public string[] Parameters
        {
            get { return new string[] { "CardID", "CardTypeID", "Status", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { CardID, cbCardType.SelectedValue.ToString(), cbStatus.SelectedValue.ToString(), MyLanguage.Language }; }
        }

        public string CardID
        {
            get { return tbCardID.Text.Trim(); }
            set { tbCardID.Text = value; }
        }

        public DataTable dtListCardState
        {
            set
            {
                cbStatus.DataSource = value;
                cbStatus.DisplayMember = "Status";
                cbStatus.ValueMember = "ID";
            }
        }

        public DataTable dtListCardType
        {
            set
            {
                cbCardType.DataSource = value;
                cbCardType.DisplayMember = "CardType";
                cbCardType.ValueMember = "ID";
            }
        }

        public DataTable CardDataTable
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
            sd.Edit_or_New = "edit";
            sd.Disabled_cbCardType();//Add by Leo 20170411
            sd.Paras = paramenters;
            sd.ManageCOM = ManageCOM;
            porisManage.Dispose();
            sd.ShowDialog();
            porisManage.Open();
            if (sd.RValue)
            {
                QueryCardData();
            }
        }
        void PrintCard()
        {
            if (SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the data to be printed!", "information");
                return;
            }

            //Leo-Show confim dialog
            if (DialogResult.OK == MessageBox.Show("Whether to print?", "Print", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
            {
                DataCardRep1 _DataCardRep1 = new DataCardRep1();
                
                //Leo-Background color
                string bgcolor = "bluevn";
                if (!_DataCardRep1.InitializeValues(SelectedRows, bgcolor))
                {
                    MessageBox.Show("Please upload a photo...");
                }
                else
                {
                    //_DataCardRep1.Print();
                    _DataCardRep1.ShowPreview();
                }
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
