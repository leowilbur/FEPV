using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FEPV.Views
{
    public partial class EGUL : Infrastructure.BaseForm
    {
        public EGUL()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
            RegisterCommand();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            BtnShow4Truck1();
            BtnShow4Guest1();
            BtnShow4Contractor1();

            deckWorkspaceTruck.Show(_TruckInfo);
            deckWorkspaceGuest.Show(_GuestInfo);
            deckWorkspaceContractor.Show(_ContractorInfo);

            _TruckInfo.eventShowTruckUnlock += new EventHandler(_TruckInfo_eventShowTruckUnlock);
            _GuestInfo.eventShowGuestUnlock += new EventHandler(_GuestInfo_eventShowGuestUnlock);
            _ContractorInfo.eventShowContractorUnlock += new EventHandler(_ContractorInfo_eventShowContractorUnlock);

            _TruckInfo.eventShowTruckProcess += new EventHandler(_TruckInfo_eventShowTruckProcess);
            _GuestInfo.eventShowGuestProcess += new EventHandler(_GuestInfo_eventShowGuestProcess);
            _ContractorInfo.eventShowContractorProcess += new EventHandler(_ContractorInfo_eventShowContractorProcess);
        }

        void _ContractorInfo_eventShowContractorProcess(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;
            string _VoucherID = (string)args.EgateDictionary["NO"];
            ShowDetails(_VoucherID);            
        }

        void _GuestInfo_eventShowGuestProcess(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;
            string _VoucherID = (string)args.EgateDictionary["NO"];
            ShowDetails(_VoucherID);
        }

        void _TruckInfo_eventShowTruckProcess(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;
            string _VoucherID = (string)args.EgateDictionary["NO"];
            ShowDetails(_VoucherID);
        }

        void ShowDetails(string VoucherID)
        {
            DataTable dt = rep.GetMISReport("Q_BlackLists_Details",
                                                new string[] { "VehicleNO" },
                                                new object[] { VoucherID }).Tables[0];

            DetailsInfo dinfo = new DetailsInfo();
            dinfo.Plan4Table = dt;
            dinfo.ShowDialog();
        }

        void _ContractorInfo_eventShowContractorUnlock(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;

            string _VoucherID = (string)args.EgateDictionary["NO"];

            if (DialogResult.OK == MessageBox.Show("You have selected in the list【" + _VoucherID + "】,Is unlock?", "To unlock the contractor", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
            {
                string str = rep.GetMISReport("Q_BlackLists_Contractor_Unlock",
                                                new string[] { "VehicleNO" },
                                                new object[] { _VoucherID }).Tables[0].Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    MainMsg = str;
                    MessageBox.Show(str, "Prompt information");
                }
                else
                {
                    MessageBox.Show("Unlock successful", "Prompt information");
                    ContractorQueryPlan();
                }
            }
        }

        void _GuestInfo_eventShowGuestUnlock(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;

            string _VoucherID = (string)args.EgateDictionary["NO"];
            if (DialogResult.OK == MessageBox.Show("You have selected in the list【" + _VoucherID + "】,Is unlock?", "To unlock the visitors", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
            {
                string str = rep.GetMISReport("Q_BlackLists_Guest_Unlock",
                                                new string[] { "VehicleNO" },
                                                new object[] { _VoucherID }).Tables[0].Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    MainMsg = str;
                    MessageBox.Show(str, "Prompt information");
                }
                else
                {
                    MessageBox.Show("Unlock successful", "Prompt information");
                    GuestQueryPlan();
                }
            }
        }

        void _TruckInfo_eventShowTruckUnlock(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;

            string _VoucherID = (string)args.EgateDictionary["NO"];
            if (DialogResult.OK == MessageBox.Show("You have selected in the list【" + _VoucherID + "】,Is unlock?", "To unlock the vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
            {
                string str = rep.GetMISReport("Q_BlackLists_Truck_Unlock",
                                                new string[] { "VehicleNO" },
                                                new object[] { _VoucherID }).Tables[0].Rows[0][0].ToString();

                if (!string.IsNullOrEmpty(str))
                {
                    MainMsg = str;
                    MessageBox.Show(str, "Prompt information");
                }
                else
                {
                    MessageBox.Show("Unlock successful", "Prompt information");
                    TruckQueryPlan();
                }
            }
        }

        TruckInfo _TruckInfo = new TruckInfo();
        GuestInfo _GuestInfo = new GuestInfo();
        ContractorInfo _ContractorInfo = new ContractorInfo();
        /// <summary>
        /// 按钮注册
        /// </summary>
        private void RegisterCommand()
        {
            //Truck
            btnSearchTruck.Click += new EventHandler(btnSearchTruck_Click);
            btExcelTruck.Click += new EventHandler(btExcelTruck_Click);
            btnUnlockTruck.Click += new EventHandler(btnUnlockTruck_Click);
            //Guest
            btnSearchGuest.Click += new EventHandler(btnSearchGuest_Click);
            btExcelGuest.Click += new EventHandler(btExcelGuest_Click);
            btnUnlockGuest.Click += new EventHandler(btnUnlockGuest_Click);
            //Contractor
            btnSearchContractor.Click += new EventHandler(btnSearchContractor_Click);
            btExcelContractor.Click += new EventHandler(btExcelContractor_Click);
            btnUnlockContractor.Click += new EventHandler(btnUnlockContractor_Click);
        }

        void btnUnlockContractor_Click(object sender, EventArgs e)
        {
            ContractorUnlock();
        }

        void btExcelContractor_Click(object sender, EventArgs e)
        {
            ContractorExcel();
        }

        void btnSearchContractor_Click(object sender, EventArgs e)
        {
            ContractorQueryPlan();
        }

        void btnUnlockGuest_Click(object sender, EventArgs e)
        {
            GuestUnlock();
        }

        void btExcelGuest_Click(object sender, EventArgs e)
        {
            GuestExcel();
        }

        void btnSearchGuest_Click(object sender, EventArgs e)
        {
            GuestQueryPlan();
        }

        void btnUnlockTruck_Click(object sender, EventArgs e)
        {
            TruckUnlock();
        }

        void btExcelTruck_Click(object sender, EventArgs e)
        {
            TruckExcel();
        }

        void btnSearchTruck_Click(object sender, EventArgs e)
        {
            TruckQueryPlan();
        }

        void BtnShow4Truck1()
        {
            btnSearchTruck.Visible = true;
            barTruck.Refresh();
        }

        void BtnShow4Guest1()
        {
            btnSearchGuest.Visible = true;
            barGuest.Refresh();
        }

        void BtnShow4Contractor1()
        {
            btnSearchContractor.Visible = true;
            barContractor.Refresh();
        }

        string MainMsg
        {
            set
            {
                _txtMsg.Text = value;
                _txtMsg.Refresh();
            }
        }
    }

    public class EgateArgs : EventArgs
    {
        public Dictionary<string, object> EgateDictionary { get; set; }
    }
}
