using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Logic.Singleton
{
    /// <summary>
    ///  Example : 
    ///  T is ConnectionDb or
    ///  T is User
    /// </summary>
    public sealed class SingletonClass<T> where T : class, new()
    {
        private static readonly T _class;

        public static T Class => _class ?? new T();
    }
}
