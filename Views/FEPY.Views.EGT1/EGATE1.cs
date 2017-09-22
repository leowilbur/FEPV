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
    public partial class EGATE1 : Infrastructure.BaseForm
    {
        public EGATE1()
        {
            InitializeComponent();
            this.tabPageShort.Parent = null;//隐藏
            //this.tabPageShort.Parent = this.tabControl1;//显示
            CultureLanuage.ApplyResourcesFrom(this, "EGT1", "EGATE1");
            this.Load += new EventHandler(EGATE_Load);
            RegisterCommand();
        }

        void EGATE_Load(object sender, EventArgs e)
        {
            if (WeightMode != "HandMode")
            {
                txtHandWeight.Visible = false;
                txtHandWeight3.Visible = false;
            }

            BtnShow4Truck0();
            BtnShow4Short0();

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MainMsg = "Serial failures : " + ex.Message + "|" + e.ToString();
            }
            //DataReceived
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            this.BeginInvoke(new VoidDelegate(delegate()
            {
                timer.Enabled = true;
                timer.Interval = 1000;
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
            }));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //Don't come out of the shuttle vehicle
            if (DateTime.Now.ToString("HH:mm:ss") == "20:00:00")
            {
                DataTable dt = rep.GetMISReport("ST_GetInCompanyShortTrucks", new string[] { }, new object[] { }).Tables[0];
                string str = dt.Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(str))
                    MessageBox.Show(str, "Prompt information");
            }
        }

        /// <summary>
        /// Register button
        /// </summary>
        private void RegisterCommand()
        {
            //Truck button
            btnSearchTruck.Click += new EventHandler(btnSearchTruck_Click);
            btnInTruck.Click += new EventHandler(btnInTruck_Click);
            btnOutTruck.Click += new EventHandler(btnOutTruck_Click);
            btnWeightTruck.Click += new EventHandler(btnWeightTruck_Click);
            btnUpWeightTruck.Click += new EventHandler(btnUpWeightTruck_Click);
            btnPrintTruck.Click += new EventHandler(btnPrintTruck_Click);
            btnBackTruck.Click += new EventHandler(btnBackTruck_Click);
            _TruckInfo.eventShowTruckView += new EventHandler(_TruckInfo_eventShowTruckView);
            _TruckInfo.eventShowTruckBar += new EventHandler(_TruckInfo_eventShowTruckBar);
            _TruckInfo.eventBtnQueryPlan += new EventHandler(_TruckInfo_eventBtnQueryPlan);
            //Short button
            btnSearchShort.Click += new EventHandler(btnSearchShort_Click);
            btnInShort.Click += new EventHandler(btnInShort_Click);
            btnOutShort.Click += new EventHandler(btnOutShort_Click);
            btnWeightShort.Click += new EventHandler(btnWeightShort_Click);
            btnUpWeightShort.Click += new EventHandler(btnUpWeightShort_Click);
            btnPrintShort.Click += new EventHandler(btnPrintShort_Click);
            btnBackShort.Click += new EventHandler(btnBackShort_Click);
            //
            _ShortInfo.eventShowShortView += new EventHandler(_ShortInfo_eventShowShortView);
        }

        TruckInfo _TruckInfo = new TruckInfo();
        JobTruckView _JobTruckView = new JobTruckView();
        ShortInfo _ShortInfo = new ShortInfo();
        JobShortView _JobShortView = new JobShortView();

        public string IsCallERP { get; set; } //Do you need to call ERP
        public string Setting4Print { get; set; }//Print Bill Setting
        public string UserID { get; set; }//The people of work flow
        public string WeightMode { get; set; }//Loadometer weighing mode (manual/automatic)
        public delegate void VoidDelegate();
        Timer timer = new Timer();//Shuttle Vehicle Timer

        public System.IO.Ports.SerialPort PORT//Serial Weighing
        {
            get
            {
                return serialPort;
            }
            set
            {
                serialPort = value;
            }
        }
        
        public string SelectTabPagName
        {
            get { return tabControl1.SelectedTab.Name; }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (serialPort != null)
                serialPort.Dispose();
            base.OnClosed(e);
        }

        #region Button Click
        //Truck
        void btnSearchTruck_Click(object sender, EventArgs e)
        {
            TruckQueryPlan();
        }

        void btnInTruck_Click(object sender, EventArgs e)
        {
            CheckIn4Truck();
        }

        void btnOutTruck_Click(object sender, EventArgs e)
        {
            CheckOut4Truck();
        }

        void btnWeightTruck_Click(object sender, EventArgs e)
        {
            Weight();
        }

        void btnPrintTruck_Click(object sender, EventArgs e)
        {
            PrintPonderation();
        }

        void btnBackTruck_Click(object sender, EventArgs e)
        {
            Back4Truck();
        }
        
        //Short Truck
        void btnSearchShort_Click(object sender, EventArgs e)
        {
            ShortQueryPlan();
        }

        void btnInShort_Click(object sender, EventArgs e)
        {
            CheckIn4Short();
        }

        void btnOutShort_Click(object sender, EventArgs e)
        {
            CheckOut4Short();
        }

        void btnWeightShort_Click(object sender, EventArgs e)
        {
            WeightShort();
        }

        void btnUpWeightShort_Click(object sender, EventArgs e)
        {
            UpWeightShort();
        }

        void btnPrintShort_Click(object sender, EventArgs e)
        {
            PrintPonderationShort();
        }

        void btnBackShort_Click(object sender, EventArgs e)
        {
            Back4Short();
        }
        #endregion

        #region button show

        //Truck
        /// <summary>
        /// The initial button to display
        /// </summary>
        void BtnShow4Truck0()
        {
            btnSearchTruck.Visible = true;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = false;
            btnUpWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = false;
            barTruck.Refresh();
            deckWorkspaceTruck.Show(_TruckInfo);
        }
        void BtnShow4Truck1()
        {
            btnSearchTruck.Visible = true;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = false;
            btnUpWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = false;
            barTruck.Refresh();
            deckWorkspaceTruck.Show(_TruckInfo);
            TruckQueryPlan();
        }
        void BtnShow4Truck2In()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = true;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = false;
            btnUpWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            deckWorkspaceTruck.Show(_JobTruckView);
        }
        void BtnShow4Truck2Weight1()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = true;
            btnUpWeightTruck.Visible = true;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            deckWorkspaceTruck.Show(_JobTruckView);
        }
        void BtnShow4Truck2Weight2()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = true;
            btnUpWeightTruck.Visible = true;
            btnPrintTruck.Visible = true;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            deckWorkspaceTruck.Show(_JobTruckView);
        }
        void BtnShow4Truck2Print()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = false;
            btnUpWeightTruck.Visible = false;
            btnPrintTruck.Visible = true;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            deckWorkspaceTruck.Show(_JobTruckView);
        }
        void BtnShow4Truck2Out()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = true;
            btnWeightTruck.Visible = false;
            btnUpWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            deckWorkspaceTruck.Show(_JobTruckView);
        }

        //ShortTruck
        /// <summary>
        /// The initial button to display
        /// </summary>
        void BtnShow4Short0()
        {
            btnSearchShort.Visible = true;
            btnInShort.Visible = false;
            btnOutShort.Visible = false;
            btnWeightShort.Visible = false;
            btnUpWeightShort.Visible = false;
            btnPrintShort.Visible = false;
            btnBackShort.Visible = false;
            barShort.Refresh();
            deckWorkspaceShort.Show(_ShortInfo);
        }
        void BtnShow4Short1()
        {
            btnSearchShort.Visible = true;
            btnInShort.Visible = false;
            btnOutShort.Visible = false;
            btnWeightShort.Visible = false;
            btnUpWeightShort.Visible = false;
            btnPrintShort.Visible = false;
            btnBackShort.Visible = false;
            barShort.Refresh();
            deckWorkspaceShort.Show(_ShortInfo);
            ShortQueryPlan();
        }
        void BtnShow4Short2In()
        {
            btnSearchShort.Visible = false;
            btnInShort.Visible = true;
            btnOutShort.Visible = false;
            btnWeightShort.Visible = false;
            btnUpWeightShort.Visible = false;
            btnPrintShort.Visible = false;
            btnBackShort.Visible = true;
            barShort.Refresh();
            deckWorkspaceShort.Show(_JobShortView);
        }
        void BtnShow4Short2Weight1()
        {
            btnSearchShort.Visible = false;
            btnInShort.Visible = false;
            btnOutShort.Visible = false;
            btnWeightShort.Visible = true;
            btnUpWeightShort.Visible = true;
            btnPrintShort.Visible = false;
            btnBackShort.Visible = true;
            barShort.Refresh();
            deckWorkspaceShort.Show(_JobShortView);
        }
        void BtnShow4Short2Weight2()
        {
            btnSearchShort.Visible = false;
            btnInShort.Visible = false;
            btnOutShort.Visible = false;
            btnWeightShort.Visible = true;
            btnUpWeightShort.Visible = true;
            btnPrintShort.Visible = true;
            btnBackShort.Visible = true;
            barShort.Refresh();
            deckWorkspaceShort.Show(_JobShortView);
        }
        void BtnShow4Short2Print()
        {
            btnSearchShort.Visible = false;
            btnInShort.Visible = false;
            btnOutShort.Visible = false;
            btnWeightShort.Visible = false;
            btnUpWeightShort.Visible = false;
            btnPrintShort.Visible = true;
            btnBackShort.Visible = true;
            barShort.Refresh();
            deckWorkspaceShort.Show(_JobShortView);
        }
        void BtnShow4Short2Out()
        {
            btnSearchShort.Visible = false;
            btnInShort.Visible = false;
            btnOutShort.Visible = true;
            btnWeightShort.Visible = false;
            btnUpWeightShort.Visible = false;
            btnPrintShort.Visible = false;
            btnBackShort.Visible = true;
            barShort.Refresh();
            deckWorkspaceShort.Show(_JobShortView);
        } 
        #endregion

        public class EgateArgs : EventArgs
        {
            public Dictionary<string, object> EgateDictionary { get; set; }
        }

        string MainMsg 
        {
            set 
            { 
                _txtMsg.Text = value; 
                _txtMsg.Refresh(); 
            }
        }
        
        string dataWeight = "";
        DataPackage dataPackage = new DataPackage { Weight = 0m, LastActive = DateTime.Now };
        private void timer4ComMonitor_Tick(object sender, EventArgs e)
        {
            string ledComName = PORT.PortName.ToUpper().Trim().Replace("COM", "").PadLeft(3, '0');
            
            ledStationID.Text = ledComName;
            ledStationID3.Text = ledComName;

            if ((dataPackage.LastValidated - DateTime.Now).Duration() > new TimeSpan(0, 0, 2))
            {
                led1.ForeColor = Color.Red;
                led3.ForeColor = Color.Red;
            }
            else
            {
                if ((dataPackage.LastChanged - DateTime.Now).Duration() < new TimeSpan(0, 0, 2))
                {
                    led1.ForeColor = Color.Yellow;
                    led3.ForeColor = Color.Yellow;
                }
                else
                {
                    led1.ForeColor = Color.Blue;
                    led3.ForeColor = Color.Blue;
                }

                dataWeight = dataPackage.Weight.ToString().PadLeft(8, ' ');
                led1.Text = dataWeight;
 
                led3.Text = dataWeight;
            }

            if ((dataPackage.LastActive - DateTime.Now).Duration() > new TimeSpan(0, 0, 5))
            {
                lc1.Visible = true;
                lc3.Visible = true;
            }
            else
            {
                lc1.Visible = false;
                lc3.Visible = false;
            }
        }
    }
}
