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
    public class GoodsBiz
    {
        private readonly IGoods proxy = ServiceFactory.Create<IGoods>();

        public string Produce(UIGoods goods)
        {
            return proxy.Produce(goods);
        }
        public DataTable iGetMaterialByAB(string[] ps, object[] vs, string UserId)
        {
            return proxy.iGetMaterialByAB(ps, vs, UserId);
        }
        public DataTable GetGoodList(string[] ps, object[] vs)
        {
            return proxy.GetGoodList(ps, vs);
        }
        public DataTable ExeProcedureUI(string pn, string[] ps, object[] vs)
        {
            return proxy.ExeProcedureUI(pn, ps, vs);
        }
        public string Print(string barCode, int point)
        {
            return proxy.Print(barCode, point);
        }
        public string GetTableName(string barCode)
        {
            return proxy.GetTableName(barCode);
        }
        public UIGoods GetInfo(string barCode)
        {
            return proxy.GetInfo(barCode);
        }
        public int Cancel(string barCode)
        {
            return proxy.Cancel(barCode);
        }
        public bool Update(UIGoods goods)
        {
            return proxy.Update(goods);
        }

    }
}