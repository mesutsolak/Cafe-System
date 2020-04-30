using CP.BusinessLayer.Operations;
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
        [AllowAnonymous]
        public ActionResult Deneme()
        {
            int i = 10;
            if (i==11)
            {
                throw new MyException("Sayı 10 olamaz");
            }
            i = i / 0;
            return View();
        }

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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logon","User");
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