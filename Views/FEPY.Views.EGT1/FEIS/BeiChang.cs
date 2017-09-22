using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FEPV.Views
{
    class BeiChang
    {
        /// <summary>
        /// 北厂
        /// </summary>
        static Regex _Regex4Transfer = new Regex(@"!0\s+(?<WT>[\d]+)\s+0");

        public static bool DoTransfer(string Data, out decimal wt)
        {
            wt = 0;
            Match match = _Regex4Transfer.Match(Data);
            if (match.Success)
            {
                wt = Convert.ToDecimal(match.Groups["WT"].Value);
                return true;
            }
            return false;
        }
    }
}
