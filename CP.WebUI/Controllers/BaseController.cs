using CP.BusinessLayer.Tools;
using CP.ServiceLayer.Firebase;
using CP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected List<SelectListItem> SelectListItems = new List<SelectListItem>();
        //public CafeProjectModel db = new CafeProjectModel();
        protected FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper("cafe-project-bfd17.appspot.com");
        protected JsonResultModel jsonResultModel = new JsonResultModel();
        protected CookieManager _CM = new CookieManager();
        protected SessionManager _SM = new SessionManager();

        [AllowAnonymous]
        public ActionResult AccessDenied(string roles)
        {
            string message = "Sayfaya ulaşmak için kullanıcının <b>" + roles + "</b>";

            if (roles != null)
            {
                var _result = roles.IndexOf(",");
                if (_result > 0)
                {
                    message += " Rollerine sahip olması gerekir.";
                }
                else
                {
                    message += " Rolüne sahip olması gerekir.";
                }
            }

            ViewBag.Message = message;
            return View();
        }
    }
}