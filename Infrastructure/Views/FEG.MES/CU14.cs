using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CredentialsManager;
using Shawoo.Core.Administration;

namespace FEG.MES
{
    public partial class CU14 : Infrastructure.BaseForm
    {
        public CU14()
        {
            InitializeComponent();
            functionBindingSource.DataSource = _roleManager.GetAllActions();

            gridControl1.DataSource = functionBindingSource;

            _Spec.DataBindings.Add("Text", functionBindingSource, "Spec");
            _Counter.DataBindings.Add("Text", functionBindingSource, "Counter");
            _Action.DataBindings.Add("Text", functionBindingSource, "Action");
            _IsPublic.DataBindings.Add("Checked", functionBindingSource, "IsPublic");

            gridView1.BestFitColumns();

        }

        CredentialsManager.IRoleManager _roleManager = Shawoo.Core.ProxyHelper<IRoleManager>.GetService();

        private void btSave_Click(object sender, EventArgs e)
        {
            if (functionBindingSource.Count == 0)
                return;

            functionBindingSource.EndEdit();

            _roleManager.SaveAction((Function)functionBindingSource.Current);
            WriteTips(3, ((Function)functionBindingSource.Current).Action+" 保存成功", Color.Blue);
        }

        private void BtExcel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
