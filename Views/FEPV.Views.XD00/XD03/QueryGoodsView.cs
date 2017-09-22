using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Practices.CompositeUI.SmartParts;
using BasicLanuage;

namespace FEPV.Views
{
    [SmartPart]
    public partial class QueryGoodsView : UserControl, IQueryGoodsView
    {
        public QueryGoodsView()
        {
            InitializeComponent();
            this.Load += new EventHandler(QueryGoodsView_Load);

            #region language
            DataSet dsgrid = CultureLanuage.ApplyResourcesFrom(this, "XD00", this.Name);
            DataTable gridData = CultureLanuage.GridHeader(dsgrid, "gridView1");
            if (gridData != null)
            {
                this.gcGoodslist.DataSource = gridData;
                CultureLanuage.GridResourcesFrom(gridView1, "gridView1", dsgrid);
                gridView1.BestFitColumns();
            }
            #endregion 
        }

        void QueryGoodsView_Load(object sender, EventArgs e)
        {
            GetGoodsColumnsName(this, EventArgs.Empty);
            bslist = new BindingSource();

            bslist.DataSource = dtlist;
            gcGoodslist.DataSource = bslist;
        }

        DataTable dtlist;

        BindingSource bslist;

        IQueryGoodsParametersView _IQueryGoodsParametersView;

        #region IQueryGoodsView Members

        public DataTable listGoods
        {
            set
            {
                if (value != null)
                    dtlist.Merge(value);
                else
                    dtlist.Clear();

                gridView1.BestFitColumns();
            }
            get
            {
                return dtlist;
            }
        }

        public DataTable listSelectGoods
        {
            get
            {
                return GetSelectGoods();
            }
        }

        public IQueryGoodsParametersView QueryGoodsParametersView
        {
            get
            {
                return _IQueryGoodsParametersView;
            }
            set
            {
                _IQueryGoodsParametersView = value;
                WorkSpaceParameters.Show(_IQueryGoodsParametersView);
                WorkSpaceParameters.Refresh();
            }
        }

        public event EventHandler GetGoodsColumnsName;

        public event EventHandler eventGetMoreGoods;

        public DataTable setGoodsColumnsName
        {
            set { dtlist = value; }
        }

        #endregion

        DataTable GetSelectGoods()
        {
            DataTable table = new DataTable();
            foreach (DataColumn column in listGoods.Columns)
            {
                table.Columns.Add(column.ColumnName);
            }
            int rowCount = gridView1.SelectedRowsCount;
            if (rowCount <= 0)
                return new DataTable();

            for (int i = 0; i < rowCount; i++)
            {
                if (gridView1.GetSelectedRows()[i] >= 0)
                {
                    DataRow row = table.NewRow();
                    foreach (DataColumn column in listGoods.Columns)
                    {
                        row[column.ColumnName] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i])[column.ColumnName].ToString();
                    }
                    table.Rows.Add(row);
                }
            }

            return table;
        }

        #region IQueryGoodsView Members

        public string StoreName
        {
            get
            {
                switch (_ProdType)
                {
                    case "C":
                        return "Q_XD00_SearchSSPFORXD03";
                    case "L":
                        return "Q_XD00_SearchPOLYFORXD03";
                }
                throw new Exception("Invalid ProdType!");
            }
        }

        string _ProdType = string.Empty;

        public string ProdType
        {
            set { _ProdType = value; }
        }

        #endregion
    }
}
