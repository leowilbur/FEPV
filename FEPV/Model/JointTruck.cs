using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shawoo.Core;

namespace FEPV.Model
{
    [Serializable]
    [Table("JointTruck")]
    public class JointTruck : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("VoucherID", true)]
        public string VoucherID { get; set; }

        /// <summary>
        /// 发货通知单号
        /// </summary>
        [Column("ShippingOrder")]
        public string ShippingOrder { get; set; }

        /// <summary>
        /// 运输公司
        /// </summary>
        [Column("TransferCompany")]
        public string TransferCompany { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        [Column("VehicleNO")]
        public string VehicleNO { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [Column("MaterielType")]
        public string MaterielType { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        [Column("Driver")]
        public string Driver { get; set; }

        /// <summary>
        /// 司机电话
        /// </summary>
        [Column("DriverPhone")]
        public string DriverPhone { get; set; }

        /// <summary>
        /// 期望到厂时间
        /// </summary>
        [Column("ExpectIn")]
        public DateTime ExpectIn { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        [Column("VehicleShape")]
        public string VehicleShape { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [Column("ValidatePeriod")]
        public DateTime ValidatePeriod { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

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
        /// 实际到厂时间
        /// </summary>
        [Column("ComeTime")]
        public DateTime? ComeTime { get; set; }

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
        /// 装货完成时间
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
