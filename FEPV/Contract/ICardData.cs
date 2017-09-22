using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FEPV.Model;
using System.Data;

namespace FEPV.Contract
{
    public interface ICardData
    {
        bool SaveCardData(CardData cardData);
    }
}
