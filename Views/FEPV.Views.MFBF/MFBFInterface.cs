using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEPV.Model;

namespace FEPV.Views
{
    public interface IMFBFView
    {
        Step STEP { get; set; }

        string MSG { set; }

        string DialogMsg { set; }

        string DialogTitle { set; }

        bool IsNotarize { get; }

        string messshow { set; }
    }

    public interface IUnsettledJobsParamenters
    {
        string[] Paramenters { get; }
        object[] Values { get; }
    }

    public interface IUnsettledJobsView
    {
        IUnsettledJobsParamenters ParamentersView { get; set; }

        DataTable tbJobs { set; }

        event EventHandler eventVoucherSelected;
    }

    public class Voucher4SearchArgs : EventArgs
    {
        public string VoucherID { get; set; }
    }

    public interface IQueryBatchParamenters
    {
        string VouID { get; }

        string[] Paramenters { get; }
        object[] Values { get; }

        DataTable dtGrade { set; }

        DataTable dtPlant { set; get; }
    }

    /// <summary>
    /// STEP 2
    /// </summary>
    public interface IQueryBatchView
    {
        DataTable tbBatches { set; }

        IQueryBatchParamenters ParamentersView { get; set; }

        event EventHandler eventBatchSelected;

    }

    public class Batch4VoucherArgs : EventArgs
    {
        public Dictionary<string, object> Paramenters { get; set; }
    }

    /// <summary>
    /// 单据参数
    /// </summary>
    public interface IVoucherView
    {
        string IsimmobilityPlantAndLoc { set; }

        Voucher Voucher2Request { get; }

        Dictionary<string, object> VoucherParamenters { set; }

        object[] SelectParameters { get; set; }

        string MaterialNO { get; set; }

        string BOM { get; set; }

        string Batch131 { get; set; }

        DataTable Plants { set; get; }

        bool IsReady { get; }

        string TransID { set; }

        string Msg { get; }

        string[] Version { get; }

        DataTable dtCenterID { set; }

        DataTable _Plant { set; }

        bool IsConvertMaterialno { set; }

        int TotalCount { set; }

        decimal TotalWeight { set; }

        string ProdType { get; set; }
    }
    /// <summary>
    /// STEP 3
    /// </summary>
    public interface IQueryGoodsView
    {
        DataTable tbGoods { set; }

        IVoucherView ParamentersView { get; set; }

        string[] BarCode2Pick { get; }

        decimal TotalNum { get; }

        event EventHandler ShowSelectGoodsInformation;
    }

    public class ShowSelectGoodsInformationArgs : EventArgs
    {
        public int TotalCount { get; set; }

        public decimal TotalWeight { get; set; }
    }

    public interface IQueryVoucherView
    {
        DataTable Master { set; }
        DataTable Detail { set; }
        string[] SelectGoods { get; }
        string SelectVoucherID { get; }
        decimal SelectTotalNum { get; }
    }
}
