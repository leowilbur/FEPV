using FEPV.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPV.Views
{
    public interface IGoodsView
    {
        bool IsReady { get; }

        string ErrorMessage { get; }

        int Count { get; set; }

        int Flow { get; set; }

        UIGoods Goods2Produce { get; }

        DataTable dtMaterial { set; }

        DataTable dtLine { set; }

    }
    public interface IXD01
    {
        string ProdType { get; set; }

        DataTable GoodsList { set; }

        string Msg { set; get; }

        string Setting { get; set; }

        bool Printable { get; }
    }
    public interface IXD03
    {
        Step step { set; get; }

        string Msg { set; }

        string DialogMsg { get; }

        string DialogTitle { set; }

        bool IsNotarize { get; }

        bool btMoreGoodsVisiable { set; }

        string Setting { get; set; }
    }
    public interface IQueryGoodsView
    {
        IQueryGoodsParametersView QueryGoodsParametersView { get; set; }

        DataTable listGoods { set; get; }

        DataTable listSelectGoods { get; }

        DataTable setGoodsColumnsName { set; }

        event EventHandler GetGoodsColumnsName;

        string ProdType { set; }

        string StoreName { get; }
    }
    public interface IQueryGoodsParametersView
    {
        bool IsReady { get; }

        DataTable listMaterial { set; }

        string[] Parameters { get; }

        object[] Values { get; }

        DataTable listBatch { set; }

        event EventHandler eventGetBatch;
    }
    public class GetBatchArgs : EventArgs
    {
        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string MaterialNO { get; set; }

        public string Plant { get; set; }
    }
    public interface IEditGoodsView
    {
        DataTable dtSelectGoods { get; set; }

        IEditGoodsParametersView EditGoodsParametersView { set; }

    }
    public interface IEditGoodsParametersView
    {
        DataTable listMaterial { set; }

        bool IsReady { get; }

        List<UIGoods> rEditGoods { get; }

        DataTable ParametersValue { set; get; }

        bool DefaltCheckState { set; }
    }
}
