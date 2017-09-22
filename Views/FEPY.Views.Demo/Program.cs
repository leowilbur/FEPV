using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MIS.Utility;

namespace FEPY.Views.Demo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyLanguage.Language = "EN";
           // Application.Run(new EGATETest());
           Application.Run(new ViewForm());
        }
    }
}
