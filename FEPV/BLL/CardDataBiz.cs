using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FEPV.Contract;
using FEPV.Model;
using MIS.Utility;
using Shawoo.Core;

namespace FEPV.BLL
{
    public class CardDataBiz
    {
        private readonly ICardData proxy = ServiceFactory.Create<ICardData>();

        public bool SaveCardData(CardData cardData)
        {
            return proxy.SaveCardData(cardData);
        }
    }
}
