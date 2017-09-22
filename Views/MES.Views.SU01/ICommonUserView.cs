using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Views
{
    public interface ICommonUserView
    {
        string UserName { get; }

        string OldPwd { get;  }

        string NewPwd1 { get; }

        string NewPwd2 { get;  }

        bool IsReady { get; }

        string ErrorMsg { get; }

        bool Cleartxt { set; }

    }
}
