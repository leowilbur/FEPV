using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using MES.Infrastructure.Library;
using System.IO;
using Infrastructure;
using Infrastructure.Library;
using Infrastructure.Library.Utility;
using CredentialsManager;
using System.Threading;
namespace Shell
{
    public delegate void VoidDelegate();

    public partial class ShellForm : Form  //DevComponents.DotNetBar.Office2007RibbonForm
    {
        Steps.SplashScreen splashScreen;

        protected override void OnClosing(CancelEventArgs e)
        {
            splashScreen.Close();
            base.OnClosing(e);
        }

        #region -----drage-----
        private void StartResize(int ht, int lparam)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(Handle, Win32.WM.WM_NCLBUTTONDOWN, ht, lparam);
        }

        void _login_OnDrage(object sender, EventArgs e)
        {
            StartResize(Win32.HT.HTCAPTION, 0);
        }

        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        const int WM_NCHITTEST = 0x0084;

        protected override void WndProc(ref   System.Windows.Forms.Message m)
        {
            base.WndProc(ref   m);
            if (m.Msg == WM_NCHITTEST)
            {
                if (m.Result == new IntPtr(HTCLIENT))
                    m.Result = new IntPtr(HTCAPTION);
                return;
            }
        }
        #endregion

        public ShellForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            splashScreen = new Shell.Steps.SplashScreen(Resource.Splash);
            InitializeComponent();

            CmdBridge.TCodeRaised += new EventHandler(CmdBridge_TCodeRaised);
            //this.ClientSize = new System.Drawing.Size(792, 573);
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            if (rect.Width > 800)
            {
                System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
                int x = ((int)(configurationAppSettings.GetValue("X", typeof(int))));
                int y = ((int)(configurationAppSettings.GetValue("Y", typeof(int))));
                //this.ClientSize = new System.Drawing.Size(880, 630);
                this.ClientSize = new System.Drawing.Size(x, y);
            }
            this.Location = new Point
                {
                    X = rect.Width - ClientSize.Width > 0 ? (rect.Width - ClientSize.Width) / 2 : 0,
                    Y = rect.Height - ClientSize.Height > 0 ? (rect.Height - ClientSize.Height) / 2 : 0
                };
            Text += "(" + rect.Width.ToString() + "x" + rect.Height.ToString() + ")";


            _mainMenuStrip.Renderer = new UI.VistaRenderer.WindowsVistaRenderer();
            _mainToolStrip.Renderer = new UI.VistaRenderer.WindowsVistaRenderer();
            _mainStatusStrip.Renderer = new UI.VistaRenderer.WindowsVistaRenderer();

            btCapture.Click += new EventHandler(btCapture_Click);
            btCalendar.Click += new EventHandler(btCalendar_Click);
            btLogOff.Click += new EventHandler(btLogOff_Click);
            btTCode.Click += new EventHandler(btTCode_Click);
            MenUpdate.Click += new EventHandler(MenUpdate_Click);
            _COM.Click += new EventHandler(_COM_ButtonClick);

            TCODE.Enter += new EventHandler(TCODE_Enter);
            TCODE.Leave += new EventHandler(TCODE_Leave);
            TCODE.KeyDown += new KeyEventHandler(TCODE_KeyDown);

