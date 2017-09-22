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
    [Table("GuestItem")]
    public class GuestItem : ORM
    {
        /// <summary>
        /// 单据号
        /// </summary>
        [Column("ID", true)]
        public Guid ID { get; set; }

        /// <summary>
        /// 访客姓名
        /// </summary>
        [Column("GuestName")]
        public string GuestName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("IdCard")]
        public string IdCard { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        [Column("Image")]
        public byte[] Image { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public Image Picture
        {
            get
            {
                if (Image != null)
                    return ImageHelper.Byte2Img(Image);
                else
                    return new Bitmap(1, 1);
            }
            set
            {
                Image = ImageHelper.Img2Byte(value);
            }
        }

        /// <summary>
        /// 感应卡号
        /// </summary>
        [Column("CardNO")]
        public string CardNO { get; set; }

        /// <summary>
        /// 访客进入厂单据号
        /// </summary>
        [Column("VoucherID")]
        public string VoucherID { get; set; }

        /// <summary>
        /// Leo-Add 2017-05-08
        /// </summary>
        [Column("IsAbsent")]
        public bool IsAbsent { get; set; }
    }
}
