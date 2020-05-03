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
using System.Threading.Tasks;
using CP.BusinessLayer.Tools;
using System.IO;

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

        [Route("KullanıcıListele")]
        public PartialViewResult UserList()
        {
            return PartialView(UserOperations.GetUsers(x=>x.IsDeleted==false));
        }

        [Route("UserUpdate")]
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult UserUpdate(int id)
        {
            var user = UserOperations.UserFind(id);
            if (user.Image != null)
            {
                var CategoryName = user.Image.Substring(124, user.Image.Length - 124).Split('?');
                ViewBag.CategoryName = CategoryName[0];
            }

            return PartialView(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public void LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> RegisterOperation(C.User user)
        {
            if (ModelState.IsValid)
            {
                jsonResultModel.Title = "Kayıt ol";

                if (await UserOperations.UserNameControl(user.Username))
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kullanıcı adı alınmış";
                    return Json(jsonResultModel,JsonRequestBehavior.AllowGet);
                }

                if (await UserOperations.EmailControl(user.Email))
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Email alınmış";
                    return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
                }

                if (!user.Images.IsNullObject() && user.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(user.Images.FileName);
                    user.Image = await firebaseStorageHelper.UploadFile(user.Images.InputStream, ImageName, "User");
                }

                int id = await UserOperations.UserAdd(user);

                if (id > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Description = "Kullanıcı Başarıyla Eklendi";
                    jsonResultModel.Modal = "UserAddModal";
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kullanıcı Ekleme Başarısız";
                }
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Lütfen eksiksiz doldurun";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public PartialViewResult Register()
        {
            return PartialView(new C.User());
        }

        [AllowAnonymous]
        public PartialViewResult PasswordForget()
        {
            return PartialView(new PasswordForgetDTO());
        }

        [AllowAnonymous]
        [Route("Kullanıcılar")]
        public ActionResult Users()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UserUpdateOperation(C.User user)
        {
            if (ModelState.IsValid)
            {
                jsonResultModel.Title = "Kullanıcı Güncelle";

                if (await UserOperations.UserNameControl(user.Username))
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kullanıcı adı alınmış";
                    return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
                }

                if (await UserOperations.EmailControl(user.Email))
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Email alınmış";
                    return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
                }

                if (!user.Images.IsNullObject() && user.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(user.Images.FileName);
                    user.Image = await firebaseStorageHelper.UploadFile(user.Images.InputStream, ImageName, "User");
                }

                int id = await UserOperations.UserUpdate(user);

                if (id > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Description = "Kullanıcı Başarıyla Güncellendi";
                    jsonResultModel.Modal = "UserUpdateModal";
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kullanıcı Güncelle Başarısız";
                }
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Lütfen eksiksiz doldurun";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);

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
                    jsonResultModel.Modal = "PasswordModal";
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

        [HttpPost]
        [Route("RemoveUser")]
        public async Task<JsonResult> RemoveUser(int id)
        {
            var _id = await UserOperations.UserRemove(id);

            if (_id > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Silindi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Kullanıcı Silme Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

    }
}