using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace Infrastructure.Library
{
    public static class Singleton<T> where T : new()
    {
        static T _instance;

        static public T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        //public static readonly T Instance = new T();
    }
}
