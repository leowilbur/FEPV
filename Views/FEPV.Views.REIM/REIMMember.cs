using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPV.Views
{
    public interface IShowVoucherView
    {
        DataTable dtVoucher { set; }
    }
    public interface IReimView
    {
        string Msg { set; }

        STEP Step { get; set; }
    }
    public interface IQueryParametersView
    {
        string[] Parameters { get; }

        object[] Values { get; }

        DataTable dtCenterID { set; }
    }
    public interface IReportSource
    {
        DataTable dataSource { set; }
    }
    public class CollectElements
    {
        public string _MaterialNO { get; set; }
        public string _ProdSpec { get; set; }
        public string _CenterID { get; set; }
        public string _Plant { get; set; }
        public string _Batch { get; set; }
        public decimal _BeginDate { get; set; }
        public decimal _PayInMonthWH { get; set; }
        public decimal _PayInDayWH { get; set; }
        public decimal _TransferInMonth { get; set; }
        public decimal _DispatchInDay { get; set; }
        public decimal _PayOutInMonth { get; set; }
        public decimal _PayOutInDay { get; set; }
        public decimal _DumpInMonth { get; set; }
        public decimal _DumpInDay { get; set; }
        public decimal _Total { get; set; }
        public string _Grade { get; set; }
        public string _Line { get; set; }
        public string _Grades { get; set; }
        public string _Chip { get; set; }
    }

}
