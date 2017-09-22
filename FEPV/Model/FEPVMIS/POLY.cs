using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Model
{
    [Serializable]
    public class POLY : UIGoods
    {
        string _Chip = "--";

        public string Chip
        {
            get { return _Chip; }
            set { _Chip = value; }
        }

        public string Line { get; set; }

        public string Grade { get; set; }

        public string GradeS { get; set; }

        public decimal GrossWeight { get; set; }

        public string CheckID { get; set; }

        public string PackID { get; set; }


        public override string Batch
        {
            get
            {
                return Grade.PadRight(2, '-') + GradeS.PadRight(2, '-') + Line.PadRight(2, '-') + Chip.PadRight(2, '-');
            }
        }
        public override string[] COLUMNS
        {
            get { return new string[] { "BarCode", "Line", "Grade", "GradeS", "GWT", "CheckID", "PackID", "Chip" }; }
        }

        public override object[] VALUES
        {
            get { return new object[] { BarCode, Line, Grade, GradeS, GrossWeight, CheckID, PackID, Chip }; }
        }

        public override string TableName
        {
            get
            {
                return "FEPV_POLY";
            }
        }

        public override void Assign(UIGoods des, UIGoods src)
        {
            base.Assign(des, src);
        }


    }
}
