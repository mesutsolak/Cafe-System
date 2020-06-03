using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Tools;
using CP.Entities.Model;
using CP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    [AccessDeniedAuthorize(Roles = "Customer,Employee")]
    public class CompanyController : BaseController
    {
        [Route("AnasayfaBilgileri")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("AnasayfaList")]
        public PartialViewResult HomeList()
        {
            return PartialView(HomePageOperation.DefaultHomePage());
        }
        [Route("AnasayfaAdd")]
        public PartialViewResult HomeAdd()
        {
            return PartialView(new HomePage());
        }
        [Route("AnasayfaGüncelle")]
        public PartialViewResult HomeUpdate()
        {
            var _result = HomePageOperation.DefaultHomePage();
            return PartialView(_result);
        }

        public JsonResult HomePageAddOperation(HomePage homePage)
        {
            jsonResultModel.Title = "Ekleme İşlemi";
            var _result = HomePageOperation.HomePageAdd(homePage);
            if (_result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Anasayfa bilgi ekleme işlemi başarıyla gerçekleşti";
                jsonResultModel.Modal = "HomePageAddModal";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Ekleme işlemi başarısız.";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult HomePageUpdateOperation(HomePage homePage)
        {
            jsonResultModel.Title = "Güncelleme İşlemi";
            var _result = HomePageOperation.HomePageUpdate(homePage);
            if (_result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Anasayfa bilgisi başarıyla güncellendi";
                jsonResultModel.Modal = "HomePageUpdateModal";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Güncelleme işlemi başarısız.";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("HomeRemove")]
        public JsonResult HomePageRemoveOperation(int id)
        {
            jsonResultModel.Title = "Silme İşlemi";
            var _result = HomePageOperation.HomeRemove(id);
            if (_result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Silindi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Silme işlemi başarısız.";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
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
        public JsonResult ContactAddOperation(Contact contact)
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

        [Route("GenelBilgiler")]
        public ActionResult GeneralInformation()
        {
            return View();
        }
        [Route("GenelList")]
        public PartialViewResult GeneralList()
        {
            return PartialView(GeneralOperation.FirstRecord());
        }
        [Route("GenelEkle")]
        public PartialViewResult GeneralAdd()
        {
            return PartialView(new General());
        }
        [Route("GenelGüncelle")]
        public PartialViewResult GeneralUpdate()
        {
            General g = GeneralOperation.FirstRecord();

            if (g.Image != null)
            {
                var general = g.Image.Substring(124, g.Image.Length - 124).Split('?');
                ViewBag.GeneralImage = general[0];
            }

            return PartialView(g);
        }
        [Route("GeneralRemove")]
        public JsonResult GeneralRemove(int id)
        {
            jsonResultModel.Title = "Silme İşlemi";


            int result = GeneralOperation.GeneralRemove(id);

            if (result > 0)
            {
                jsonResultModel.Description = "Başarıyla Silindi";
                jsonResultModel.Icon = "success";
            }
            else
            {
                jsonResultModel.Description = "Genel Bilgi Silme Başarısız";
                jsonResultModel.Icon = "error";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GeneralAddOperation(General general)
        {
            jsonResultModel.Title = "Ekleme İşlemi";

            if (ModelState.IsValid)
            {
                jsonResultModel.Modal = "GeneralAddModal";

                if (!general.Images.IsNullObject() && general.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(general.Images.FileName);
                    general.Image = await firebaseStorageHelper.UploadFile(general.Images.InputStream, ImageName, "General");
                }


                int result = GeneralOperation.GeneralAdd(general);

                if (result > 0)
                {
                    jsonResultModel.Description = "Genel Bilgi Ekleme Başarılı";
                    jsonResultModel.Icon = "success";
                }
                else
                {
                    jsonResultModel.Description = "Genel Bilgi Ekleme Başarısız";
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
        [HttpPost]
        public async Task<JsonResult> GeneralUpdateOperation(General general)
        {
            jsonResultModel.Title = "Güncelleme İşlemi";

            if (ModelState.IsValid)
            {
                jsonResultModel.Modal = "GeneralUpdateModal";

                if (!general.Images.IsNullObject() && general.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(general.Images.FileName);
                    general.Image = await firebaseStorageHelper.UploadFile(general.Images.InputStream, ImageName, "General");
                }


                int result = GeneralOperation.GeneralUpdate(general);

                if (result > 0)
                {
                    jsonResultModel.Description = "Genel Bilgi Güncelleme Başarılı";
                    jsonResultModel.Icon = "success";
                }
                else
                {
                    jsonResultModel.Description = "Genel Bilgi Güncelleme Başarısız";
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