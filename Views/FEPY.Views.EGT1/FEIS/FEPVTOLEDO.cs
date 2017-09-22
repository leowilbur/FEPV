using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FEPV.Views
{
    class FEPVTOLEDO
    {
        #region Weight For FEPV ToLeDo
        //TOLEDO at FEPV Leo update 20150415
       // static Regex _Regex4Transfer = new Regex(@"\)(0|8|2)\s+(?<WT>\d+)+\s+00");
         static Regex _Regex4Transfer = new Regex(@"\S+\s+(?<WT>\d+)\s+");

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
