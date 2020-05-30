using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace CP.BusinessLayer.Tools
{
    public class SessionManager
    {
        private HttpSessionState _Session { get; set; }
        public SessionManager()
        {
            _Session = HttpContext.Current.Session;
        }

        public void Set(string key, object value)
        {
            if (_Session[key].IsNullObject())
                _Session.Add(key, value);
            else
                _Session[key] = value;
        }
        public object Value(string key)
        {
            return _Session[key];
        }
        public void Remove(string key)
        {
            _Session.Remove(key);
        }
        public void Clear()
        {
            _Session.Clear();
        }
        public void RemoveAll()
        {
            _Session.RemoveAll();
        }
        public void Abandon()
        {
            _Session.Abandon();
        }
        public string SessionId()
        {
            return _Session.SessionID;
        }
    }
}
