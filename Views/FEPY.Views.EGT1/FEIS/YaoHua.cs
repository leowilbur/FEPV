using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FEPV.Views
{
    public class YaoHua
    {
        #region Weight For 远纺南门

        static Regex _Regex4Transfer = new Regex(@"(\+|\-)(?<WT>\d\d\d\d\d\d)\d\d\w");

        public static bool DoTransfer(string Data, out decimal wt)
        {
            wt = 0m;
            Match match = _Regex4Transfer.Match(Data);
            if (match.Success)
            {
                wt = Convert.ToDecimal(match.Groups["WT"].Value);
                return true;
            }
            return false;
        }
        #endregion
    }
}
