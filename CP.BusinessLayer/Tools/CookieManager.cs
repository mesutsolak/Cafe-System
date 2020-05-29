using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CP.BusinessLayer.Tools
{
    public class CookieManager
    {
        private HttpCookieCollection _response { get; set; }
        private HttpCookieCollection _request { get; set; }
        public CookieManager()
        {
            _response = HttpContext.Current.Response.Cookies;
            _request = HttpContext.Current.Request.Cookies;
        }
        public void CookieSetValue(string key, string value)
        {
            _response[key].Value = value;
        }
        public string CookieGetValue(string key)
        {
            return _request[key].Value;
        }
        public void CookieCreateValue(string key, IDictionary<string, string> keyValues)
        {
            HttpCookie cookies = new HttpCookie(key);

            foreach (var item in keyValues)
            {
                cookies[item.Key] = item.Value;
            }

            cookies.Expires.Add(new TimeSpan(0, 1, 0));
            _response.Add(cookies);
        }
        public void CookieClear(HttpCookie cookie)
        {
            //Silmek için kullanılır
            cookie.Expires = DateTime.Now.AddHours(-1);
        }
    }
}
