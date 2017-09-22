using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface IAc
    {
        DataTable GetGuests(string[] ps, object[] vs, string UserId);

        bool SaveGuestItem(GuestItem guestItem);

        DataTable GetTrucks(string[] ps, object[] vs, string UserId);

        bool CreatePtaEgItem(PtaEgItem ptaEgItem);

        DataTable GetGoods(string[] ps, object[] vs, string UserId);

        DataTable GetGoodsBack(string[] ps, object[] vs);

        bool SaveGoodsBackItem(GoodsBackItem goodsBackItem);

        Guest GetGuestEntity(string voucherid);

        bool SaveGuest(Guest guest);

        Goods GetGoodsEntity(string voucherid);

        bool SaveGoods(Goods goods);
    }
}
