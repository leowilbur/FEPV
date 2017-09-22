using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Shawoo.Core;
using System.Drawing;

namespace FEPV.Model
{
    [Serializable]
    [Table("GoodsItem")]
    public class GoodsItem : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("ID", true)]
        public Guid ID { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        [Column("GoodsName")]
        public string GoodsName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Column("GoodsAmount")]
        public int GoodsAmount { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Column("Unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        [Column("Reason")]
        public string Reason { get; set; }

        /// <summary>
        ///  物品出厂单据号
        /// </summary>
        [Column("VoucherID")]
        public string VoucherID { get; set; }
    }
}
