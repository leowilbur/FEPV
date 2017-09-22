using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using FEPV.BLL;
namespace FEPV.Views
{
    public delegate void LoadData(string msg);

    public class Material
    {
        public static event LoadData eventLoadData;
        static UIReporting report = new UIReporting();
        public static BindingList<Material> GetMaterials(string mateialNo)
        {
            BindingList<Material> _materials = new BindingList<Material>();
            int index = 1;
            int count;
            DataTable tb = report.SearchDataByPage("Material", "*", "MaterialNO", 500, index, false,
                                                   string.Format(@"MaterialNo LIKE '{0}'",
                                                                 mateialNo
                                                                 ),
                                                   out count).Tables[0];
            foreach (DataRow row in tb.Rows)
            {
                _materials.Add(new Material
                {
                    MaterialNo = (string)row["MaterialNO"],
                    ProdSpec = (string)row["ProdSpec"],
                    ProdType = (string)row["AB"],
                    Unit = (string)row["Unit"]

                });
            }
            return _materials;
        }
        /// <summary>
        /// 物料
        /// </summary>
        public string MaterialNo { get; set; }
        /// <summary>
        /// 产品别
        /// </summary>
        public string ProdType { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string ProdSpec { get; set; }
        /// <summary>
        /// 基本单位
        /// </summary>
        public string Unit { get; set; }

        BindingList<WERKS> _Plants;
        public BindingList<WERKS> Werks
        {
            get
            {
                if (_Plants != null)
                    return
                        _Plants;
                _Plants = new BindingList<WERKS>();

                int index = 1;
                int count;
                if (eventLoadData != null)
                    eventLoadData(MaterialNo + "->WERKS");
                DataTable tb = report.SearchDataByPage("vWERKS", "PLANT,MaterialNO ", "MaterialNO", 500, index, false,
                                                       string.Format(@"MaterialNo = '{0}'",
                                                                     MaterialNo
                                                                     ),
                                                       out count).Tables[0];
                _Plants.Clear();
                foreach (DataRow row in tb.Rows)
                {
                    _Plants.Add(new WERKS
                    {
                        Plant = (string)row["Plant"],
                        MaterialNO = (string)row["MaterialNO"],
                    });
                }

                if (eventLoadData != null)
                    eventLoadData("");
                return _Plants;
            }
        }
    }

    public class WERKS
    {
        static UIReporting report = new UIReporting();
        public static event LoadData eventLoadData;
        public string Plant { get; set; }
        public string MaterialNO { get; set; }


        public override string ToString()
        {
            return MaterialNO + "(" + Plant + ")";
        }

        BindingList<Version> _Versions = new BindingList<Version>();
        public BindingList<Version> Version
        {
            get
            {
                int index = 1;
                int count;
                if (eventLoadData != null)
                    eventLoadData(MaterialNO + "+" + Plant + "->Version");
                DataTable tb = report.SearchDataByPage("Version", "*", "VER", 5000, index, false,
                                                       string.Format(@"MaterialNo = '{0}'
                                                                   AND PLANT = '{1}'
                                                                      ",
                                                                     MaterialNO, Plant
                                                                     ),
                                                       out count).Tables[0];
                _Versions.Clear();
                foreach (DataRow row in tb.Rows)
                {
                    _Versions.Add(new Version
                    {
                        MaterialNO = (string)row["MaterialNO"],
                        Plant = (string)row["PLANT"],
                        STLAL = (string)row["STLAL"],
                        STLOC = (string)row["STLOC"],
                        Ver = (string)row["VER"],
                        Spec = (string)row["Spec"],
                        ADATU = (DateTime)row["ADATU"],
                        BDATU = (DateTime)row["BDATU"]

                    });
                }
                if (eventLoadData != null)
                    eventLoadData("");
                return _Versions;
            }
        }
    }

    public class Version
    {
        static UIReporting report = new UIReporting();
        /// <summary>
        /// 物料
        /// </summary>
        public string MaterialNO { get; internal set; }
        /// <summary>
        /// 工厂
        /// </summary>
        public string Plant { get; internal set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Ver { get; internal set; }
        /// <summary>
        /// 可选BOM
        /// </summary>
        public string STLAL { get; internal set; }
        /// <summary>
        /// 版本说明
        /// </summary>
        public string Spec { get; internal set; }
        /// <summary>
        /// 入库地点
        /// </summary>
        public string STLOC { get; internal set; }
        /// <summary>
        /// 起始有效期
        /// </summary>
        public DateTime ADATU { get; internal set; }
        /// <summary>
        /// 终止有效期
        /// </summary>
        public DateTime BDATU { get; internal set; }

        BindingList<Bom> _Boms = new BindingList<Bom>();
        public static event LoadData eventLoadData;
        public BindingList<Bom> BOM
        {
            get
            {
                int index = 1;
                int count;
                if (eventLoadData != null)
                    eventLoadData(MaterialNO + "+" + Plant + "+" + STLAL + "->BOM");
                DataTable tb = report.SearchDataByPage("vBOM", "*", "IDNRK", 5000, index, false,
                                                       string.Format(@"MaterialNo = '{0}'
                                                                   AND PLANT = '{1}'
                                                                   AND STLAL = '{2}'
                                                                      ",
                                                                     MaterialNO, Plant, STLAL
                                                                     ),
                                                       out count).Tables[0];
                _Boms.Clear();
                foreach (DataRow row in tb.Rows)
                {
                    WERKS wks = new WERKS { MaterialNO = (string)row["IDNRK"], Plant = Plant };
                    _Boms.Add(new Bom
                    {
                        IDNRK = (string)row["IDNRK"],
                        MENGE = (decimal)row["MENGE"],
                        MEINS = (string)row["MEINS"],
                        Versions = wks.Version
                    });
                }
                if (eventLoadData != null)
                    eventLoadData("");
                return _Boms;
            }
        }

    }

    public class Bom
    {
        internal string MaterialNO;
        public static event LoadData eventLoadData;
        internal string Plant { get; set; }
        internal string STLAL { get; set; }
        /// <summary>
        /// 原料物料号
        /// </summary>
        public string IDNRK { get; internal set; }
        /// <summary>
        /// 原料消耗量
        /// </summary>
        public Decimal MENGE { get; internal set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string MEINS { get; internal set; }
        /// <summary>
        /// 前道版本
        /// </summary>
        public BindingList<Version> Versions
        {
            get;
            internal set;
        }
    }

}
