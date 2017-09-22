using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shawoo.Core;

namespace FEPV.Model
{
    [Serializable]
    [Table("GoodsBackItem")]
    public class GoodsBackItem : ORM
    {
        /// <summary>
        /// 项次号
        /// </summary>
        [Column("ItemID", true)]
        public Guid ItemID { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
        [Column("VoucherID")]
        public string VoucherID { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        [Column("GoodsName")]
        public string GoodsName { get; set; }

        /// <summary>
        /// 物品数量
        /// </summary>
        [Column("GoodsAmount")]
        public string GoodsAmount { get; set; }

        /// <summary>
        /// 物品单位
        /// </summary>
        [Column("Unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 回厂时间
        /// </summary>
        [Column("InTime")]
        public DateTime? InTime { get; set; }

        /// <summary>
        /// 回厂确认时间
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
