using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace FEPV.Model
{
    public class ImageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] Img2Byte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            byte[] imagedata = null;
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            imagedata = ms.GetBuffer();
            return imagedata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public static Image Byte2Img(byte[] by)
        {
            MemoryStream ms = new MemoryStream(by);
            Image img = Image.FromStream(ms);
            return img;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public byte[] GetImg(string fileName)
        {
            FileStream fs;
            Byte[] Data;
            fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            Data = new Byte[fs.Length];
            fs.Read(Data, 0, (int)fs.Length);
            fs.Dispose();
            return Data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public bool PutImg(string fileName, byte[] by)
        {
            Byte2Img(by).Save(fileName);
            return true;
        }
    }
}
