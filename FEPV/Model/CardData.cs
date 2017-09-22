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
    [Table("CardData")]
    public class CardData : ORM
    {
        /// <summary>
        /// 卡号
        /// </summary>
        [Column("CardID", true)]
        public string CardID { get; set; }

        /// <summary>
        /// 卡号的编号
        /// </summary>
        [Column("CNO")]
        public string CNO { get; set; }

        /// <summary>
        /// 卡片类型
        /// </summary>
        [Column("CardTypeID")]
        public string CardTypeID { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [Column("ValidTo")]
        public DateTime ValidTo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Column("Status")]
        public string Status { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Column("UserID")]
        public string UserID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("AccDate")]
        public DateTime AccDate { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [Column("Stamp")]
        public DateTime Stamp { get; set; }
    }
}
