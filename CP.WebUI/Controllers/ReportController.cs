using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [Route("Raporlar")]
        public ActionResult Index()
        {
            return View();
        }
    }
}