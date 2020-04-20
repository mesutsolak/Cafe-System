using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Tools
{
    public static class Extension
    {
        /// <summary>
        /// Convert string to int value
        /// </summary>
        /// <param name="value">String Value</param>
        /// <returns>int value</returns>
        public static int IntConvert(this string value)
        {
            return int.Parse(value);
        }
        public static bool IsNullObject(this object value)
        {
            return value == null ? true : false;
        }
        public static bool IsNullString(this string value)
        {
            return value == null ? false : true;
        }
        public static int ObjectIntConvert(this object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
