using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Tools;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        [Route("SliderUpdate")]
        public PartialViewResult SliderUpdate(int id)
        {
            var _slider = SliderOperations.SliderFind(id);

            if (_slider.Image != null)
            {
                var productName = _slider.Image.Substring(124, _slider.Image.Length - 124).Split('?');
                ViewBag.SliderName = productName[0];
            }


            return PartialView(_slider);
        }

        public async Task<JsonResult> SliderAddOperation(Slider slider)
        {
            jsonResultModel.Title = "Ekleme İşlemi";

            if (ModelState.IsValid)
            {
                jsonResultModel.Modal = "SliderAddModal";

                if (!slider.Images.IsNullObject() && slider.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(slider.Images.FileName);
                    slider.Image = await firebaseStorageHelper.UploadFile(slider.Images.InputStream, ImageName, "Slider");
                }


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
            }
            else
            {

                jsonResultModel.Description = "Lütfen formu eksiksiz doldurun.";
                jsonResultModel.Icon = "error";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
        [Route("SliderRemove")]
        public JsonResult SliderRemoveOperation(int id)
        {
            jsonResultModel.Title = "Silme İşlemi";

            int result = SliderOperations.SliderRemove(id);

            if (result > 0)
            {
                jsonResultModel.Description = "Başarıyla Silindi";
                jsonResultModel.Icon = "success";
            }
            else
            {
                jsonResultModel.Description = "Slider Silme Başarısız";
                jsonResultModel.Icon = "error";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public async Task<JsonResult> SliderUpdateOperation(Slider slider)
        {
            jsonResultModel.Title = "Güncelleme İşlemi";

            if (ModelState.IsValid)
            {
                jsonResultModel.Modal = "SliderUpdateModal";

                if (!slider.Images.IsNullObject() && slider.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(slider.Images.FileName);
                    slider.Image = await firebaseStorageHelper.UploadFile(slider.Images.InputStream, ImageName, "Slider");
                }


                int result = SliderOperations.SliderUpdate(slider);

                if (result > 0)
                {
                    jsonResultModel.Description = "Slider Güncelleme Başarılı";
                    jsonResultModel.Icon = "success";
                }
                else
                {
                    jsonResultModel.Description = "Slider Güncelleme Başarısız";
                    jsonResultModel.Icon = "error";
                }
            }
            else
            {

                jsonResultModel.Description = "Lütfen formu eksiksiz doldurun.";
                jsonResultModel.Icon = "error";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

    }
}