using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.ComponentModel;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Data;
using System.Threading;
using FEPV.BLL;


namespace FEPV.Views
{
    public class XD01Biz
    {
        IXD01 _IXD01;

        public IXD01 IXD01
        {
            get { return _IXD01; }
            set { _IXD01 = value; }
        }

        IGoodsView _IGoodsView;

        public IGoodsView IGoodsView
        {
            get { return _IGoodsView; }
            set { _IGoodsView = value; }
        }

        GoodsBiz gbiz = new GoodsBiz();

        SerialPort Port = new SerialPort();

        int point;
        /// <summary>
        /// Get Line User can access
        /// </summary>
        public void GetLine()
        {

            if (_IXD01.ProdType != "D")
            {
                _IGoodsView.dtLine = gbiz.ExeProcedureUI("Q_XD00_LINE", new string[] { }, new object[] { });
            }
        }
        /// <summary>
        /// Get Material By ProdType (AB)
        /// </summary>
        public void GetMaterial()
        {

            _IGoodsView.dtMaterial = gbiz.iGetMaterialByAB(new string[] { "AB" }, new object[] { _IXD01.ProdType }, "");

        }

        public void CreatGoods()
        {

            IXD01.Msg = "@_@";
            if (!_IGoodsView.IsReady)
            {
                _IXD01.Msg = _IGoodsView.ErrorMessage;
                return;
            }

            string msg = "";
            int Flow = _IGoodsView.Flow;
            int Count = _IGoodsView.Count;

            for (int i = Flow; i < (Flow + Count); i++)
            {
                if (_IXD01.Printable)
                {
                    if (!IsReady2Print(ref msg, ref point, ref Port, IXD01.Setting))
                    {

                        _IXD01.Msg = msg;
                        break;
                    }
                    else
                    {
                        NewGoods();
                    }
                }
                else
                {
                    NewGoods();
                }

            }
        }

        void NewGoods()
        {
            Console.WriteLine("-----_IGoodsView.Goods2Produce.Batch---" + _IGoodsView.Goods2Produce.Batch);
            string goodsID = gbiz.Produce(_IGoodsView.Goods2Produce);
            _IXD01.Msg = goodsID + " " + DateTime.Now.ToString();
            Console.WriteLine("-----goodsID---" + goodsID);
            if (string.IsNullOrEmpty(goodsID))
            {
                System.Windows.Forms.MessageBox.Show(":(");
                return;
            }
            else
            {
                if (_IXD01.Printable)
                {
                    gbiz.Print(goodsID, point);
                    PrintLabel doc = new PrintLabel();
                    doc.content = PrintLabel(goodsID);
                    doc.PrintStart();
                    //Port.Write(gbiz.Print(goodsID, point));
                    //if (Port.IsOpen)
                    //   Port.Close();

                }

                _IXD01.GoodsList = gbiz.ExeProcedureUI("Q_XD00_goods4CreatGoods", new string[] { "BarCode" }, new object[] { goodsID });
            }

            _IGoodsView.Flow++;
            _IGoodsView.Count--;
        }

        public static bool IsReady2Print(ref string msg, ref int _point, ref SerialPort port, string setting)
        {
            //msg = "";

            //lPortBuilder.Build(port, setting);
            //port.Open();
            //port.ReadExisting();

            //port.WriteLine("~hi");
            //System.Threading.Thread.Sleep(200);

            //string HI = port.ReadExisting();
            //Regex regexHI = new Regex(@"(?<model>[\w|-]+),(?<version>[\w|\d|.]+),(?<dpm>[\d]+),(?<memory>[\d]+)KB");
            //  Match matchHI = regexHI.Match(HI);

            //if (!matchHI.Success)
            //{
            //   msg = "打印机离线";
            //  return false;
            //}
            //_point = 200;
            // _point = Convert.ToInt32(matchHI.Groups["dpm"].Value);
            //            Port.Write("~hs");
            //            Thread.Sleep(500);

            //            string Result = Port.ReadExisting();
            //            Regex regexResult = new Regex(
            //                  @"(?<aaa>[\d]+),(?<b>[\d]),(?<c>[\d]),(?<dddd>[\d]+),(?<eee>[\d]+),(?<f>[\d]),(?<g>[\d]),(?<h>[\d]),(?<iii>[\d]+),(?<j>[\d]),(?<k>[\d]),(?<l>[\d])
            //(?<mmm>[\d]+),(?<n>[\d]),(?<o>[\d]),(?<p>[\d]),(?<q>[\d]),(?<r>[\d]),(?<s>[\d]),(?<t>[\d]),(?<uuuuuuuu>[\d]+),(?<v>[\d]),(?<www>[\d]+)
            //(?<xxxx>[\d]+),(?<y>[\d])");

            //            Match matchResult = regexResult.Match(Result);
            //            StringBuilder error = new StringBuilder();
            //            if (matchResult.Groups["b"].Value == "1")
            //                error.Append("纸张出界");
            //            if (matchResult.Groups["c"].Value == "1")
            //                error.Append("/暂停状态");
            //            if (matchResult.Groups["f"].Value == "1")
            //                error.Append("/接收器溢出");
            //            if (matchResult.Groups["p"].Value == "1")
            //                error.Append("/色带出界");
            //            if (matchResult.Groups["j"].Value == "1")
            //                error.Append("/RAM损坏");
            //            if (matchResult.Groups["k"].Value == "1")
            //                error.Append("/温度过高");
            //            if (matchResult.Groups["l"].Value == "1")
            //                error.Append("/温度过低");
            //            if (error.Length == 0)
            //                return true;
            //            else
            //            {
            //                msg = error.ToString();
            //                return false;
            //            }

            return true;


        }

     //   public string Print(string barCode, int point)
     //   {
     //       POLY polyinfo = (POLY)gbiz.GetInfo(barCode);
     //       StringBuilder r = new StringBuilder();
     //       r.Append(string.Format(@"
					//^xa																						         
					//^lh50,20																						 
					//^ll97^fs																					     
					//^fo460,50^abr,77,49^fd{0}^fs   
					//^fo460,700^abr,88,56^fd{1}^fs   
					//^fo360,50^abr,55,21^fd{2}^fs    
					//^fo360,480^abr,55,21^fd{3}^fs      
					//^fo80,90^abr,55,21^fd{4}^fs    
					//^by4,2.1,60																				     
					//^fo80,490^abr,55,21^fd{5}^fs    
					//^by4,2.1,60																					     
					//^fo80,700^abr,55,21^fd{6}^fs   
					//^by4,2.1,60															                             
					//^fo230,50^b3r,n,120,n,n^fd{7}^fs   
					//^fo160,50^abr,77,49^fd{8}^fs 
					//^xz"
     //          , polyinfo.MaterialNO, polyinfo.Grade, polyinfo.ProdSpec, //sspinfo.GrossWeight,
     //          polyinfo.Num,
     //          polyinfo.ProdDate.ToString("yyyy-MM-dd"), polyinfo.PackID, polyinfo.CheckID, polyinfo.BarCode, polyinfo.BarCode));

     //       //return base.Print(barCode, point) + r;
     //       return r.ToString();

     //   }

        public string PrintLabel(string barCode)
        {
            StringBuilder r = new StringBuilder();
            switch (_IXD01.ProdType)
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

        public DataTable GetColumnsName()
        {
            return gbiz.GetGoodList(new string[] { "UserID", "BarCode" }, new object[] { "", "" });
        }
    }
}
