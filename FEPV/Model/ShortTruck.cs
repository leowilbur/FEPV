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
    [Table("ShortTruck")]
    public class ShortTruck : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("VoucherID", true)]
        public string VoucherID { get; set; }

        /// <summary>
        /// 车行
        /// </summary>
        [Column("TransferCompany")]
        public string TransferCompany { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        [Column("VehicleNO")]
        public string VehicleNO { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [Column("Customer")]
        public string Customer { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        [Column("Driver")]
        public string Driver { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        [Column("Definition")]
        public string Definition { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [Column("MaterialType")]
        public string MaterialType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [Column("EffectiveTo")]
        public DateTime EffectiveTo { get; set; }


        /// <summary>
        /// 流程进程ID
        /// </summary>
        [Column("PID")]
        public string PID { get; set; }


        /// <summary>
        /// 异常通知消息
        /// </summary>
        [Column("Message")]
        public string Message { get; set; }

        /// <summary>
        /// 异常原因
        /// </summary>
        [Column("Reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 发货厂区进厂时间
        /// </summary>
        [Column("CloseTime")]
        public DateTime? CloseTime { get; set; }


        /// <summary>
        /// 关闭用户
        /// </summary>
        [Column("CloseUser")]
        public string CloseUser { get; set; }

        /// <summary>
        /// 关闭备注
        /// </summary>
        [Column("CloseRemark")]
        public string CloseRemark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Column("UserID")]
        public string UserID { get; set; }


        /// <summary>
        /// 创建人
        /// </summary>
        [Column("Stamp")]
        public DateTime Stamp { get; set; }

        
    }
}
