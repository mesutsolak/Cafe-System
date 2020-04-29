using CP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        ErrorModel models = new ErrorModel();

        //401,403,404,500

        public ActionResult PageError(Exception exception=null)
        {
            if (exception!=null)
            {
                models.Exception = exception;
            }
            return View(models);
        }
        public ActionResult Page404(string aspxerrorpath)
        {
            if (!string.IsNullOrEmpty(aspxerrorpath))
                models.Source = aspxerrorpath;

            models.Title = "Sayfa Bulunamadı";

            models.Url = "~/Content/template/assets/img/error-404-monochrome.svg";

            return View("PageError",null);
        }
        public ActionResult Page403(string aspxerrorpath)
        {
            if (!string.IsNullOrEmpty(aspxerrorpath))
                models.Source = aspxerrorpath;
            models.Title = "Sayfa Gizlenmiştir";

            models.Url = "https://cdn.dribbble.com/users/516732/screenshots/4527062/dribbble-403.png";

            return View("PageError",null);
        }
        public ActionResult Page500(string aspxerrorpath)
        {
            if (!string.IsNullOrEmpty(aspxerrorpath))
                models.Source = aspxerrorpath;
            models.Title = "Sunucuda bir hata oluştu ve istek karşılanamadı.";

            models.Url = "https://cdn1.iconfinder.com/data/icons/browser-5/100/ui-brower-go-25-512.png";

            return View("PageError",null);
        }
        public ActionResult Page401(string aspxerrorpath)
        {
            if (!string.IsNullOrEmpty(aspxerrorpath))
                models.Source = aspxerrorpath;

            models.Url = "https://cdn1.iconfinder.com/data/icons/website-internet-browser/711/401_error_unauthorized_internet_window_browser-512.png";

            models.Title = "İstek için kimlik doğrulaması gerekiyor.";

            return View("PageError",null);
        }

    }
}