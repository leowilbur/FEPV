using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FEPV.Views
{
    class TOLEDO
    {
        #region Weight For 远纺北门

        static Regex _Regex4Transfer = new Regex(@"\w\w (?<WT>\d\d\d\d\d\d\d\d)\d\d\d\d\d\d"); 
 
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
        #endregion
    }
}
