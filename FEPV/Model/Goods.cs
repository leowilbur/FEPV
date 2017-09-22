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
    [Table("Goods")]
    public class Goods : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("VoucherID", true)]
        public string VoucherID { get; set; }

        /// <summary>
        /// 物品类型
        /// </summary>
        [Column("GoodsType")]
        public string GoodsType { get; set; }

        /// <summary>
        /// 是否回厂
        /// </summary>
        [Column("IsBack")]
        public bool IsBack { get; set; }

        /// <summary>
        /// 期望回厂日期
        /// </summary>
        [Column("ExpectBack")]
        public DateTime ExpectBack { get; set; }

        /// <summary>
        /// 携出人
        /// </summary>
        [Column("TakeOut")]
        public string TakeOut { get; set; }

        /// <summary>
        /// 厂商
        /// </summary>
        [Column("TakeCompany")]
        public string TakeCompany { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        [Column("VehicleNO")]
        public string VehicleNO { get; set; }

        /// <summary>
        /// 预计出厂日期
        /// </summary>
        [Column("ExpectOut")]
        public DateTime? ExpectOut { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 出厂时间
        /// </summary>
        [Column("OutTime")]
        public DateTime? OutTime { get; set; }

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

        /// <summary>
        /// 图片名称
        /// </summary>
        [Column("FileNames")]
        public string FileNames { get; set; }

        public List<GoodsItem> GoodsItems { get; set; }
    }
}
