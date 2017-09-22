using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using System.Runtime.Remoting;

namespace Shell
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

            //********Remoting
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            string Server = ((string)(configurationAppSettings.GetValue("Server", typeof(string))));
            Shawoo.Common.Token.URL = Server;
            //if (Remoting)
            RemotingConfiguration.Configure("Remoting.xml", false);
            //*******
            Application.Run(new ShellForm());
        }
    }
}
