using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shawoo.Core;

namespace FEPV.Model
{
    [Serializable]
    [Table("PtaEgItem")]
    public class PtaEgItem : ORM
    { 
        /// <summary>
        /// 项次号
        /// </summary>
        [Column("ItemID", true)]
        public Guid ItemID { get; set; }

        /// <summary>
        /// 主表单号
        /// </summary>
        [Column("VoucherID")]
        public string VoucherID { get; set; }

        /// <summary>
        /// 柜号
        /// </summary>
        [Column("CupboardNO")]
        public string CupboardNO { get; set; }

        /// <summary>
        /// 卸货地点
        /// </summary>
        [Column("Discharge")]
        public string Discharge { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 参考重量
        /// </summary>
        [Column("ReferWeight")]
        public decimal? ReferWeight { get; set; }

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
        /// 现场确认完成时间
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
