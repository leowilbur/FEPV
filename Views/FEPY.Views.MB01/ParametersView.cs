using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using FEPV.BLL;
using MIS.Utility;
using BasicLanuage;

namespace FEPV.Views
{
    [SmartPart]
    public partial class ParametersView : UserControl,IQueryView
    {
        public ParametersView()
        {
            InitializeComponent();
            CultureLanuage.ApplyResourcesFrom(this, "MB01", this.Name);
            double hours = DateTime.Today.Hour;
            double minutes = DateTime.Today.Minute;
            double seconds = DateTime.Today.Second;
            idatebegin.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            idateend.Text = DateTime.Today.AddDays(1).AddHours(-hours).AddMinutes(-minutes).AddSeconds(-seconds - 1).ToString("yyyy-MM-dd HH:mm:ss");
            dtListCardType = rep.GetMISReport("MB01_CardLogs_Type",
                new string[] { "Language" }, new object[] { MyLanguage.Language }).Tables[0];
        }

        ReportBiz rep = new ReportBiz();
        #region IQueryView Members

        public string[] Parameters
        {
            get { return new string[] { "TimeB", "TimeE", "CardID", "Company", "Name", "ContractorID", "CardType", "IsNormal", "Language" }; }
        }

        public object[] Values
        {
            get { return new object[] { B, E, CardID, Company, ContractorName, ContractorID, CardType, IsNormal, MyLanguage.Language }; }
        }

        DateTime? B
        {
            get
            {
                if (string.IsNullOrEmpty(idatebegin.Text))
                    return null;
                return Convert.ToDateTime(idatebegin.Text);
            }
        }

        DateTime? E
        {
            get
            {
                if (string.IsNullOrEmpty(idateend.Text))
                    return null;
                return Convert.ToDateTime(idateend.Text);
            }
        }

        public string CardID
        {
            get
            {
                if (string.IsNullOrEmpty(txtCardID.Text.Trim()))
                    return null;
                return txtCardID.Text;
            }
        }

        public string Company
        {
            get
            {
                if (string.IsNullOrEmpty(txtCompany.Text.Trim()))
                    return null;
                return txtCompany.Text;
            }
        }

        public string ContractorName
        {
            get
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                    return null;
                return txtName.Text;
            }
        }

        public string ContractorID
        {
            get
            {
                if (string.IsNullOrEmpty(txtContractorID.Text.Trim()))
                    return null;
                return txtContractorID.Text;
            }
        }

        public string CardType
        {
            get
            {
                if (string.IsNullOrEmpty(cbCardType.Text.Trim()))
                    return null;
                return cbCardType.Text.Trim().Split('-')[0];
            }
        }

        public bool IsNormal
        {
            get
            {
                return chkIsNormal.Checked;
            }
        }

        public DataTable dtListCardType
        {
            set
            {
                cbCardType.DataSource = value;
                cbCardType.DisplayMember = "TypeName";
                cbCardType.ValueMember = "TypeName";
            }
        }

        #endregion
    }
}
