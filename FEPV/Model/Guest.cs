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
    [Table("Guest")]
    public class Guest : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("VoucherID", true)]
        public string VoucherID { get; set; }

        /// <summary>
        /// 事由
        /// </summary>
        [Column("Content")]
        public string Content { get; set; }

        /// <summary>
        /// 是否受访人确认
        /// </summary>
        [Column("IsNeedConfirm")]
        public bool IsNeedConfirm { get; set; }

        /// <summary>
        /// 访客类型
        /// </summary>
        [Column("GuestType")]
        public string GuestType { get; set; }

        /// <summary>
        /// 造访区域（行政楼 / 厂区）
        /// </summary>
        [Column("Region")]
        public string Region { get; set; }

        /// <summary>
        /// 受访人工号
        /// </summary>
        [Column("Respondent")]
        public string Respondent { get; set; }

        /// <summary>
        /// 分机号
        /// </summary>
        [Column("ExtNO")]
        public string ExtNO { get; set; }

        /// <summary>
        /// 客户单位
        /// </summary>
        [Column("Enterprise")]
        public string Enterprise { get; set; }

        /// <summary>
        /// 预计到厂日期
        /// </summary>
        [Column("ExpectIn")]
        public DateTime ExpectIn { get; set; }

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
        /// 确认受访完成时间
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

        /// <summary>
        /// 详细访客信息
        /// </summary>
        public List<GuestItem> GuestItems { get; set; }
    }
}
