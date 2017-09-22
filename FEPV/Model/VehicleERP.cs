using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPV.Model
{
    [Serializable]
    public class VehicleERPOutput
    {
        public string OUTNO { set; get; }
        public string ErrCode { set; get; }
        public string ErrMsg { set; get; }
    }

    [Serializable]
    public class VehicleERPInput
    {
        public string orders { set; get; }
        public string GDELINO { set; get; }
        public string TRUCKNO { set; get; }
        public string CDRIVER { set; get; }
        public string OUTTIME { set; get; }
    }

    [Serializable]
    public class ShippingOrderERPOutput
    {
        public string OUTNO { set; get; }
        public string DIRECTION { set; get; }
        public string UNICODE { set; get; }
        public decimal PRQUAN { set; get; }
        public decimal REQUAN { set; get; }
        public string unit { set; get; }
        public string isprn { set; get; }
        public string ErrCode { set; get; }
        public string ErrMsg { set; get; }
    }
}
