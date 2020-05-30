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
        public HttpCookie CookieGetValue(string key)
        {
            return _request[key];
        }
        public void CookieCreateValue(string key, IDictionary<string, string> keyValues)
        {
            HttpCookie cookies = new HttpCookie(key);

            foreach (var item in keyValues)
            {
                cookies[item.Key] = item.Value;
            }

            cookies.Expires = DateTime.Now.AddDays(3);
            _response.Add(cookies);
        }
        public void CookieClear(string name)
        {
            //Silmek için kullanılır
            _response[name].Expires = DateTime.Now.AddHours(-1);
        }
    }
}
