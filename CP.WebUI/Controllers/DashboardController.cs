using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        [Route("Panel")]
        public ActionResult Index()
        {
            return View();
        }
    }
}