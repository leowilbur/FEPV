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
    [Table("ShortTruckItem")]
    public class ShortTruckItem : ORM
    {
        /// <summary>
        /// 计划单号
        /// </summary>
        [Column("VoucherID", true)]
        public string VoucherID { get; set; }

        /// <summary>
        /// 项次
        /// </summary>
        [Column("ItemID", true)]
        public string ItemID { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [Column("Material")]
        public string Material { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Column("Amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Column("Unit")]
        public string Unit { get; set; }

       
    }
}
