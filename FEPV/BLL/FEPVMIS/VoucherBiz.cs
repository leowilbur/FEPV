using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using Shawoo.Core;

namespace FEPV.BLL
{
    public class VoucherBiz
    {
        private readonly IVouchers proxy = ServiceFactory.Create<IVouchers>();

        public string[] Pick(string voucherID, string[] goodsIDs)
        {
            List<string> BarCodes = new List<string>();
            for (int i = 0; i < goodsIDs.Length; i++)
            {
                if (proxy.Pick(voucherID, goodsIDs[i]))
                    BarCodes.Add(goodsIDs[i]);
            }
            return BarCodes.ToArray();
        }

        public string Insert(Voucher voucherInfo)
        {
            return proxy.Insert(voucherInfo);
        }

        public string[] CancelPick(string voucherID, string[] goodsIDs)
        {
            List<string> BarCodes = new List<string>();

            for (int i = 0; i < goodsIDs.Length; i++)
            {
                if (proxy.CancelPick(voucherID, goodsIDs[i]))
                    BarCodes.Add(goodsIDs[i]);
            }
            return BarCodes.ToArray();

        }

        public bool Cancel(string voucherID)
        {
            return proxy.Cancel(voucherID);
        }

        public bool Commit2Flow(string voucherID, out string msg)
        {
            return proxy.Commit2Flow(voucherID, out msg);
        }

        public DataTable TakeDetails(string voucherID)
        {
            byte[] b = proxy.TakeDetails(voucherID);
            return DataFormatter.RetrieveDataSetDecompress(b).Tables[0];
        }

        public DataTable TakeMaster(string voucherID)
        {
                byte[] b = proxy.TakeMaster(voucherID);
                return DataFormatter.RetrieveDataSetDecompress(b).Tables[0];
        }

        public bool Qpass(string voucherID)
        {
            return proxy.Qpass(voucherID);
        }

        public bool Sync2SAP(string voucherID, out string msg)
        {
            return proxy.Sync2SAP(voucherID, out msg);
        }

        public bool Submit2Stock(string voucherID)
        {
            return proxy.Submit2Stock(voucherID);
        }

        public bool Withdrawal(string voucherID, string remark, out string msg)
        {
            return proxy.Withdrawal(voucherID, remark, out msg);
        }

        public DataTable BarCodeList(string StoreName_Goods, string[] paramenters, object[] values)
        {
            return proxy.BarCodeList(StoreName_Goods, paramenters, values);
        }


    }
}
