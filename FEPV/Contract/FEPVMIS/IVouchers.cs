using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface IVouchers
    {
        bool Pick(string voucherID, string goodsID);

        string Insert(Voucher voucherInfo);

        bool CancelPick(string voucherID, string BarCode);

        bool Cancel(string voucherID);

        bool Commit2Flow(string voucherID, out string msg);

        byte[] TakeDetails(string voucherID);

        byte[] TakeMaster(string voucherID);

        bool Qpass(string voucherID);

        bool Sync2SAP(string voucherID, out string msg);

        bool Submit2Stock(string voucherID);

        bool Withdrawal(string voucherID, string remark, out string msg);

        DataTable BarCodeList(string StoreName_Goods, string[] paramenters, object[] values);

    }
}
