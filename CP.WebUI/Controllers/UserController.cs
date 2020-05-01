using CP.BusinessLayer.Operations;
using C=CP.Entities.Model;
using CP.ServiceLayer.DTO;
using CP.WebUI.Models;
using CP.WebUI.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CP.WebUI.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        [Route("Giriş Yap")]
        [AllowAnonymous]
        public ActionResult Logon()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(new LoginControl());
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public void LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
        }

        [HttpGet]
        [ChildActionOnly]
        [AcceptVerbs(HttpVerbs.Get)]
        [Route("Register")]
        [AllowAnonymous]
        public PartialViewResult Register()
        {
            return PartialView("Register",new C.User());
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult RegisterOperation()
        {
            return null;
        }

        [AllowAnonymous]
        public PartialViewResult PasswordForget()
        {
            return PartialView(new PasswordForgetDTO());
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult PasswordOperation(PasswordForgetDTO passwordForgetDTO)
        {
            jsonResultModel.Title = "Şifremi Unuttum";
            if (ModelState.IsValid)
            {
                var result = UserOperations.PasswordForget(passwordForgetDTO.Email);

                if (result.StartsWith("Başarıyla"))
                {
                    jsonResultModel.Icon = "success";
                }
                else
                    jsonResultModel.Icon = "error";

                jsonResultModel.Description = result ?? "Bir hata meydana geldi";

            }
            else
            {
                jsonResultModel.Description = "Lütfen formu eksiksiz doğrulayın";
                jsonResultModel.Icon = "error";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult LogonOperation(LoginControl loginControl)
        {
            jsonResultModel.Title = "Giriş İşlemi";

            if (ModelState.IsValid)
            {
                var _result = UserOperations.Login(loginControl).Result;

                if (_result.StartsWith("Başarıyla"))
                {
                    Session["FirstAndLast"] = UserOperations.UserFirstAndLast(loginControl.UserName);

                    jsonResultModel.Icon = "success";
                    jsonResultModel.Url = "/Anasayfa";
                    FormsAuthentication.SetAuthCookie(loginControl.UserName, false);
                }
                else
                    jsonResultModel.Icon = "error";

                jsonResultModel.Description = _result ??"Bir hata meydana geldi";
            }
            else
            {
                jsonResultModel.Description = "Lütfen formu eksiksiz doğrulayın";
                jsonResultModel.Icon = "error";
            }
            return Json(jsonResultModel,JsonRequestBehavior.AllowGet);
        }
    }
}