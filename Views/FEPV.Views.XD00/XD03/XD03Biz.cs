using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Threading;
using FEPV.BLL;
using System.IO.Ports;

namespace FEPV.Views
{
    public class XD03Biz
    {
        SerialPort Port = new SerialPort();

        UIReporting report = new UIReporting();
        GoodsBiz gbiz = new GoodsBiz();

        int page = 0;
        int count = 0;
        public bool IsPrintDate { get; set; }

        public string ProdType { get; set; }

        IXD03 _IXD03;
        public IXD03 IXD03
        {
            get { return _IXD03; }
            set { _IXD03 = value; }
        }

        IQueryGoodsView _IQueryGoodsView;
        public IQueryGoodsView IQueryGoodsView
        {
            get { return _IQueryGoodsView; }
            set
            {
                _IQueryGoodsView = value;
                _IQueryGoodsView.GetGoodsColumnsName += new EventHandler(_IQueryGoodsView_GetGoodsColumnsName);
            }
        }

        void _IQueryGoodsView_GetGoodsColumnsName(object sender, EventArgs e)
        {
            IQueryGoodsView.setGoodsColumnsName = GetGoodsList();
        }

        IQueryGoodsParametersView _IQueryGoodsParametersView;
        public IQueryGoodsParametersView IQueryGoodsParametersView
        {
            get { return _IQueryGoodsParametersView; }
            set
            {
                _IQueryGoodsParametersView = value;
                _IQueryGoodsView.QueryGoodsParametersView = IQueryGoodsParametersView;
                _IQueryGoodsParametersView.eventGetBatch += new EventHandler(_IQueryGoodsParametersView_eventGetBatch);
            }
        }

        void _IQueryGoodsParametersView_eventGetBatch(object sender, EventArgs e)
        {
            GetBatchArgs args = (GetBatchArgs)e;
            string[] p = new string[] { "B", "E", "MaterialNO", "Plant" };
            object[] v = new object[] { args.Start, args.End, args.MaterialNO, args.Plant };

            AddInParamenter("ProdType", this.ProdType, ref p, ref v);
            _IQueryGoodsParametersView.listBatch = report.GetMISReport("Q_XD00_batchFORGoods", p, v).Tables[0];
        }

        IEditGoodsView _IEditGoodsView;
        public IEditGoodsView IEditGoodsView
        {
            get { return _IEditGoodsView; }
            set { _IEditGoodsView = value; }
        }

        IEditGoodsParametersView _IEditGoodsParametersView;
        public IEditGoodsParametersView IEditGoodsParametersView
        {
            get { return _IEditGoodsParametersView; }
            set
            {
                _IEditGoodsParametersView = value;
                _IEditGoodsView.EditGoodsParametersView = IEditGoodsParametersView;
            }
        }

        public void GetMaterial()
        {
            GoodsBiz MaterialBiz = new GoodsBiz();
            DataTable dtMaterial = MaterialBiz.iGetMaterialByAB(new string[] { "AB" }, new object[] { ProdType }, "");
            DataRow row = dtMaterial.NewRow();
            dtMaterial.Rows.InsertAt(row, 0);
            if (dtMaterial != null)
            {
                IQueryGoodsParametersView.listMaterial = dtMaterial;
                IEditGoodsParametersView.listMaterial = dtMaterial;
            }
        }
        public void Back()
        {
            _IXD03.step--;
        }

        void GotoStep(Step step)
        {
            _IXD03.step = step;
        }

        public void Ready2Work()
        {
            GotoStep(Step.QueryBarCodes);
        }

        public void QueryGoods()
        {
            if (IQueryGoodsParametersView.IsReady)
            {
                _IQueryGoodsView.listGoods = null;
                page = 1;
                IQueryGoodsView.listGoods = GetGoodsList();
                SetbtMoreGoodsVisiable();
            }
            else
            {
                _IXD03.Msg = "Material/Batch can not be empty!";
            }
        }

        public void QueryMoreGoods()
        {
            _IXD03.Msg = "";
            if (_IQueryGoodsView.listGoods.Rows.Count < count)
            {
                if (IQueryGoodsParametersView.IsReady)
                {
                    page++;
                    IQueryGoodsView.listGoods = GetGoodsList();
                    SetbtMoreGoodsVisiable();
                }
                else
                {
                    _IXD03.Msg = "Material/Grade/Grades/line can not be empty!";
                }
            }
            else
            {
                _IXD03.Msg = "This is the last page!";
            }
        }

        void SetbtMoreGoodsVisiable()
        {
            if (_IQueryGoodsView.listGoods.Rows.Count < count)
            {
                _IXD03.btMoreGoodsVisiable = true;
            }
            else
            {
                _IXD03.btMoreGoodsVisiable = false;
            }
        }

        DataTable GetGoodsList()
        {
            string[] p = IQueryGoodsParametersView.Parameters;
            object[] v = IQueryGoodsParametersView.Values;

            AddInParamenter("pageIndex", page, ref p, ref v);
            AddInParamenter("pageSize", 200, ref p, ref v);

            _IQueryGoodsView.ProdType = this.ProdType;
            DataTable dtGoods = report.GetMISReportByPage(_IQueryGoodsView.StoreName, p, v, out count).Tables[0];

            return dtGoods;
        }

