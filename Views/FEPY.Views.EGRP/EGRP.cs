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
using BasicLanuage;

namespace FEPV.Views
{
    public partial class EGRP : Infrastructure.BaseForm
    {
        public EGRP()
        {
            InitializeComponent();
            this.Load += new EventHandler(EGATE_Load);
            CultureLanuage.ApplyResourcesFrom(this, "EGRP", "EGRP");
            RegisterCommand();
        }

        void EGATE_Load(object sender, EventArgs e)
        {
            BtnShow4Truck1();
            BtnShow4Guest1();
            BtnShow4Goods1();

            deckWorkspaceTruck.Show(_TruckInfo);
            deckWorkspaceGuest.Show(_GuestInfo);

            _TruckInfo.eventShowTruckProcess += new EventHandler(_TruckInfo_eventShowTruckProcess);
            _GuestInfo.eventShowGuestProcess += new EventHandler(_GuestInfo_eventShowGuestProcess);
            _GoodsInfo.eventShowGoodsProcess += new EventHandler(_GoodsInfo_eventShowGoodsProcess);
        }

        void _TruckInfo_eventShowTruckProcess(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;

            string _VoucherID = (string)args.EgateDictionary["VoucherID"];
            string _Item = args.EgateDictionary["ItemID"].ToString();
            string status = (string)args.EgateDictionary["Status"];
            string flag = (string)args.EgateDictionary["Types"];

            if (status == "O" || status == "X" || status == "")
            {
                MessageBox.Show("No task information!", "Current node");
                return;
            }
            if (flag == "ST")
            {
                return;
            }
            else if (flag == "PE" && !string.IsNullOrEmpty(_Item))
            {
                GetTasksWF(_Item);
            }
            else
            {
                GetTasksWF(_VoucherID);
            }
        }

        void _GuestInfo_eventShowGuestProcess(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;

            string _VoucherID = (string)args.EgateDictionary["VoucherID"];
            string status = (string)args.EgateDictionary["Status"];

            if (status == "O" || status == "X" || status == "")
            {
                MessageBox.Show("No task information!", "Current node");
                return;
            }
            if (!string.IsNullOrEmpty(_VoucherID))
                GetTasksWF(_VoucherID);
        }

        void _GoodsInfo_eventShowGoodsProcess(object sender, EventArgs e)
        {
            EgateArgs args = (EgateArgs)e;

            string _VoucherID = (string)args.EgateDictionary["VoucherID"];
            string status = (string)args.EgateDictionary["Status"];

            if (status == "O" || status == "X" || status == "N" || status == "W")
            {
                MessageBox.Show("No task information!", "Current node");
                return;
            }
            GetTasksWF(_VoucherID);
        }

        TruckInfo _TruckInfo = new TruckInfo();
        GuestInfo _GuestInfo = new GuestInfo();
        GoodsInfo _GoodsInfo = new GoodsInfo();
        GoodsNobackInfo _GoodsNobackInfo = new GoodsNobackInfo();

        /// <summary>
        /// 按钮注册
        /// </summary>
        private void RegisterCommand()
        {
            //Truck
            btnSearchTruck.Click += new EventHandler(btnSearchTruck_Click);
            btExcelTruck.Click += new EventHandler(btExcelTruck_Click);
            //Guest
            btnSearchGuest.Click += new EventHandler(btnSearchGuest_Click);
            btExcelGuest.Click += new EventHandler(btExcelGuest_Click);
            btnDetailsGuest.Click += new EventHandler(btnDetailsGuest_Click);
            btnRepGuest.Click += new EventHandler(btnRepGuest_Click);
            //Goods
            btnSearchGoods.Click += new EventHandler(btnSearchGoods_Click);
            btExcelGoods.Click += new EventHandler(btExcelGoods_Click);
            btExcelNoback.Click += new EventHandler(btExcelNoback_Click);
            btBackGoods.Click += new EventHandler(btBackGoods_Click);
        }

        void btBackGoods_Click(object sender, EventArgs e)
        {
            BtnShow4Goods1();
        }

        void btExcelNoback_Click(object sender, EventArgs e)
        {
            GoodsNobackExcel();
        }

        void btnRepGuest_Click(object sender, EventArgs e)
        {
            GuestForRepPrint();
        }

        void btnDetailsGuest_Click(object sender, EventArgs e)
        {
            GuestGetDetails();
        }

        void btExcelGoods_Click(object sender, EventArgs e)
        {
            GoodsExcel();
        }

        void btExcelGuest_Click(object sender, EventArgs e)
        {
            GuestExcel();
        }

        void btExcelTruck_Click(object sender, EventArgs e)
        {
            TruckExcel();
        }

        void btnSearchTruck_Click(object sender, EventArgs e)
        {
            TruckQueryPlan();
        }

        void btnSearchGuest_Click(object sender, EventArgs e)
        {
            GuestQueryPlan();
        }

        void btnSearchGoods_Click(object sender, EventArgs e)
        {
            if (_GoodsInfo.GoodsState == "B")
            {
                BtnShow4Goods2();
                GoodsNoBackQueryPlan();
            }
            else
            {
                GoodsQueryPlan(); 
            }
        }

        void BtnShow4Truck1()
        {
            barTruck.Refresh();
        }

        void BtnShow4Guest1()
        {
            btnRepGuest.Visible = false;
            barGuest.Refresh();
        }

        void BtnShow4Goods1()
        {
            btnSearchGoods.Visible = true;
            btExcelGoods.Visible = true;
            btExcelNoback.Visible = false;
            btBackGoods.Visible = false;
            barGoods.Refresh();
            deckWorkspaceGoods.Show(_GoodsInfo);
        }

        void BtnShow4Goods2()
        {
            btnSearchGoods.Visible = false;
            btExcelGoods.Visible = false;
            btExcelNoback.Visible = true;
            btBackGoods.Visible = true;
            barGoods.Refresh();
            deckWorkspaceGoods.Show(_GoodsNobackInfo);
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
