using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;


namespace FEPV.Model
{
    [Serializable]
    public class PrdVersion
    {
        public string STLOC { get; set; }

        public string MaterialNO { get; set; }

        public string Plant { get; set; }

        public string VER { get; set; }

        public string STLAL { get; set; }

        public string Spec { get; set; }

        public DateTime ADATU { get; set; }

        public DateTime BDATU { get; set; }

        public string SERKZ { get; set; }

        public string STLAN { get; set; }

        public string STLTY { get; set; }

        public string STLNR { get; set; }

        public override string ToString()
        {
            string rValue = "MIS.Model.PrdVersion_Info|";
            rValue += string.Format("ADATU:{0};", this.ADATU);
            rValue += string.Format("BDATU:{0};", this.BDATU);
            rValue += string.Format("MaterialNO:{0};", this.MaterialNO);
            rValue += string.Format("Plant:{0};", this.Plant);
            rValue += string.Format("SERKZ:{0};", this.SERKZ);
            rValue += string.Format("Spec:{0};", this.Spec);
            rValue += string.Format("STLAL:{0};", this.STLAL);
            rValue += string.Format("STLAN:{0};", this.STLAN);
            rValue += string.Format("STLNR:{0};", this.STLNR);
            rValue += string.Format("STLTY:{0};", this.STLTY);
            rValue += string.Format("VER:{0};", this.VER);
            return rValue;
        }
    }

}
