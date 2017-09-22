using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Infrastructure.Library;
using Infrastructure.Library.Utility;
using System.Threading;
using CredentialsManager;
using Shawoo.Chat.KnownObjects;
using Shawoo.Common;
using System.Reflection;
using System.Globalization;
using System.Resources;
namespace Shell.Steps
{
    [SmartPart]
    public partial class smpLogin : UserControl
    {
        public smpLogin()
        {
            InitializeComponent();
            
            _Client.Text = Shell.Properties.Settings.Default.Client;

            loadingCircle.Active = false;
            loadingCircle.Visible = false;

            this.KeyDown += new KeyEventHandler(smpLogin_KeyDown);
            _Client.KeyDown += new KeyEventHandler(_Client_KeyDown);
            _User.KeyDown += new KeyEventHandler(_User_KeyDown);
            _PassWord.KeyDown += new KeyEventHandler(_PassWord_KeyDown);
            _Language.KeyDown += new KeyEventHandler(_Language_KeyDown);
        }

        #region Enter Flow
        void smpLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            _Client.Focus();
            _Client.SelectAll();
        }

        void _Client_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            _User.Focus();
            _User.SelectAll();
        }

        void _User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            _PassWord.Focus();
            _PassWord.SelectAll();
        }

        void _PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            _Language.Focus();
            _Language.SelectAll();
        }

        void _Language_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            if (_User.Text.Trim() == "")
            {
                _PassWord.Text = "";
                _User.Focus();
                _User.SelectAll();
                return;
            }

            if (_PassWord.Text.Trim() == "")
            {
                _PassWord.Focus();
                _PassWord.SelectAll();
                return;
            }

            if (_Language.Text.Trim().ToUpper() == "VN" || _Language.Text.Trim().ToUpper() == "CN" || _Language.Text.Trim().ToUpper() == "EN" || _Language.Text.Trim().ToUpper() == "TW")
            {
                Login(_User.Text.Trim().ToLower(), _PassWord.Text);
            }
            else
            {
                //label5.Visible = true;
                _Language.Focus();
                _Language.SelectAll();
            }
        }
        #endregion

        public void Load()
        {
            _PassWord.Text = "";
            _User.Focus();
        }

        public void Logout()
        {
                loadingCircle.Active = false;
                loadingCircle.Visible = false;
                if (ConnectionStateChanged != null)
                    ConnectionStateChanged(false, EventArgs.Empty);
        }

        public void Login(string uid, string pwd)
        {

            loadingCircle.Visible = true;
            loadingCircle.Active = true;

            _IQ.Text = "";

            Shell.Properties.Settings.Default.Client = _Client.Text.Trim().ToUpper();
            Shell.Properties.Settings.Default.Save();


            //string mac = "(" + Singleton<Machine>.Instance.MAC.Count.ToString() + ")";
            //foreach (string m in Singleton<Machine>.Instance.MAC)
            //{
            //    mac += m;
            //    break;
            //}

            Shawoo.Common.Token.UID = uid;
            Shawoo.Common.Token.PWD = pwd;
            Console.WriteLine("login start");
            Console.WriteLine(Shawoo.Common.Token.URL);
            MIS.Utility.MyLanguage.Language = this._Language.Text.ToString();

       //  Application.CurrentInputLanguage = this._Language.Text.Trim();
      //    IUserManager userManager = (IUserManager)Activator.GetObject(typeof(IUserManager),
            //    /*ConfigurationSettings.AppSettings["RemoteHostUri"]*/
            //           Shawoo.Common.Token.URL +
            //           string.Format(@"/{0}.rem", typeof(IUserManager).ToString()));

            IUserManager userManager = Shawoo.Core.ProxyHelper<IUserManager>.GetService();
            try
            {
                if (userManager.Authenticate("", uid, pwd))
                {
                    Console.WriteLine("login Authenticate ");
                    Assembly a = Assembly.Load("BasicLanuage");
                    CultureInfo currentCultureInfo;
                    switch (this._Language.Text.ToString())
                    {
                        case "EN":
                            currentCultureInfo = new CultureInfo("en-US");
                            break;

                        case "CN":
                            currentCultureInfo = new CultureInfo("zh-CN");
                            break;
                        case "TW":
                            currentCultureInfo = new CultureInfo("zh-TW");
                            break;
                        case "VN":
                            currentCultureInfo = new CultureInfo("vi");
                            break;
                        default:
                            currentCultureInfo = new CultureInfo("zh-CN");
                            break;

                    }
                    MIS.Utility.MyLanguage.rm = new ResourceManager("BasicLanuage.ReadFiles", a);

                    MIS.Utility.MyLanguage.currentCultureInfo = currentCultureInfo;
                    ConnectionStateChanged("", EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                Shawoo.Common.Token.PWD = "";
                ConnectionStateChanged(ex.Message, EventArgs.Empty);
            }
            finally
            {
                Working = false;
            }
        }

        public bool Working
        {
            set 
            {
                _Client.Enabled = !value;
                _User.Enabled = !value;
                _PassWord.Enabled = !value;
                _Language.Enabled = !value;

                loadingCircle.Visible = value;
                loadingCircle.Active = value;
            }
        }

        public event EventHandler OnDrage;
        private void _loginPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (OnDrage != null)
                OnDrage(this, EventArgs.Empty);
        }

        public event EventHandler ConnectionStateChanged;
    }
}
