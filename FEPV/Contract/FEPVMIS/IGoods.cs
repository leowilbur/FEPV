using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface IGoods
    {
        DataTable iGetMaterialByAB(string[] ps, object[] vs, string UserId);

        DataTable GetGoodList(string[] ps, object[] vs);

        DataTable ExeProcedureUI(string pn, string[] ps, object[] vs);

        string Produce(UIGoods goods);

        string Print(string barCode, int point);

        string GetTableName(string barCode);

        UIGoods GetInfo(string BarCode);

        int Cancel(string BarCode);

        bool Update(UIGoods goods);
    }

}
