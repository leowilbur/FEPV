using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;


namespace FEPV.Model
{
    [Serializable]
    public class BomItem
    {
        public string MaterialNO { get; set; }

        public string Plant { get; set; }

        public string STLAL { get; set; }

        public string IDNRK { get; set; }

        public string POSNR { get; set; }

        public decimal MENGE { get; set; }

        public string MEINS { get; set; }

        public override string ToString()
        {
            string rValue = "MIS.Model.BomItem_Info|";
            rValue += string.Format("IDNRK:{0};", this.IDNRK);
            rValue += string.Format("MaterialNO:{0};", this.MaterialNO);
            rValue += string.Format("MEINS:{0};", this.MEINS);
            rValue += string.Format("MENGE:{0};", this.MENGE);
            rValue += string.Format("Plant:{0};", this.Plant);
            rValue += string.Format("POSNR:{0};", this.POSNR);
            rValue += string.Format("STLAL:{0};", this.STLAL);
            return rValue;
        }
    }
}
