using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEPV.Views
{
    public interface IQueryView
    {
        string[] Parameters { get; }

        object[] Values { get; }
    }
}
