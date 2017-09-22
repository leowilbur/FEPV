using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FEPV.Views
{
    public interface IAUDI
    {
        string Msg { set; }

        int Step { get; set; }

        int SetPBar { set; }

        string MessBox { set; }

        bool PBarVisible { set; }

        bool frmEnable { set; }

        bool IsAffirm { get; }

        string Remarks { get; }
    }

    public interface IQueryVoucherView
    {
        string[] Parameters { get; }

        object[] Values { get; }

        DataTable listVoucher { set; }

        event EventHandler eventGetSelectVoucher;

        string selectVoucher { get; }
    }

    public interface IVoucherDetailsView
    {
        DataTable listMaster { set; }
        DataTable listVoucherDetails { set; }
    }
}
