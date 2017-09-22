using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Shawoo.Core;
using System.Drawing;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Text;

namespace FEPV.Model
{
    [Serializable]
    public abstract class UIGoods : ORM
    {

        public string WoNo { get; set; }

        public DateTime LabelDate { get; set; }

        public string Store { get; set; }

        public string BarCode { get; set; }

        public string MaterialNO { get; set; }

        public string ProdSpec { get; set; }

        public string CenterID { get; set; }

        public string Plant { get; set; }

        public string Loc { get; set; }

        public abstract string Batch { get; }

        public decimal Num { get; set; }

        public DateTime ProdDate { get; set; }

        public string UserID { get; set; }

        public int Counter { get; set; }

        public DateTime Stamp { get; set; }

        public Guid Checker { get; set; }

        public string LastVouID { get; set; }

        public string PrevVouID { get; set; }

        public abstract string TableName { get; }

        public string State { get; set; }

        public string Version { get; set; }

        public string Remark { get; set; }

        public string Version0 { get; set; }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(string.Format(@"
                                        BarCode:{0} 
                                        Batch:{1} 
                                        CenterID:{2} 
                                        Counter:{3} 
                                        LastVouID:{4} 
                                        Loc:{5} 
                                        MaterialNO:{6} 
                                        Num:{7} 
                                        Plant:{8} 
                                        PrevVouID:{9} 
                                        ProdDate:{10} 
                                        ProdSpec:{11} 
                                        State:{12} 
                                        UserID:{13} 
                                        Version:{14}
                                        Version0:{15}",
                                     this.BarCode, this.Batch, this.CenterID, this.Counter, this.LastVouID, this.Loc, this.MaterialNO
                                    , this.Num, this.Plant, this.PrevVouID, this.ProdDate, this.ProdSpec, this.State, this.UserID, this.Version, this.Version0));
            return info.ToString();

        }

        public virtual void Assign(UIGoods des, UIGoods src)
        {
            if (!string.IsNullOrEmpty(src.BarCode))
                des.BarCode = src.BarCode;
            if (!string.IsNullOrEmpty(src.MaterialNO))
                des.MaterialNO = src.MaterialNO;
            if (!string.IsNullOrEmpty(src.ProdSpec))
                des.ProdSpec = src.ProdSpec;
            if (!string.IsNullOrEmpty(src.CenterID))
                des.CenterID = src.CenterID;
            if (!string.IsNullOrEmpty(src.Plant))
                des.Plant = src.Plant;
            if (!string.IsNullOrEmpty(src.Loc))
                des.Loc = src.Loc;
            if (src.Num != decimal.Zero)
                des.Num = src.Num;
            if (!string.IsNullOrEmpty(src.Version))
                des.Version = src.Version;
            if (src.ProdDate != DateTime.MinValue)
                des.ProdDate = src.ProdDate;
            if (!string.IsNullOrEmpty(src.State))
                des.State = src.State;
            if (!string.IsNullOrEmpty(src.UserID))
                des.UserID = src.UserID;
            if (src.Counter != 0)
                des.Counter = src.Counter;
            if (src.Stamp != DateTime.MinValue)
                des.Stamp = src.Stamp;
            if (src.Checker != Guid.Empty)
                des.Checker = src.Checker;
            if (!string.IsNullOrEmpty(src.LastVouID))
                des.LastVouID = src.LastVouID;
            if (!string.IsNullOrEmpty(src.PrevVouID))
                des.PrevVouID = src.PrevVouID;
            if (!string.IsNullOrEmpty(src.Remark))
                des.Remark = src.Remark;
            if (!string.IsNullOrEmpty(src.Store))
                des.Store = src.Store;
        }

        #region ORM Members

        public abstract string[] COLUMNS { get; }

        public abstract object[] VALUES { get; }

        #endregion
    }
}
