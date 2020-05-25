using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    public class CompanyController : BaseController
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
        [Route("SliderAdd")]
        public PartialViewResult SliderAdd()
        {
            return PartialView(new Slider());
        }
        public JsonResult SliderAddOperation(Slider slider)
        {
            jsonResultModel.Title = "Ekleme İşlemi";
            jsonResultModel.Modal = "SliderAddModal";


            int result = SliderOperations.SliderAdd(slider);

            if (result > 0)
            {
                jsonResultModel.Description = "Slider Ekleme Başarılı";
                jsonResultModel.Icon = "success";
            }
            else
            {
                jsonResultModel.Description = "Slider Ekleme Başarısız";
                jsonResultModel.Icon = "error";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
    }
}