using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Data.Linq;

namespace FEPV.Model
{
    [Serializable]
    public abstract class Voucher : UIVoucher
    {
        public Voucher()
        {
            _MaterialNO = string.Empty;
            _CenterID = string.Empty;
            _Plant = string.Empty;
            _Loc = string.Empty;
            _Batch = string.Empty;
        }
        public string VoucherID { get; set; }

        public string MT { get; set; }

        public string TransID { get; set; }

        public string MaterialNO { get; set; }

        public string CenterID { get; set; }

        public string Plant { get; set; }

        public string Loc { get; set; }

        public string Batch { get; set; }

        public string _MaterialNO { get; set; }

        public string _CenterID { get; set; }

        public string _Plant { get; set; }

        public string _Loc { get; set; }

        public string _Batch { get; set; }

        public decimal TotalNum { get; set; }

        public int TotalCount { get; set; }

        public string SAP { get; set; }

        public string State { get; set; }

        public string UserID { get; set; }

        public string CheckID { get; set; }

        public int Counter { get; set; }

        public DateTime Stamp { get; set; }

        public Guid Checker { get; set; }

        public DateTime AccDate { get; set; }

        public abstract string TableName { get; }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(string.Format(@"
                                        VoucherID:{0}
                                        MT:{1};
                                        MaterialNO:{2}
                                        CenterID:{3}
                                        Plant:{4}
                                        Loc:{5}
                                        Batch:{6}
                                        TotalNum:{7}
                                        TotalCount:{8}
                                        SAP:{9}
                                        State:{10}
                                        UserID:{11}
                                        CheckID:{12}
                                        Counter:{13}
                                        Stamp:{14}
                                        Checker:{15}
                                        AccDate:{16}
                                        TableName:{17}",
                               this.VoucherID, this.MT, this.MaterialNO, this.CenterID, this.Plant, this.Loc,
                               this.Batch, this.TotalNum, this.TotalCount, this.SAP, this.State, this.UserID,
                               this.CheckID, this.Counter, this.Stamp, this.Checker, this.AccDate, this.TableName));


            return info.ToString();

        }

        #region ORM Members

        public abstract string[] COLUMNS { get; }

        public abstract object[] VALUES { get; }
        #endregion
    }
    public interface UIVoucher
    {
        string[] COLUMNS { get; }

        object[] VALUES { get; }
    }
}
