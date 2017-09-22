using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BasicLanuage;

namespace FEPV.Views
{
    public partial class JobCameraView : UserControl
    {
        private ClassVedioCapture VC = new ClassVedioCapture();

        public JobCameraView()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "EGT3", this.Name);
        }

        internal void InitView()
        {
            try
            {
                VC.Initialize(this.pictureBoxShow, this.pictureBoxShow.Width, this.pictureBoxShow.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event EventHandler eventShowListView;
        internal void CaptureImage()
        {
            VC.CopyToClipBorad();
            string filename = "images\\" + DateTime.Now.ToString("yyMMddHHmmss") + ".jpg";
            ClassSave.Save(filename, VC.getCaptureImage());

            VC.UnLoad();

            Dictionary<string, object> paramenters = new Dictionary<string, object>();
            paramenters.Add("filename", filename);

            if (eventShowListView != null)
            {
                eventShowListView(this, new FEPV.Views.EGATE3.EgateArgs { EgateDictionary = paramenters });
            }
        }

        internal void VcUnLoad()
        {
            VC.UnLoad();
        }
    }
}
