using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEPV.Model;
using BasicLanuage;
namespace FEPV.Views
{
    public partial class MM01 : Infrastructure.BaseForm
    {
        public MM01()
        {
            InitializeComponent();
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "MM01", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.gridMaterials.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }

            DataBinding();

            Material.eventLoadData += new LoadData(OnEventLoadData);
            WERKS.eventLoadData += new LoadData(OnEventLoadData);
            Version.eventLoadData += new LoadData(OnEventLoadData);
            Bom.eventLoadData += new LoadData(OnEventLoadData);
            btSearch.Click += new System.EventHandler(this.btSearch_Click);
            btDown.Click += new System.EventHandler(this.btDown_Click);


        }

        void OnEventLoadData(string msg)
        {
            bool action = msg.Trim() == "";
            //MessageBox.Show(msg);
            if (!action)
                _MSG.Text = msg;
        }

        private void DataBinding()
        {
            bindingSourceMaterial.DataSource = _Materials;
            gridMaterials.DataSource = _Materials;
        }

        BindingList<Material> _Materials = new BindingList<Material>();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            gridView1.BestFitColumns();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            SearchMaterial(_iMaterialNo.Text.Trim() + "%");
        }

        private void SearchMaterial(string material)
        {
            _Materials.Clear();
            foreach (var m in Material.GetMaterials(material))
            {
                _Materials.Add(m);
            }
            gridView1.BestFitColumns();
        }

        //SAPFEPV.BLL.MaterialBiz mb = MaterialBiz();
        private void btDown_Click(object sender, EventArgs e)
        {
            string material = _iMaterialNo.Text.Trim();
            //SAPmb.AllInOne(_iMaterialNo.Text.Trim(), _iPlant.Text.Trim(), "FEIS");
            SearchMaterial(material);
        }

     }
}
