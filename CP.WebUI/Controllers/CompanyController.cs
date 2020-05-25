using CP.BusinessLayer.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        [Route("FirmaBilgileri")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Slider")]
        public ActionResult Slider()
        {
            return View();
        }
        [Route("SliderList")]
        public PartialViewResult SliderList()
        {
            return PartialView(SliderOperations.GetSliders());
        }
    }
}