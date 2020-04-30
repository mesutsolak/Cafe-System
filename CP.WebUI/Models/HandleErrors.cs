using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace CP.WebUI.Models
{
    [AllowAnonymous]
    public class HandleErrors : ActionFilterAttribute
    {
        private LogInfo log = new LogInfo();
        private Log l = new Log();
        private Stopwatch _stopwatch;
        int UserId;

        public HandleErrors()
        {
            _stopwatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopwatch.Stop();  //kronometreyi durdur

            filterContext.ExceptionHandled = true;

            var request = filterContext.HttpContext.Request;

            var exception = filterContext.Exception;

            if (exception != null)
            {

                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    UserId = UserOperations.UserFindId(filterContext.HttpContext.User.Identity.Name);
                    log.UserId = UserId;
                    l.UserId = UserId;
                }

                log.Controller = filterContext.RouteData.Values["controller"].ToString();
                log.Action = filterContext.RouteData.Values["action"].ToString();
                log.Date = DateTime.Now;
                log.Type = filterContext.Exception.GetType().ToString();
                log.ExceptionMessage = GetInnerException(filterContext.Exception).Message;
                log.LogStatusId = 2;

                l.AddedDate = DateTime.Now;
                l.Data = SerializeRequest(request); //yukarıda alınan requesti serialize edip, string olarak yazıyorum. 
                l.ExecutionMs = _stopwatch.ElapsedMilliseconds; //çalışma süresi
                l.IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
                l.UrlAccessed = request.RawUrl; //erişilen sayfanın ham url'i
                l.LogStatusId = 2;

                LogOperation.LogInfoAdd(log);

                LogOperation.LogAdd(l);

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var viewResult = new JsonResult();

                    viewResult.Data = new JsonResultModel
                    {
                        Title = "Hata",
                        Description = "Hata Meydana Geldi",
                        Icon = "error",
                        Url = ""
                    };
                    filterContext.Result = viewResult;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Hata");
                }
            }

            base.OnActionExecuted(filterContext);

            //Log classının alanlarını doldur
            //Log classını veritabanına kaydet

            //base.OnActionExecuted(filterContext);   //işlem devam etsin
        }
        private Exception GetInnerException(Exception exception)
        {
            if (exception.InnerException != null)
            {
                return GetInnerException(exception.InnerException);
            }
            else
                return exception;
        }
        private string SerializeRequest(HttpRequestBase request)
        {
            string result = string.Empty;
            #region Form
            List<string> formVals = new List<string>(); //eğer sayfada bir form varsa, formda gönderilen tüm inputları alıp bir listeye atıyorum.
            if (request.Form.AllKeys != null && request.Form.AllKeys.ToList().Count > 0)
            {
                foreach (string s in request.Form.AllKeys.ToList())
                {
                    formVals.Add(request.Form[s]);
                }
            }
            #endregion

            result = Json.Encode(new
            {
                request.Form,    //gönderilen formun tamamı
                formVals,   //formdaki inputlara girilen veriler
                request.Browser.Browser,    //kullanıcının tarayıcısı
                request.Browser.IsMobileDevice,     //istek bir mobil cihazdan mı geldi
                request.Browser.Version,    //kullanıcının tarayıcı versiyonu
                request.UserAgent,      //yönlendiren kuruluşu bulmamızı sağlayan useragent bilgisi
                request.UserLanguages,  //tarayıcı dili
                request.UrlReferrer     //yönlendiren sayfayı bulmamızı sağlayan urlreferrer bilgisi
            });     //tüm bu bilgileri serialize edip stringe çeviriyorum

            return result;
        }
    }
}
