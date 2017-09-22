#region 程序集 MIS.Utility.dll, v1.0.0.0
// D:\源代码管理\YZMES\Volere\MIS.Utility\bin\Debug\MIS.Utility.dll
#endregion

using System;
using System.Globalization;
using System.Resources;

namespace MIS.Utility
{
    public class MyLanguage
    {   
        public static string Language { get; set; }

        public static CultureInfo currentCultureInfo { get; set; }

        public static ResourceManager rm { get; set; }
    }
}
