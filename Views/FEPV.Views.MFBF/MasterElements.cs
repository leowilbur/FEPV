using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Views
{
    public class MasterElements
    {
        public string 事务 { get; set; }
        public string 单号 { get; set; }
        public string 物料 { get; set; }
        public string 规格 { get; set; }
        public string 工厂 { get; set; }
        public string 成本中心 { get; set; }
        public string 批次 { get; set; }
        public string 单据日期 { get; set; }
        public string 当道版本 { get; set; }
        public string 前道版本 { get; set; }
        public int 包数 { get; set; }
        public decimal 总净重 { get; set; }

        public List<DetailElements> Goodses { get; set; }
    }
}
