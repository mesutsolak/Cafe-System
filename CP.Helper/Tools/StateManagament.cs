using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PES.Logic.Tools
{
    public static class StateManagament
    {
        public static void SessionEnd()
        {
            HttpContext.Current.Session.Abandon();
        }
        public static HttpCookie CookieCreate(string CookieName)
        {
            return HttpContext.Current.Request.Cookies[CookieName];
        }
        public static void SessionAdd(string key, string value)
        {
            HttpContext.Current.Session.Add(key, value);
        }
        public static void SessionAdd(string key, int value)
        {
            HttpContext.Current.Session.Add(key, value);
        }
        public static object SessionValue(string key)
        {
            return HttpContext.Current.Session[key];
        }
        public static void CookieEnd(string key)
        {
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
