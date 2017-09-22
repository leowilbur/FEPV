using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;

namespace FEPV.Views
{
    public class ClassEncode
    {
        public static ImageCodecInfo GetEncoderInfo(String mimeType)
        {//图像编码器
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            return null;
        } 
    }
}
