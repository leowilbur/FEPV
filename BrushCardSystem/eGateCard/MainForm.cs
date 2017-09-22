using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Service;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace eGateCard
{
    public delegate void VoidDelegate();

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            InitForm();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                //Remoting连接判断
                helper = IsConnectRemoting(out msg);
                if (!string.IsNullOrEmpty(msg) || helper == null)
                {
                    MessageBox.Show("ConnectRemoting Error : " + msg, "Prompt message");
                    return;
                }

                //读取配置文件
                ID1 = (int)(configurationAppSettings.GetValue("ID1", typeof(int)));
                ID2 = (int)(configurationAppSettings.GetValue("ID2", typeof(int)));
                ID3 = (int)(configurationAppSettings.GetValue("ID3", typeof(int)));
                ID4 = (int)(configurationAppSettings.GetValue("ID4", typeof(int)));
                ID5 = (int)(configurationAppSettings.GetValue("ID5", typeof(int)));
                ID6 = (int)(configurationAppSettings.GetValue("ID6", typeof(int)));
                ID7 = (int)(configurationAppSettings.GetValue("ID7", typeof(int)));
                ID8 = (int)(configurationAppSettings.GetValue("ID8", typeof(int)));
                TimeOut = (int)(configurationAppSettings.GetValue("TimeOut", typeof(int)));
                StatesCount = (int)(configurationAppSettings.GetValue("MaxRow", typeof(int)));

                //配置串口
                poris1 = new Poris("COM" + ID1.ToString());
                poris1.TimeOut = TimeOut;
                poris1.eventPassportScaned += new EventHandler(poris1_eventPassportScaned);

                poris2 = new Poris("COM" + ID2.ToString());
                poris2.TimeOut = TimeOut;
                poris2.eventPassportScaned += new EventHandler(poris2_eventPassportScaned);

                poris3 = new Poris("COM" + ID3.ToString());
                poris3.TimeOut = TimeOut;
                poris3.eventPassportScaned += new EventHandler(poris3_eventPassportScaned);

                poris4 = new Poris("COM" + ID4.ToString());
                poris4.TimeOut = TimeOut;
                poris4.eventPassportScaned += new EventHandler(poris4_eventPassportScaned);

                poris5 = new Poris("COM" + ID5.ToString());
                poris5.TimeOut = TimeOut;
                poris5.eventPassportScaned += new EventHandler(poris5_eventPassportScaned);

                poris6 = new Poris("COM" + ID6.ToString());
                poris6.TimeOut = TimeOut;
                poris6.eventPassportScaned += new EventHandler(poris6_eventPassportScaned);

                poris7 = new Poris("COM" + ID7.ToString());
                poris7.TimeOut = TimeOut;
                poris7.eventPassportScaned += new EventHandler(poris7_eventPassportScaned);

                poris8 = new Poris("COM" + ID8.ToString());
                poris8.TimeOut = TimeOut;
                poris8.eventPassportScaned += new EventHandler(poris8_eventPassportScaned);
            }
            catch (Exception ex)
            {
                Text += "  :  " + ex.Message;
                MessageBox.Show(" Load Error : " + ex.Message, "Prompt message");
            }

            //
            IDScanded += new EventHandler(MainForm_IDScanded);
            lblTimer.DoubleClick += lblTimer_DoubleClick;

            this.BeginInvoke(new VoidDelegate(delegate()
            {
                timer1.Enabled = true;
                timer1.Interval = 500;
                timer1.Start();
                timer1.Tick += new EventHandler(timer1_Tick);
                //
                timer1.Enabled = true;
            }));
        }

        void lblTimer_DoubleClick(object sender, EventArgs e)
        {
            tbPointTest.Visible = !tbPointTest.Visible;
            tbCardNoTest.Visible = !tbCardNoTest.Visible;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void InitForm()
        {
            bindingSource1.DataSource = models;
            txtCardNo.DataBindings.Add("Text", bindingSource1, "Mac");
            txtState.DataBindings.Add("Text", bindingSource1, "State");
            txtState.DataBindings.Add("ForeColor", bindingSource1, "ColorStates");
            txtInOut.DataBindings.Add("Text", bindingSource1, "InOut");
            txtName.DataBindings.Add("Text", bindingSource1, "Name");
            txtDep.DataBindings.Add("Text", bindingSource1, "Department");
            _picture.DataBindings.Add("Image", bindingSource1, "Pic");

            gridControl1.DataSource = bindingSource1;
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[0].Visible = false;
            //gridView1.BestFitColumns();
            gridView1.Columns[1].Width = 90;
            gridView1.Columns[2].Width = 140;
            gridView1.Columns[3].Width = 180;
            gridView1.Columns[4].Width = 60;
            gridView1.Columns[5].Width = 140;
            gridView1.Columns[6].Width = 140;
            gridView1.Columns[7].Width = 140;
            gridView1.Columns[8].Width = 200;
            gridView1.Columns[9].Width = 180;
            tbCardNoTest.KeyDown += tbCardNoTest_KeyDown;
        }

        void tbCardNoTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

            IDScanded(string.Format("{0}|{1}|{2}", tbPointTest.Text.Trim(), tbCardNoTest.Text.PadLeft(10, '0'), DateTime.Now),
                                  EventArgs.Empty);
        }

        TServiceHelper helper;
        BindingList<Model> models = new BindingList<Model>();
        ArrayList states = new ArrayList();

        public int StatesCount { get; set; }

        public string AddRow(string Data)
        {
            try
            {
                List<Model> _model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model>>(Data);
                //MessageBox.Show("_model.Count:" + _model.Count.ToString());
                foreach (var m in _model)
                {
                    states.Insert(0, m);
                    if (states.Count > 0)
                    {
                        bindingSource1.ResetBindings(false);
                        if (states.Count > StatesCount)
                            states.RemoveAt(StatesCount);
                    }
                }
                bindingSource1.DataSource = states;

                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(DateTime.Now.ToString() + " AddRow Error : " + ex.Message);
                return string.Empty;
            }
        }
        
        public static System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
        public int ID1 { get; set; }
        public int ID2 { get; set; }
        public int ID3 { get; set; }
        public int ID4 { get; set; }
        public int ID5 { get; set; }
        public int ID6 { get; set; }
        public int ID7 { get; set; }
        public int ID8 { get; set; }
        public int TimeOut { get; set; }

        Poris poris1 = null;
        Poris poris2 = null;
        Poris poris3 = null;
        Poris poris4 = null;
        Poris poris5 = null;
        Poris poris6 = null;
        Poris poris7 = null;
        Poris poris8 = null;

        void poris1_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(1, string.Empty);
            ComDataReceived(ref stamp1, (string)sender, ID1);
        }

        void poris2_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(2, string.Empty);
            ComDataReceived(ref stamp2, (string)sender, ID2);
        }

        void poris3_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(3, string.Empty);
            ComDataReceived(ref stamp3, (string)sender, ID3);
        }

        void poris4_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(4, string.Empty);
            ComDataReceived(ref stamp4, (string)sender, ID4);
        }

        void poris5_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(5, string.Empty);
            ComDataReceived(ref stamp5, (string)sender, ID5);
        }

        void poris6_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(6, string.Empty);
            ComDataReceived(ref stamp6, (string)sender, ID6);
        }

        void poris7_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(7, string.Empty);
            ComDataReceived(ref stamp7, (string)sender, ID7);
        }

        void poris8_eventPassportScaned(object sender, EventArgs e)
        {
            PopCom(8, string.Empty);
            ComDataReceived(ref stamp8, (string)sender, ID8);
        }
        
        public void PopCom(int com, string mac)
        {
            this.Invoke(new VoidDelegate(delegate()
            {
                if (com == 1)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[0] = DateTime.Now;
                    }
                    else
                        stamps[0] = DateTime.Now.AddSeconds(-4);
                }

                if (com == 2)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[1] = DateTime.Now;
                    }
                    else
                        stamps[1] = DateTime.Now.AddSeconds(-4);
                }

                if (com == 3)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[2] = DateTime.Now;
                    }
                    else
                        stamps[2] = DateTime.Now.AddSeconds(-4);
                }

                if (com == 4)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[3] = DateTime.Now;
                    }
                    else
                        stamps[3] = DateTime.Now.AddSeconds(-4);
                }

                if (com == 5)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[4] = DateTime.Now;
                    }
                    else
                        stamps[4] = DateTime.Now.AddSeconds(-4);
                }

                if (com == 6)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[5] = DateTime.Now;
                    }
                    else
                        stamps[5] = DateTime.Now.AddSeconds(-4);
                }

                if (com == 7)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[6] = DateTime.Now;
                    }
                    else
                        stamps[6] = DateTime.Now.AddSeconds(-4);
                }

                if (com == 8)
                {
                    if (mac.Trim() != "")
                    {
                        stamps[7] = DateTime.Now;
                    }
                    else
                        stamps[7] = DateTime.Now.AddSeconds(-4);
                }
            }));
        }

        DateTime[] stamps = { DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, 
                              DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now };

        void MainForm_IDScanded(object sender, EventArgs e)
        {
            string[] args = (sender.ToString() + "|").Split("|".ToCharArray());

            this.BeginInvoke(new VoidDelegate(delegate()
            {
                string[] paramenters = new string[]
                {
                   "COM","MAC","Stamp","UserID"
                };

                try
                {
                    //MessageBox.Show("Report");
                    DataTable dt = helper.Report("iDoIdProcess_Poris", paramenters, new object[] { args[0], args[1], args[2], "" });
                    if (dt.Rows.Count == 0) //忽略
                        return;
                    //MessageBox.Show("dt.Rows.Count:" + dt.Rows.Count.ToString());
                    //string data = MBR.KnownObjects.Utility.J2S(dt);
                    string data = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
                    //MessageBox.Show("data:" + data);
                    AddRow(data);

                    DataRow row = dt.Rows[0];

                    //if (!string.IsNullOrEmpty((string)row["Speach"]) && ((string)row["Speach"]).Length < 50)
                    //    Speach((string)row["Speach"]);

                    if (((int)row["ON"]) == 1)
                    {
                        if (Convert.ToInt32(args[0]) == ID1)
                        {
                            //poris1.ON = true;
                            this.Text = "COM" + ID1.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }

                        if (Convert.ToInt32(args[0]) == ID2)
                        {
                            //poris2.ON = true;
                            this.Text = "COM" + ID2.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }

                        if (Convert.ToInt32(args[0]) == ID3)
                        {
                            //poris3.ON = true;
                            this.Text = "COM" + ID3.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }

                        if (Convert.ToInt32(args[0]) == ID4)
                        {
                            //poris4.ON = true;
                            this.Text = "COM" + ID4.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }

                        if (Convert.ToInt32(args[0]) == ID5)
                        {
                            //poris5.ON = true;
                            this.Text = "COM" + ID5.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }

                        if (Convert.ToInt32(args[0]) == ID6)
                        {
                            //poris6.ON = true;
                            this.Text = "COM" + ID6.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }

                        if (Convert.ToInt32(args[0]) == ID7)
                        {
                            //poris7.ON = true;
                            this.Text = "COM" + ID7.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }

                        if (Convert.ToInt32(args[0]) == ID8)
                        {
                            //poris8.ON = true;
                            this.Text = "COM" + ID8.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss.fff");
                            return;
                        }
                    }
                    //C#手动回收内存
                    System.GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" IDScanded Error : " + ex.Message, "Prompt message");
                }
            }));
        }

        public event EventHandler IDScanded;

        DateTime stamp1 = DateTime.Now;
        DateTime stamp2 = DateTime.Now;
        DateTime stamp3 = DateTime.Now;
        DateTime stamp4 = DateTime.Now;
        DateTime stamp5 = DateTime.Now;
        DateTime stamp6 = DateTime.Now;
        DateTime stamp7 = DateTime.Now;
        DateTime stamp8 = DateTime.Now;

        private void ComDataReceived(ref DateTime stamp, string mac, int comPort)
        {
            if (IDScanded != null)
                IDScanded(string.Format("{0}|{1}|{2}", comPort, mac, DateTime.Now), EventArgs.Empty);

            stamp = DateTime.Now;
        }

        private TServiceHelper IsConnectRemoting(out string mes)
        {
            mes = "";
            try
            {
                TcpChannel chan1 = new TcpChannel();
                ChannelServices.RegisterChannel(chan1);
                TServiceHelper helper = (TServiceHelper)Activator.GetObject(typeof(TServiceHelper),
                    System.Configuration.ConfigurationSettings.AppSettings["ServiceURL"]);

                if (helper == null)
                {
                    mes = "TCP server not turned on!";
                    return null;
                }
                return helper;
            }
            catch (Exception e)
            {
                mes = e.Message + e.InnerException;
                MessageBox.Show(mes);
                return null;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("   Confirm exit    ??   ", "Prompt message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            timer1.Enabled = false;

            base.OnClosing(e);
        }  
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Model
    {
        [JsonProperty]
        public string ON { get; set; }//状态  
        [JsonProperty]
        public string Mac { get; set; }//  
        [JsonProperty]
        public string EmployeeID { get; set; }// 
        [JsonProperty]
        public string Name { get; set; }//姓名 
        [JsonProperty]
        public string InOut { get; set; }//进出状态 
        [JsonProperty]
        public string BlushTime { get; set; }//刷卡时间 
        [JsonProperty]
        public string SiteName { get; set; }// 
        [JsonProperty]
        public string State { get; set; }
        [JsonProperty]
        public string Department { get; set; }//部门       
        [JsonProperty]
        public string Remark { get; set; }//备注

        Color _colorState = System.Drawing.Color.White;
        public Color ColorStates
        {
            get { return _colorState; }
            set { _colorState = value; }
        }
        [JsonProperty]
        public int ColorState//颜色状态
        {
            get { return Color2Int(_colorState); }
            set { _colorState = Int2Color(value); }
        }

        public static int Color2Int(Color c)
        {
            return c.ToArgb();
        }

        public static Color Int2Color(int c)
        {
            return System.Drawing.Color.FromArgb(c);
        }

        Image _Pic = new Bitmap(@"9ab.jpg");
        public Image Pic
        {
            get { return _Pic; }
            set { _Pic = value; }
        }
        [JsonProperty]
        public byte[] Images
        {
            get { return Img2Byte(_Pic); }
            set
            {
                if (value == null)
                    _Pic = new Bitmap(@"9ab.jpg");
                else
                    _Pic = Byte2Img(value);
            }
        }

        public static Image Byte2Img(byte[] by)
        {
            MemoryStream ms = new MemoryStream(by);
            Image img = Image.FromStream(ms);
            return img;
        }

        public static byte[] Img2Byte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            byte[] imagedata = null;
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            imagedata = ms.GetBuffer();
            return imagedata;
        }
    }
}
