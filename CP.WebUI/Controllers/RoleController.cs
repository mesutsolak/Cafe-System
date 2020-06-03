using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using CP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{

    [AccessDeniedAuthorize(Roles = "Admin")]
    public class RoleController : BaseController
    {
        // GET: Role
        [Route("Roller")]
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult RoleAdd()
        {
            return PartialView(new Roles());
        }

        [Route("RoleUpdate")]
        public PartialViewResult RoleUpdate(int id)
        {
            return PartialView(RoleOperation.GetRole(id));
        }

        [Route("RolList")]
        public PartialViewResult RoleList()
        {
            return PartialView(RoleOperation.GetRoles());
        }

        [HttpPost]
        public JsonResult RoleAddOperation(Roles roles)
        {
            jsonResultModel.Title = "Rol Ekleme";
            if (ModelState.IsValid)
            {
                var result = RoleOperation.RoleAdd(roles);

                if (result > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Modal = "RoleAddModal";
                    jsonResultModel.Description = "Rol Ekleme Başarılı";

                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Role Ekleme Başarısız";
                }
            }
            else
            {
                jsonResultModel.Description = "Lütfen formu eksiksiz doğrulayın";
                jsonResultModel.Icon = "error";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult RoleUpdateOperation(Roles roles)
        {
            jsonResultModel.Title = "Rol Güncelleme";
            if (ModelState.IsValid)
            {
                var result = RoleOperation.RoleUpdate(roles);

                if (result > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Modal = "RoleUpdateModal";
                    jsonResultModel.Description = "Rol Güncelleme Başarılı";

                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Role Güncelleme Başarısız";
                }
            }
            else
            {
                jsonResultModel.Description = "Lütfen formu eksiksiz doğrulayın";
                jsonResultModel.Icon = "error";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        [Route("RemoveRole")]
        public JsonResult RemoveRole(int id)
        {
            int _id = RoleOperation.RoleRemove(id);

            if (_id > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Silindi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Rol Silme Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
    }
}