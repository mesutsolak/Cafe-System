﻿using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
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
        public PartialViewResult RoleUpdate(int id)
        {
            return PartialView(RoleOperation.GetRole(id));
        }

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
    }
}                                      