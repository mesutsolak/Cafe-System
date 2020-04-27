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
    }
}