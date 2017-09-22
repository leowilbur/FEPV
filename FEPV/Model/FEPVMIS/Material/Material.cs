using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;


namespace FEPV.Model
{
    [Serializable]
    public partial class Material
    {
        public string MaterialNO { get; set; }

        public string AB { get; set; }

        public string ProdSpec { get; set; }

        public string Unit { get; set; }

        public override string ToString()
        {
            string rValue = "MIS.Model.Material_Info|";
            rValue += string.Format("AB:{0};", this.AB);
            rValue += string.Format("MaterialNO:{0};", this.MaterialNO);
            rValue += string.Format("ProdSpec:{0};", this.ProdSpec);
            rValue += string.Format("Unit:{0};", this.Unit);
            return rValue;
        }
    }
}
