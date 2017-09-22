using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shawoo.Core;

namespace FEPV.Model
{
    [Serializable]
    [Table("PtaEgTruck")]
    public class PtaEgTruck : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("VoucherID", true)]
        public string VoucherID { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        [Column("VehicleNO")]
        public string VehicleNO { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Column("OrderNO")]
        public string OrderNO { get; set; }

        /// <summary>
        /// 厂商
        /// </summary>
        [Column("Manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 期望进厂日期
        /// </summary>
        [Column("ExpectIn")]
        public DateTime ExpectIn { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [Column("ValidatePeriod")]
        public DateTime ValidatePeriod { get; set; }

        /// <summary>
        /// 进厂联系人
        /// </summary>
        [Column("LinkMan")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("LinkPhone")]
        public string LinkPhone { get; set; }

        /// <summary>
        /// Pta/Eg
        /// </summary>
        [Column("PtaEg")]
        public string PtaEg { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Column("Status")]
        public string Status { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [Column("Stamp")]
        public DateTime Stamp { get; set; }

        /// <summary>
        /// 创建者工号
        /// </summary>
        [Column("UserID")]
        public string UserID { get; set; }
    }
}
