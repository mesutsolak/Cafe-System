using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Repository.Concrete;
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
using System.Web.UI.WebControls.WebParts;

namespace CP.WebUI.Controllers
{
    [AccessDeniedAuthorize(Roles = "Customer,Employee")]
    public class CampaignController : BaseController
    {
        // GET: Campaign
        [Route("Kampanyalar")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("KampanyaList")]
        public PartialViewResult CampaignList()
        {
            return PartialView(CampaignOperation.GetListCampaigns());
        }
        [Route("KampanyaEkle")]
        public PartialViewResult CampaignAdd()
        {
            return PartialView(new Campaign());
        }
        [Route("KampanyaGüncelle")]
        public ActionResult CampaignUpdate(int id)
        {

            var _campaign = CampaignOperation.GetCampaign(id);
            if (_campaign.Image != null)
            {
                var _campaignName = _campaign.Image.Substring(124, _campaign.Image.Length - 124).Split('?');
                ViewBag._campaignName = _campaignName[0];
            }
            return PartialView(_campaign);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CampaignAddOperation(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                jsonResultModel.Title = "Ekleme İşlemi";

                if (!campaign.Images.IsNullObject() && campaign.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(campaign.Images.FileName);
                    campaign.Image = await firebaseStorageHelper.UploadFile(campaign.Images.InputStream, ImageName, "Campaign");
                }

                int id = CampaignOperation.CampaignAdd(campaign);

                if (id > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Modal = "CampaignAddModal";
                    jsonResultModel.Description = "Kampanya Başarıyla Eklendi";
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kampanya Ekleme Başarısız";
                }
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Lütfen eksiksiz doldurun";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CampaignUpdateOperation(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                jsonResultModel.Title = "Güncelleme İşlemi";

                if (!campaign.Images.IsNullObject() && campaign.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(campaign.Images.FileName);
                    campaign.Image = await firebaseStorageHelper.UploadFile(campaign.Images.InputStream, ImageName, "Campaign");
                }

                int id = CampaignOperation.CampaignUpdate(campaign);

                if (id > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Description = "Kampanya Başarıyla Güncellendi";
                    jsonResultModel.Modal = "CampaignUpdateModal";
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kampanya Güncelleme Başarısız";
                }
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Lütfen eksiksiz doldurun";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("RemoveCampaign")]
        public JsonResult RemoveProduct(int id)
        {
            int _id = CampaignOperation.CampaignRemove(id);

            if (_id > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Silindi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Kampanya Silme Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
    }
}