using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicLanuage;
using FEPV.BLL;

namespace FEPV.Views
{
    public partial class MasterShow : UserControl
    {
        public MasterShow()
        {
            InitializeComponent();
            
        }
        VoucherBiz voucherbiz = new VoucherBiz();
        string _voucherId;
        public int stt = 1;
        public string VoucherID
        {
            set
            {
                _voucherId = value;

                #region language

                DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "MB51", this.Name);
                if(dsgrid!=null)
                CultureLanuage.GridResourcesFrom(gridMaster, "gridMaster", dsgrid);
                dsgrid = CultureLanuage.ApplyResourcesFrom(this, "MB51", this.Name);
                if (dsgrid != null)
                CultureLanuage.GridResourcesFrom(gridDetails, "gridDetails", dsgrid);
                #endregion
                VouListMaster.DataSource = voucherbiz.TakeMaster(_voucherId);
                VouListDetails.DataSource = voucherbiz.TakeDetails(_voucherId);
                gridMaster.BestFitColumns();
                gridDetails.BestFitColumns();
            }
        }

    }
}
