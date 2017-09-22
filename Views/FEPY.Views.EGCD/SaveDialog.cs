using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FEPV.BLL;
using FEPV.Model;
using System.IO;
using MIS.Utility;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class SaveDialog : Infrastructure.StyleForm
    {
        public SaveDialog()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "EGCD", this.Name);
            deValidTo.Text = DateTime.Today.AddYears(1).ToString("yyyy-MM-dd");
            dtListCardState = rep.GetMISReport("EGCD_Get_CardData_State", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            dtListCardType = rep.GetMISReport("EGCD_Get_CardData_Type", new string[] { "Language" }
                , new object[] { MyLanguage.Language }).Tables[0];
            btSave.Click += btSave_Click;
            btCancel.Click += btCancel_Click;
            this.Load += new EventHandler(SaveDialog_Load);
        }


        void SaveDialog_Load(object sender, EventArgs e)
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
        public string ManageCOM { get; set; }//办证COM串口
        string rData = string.Empty;
        //访客办证串口
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
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (porisManage != null)
                porisManage.Dispose();

            base.OnClosed(e);
        }

        CardDataBiz cdbiz = new CardDataBiz();
        ReportBiz rep = new ReportBiz();

        void btCancel_Click(object sender, EventArgs e)
        {
            rValue = false;
            this.Close();
        }

        void btSave_Click(object sender, EventArgs e)
        {
            if (SaveCardNo())
            {
                rValue = true;
                //this.Close(); Leo-Do not close
                MessageBox.Show("Save success", "FEPV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Auto Clear and Next ID when save complete
                if (Edit_or_New == "new")
                {
                    ClearData();
                    ValidTo = DateTime.Today.AddYears(1);//Leo-add valid upto 1 year from today
                    CNO = NewCard(); //Leo-Add function NewCard
                }
                if (Edit_or_New == "edit")
                {
                }
            }
            else
            {
                rValue = false;
                MessageBox.Show("Save failed！", "Prompt information");
            }
        }

        public bool SaveCardNo()
        {
            if (string.IsNullOrEmpty(tbCardID.Text.Trim()) || string.IsNullOrEmpty(tbCNO.Text.Trim()))
            {
                MessageBox.Show("Please enter the card number！", "Prompt information");
                return false;
            }
            CardData cardData = new CardData();
            cardData.CardID = CardID;
            cardData.CNO = CNO;
            cardData.CardTypeID = CardTypeID;
            cardData.Status = Status;
            cardData.ValidTo = ValidTo;
            cardData.Remark = Remark;
            if (tbCardID.Enabled == true)
            {
                cardData.AccDate = DateTime.Now;
            }
            //保存卡信息
            return cdbiz.SaveCardData(cardData);
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

        public Dictionary<string, object> Paras
        {
            set
            {
                CardID = value["CardID"].ToString();
                CNO = value["CNO"].ToString();
                CardTypeID = value["CardTypeID"].ToString();
                ValidTo = Convert.ToDateTime(value["ValidTo"]);
                Remark = value["Remark"].ToString();
                Status = value["Status"].ToString();
            }
        }

        public void ClearData()
        {
            CardID = "";
            CNO = ""; 
            ValidTo = DateTime.Now;
            Remark = "";
        }

        bool rValue = false;
        public bool RValue { get { return rValue; } }

        public string CardID
        {
            get { return tbCardID.Text.Trim(); }
            set { tbCardID.Text = value; }
        }
        public string CNO
        {
            get { return tbCNO.Text.Trim(); }
            set { tbCNO.Text = value; }
        }
        public string CardTypeID
        {
            get { return cbCardType.SelectedValue.ToString(); }
            //set { cbCardType.ValueMember = value; }
            set { cbCardType.SelectedValue = value; }
        }
        public DateTime ValidTo
        {
            get
            {
                if (string.IsNullOrEmpty(deValidTo.Text))
                {
                    return DateTime.Today;
                }
                return Convert.ToDateTime(deValidTo.Text);
            }
            set { deValidTo.Text = value.ToString("yyyy-MM-dd"); }
        }
        public string Remark
        {
            get { return tbRemark.Text.Trim(); }
            set { tbRemark.Text = value; }
        }
        public string Status
        {
            get { return cbStatus.SelectedValue.ToString(); }
            set { cbStatus.SelectedValue = value; }
        }
        public string Edit_or_New
        {
            get;
            set;
        }
        public void Disabled_cbCardType()
        {
            cbCardType.Enabled = false;
            cbCardType.BackColor = Color.FromArgb(255, 255, 128);
        }
        //Add by Leo 2017-04-07
        private void cbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Edit_or_New == "new")
                CNO = NewCard();
        }
        public string NewCard()
        {
            DataTable dt = new DataTable();
            dt = rep.GetMISReport("EGCD_QueryCardData", new string[] { "CardID", "CardTypeID", "Status", "Language" }
                , new object[] { "", "0", "0", MyLanguage.Language }).Tables[0];

            int[] New_CardNo = { 0, 0, 0, 0, 0 };//Leo-New ID card is 1 (in case they doesn't have any card)
            string[] New_CardType = { "V", "C", "VIP", "G", "T" };
            foreach (DataRow dr in dt.Rows)
            {
                int max;
                switch (dr["CardTypeID"].ToString())
                {
                    case "1"://Guest
                        max = Convert.ToInt32(dr["CNO"].ToString().Substring(dr["CNO"].ToString().Length-4, 4));
                        if(max> New_CardNo[0])
                            New_CardNo[0] =max;//Leo-Count max new card
                        break;
                    case "2":
                        max = Convert.ToInt32(dr["CNO"].ToString().Substring(dr["CNO"].ToString().Length-4, 4));
                        if(max> New_CardNo[1])
                            New_CardNo[1] =max;//Leo-Count max new card
                        break;
                    case "3":
                        max = Convert.ToInt32(dr["CNO"].ToString().Substring(dr["CNO"].ToString().Length-4, 4));
                        if(max> New_CardNo[2])
                            New_CardNo[2] =max;//Leo-Count max new card
                        break;
                    case "4":
                        max = Convert.ToInt32(dr["CNO"].ToString().Substring(dr["CNO"].ToString().Length-4, 4));
                        if(max> New_CardNo[3])
                            New_CardNo[3] =max;//Leo-Count max new card
                        break;
                    case "5":
                        max = Convert.ToInt32(dr["CNO"].ToString().Substring(dr["CNO"].ToString().Length-4, 4));
                        if(max> New_CardNo[4])
                            New_CardNo[4] =max;//Leo-Count max new card
                        break;
                }
            }
            int i = Convert.ToInt32(cbCardType.SelectedValue);
            New_CardNo[i - 1] += 1;//Add +1 to new ID Card
            return New_CardType[i - 1] + New_CardNo[i - 1].ToString("0000");//Leo-Return new CardNo ID with format A0000
        }

    }
}
