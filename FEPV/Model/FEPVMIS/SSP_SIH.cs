using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Model
{
    [Serializable]
    public class SSP_SIH : Voucher
    {

        public string Line { get; set; }

        public string Grade { get; set; }

        public string GradeS { get; set; }

        public string Version0 { get; set; }

        public string Version { get; set; }

        public override string[] COLUMNS
        {
            get { return new string[] { "VoucherID", "Grade", "GradeS", "Line", "Version0", "Version" }; }
        }

        public override object[] VALUES
        {
            get { return new object[] { VoucherID, Grade, GradeS, Line, Version0, Version }; }
        }


        public override string TableName
        {
            get { return "FEPV_SSP_SIH"; }
        }
    }
}
