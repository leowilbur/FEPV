using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FEPV.Views
{
    class DongChang
    {
        /// <summary>
        /// 远纺东门
        /// </summary>
        private static Regex _Regex4Transfer = new Regex("\x0002\\w+\\s+(?<WT>\\d+)\\s+\\d+");

        public static bool DoTransfer(string Data, out decimal wt)
        {
            wt = 0M;
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
