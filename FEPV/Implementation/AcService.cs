using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using System.Data;
using Shawoo.Core;
using Shawoo.Common;

namespace FEPV.Implementation
{
    public class AcService : MarshalByRefObject, IAc
    {
        public AcService()
        {
            ac.RegisterSqlLogger(new NBear.Common.LogHandler(Logger.Trace));
        }

        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");
        
        #region IAc 成员

        public DataTable GetGuests(string[] ps, object[] vs, string UserId)
        {
            Console.WriteLine("AcService - DataTable GetGuests()" + " - " + DateTime.Now.ToString());

            List<string> paramenters = ps.ToList();
            paramenters.Add("UserID");
            ps = paramenters.ToArray();
            List<object> values = vs.ToList();
            values.Add(UserId);
            vs = values.ToArray();

            DataTable dtGuests = ac.DbHelper.ExecuteStoredProcedure("FK_AC_GetTasks_Guest", ps, vs).Tables[0];
            return dtGuests;
        }

        public DataTable GetTrucks(string[] ps, object[] vs, string UserId)
        {
            Console.WriteLine("AcService - DataTable GetTrucks()" + " - " + DateTime.Now.ToString());
            DataTable dtTrucks = ac.DbHelper.ExecuteStoredProcedure("TK_AC_GetTasks_Trucks", ps, vs).Tables[0];
            return dtTrucks;
        }

        public DataTable GetGoods(string[] ps, object[] vs, string UserId)
        {
            Console.WriteLine("AcService - DataTable GetGoods()" + " - " + DateTime.Now.ToString());

            List<string> paramenters = ps.ToList();
            paramenters.Add("UserID");
            ps = paramenters.ToArray();
            List<object> values = vs.ToList();
            values.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
            vs = values.ToArray();

            DataTable dtGoods = ac.DbHelper.ExecuteStoredProcedure("GD_AC_GetTasks_GoodsOut", ps, vs).Tables[0];
            return dtGoods;
        }

        public DataTable GetGoodsBack(string[] ps, object[] vs)
        {
            Console.WriteLine("AcService - DataTable GetGoodsBack()" + " - " + DateTime.Now.ToString());

            List<string> paramenters = ps.ToList();
            paramenters.Add("UserID");
            ps = paramenters.ToArray();
            List<object> values = vs.ToList();
            values.Add(Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString());
            vs = values.ToArray();

            DataTable dtGoods = ac.DbHelper.ExecuteStoredProcedure("GD_AC_GetTasks_GoodsBack", ps, vs).Tables[0];
            return dtGoods;
        }

        public bool SaveGuestItem(GuestItem guestItem)
        {
            Console.WriteLine("AcService - bool SaveGuestItem()" + " - " + DateTime.Now.ToString());

            ac.ExecuteNonQuery("Update GuestItem SET CardNO=@CardNO,GuestName=@GuestName,IdCard=@IdCard Where ID=@ID"
                                , new object[] { guestItem.CardNO, guestItem.GuestName, guestItem.IdCard, guestItem.ID });

            return true;
        }

        public bool CreatePtaEgItem(PtaEgItem ptaEgItem)
        {
            bool rValue = false;
            Console.WriteLine("AcService - bool CreatePtaEgItem()" + " - " + DateTime.Now.ToString());
            try
            {
                ptaEgItem.InTime = DateTime.Now;
                ptaEgItem.Status = "";
                ptaEgItem.Stamp = DateTime.Now;
                ptaEgItem.UserID = Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString();
                db.Save<PtaEgItem>(ptaEgItem);

                if (ac.SelectScalar<int>("SELECT count(*) FROM PtaEgItem WHERE ItemID = @ItemID",
                                          new object[] { ptaEgItem.ItemID }) == 1)
                {
                    rValue = true;
                }

                return rValue;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }

        public bool SaveGoodsBackItem(GoodsBackItem goodsBackItem)
        {
            bool rValue = false;
            Console.WriteLine("AcService - bool SaveGoodsBackItem()" + " - " + DateTime.Now.ToString());
            try
            {
                ac.ExecuteNonQuery(@"INSERT INTO [GoodsBackItem]
                                           ([ItemID]
                                           ,[VoucherID]
                                           ,[GoodsName]
                                           ,[GoodsAmount]
                                           ,[Unit]
                                           ,[InTime]
                                           ,[Complete]
                                           ,[Status]
                                           ,[Stamp]
                                           ,[UserID])
                                     VALUES
                                            (@ItemID
                                            ,@VoucherID
                                            ,@GoodsName
                                            ,@GoodsAmount
                                            ,@Unit
                                            ,@InTime
                                            ,@Complete
                                            ,@Status
                                            ,@Stamp
                                            ,@UserID)"
                                    , new object[] { goodsBackItem.ItemID, 
                                                goodsBackItem.VoucherID,
                                                goodsBackItem.GoodsName,
                                                goodsBackItem.GoodsAmount,
                                                goodsBackItem.Unit,
                                                DateTime.Now,
                                                null,
                                                "",
                                                DateTime.Now,
                                                Shawoo.GenuineChannels.GenuineUtility.CurrentSession["UID"].ToString()
                                    });

                //return true;
                if (ac.SelectScalar<int>("SELECT count(*) FROM GoodsBackItem WHERE ItemID = @ItemID",
                                          new object[] { goodsBackItem.ItemID }) == 1)
                {
                    rValue = true;
                }

                return rValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        #endregion

        #region 
        /// <summary>
        /// 获得访客实体
        /// </summary>
        public Guest GetGuestEntity(string voucherid)
        {
            Console.WriteLine("AcService - GetGuestEntity()" + " - " + DateTime.Now.ToString());
            return db.Select<Guest>(new Guest { VoucherID = voucherid});
        }

        public bool SaveGuest(Guest guest)
        {
            Console.WriteLine("AcService - SaveGuest()" + " - " + DateTime.Now.ToString());
            Console.WriteLine(guest.VoucherID);
            Console.WriteLine(guest.Status);
            try
            {
                ac.ExecuteNonQuery(@"UPDATE [Guest]
                           SET [InTime] = @InTime
                              ,[OutTime] = @OutTime
                              ,[Status] = @Status
                              ,[Stamp] = @Stamp
                        WHERE VoucherID = @VoucherID",
                        new object[] { 
                            guest.InTime
                            ,guest.OutTime
                            ,guest.Status
                            ,guest.Stamp
                            ,guest.VoucherID});
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        /// <summary>
        /// 获得物品实体
        /// </summary>
        public Goods GetGoodsEntity(string voucherid)
        {
            Console.WriteLine("AcService - GetGoodsEntity()" + " - " + DateTime.Now.ToString());
            return db.Select<Goods>(new Goods { VoucherID = voucherid });
        }
        public bool SaveGoods(Goods goods)
        {
            Console.WriteLine("AcService - SaveGoods()" + " - " + DateTime.Now.ToString());
            Console.WriteLine(goods.VoucherID);
            Console.WriteLine(goods.Status);
            try
            {
                ac.ExecuteNonQuery(@"UPDATE [Goods]
                           SET [OutTime] = @OutTime
                              ,[Status] = @Status
                              ,[Stamp] = @Stamp
                        WHERE VoucherID = @VoucherID",
                        new object[] { 
                            goods.OutTime
                            ,goods.Status
                            ,goods.Stamp
                            ,goods.VoucherID});
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
        
        #endregion
    }
}
