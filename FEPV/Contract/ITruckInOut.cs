using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface ITruckInOut
    {
        /// <summary>
        /// 进厂
        /// </summary>
        bool CheckIn(string voucherid, string type);

        /// <summary>
        /// 一次过磅
        /// </summary>
        bool WeightOne(string voucherid, decimal weight, string type);

        /// <summary>
        /// 二次过磅
        /// </summary>
        bool WeightTwo(string voucherid, decimal weight, string type);

        /// <summary>
        /// 出厂
        /// </summary>
        bool CheckOut(string voucherid, string type);

        /// <summary>
        /// 过磅容差验证
        /// </summary>
        bool PonderationValidate(string voucherid, decimal weight, string type, out string msg);

        /// <summary>
        /// 打印磅单
        /// </summary>
        bool PrintWeight(string voucherid, string type);

        /// <summary>
        /// 取消一次过磅
        /// </summary>
        bool CancelWeightOne(string voucherid, string type);

        /// <summary>
        /// 取消二次过磅
        /// </summary>
        bool CancelWeightTwo(string voucherid, string type);

        /// <summary>
        /// 取消打印磅单
        /// </summary>
        bool CancelPrintWeight(string voucherid, string type);
    }
}
