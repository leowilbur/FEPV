using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;


namespace FEPV.Model
{
    [Serializable]
    public class Bom
    {
        public string MaterialNO { get; set; }

        public string Plant { get; set; }

        public string STLAL { get; set; }

        public string STLNR { get; set; }

        public string STLAN { get; set; }

        public decimal BMENG { get; set; }

        public string BMEIN { get; set; }

        public override string ToString()
        {
            string rValue = "MIS.Model.Bom_Info|";
            rValue += string.Format("BMEIN:{0};", this.BMEIN);
            rValue += string.Format("BMENG:{0};", this.BMENG);
            rValue += string.Format("MaterialNO:{0};", this.MaterialNO);
            rValue += string.Format("Plant:{0};", this.Plant);
            rValue += string.Format("STLAL:{0};", this.STLAL);
            rValue += string.Format("STLAN:{0};", this.STLAN);
            rValue += string.Format("STLNR:{0};", this.STLNR);
            return base.ToString();
        }
    }

}
