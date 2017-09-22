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
    public class TruckInOutBiz
    {
        private readonly ITruckInOut proxy = ServiceFactory.Create<ITruckInOut>();

        /// <summary>
        /// 进厂
        /// </summary>
        public bool CheckIn(string voucherid, string type)
        {
            bool results = false;
            try
            {
                results = proxy.CheckIn(voucherid, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 一次过磅
        /// </summary>
        public bool WeightOne(string voucherid, decimal weight, string type)
        {
            bool results = false;
            try
            {
                results = proxy.WeightOne(voucherid, weight, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 二次过磅
        /// </summary>
        public bool WeightTwo(string voucherid, decimal weight, string type)
        {
            bool results = false;
            try
            {
                results = proxy.WeightTwo(voucherid, weight, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 出厂
        /// </summary>
        public bool CheckOut(string voucherid, string type)
        {
            bool results = false;
            try
            {
                results = proxy.CheckOut(voucherid, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 磅单容差验证
        /// </summary>
        public bool PonderationValidate(string voucherid, decimal weight, string type, out string msg)
        {
            bool results = false;
            try
            {
                results = proxy.PonderationValidate(voucherid, weight, type, out  msg);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 打印磅单
        /// </summary>
        public bool PrintWeight(string voucherid, string type)
        {
            bool results = false;
            try
            {
                results = proxy.PrintWeight(voucherid, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 取消一次过磅
        /// </summary>
        public bool CancelWeightOne(string voucherid, string type)
        {
            bool results = false;
            try
            {
                results = proxy.CancelWeightOne(voucherid, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 取消二次过磅
        /// </summary>
        public bool CancelWeightTwo(string voucherid, string type)
        {
            bool results = false;
            try
            {
                results = proxy.CancelWeightTwo(voucherid, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }

        /// <summary>
        /// 取消打印磅单
        /// </summary>
        public bool CancelPrintWeight(string voucherid, string type)
        {
            bool results = false;
            try
            {
                results = proxy.CancelPrintWeight(voucherid, type);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message + ee.StackTrace);
            }
            return results;
        }
    }
}