        public void DeleteGoods()
        {
            _IXD03.Msg = "";
            if (IQueryGoodsView.listSelectGoods.Rows.Count > 0)
            {
                _IXD03.DialogTitle = "Enter reason to delte:";
                if (_IXD03.IsNotarize)
                {
                    if (string.IsNullOrEmpty(_IXD03.DialogMsg))
                    {
                        _IXD03.Msg = "Can not delete！";
                        return;
                    }
                    foreach (DataRow row in IQueryGoodsView.listSelectGoods.Rows)
                    {
                        gbiz.Cancel(row["BarCode"].ToString());
                    }
                    QueryGoods();
                }
            }
            else
            {
                _IXD03.Msg = "No goods is chosen";
            }
        }

        public void EditGoods()
        {
            _IXD03.Msg = "";
            if (_IQueryGoodsView.listSelectGoods.Rows.Count > 0)
            {
                GotoStep(Step.EditGoods);
                _IEditGoodsView.dtSelectGoods = _IQueryGoodsView.listSelectGoods;
                _IEditGoodsParametersView.ParametersValue = _IQueryGoodsView.listSelectGoods;
                IEditGoodsParametersView.DefaltCheckState = false;
            }
            else
            {
                _IXD03.Msg = "No goods is chosen";
            }
        }

        public void UpdateGoods()
        {
            _IXD03.Msg = "";
            if (_IEditGoodsParametersView.IsReady)
            {
                _IXD03.DialogTitle = "Enter reason to update:";

                if (_IXD03.IsNotarize)
                {
                    if (string.IsNullOrEmpty(_IXD03.DialogMsg))
                    {
                        _IXD03.Msg = "No goods is chosen！";
                        return;
                    }

                    foreach (UIGoods goods in _IEditGoodsParametersView.rEditGoods)
                    {
                        goods.ProdSpec = report.GetMISReport("Q_GetProdSpecByMaterialNO", new string[] { "MaterialNO" }, new object[] { goods.MaterialNO }).Tables[0].Rows[0]["ProdSpec"].ToString();
                        goods.Remark = _IXD03.DialogMsg + " Time change:" + DateTime.Now.ToString();
                        gbiz.Update(goods);
                    }
                    GotoStep(Step.QueryBarCodes);
                    QueryGoods();
                }
            }
            else
            {
                _IXD03.Msg = "Do not modify any product information!";
            }
        }

        public void RePrint()
        {
            string msg = string.Empty;
            int point = 0;
            //Port.Open();
            for (int i = 0; i < IQueryGoodsView.listSelectGoods.Rows.Count; i++)
            {
                string barcode = IQueryGoodsView.listSelectGoods.Rows[i]["BarCode"].ToString();
                if (XD01Biz.IsReady2Print(ref msg, ref point,ref Port, IXD03.Setting))
                {
                    RePrint(barcode, point);
                }
                else
                {
                    IXD03.Msg = msg;
                }
            }
            //Port.Close();
        }

        private void RePrint(string barcode, int point)
        {
            //Update Goods Count +1
            gbiz.Print(barcode, point);
            PrintLabel doc = new PrintLabel();
            if (PrintLabel(barcode) == "")
                return;
            doc.content = PrintLabel(barcode);
            doc.PrintStart();

        }

        string PrintLabel(string barCode)
        {
            StringBuilder r = new StringBuilder();
            switch (ProdType)
            {
                case "L":
                    POLY InfoPOLY = (POLY)gbiz.GetInfo(barCode);
                    
                    r.AppendLine("POLY PRINT TEST BY LEO");
                    r.AppendLine("MaterialNo: " + InfoPOLY.MaterialNO);
                    r.AppendLine("Grade: " + InfoPOLY.Grade);
                    r.AppendLine("Num: " + InfoPOLY.Num);
                    r.AppendLine("ProdDate: " + InfoPOLY.ProdDate);
                    r.AppendLine("PackID: " + InfoPOLY.PackID);
                    r.AppendLine("BarCode: " + InfoPOLY.BarCode);
                    break;
                case "C":
                    SSP InfoSSP = (SSP)gbiz.GetInfo(barCode);
                    r.AppendLine("SSP PRINT TEST BY LEO");
                    r.AppendLine("MaterialNo: " + InfoSSP.MaterialNO);
                    r.AppendLine("Grade: " + InfoSSP.Grade);
                    r.AppendLine("Num: " + InfoSSP.Num);
                    r.AppendLine("ProdDate: " + InfoSSP.ProdDate);
                    r.AppendLine("PackID: " + InfoSSP.PackID);
                    r.AppendLine("BarCode: " + InfoSSP.BarCode);
                    break;
                default:
                    break;
            }
            return r.ToString();
        }

        public void AddInParamenter(string paramenter, object value, ref string[] paramenters, ref object[] values)
        {
            List<string> ps = paramenters.ToList();
            ps.Add(paramenter);
            paramenters = ps.ToArray();

            List<object> vs = values.ToList();
            vs.Add(value);
            values = vs.ToArray();
        }
    }

    public enum Step{
        QueryBarCodes, EditGoods
    }

}
