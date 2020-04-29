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
        private Stopwatch _stopwatch;

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

            var exception = filterContext.Exception;

            if (exception != null)
            {

                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    log.UserId = UserOperations.UserFindId(filterContext.HttpContext.User.Identity.Name);
                }

                log.Controller = filterContext.RouteData.Values["controller"].ToString();
                log.Action = filterContext.RouteData.Values["action"].ToString();
                log.Date = DateTime.Now;
                log.Type = filterContext.Exception.GetType().ToString();
                log.ExceptionMessage = GetInnerException(filterContext.Exception).Message;
                log.LogStatusId = 2;

                LogOperation.LogInfoAdd(log);

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
    }
}
