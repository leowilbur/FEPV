using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CredentialsManager;

namespace FEG.MES
{
    public partial class CU15 : Infrastructure.BaseForm
    {
        public CU15()
        {
            InitializeComponent();
        }

        DataTable _tb = null;

        CredentialsManager.IRoleManager _roleManager = Shawoo.Core.ProxyHelper<IRoleManager>.GetService();
        private void CU15_Load(object sender, EventArgs e)
        {
            _tb = _roleManager.GetTCodeRights(_Role.TextBox.Text.Trim());
            bindingSource1.DataSource = _tb;
            gridControl1.DataSource = bindingSource1;
            gridView1.BestFitColumns();

            _Type.DataBindings.Add("Text", bindingSource1, "Type");
            _Spec.DataBindings.Add("Text", bindingSource1, "Spec");
            _Key.DataBindings.Add("Text", bindingSource1, "Key");
            _Access.DataBindings.Add("Checked", bindingSource1, "Access");
            _Access.DataBindings.Add("Text", bindingSource1, "Role");
        }

        private void btTCode_Click(object sender, EventArgs e)
        {
            _tb.Clear();
            _tb.Merge(_roleManager.GetTCodeRights(_Role.TextBox.Text.Trim()));
            gridView1.BestFitColumns();
        }

        private void btFunction_Click(object sender, EventArgs e)
        {
            _tb.Clear();
            _tb.Merge(_roleManager.GetActionRights(_Role.TextBox.Text.Trim()));
            gridView1.BestFitColumns();
        }

        private void _Access_CheckedChanged_1(object sender, EventArgs e)
        {
            if (_Access.Checked)
                btRights.Text = "Remove";
            else
                btRights.Text = "Assigen";

            //bindingSource1.EndEdit();
            //gridControl1.Focus();
            //WriteTips(3, _Access.Checked.ToString());
        }

        private void btRights_Click(object sender, EventArgs e)
        {
            //bindingSource1.EndEdit();
            if (bindingSource1.Count == 0)
                return;
            //
            DataRowView row = (DataRowView)bindingSource1.Current;
            string Type = row["Type"].ToString().ToUpper().Trim();
            string Key = row["Key"].ToString().ToUpper().Trim();
            string Role = row["Role"].ToString().ToUpper().Trim();

            bool Access = (bool)row["Access"];

            if (Type == "TCODE")
            {
                if (Access)
                    _roleManager.RemoveTCodeFromRole(Key, Role);
                else
                    _roleManager.AddTCodeToRole(Key, Role);
            }
            else //FUNCTION
            {
                if (Access)
                    _roleManager.RemoveActionFromRole(Key, Role);
                else
                    _roleManager.AddActionToRole(Key, Role);
            }

            row["Access"] = !Access;

            WriteTips(3, " ["+Type+"] "
                        +Key
                        +(Access ? " Removed from " : " Assigened to ")
                        +Role, 
                      Color.Blue);
            //
        }
    }
}
