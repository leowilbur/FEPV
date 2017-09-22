using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shawoo.Core;

namespace FEPV.Model
{
    [Serializable]
    [Table("UnJointTruck")]
    public class UnJointTruck : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("VoucherID", true)]
        public string VoucherID { get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        [Column("VehicleType")]
        public string VehicleType { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        [Column("VehicleNO")]
        public string VehicleNO { get; set; }

        /// <summary>
        /// 送/提货厂商
        /// </summary>
        [Column("Manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Column("OrderNO")]
        public string OrderNO { get; set; }

        /// <summary>
        /// 物料类别
        /// </summary>
        [Column("Material")]
        public string Material { get; set; }

        /// <summary>
        /// 期望到厂日期
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
        /// 柜号
        /// </summary>
        [Column("StorageNO")]
        public string StorageNO { get; set; }

        /// <summary>
        /// 一次过磅重量
        /// </summary>
        [Column("FirstWeight")]
        public decimal? FirstWeight { get; set; }

        /// <summary>
        /// 一次过磅时间
        /// </summary>
        [Column("FirstTime")]
        public DateTime? FirstTime { get; set; }

        /// <summary>
        /// 二次过磅重量
        /// </summary>
        [Column("SecondWeight")]
        public decimal? SecondWeight { get; set; }

        /// <summary>
        /// 二次过磅时间
        /// </summary>
        [Column("SecondTime")]
        public DateTime? SecondTime { get; set; }

        /// <summary>
        /// 进厂时间
        /// </summary>
        [Column("InTime")]
        public DateTime? InTime { get; set; }

        /// <summary>
        /// 出厂时间
        /// </summary>
        [Column("OutTime")]
        public DateTime? OutTime { get; set; }

        /// <summary>
        /// 确认装卸货完成时间
        /// </summary>
        [Column("Complete")]
        public DateTime? Complete { get; set; }

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
