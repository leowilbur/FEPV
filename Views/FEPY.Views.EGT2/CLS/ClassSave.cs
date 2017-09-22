using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

namespace FEPV.Views
{
    public class ClassSave
    {
        private static ClassVedioCapture VC = new ClassVedioCapture();
        public static void Save(string filename, System.Drawing.Image i)
        {
            ImageCodecInfo ici;
            Encoder enc;
            EncoderParameter ep;
            EncoderParameters epa;

            try
            {
                //   Initialize   the   necessary   objects   
                ici = ClassEncode.GetEncoderInfo("image/jpeg");
                enc = Encoder.Quality;//设置保存质量   
                epa = new EncoderParameters(1);

                //   Set   the   compression   level   
                ep = new EncoderParameter(enc, 15L);//质量等级为25%   
                epa.Param[0] = ep;
                //i.Save(Application.StartupPath + "\\test.jpg", ici, epa);
                i.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                i.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
    }
}
