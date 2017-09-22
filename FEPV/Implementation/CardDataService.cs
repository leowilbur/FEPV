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
    public class CardDataService : MarshalByRefObject, ICardData
    {
        public CardDataService()
        {
            ac.RegisterSqlLogger(new NBear.Common.LogHandler(Logger.Trace));
        }

        protected static NBear.Data.Gateway ac = new NBear.Data.Gateway("Beling");
        DB db = new DB("Beling");

        /// <summary>
        /// 获得卡片实体
        /// </summary>
        private CardData GetCardDataEntity(string cardId)
        {
            Console.WriteLine("CardDataService - GetCardDataEntity()" + " - " + DateTime.Now.ToString());
            Console.WriteLine(cardId);

            try
            {
                return db.Select<CardData>(new CardData { CardID = cardId });
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
        /// 保存卡片数据
        /// </summary>
        /// <param name="cardData"></param>
        /// <returns></returns>
        public bool SaveCardData(CardData cardData)
        {
            Console.WriteLine("CardDataService - SaveCardData()" + " - " + DateTime.Now.ToString());
            Console.WriteLine(cardData.CardID);
            
            try
            {
                cardData.Stamp = DateTime.Now;
                cardData.UserID = DB.User;

                CardData _CardData = GetCardDataEntity(cardData.CardID);
                Console.WriteLine("_CardData.CardTypeID:" + _CardData.CardTypeID);
                if (!string.IsNullOrEmpty(_CardData.CardTypeID))//因为_CardData.CardID不为空，并且=cardData.CardID
                {
                    Console.WriteLine("Update--------------");
                    return db.Update(cardData);
                }
                Console.WriteLine("InsertCardData--------------");
                return db.Save<CardData>(cardData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.Trace(e);
                Logger.Warnning(e);
                throw e;
            }
        }
    }
}
