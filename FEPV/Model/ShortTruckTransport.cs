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
    [Table("ShortTruckTransport")]
    public class ShortTruckTransport : ORM
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
        ///东厂进厂时间
        /// </summary>
        [Column("InTime")]
        public DateTime InTime { set; get; }


        /// <summary>
        ///东厂进厂过磅时间
        /// </summary>
        [Column("Weight1Time")]
        public DateTime? Weight1Time { set; get; }


        /// <summary>
        ///东厂进厂过磅
        /// </summary>
        [Column("Weight1")]
        public decimal Weight1 { set; get; }


        /// <summary>
        ///东厂出厂时间
        /// </summary>
        [Column("Weight2Time")]
        public DateTime? Weight2Time { set; get; }

        /// <summary>
        ///东厂出厂过磅
        /// </summary>
        [Column("Weight2")]
        public decimal Weight2 { set; get; }

        /// <summary>
        ///东厂 出厂时间
        /// </summary>
        [Column("OutTime1")]
        public DateTime? OutTime1 { set; get; }



        /// <summary>
        ///北厂 进厂时间
        /// </summary>
        [Column("InTime2")]
        public DateTime? InTime2 { set; get; }


        /// <summary>
        ///北厂 进厂过磅
        /// </summary>
        [Column("Weight3")]
        public decimal Weight3 { set; get; }

        /// <summary>
        ///北厂 进厂过磅时间
        /// </summary>
        [Column("Weight3Time")]
        public DateTime? Weight3Time { set; get; }

        /// <summary>
        ///北厂 2次过磅
        /// </summary>
        [Column("Weight4")]
        public decimal Weight4 { set; get; }

        /// <summary>
        ///北厂 重磅时间
        /// </summary>
        [Column("Weight4Time")]
        public DateTime? Weight4Time { set; get; }

        /// <summary>
        ///北厂 出厂时间
        /// </summary>
        [Column("OutTime2")]
        public DateTime? OutTime2 { set; get; }


        /// <summary>
        /// 过磅状态
        /// </summary>
        [Column("Status")]
        public string Status { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("Stamp")]
        public DateTime Stamp { set; get; }


        /// <summary>
        /// 创建User
        /// </summary>
        [Column("UserID")]
        public string UserID { set; get; }


        /// <summary>
        /// 超重通知消息
        /// </summary>
        [Column("Message")]
        public string Message { get; set; }

        /// <summary>
        /// 超重异常原因
        /// </summary>
        [Column("Reason")]
        public string Reason { get; set; }


        /// <summary>
        /// 超时通知消息
        /// </summary>
        [Column("OverTimeMessage")]
        public string OverTimeMessage { get; set; }

        /// <summary>
        /// 超时异常原因
        /// </summary>
        [Column("OverTimeReason")]
        public string OverTimeReason { get; set; }


        /// <summary>
        /// 流程进程ID
        /// </summary>
        [Column("PID")]
        public string PID { get; set; }
    }
}
