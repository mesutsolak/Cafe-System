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
        [Route("Bilgiler")]
        public ActionResult Informations()
        {
            return View();
        }
        [Route("BilgiList")]
        public PartialViewResult InformationList()
        {
            return PartialView(CompanyOperation.GetCompanyInformation());
        }
        [Route("BilgiEkle")]
        public PartialViewResult InformationAdd()
        {
            return PartialView(new CompanyInformation());
        }
        [Route("BilgiGüncelle")]
        public PartialViewResult InformationUpdate(int id)
        {
            var _information = CompanyOperation.GetCompanyInformation();
            return PartialView(_information);
        }

        public JsonResult InformationAddOperation(CompanyInformation companyInformation)
        {
            jsonResultModel.Title = "Ekleme İşlemi";

            int result = CompanyOperation.CompanyInfoAdd(companyInformation);

            if (result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Modal = "InformationAddModal";
                jsonResultModel.Description = "Bilgi Başarıyla Eklendi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Bilgi Ekleme Başarısız";
            }


            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
        [Route("InformationRemove")]
        public JsonResult InformationRemoveOperation(int id)
        {
            jsonResultModel.Title = "Silme İşlemi";


            int result = CompanyOperation.CompanyInfoRemove(id);

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

        public JsonResult InformationUpdateOperation(CompanyInformation companyInformation)
        {
            jsonResultModel.Title = "Güncelleme İşlemi";

            int result = CompanyOperation.CompanyInfoUpdate(companyInformation);

            if (result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Modal = "InformationUpdateModal";
                jsonResultModel.Description = "Bilgi Başarıyla Güncellendi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Bilgi Güncelleme Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

        [Route("İletişim")]
        public ActionResult Contact()
        {
            return View();
        }
        [Route("İletişimListele")]
        public PartialViewResult ContactList()
        {
            return PartialView(ContactOperation.GetContact());
        }
        [Route("ContactAdd")]
        public PartialViewResult ContactAdd()
        {
            return PartialView(new Contact());
        }
        [Route("ContactUpdate")]
        public PartialViewResult ContactUpdate()
        {
            return PartialView(ContactOperation.GetContact());
        }
        [Route("İletişimSil")]
        public JsonResult ContactRemove(int id)
        {

            jsonResultModel.Title = "Silme İşlemi";


            int result = ContactOperation.ContactRemove(id);

            if (result > 0)
            {
                jsonResultModel.Description = "Başarıyla Silindi";
                jsonResultModel.Icon = "success";
            }
            else
            {
                jsonResultModel.Description = "İletişim Silme Başarısız";
                jsonResultModel.Icon = "error";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
        [Route("İletişimEkle")]
        [HttpPost]
        public JsonResult ContactAdd(Contact contact)
        {
            jsonResultModel.Title = "Ekleme İşlemi";

            int result = ContactOperation.ContactAdd(contact);

            if (result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Modal = "ContactAddModal";
                jsonResultModel.Description = "İletişim Başarıyla Eklendi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "İletişim Ekleme Başarısız";
            }


            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
        [Route("İletişimGüncelle")]
        [HttpPost]
        public JsonResult ContactUpdateOperation(Contact contact)
        {
            jsonResultModel.Title = "Güncelleme İşlemi";

            int result = ContactOperation.ContactUpdate(contact);

            if (result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Modal = "ContactUpdateModal";
                jsonResultModel.Description = "İletişim Başarıyla Güncellendi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "İletişim Güncelleme Başarısız";
            }


            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GeneralInformation()
        {
            return View();
        }
        [Route("GenelBilgiler")]
        public PartialViewResult GeneralList()
        {
            return PartialView();
        }
    }
}