            _FirstLoad.DoWork += new DoWorkEventHandler(_FirstLoad_DoWork);
            _FirstLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_FirstLoad_RunWorkerCompleted);

            coder.DoWork += new DoWorkEventHandler(coder_DoWork);
            coder.RunWorkerCompleted += new RunWorkerCompletedEventHandler(coder_RunWorkerCompleted);
        }

        void CmdBridge_TCodeRaised(object sender, EventArgs e)
        {
            RunCode((string)sender);
        }

        void _FirstLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Workspace.Show(_login);
            //_login.Load();

            _IP.Text = (string)e.Result;

            //splashScreen.Close();
        }

        void _FirstLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = string.Empty;

            try
            {
                this.Invoke(new VoidDelegate(delegate()
                {
                    _IP.ForeColor = Color.White;
                    _IP.Text = string.Empty;
                }));

                //RFClient RFC = new RFClient();
                Infrastructure.Contract.IRF RFC = Shawoo.Core.ServiceFactory.Create<Infrastructure.Contract.IRF>();
                DataSet dsOut;
                object[] outPara;

                //RFC.CallFunction(0, "", "", new DataSet(), out dsOut, new object[] { }, out outPara, out msg);
                //msg = (Convert.ToDateTime(msg.Split('(').GetValue(0)) - DateTime.Now).Duration().TotalMinutes.ToString();
                //msg =  Math.Round((Convert.ToDateTime(msg.Split('(').First()) - DateTime.Now).Duration().TotalMinutes, 2).ToString();
                //if (Convert.ToDecimal(msg) >= 5.0m)
                //{
                //    _IP.ForeColor = Color.Red;
                //    msg = "请修正系统时间:" + msg;
                //}
                string range = string.Empty;

                if (1 == RFC.CallFunction(-1, "", "", new DataSet(), out dsOut, new object[] { }, out outPara, out range))
                    msg += "  * " + range;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //
                _IP.ForeColor = Color.Red;
            }

            e.Result = MachineInfo() + msg;
        }

        bool loadCom = false;
        private string MachineInfo()
        {
            AppDomain.CurrentDomain.BaseDirectory.ToString();
            string ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string ip = "";//Singleton<Infrastructure.Library.Utility.Machine>.Instance.IPAddress;

            //string mac = "(" + Singleton<MES.Infrastructure.Library.Utility.Machine>.Instance.MAC.Count.ToString() + ")";
            //foreach (string m in Singleton<MES.Infrastructure.Library.Utility.Machine>.Instance.MAC)
            //{
            //    mac += m;
            //    break;
            //}
            if (!loadCom)
            {
                foreach (string c in Singleton<Infrastructure.Library.Utility.Machine>.Instance.COM)
                {
                    _COM.DropDownItems.Add(c);
                }
                loadCom = true;
            }
            string cpu = Singleton<Infrastructure.Library.Utility.Machine>.Instance.CPU[0];
            cpu += ("(" + Singleton<Infrastructure.Library.Utility.Machine>.Instance.CPU.Count + ")");

            return string.Format("   @{0} || {1}@   ", ver, ip);
        }

        delegate void DelegateShowMessage();
        delegate void DelegateRunScript(string cmd);
        void RunScript(string cmd)
        {
            try
            {
                this._dock.RunScript(cmd);
            }
            catch (Exception ex)
            { }
        }


        #region ToolBar
        void TCODE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

            RunCode(TCODE.Text);
        }

        void TCODE_Leave(object sender, EventArgs e)
        {
            TCODE.BackColor = System.Drawing.Color.White;
        }

        void TCODE_Enter(object sender, EventArgs e)
        {
            TCODE.BackColor = System.Drawing.Color.Yellow;
            TCODE.SelectAll();
        }

        void btTCode_Click(object sender, EventArgs e)
        {
            RunCode(TCODE.Text);
        }

        void btCapture_Click(object sender, EventArgs e)
        {
            Image img;
            System.Drawing.Imaging.ImageFormat imgformat = null;
            imgformat = System.Drawing.Imaging.ImageFormat.Gif;
            img = Machine.CaptureDesktopWindow();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "GIF(*.gif)|*.gif";
            sfd.Title = "Save the screenshot";
            sfd.FileName = DateTime.Now.ToString("yyMMddhhmmss") + ".gif";
            if (sfd.ShowDialog() == DialogResult.OK)
                img.Save(sfd.FileName, imgformat);
        }

        void btCalendar_Click(object sender, EventArgs e)
        {
            LoginOn();
        }

        void MenUpdate_Click(object sender, EventArgs e)
        {
            LiveUpdate();
        }

        public void LiveUpdate()
        {
            needUpdate = true;
            this.Close();
        }

        bool needUpdate = false;
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            try
            {
                if (needUpdate)
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Live.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void btLogOff_Click(object sender, EventArgs e)
        {
            _dock.Clear();
            _login.Logout();
            //LogOff();
            //Pass = false;
        }
        #endregion

        #region Setps
        Steps.smpLogin _login;
        Steps.smpDock _dock;

        #endregion

        BackgroundWorker _FirstLoad = new BackgroundWorker();

        private void ShellForm_Load(object sender, EventArgs e)
        {

            _login = new Shell.Steps.smpLogin();
            _login.ConnectionStateChanged += new EventHandler(_login_ConnectionStateChanged);
            _login.OnDrage += new EventHandler(_login_OnDrage);

            _dock = new Shell.Steps.smpDock(this);

            Workspace.Show(_login);
            _login.Load();
            splashScreen.Close();

            _FirstLoad.RunWorkerAsync();
            Steps.Explorer.eventTCodeRaised += new EventHandler(Explorer_eventTCodeRaised);
        }

        void _login_ConnectionStateChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(sender.ToString()))
            {
                Pass = true;
                Workspace.Show(_dock);
                LoginOn();
            }
            else
            {
                Pass = false;
                Workspace.Show(_login);
                _login._IQ.Text = sender.ToString();
                _login.Load();
            }
        }

        void Explorer_eventTCodeRaised(object sender, EventArgs e)
        {
            RunCode((string)sender);
        }

        public void RunCode(string TCode)
        {
            if (TCode.Trim().ToLower().StartsWith("@"))
            {
                //msn.Text = TCode.Split('@').GetValue(TCode.Split('@').Length-1).ToString();
                return;
            }
            _TCODE_ = TCode;
            if (coder.IsBusy)
                return;

            coder.RunWorkerAsync();
        }

        public bool Pass
        {
            set
            {
                btCalendar.Enabled = value;
                btIM.Enabled = value;
                btLogOff.Enabled = value;
                TCODE.Enabled = value;
                btTCode.Enabled = value;
            }
        }

        private void LoginOn()
        {
            ShowWorkSpace();// this.Invoke(new delegateShowWorkSpace(ShowWorkSpace));
        }

        private void LogOff()
        {
            Pass = false;
            //
            Workspace.Show(_login);
            _login.Load();
        }

        #region DelegateList
        delegate void delegateShowWorkSpace();
        void ShowWorkSpace()
        {
            Workspace.Show(_dock);
            _dock.Load();
        }
        #endregion

        System.ComponentModel.BackgroundWorker coder = new System.ComponentModel.BackgroundWorker();
        void coder_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            //TCODE.Text = (DateTime.Now - b).TotalMilliseconds.ToString();
            _statusLabel.Text = _TCODE_.ToUpper() + "-" + (DateTime.Now - b).TotalMilliseconds.ToString();
            try
            {
                this._dock.RunScript((string)e.Result);
            }
            catch (Exception ex)
            {
                string file = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Logs\" + DateTime.Now.ToString("yyMMddhhmmssff") + ".txt";
                TCODE.Text = "ERROR";
                //try
                //{
                using (TextWriter streamWriter =
                          new StreamWriter(file))
                {
                    streamWriter.WriteLine(ex.ToString());
                    streamWriter.Close();
                }

                //System.Diagnostics.Process.Start(file);
                //}
                //catch
                //{ }
                return;
            }
            TCODE.Text = "";
        }

        DateTime b = DateTime.Now;
        string _TCODE_ = string.Empty;
        void coder_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string code = string.Empty;
            b = DateTime.Now;
            ITCode tcode = Shawoo.Core.ServiceFactory.Create<ITCode>();
            {
                try
                {
                    code = tcode.GetTCodeScript(_TCODE_, DateTime.Now);
                }
                catch (Exception ex)
                {
                    this.Invoke(new VoidDelegate(delegate()
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    ));
                }
            }
            e.Result = code;
        }

        private void _COM_ButtonClick(object sender, EventArgs e)
        {
            if (_FirstLoad.IsBusy)
                return;

            _FirstLoad.RunWorkerAsync();
        }

        private void ShellForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            if (MessageBox.Show("Are you sure exit system?", "MES",
               MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
