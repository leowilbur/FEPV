using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using FEPV.BLL;
using BasicLanuage;
using MIS.Utility;

namespace FEPV.Views
{
    public partial class JobGoodsView : UserControl
    {
        public JobGoodsView()
        {
            InitializeComponent();
            
            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "EGT2", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView7");
            if (gridData != null)
            {
                this.gcGoodsDetails.DataSource = gridData;
                gridView7.BestFitColumns();
                CultureLanuage.GridResourcesFrom(gridView7, "gridView7", dsgrid);
            }
            #endregion
        }

        public DataTable Plan4GoodsDetailsTable
        {
            set
            {
                gcGoodsDetails.DataSource = value;
                gridView7.BestFitColumns();
            }
        }

        ReportBiz rep = new ReportBiz();

        public Dictionary<string, object> Paras
        {
            set
            {
                _VoucherID.Text = (string)value["VoucherID"];
                _TakeOut.Text = (string)value["TakeOut"];
                _VehicleNO.Text = value["VehicleNO"].ToString();
                _TakeCompany.Text = (string)value["TakeCompany"];
                _UserID.Text = (string)value["UserID"];
                _PhoneNo.Text = (string)value["PhoneNo"];
                _Remark.Text = value["Remark"].ToString();

                DataTable tbCallee = rep.GetMISReport("FK_AC_GuestItem_Callee", new string[] { "CalleeNo" }, new object[] { _UserID.Text }).Tables[0];
                if (tbCallee.Rows.Count == 1)
                {
                    DataRow rowCallee = tbCallee.Rows[0];
                    _Name.Text = rowCallee["Name"].ToString();
                    _Specification.Text = rowCallee["Specification"].ToString();
                }
                else
                {
                    _Name.Text = _UserID.Text;
                    _Specification.Text = "--";
                }
            }
        }
    }
}
