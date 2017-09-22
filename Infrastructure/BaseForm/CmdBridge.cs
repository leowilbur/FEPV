using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class CmdBridge
    {
        public static event EventHandler TCodeRaised;

        public static void RunCode(string TCode)
        {
            if (TCodeRaised != null)
                TCodeRaised(TCode, EventArgs.Empty);
        }
    }
}
