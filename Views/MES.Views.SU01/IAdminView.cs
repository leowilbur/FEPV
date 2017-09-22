using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Views
{
    public interface IAdminView
    {
        string UserName { get; }

        string Pwd { get; }

        bool IsReady { get; }

        string ErrorMsg { get; }

        bool Cleartxt { set; }

    }
}
