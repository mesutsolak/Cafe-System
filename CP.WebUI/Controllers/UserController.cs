using CP.BusinessLayer.Operations;
using C = CP.Entities.Model;
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
using CP.Entities.ViewModel;
using CP.Entities.Model;

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

        [Route("KullanıcıRolleri")]
        public PartialViewResult UserRoles(int id)
        {

            return PartialView();
        }

        [Route("KullanıcıListele")]
        public PartialViewResult UserList()
        {
            return PartialView(UserOperations.GetUsers());
        }

        [Route("UserUpdate")]
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult UserUpdate(int id)
        {
            var user = UserOperations.UserFind(id);
            if (user.ProfilPhoto != null)
            {
                var ProfilName = user.ProfilPhoto.Substring(124, user.ProfilPhoto.Length - 124).Split('?');
                ViewBag.ProfilName = ProfilName[0];
            }

            if (user.BackGroundPhoto != null)
            {
                var BackGroundPhoto = user.BackGroundPhoto.Substring(124, user.ProfilPhoto.Length - 124).Split('?');
                ViewBag.BackGroundPhoto = BackGroundPhoto[0];
            }

            SelectListItems.Clear();

            foreach (var item in GenderOperation.GetGenders())
            {
                if (user.GenderId.Value == item.Id)
                {
                    SelectListItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    SelectListItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    });
                }
            }

            TempData["Gender"] = SelectListItems;

            return PartialView(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public void LogOut()
        {
            FormsAuthentication.SignOut();
            _Cookie.CookieClear("User");
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
                    return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
                }

                if (await UserOperations.EmailControl(user.Email))
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Email alınmış";
                    return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
                }

                if (!user.ProfilPhotos.IsNullObject() && user.ProfilPhotos.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(user.ProfilPhotos.FileName);
                    user.ProfilPhoto = await firebaseStorageHelper.UploadFile(user.ProfilPhotos.InputStream, ImageName, "User");
                }

                if (!user.BackGroundPhotos.IsNullObject() && user.BackGroundPhotos.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(user.BackGroundPhotos.FileName);
                    user.BackGroundPhoto = await firebaseStorageHelper.UploadFile(user.BackGroundPhotos.InputStream, ImageName, "User");
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

            SelectListItems.Clear();

            foreach (var item in GenderOperation.GetGenders())
            {
                SelectListItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            TempData["Gender"] = SelectListItems;

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
            jsonResultModel.Title = "Kullanıcı Güncelle";


            if (ModelState.IsValid)
            {
                if (await UserOperations.UserNameControl(user.Username, user.Id))
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kullanıcı adı alınmış";
                    return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
                }

                if (await UserOperations.EmailControl(user.Email, user.Id))
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Email alınmış";
                    return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
                }

                if (!user.ProfilPhotos.IsNullObject() && user.ProfilPhotos.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(user.ProfilPhotos.FileName);
                    user.ProfilPhoto = await firebaseStorageHelper.UploadFile(user.ProfilPhotos.InputStream, ImageName, "User");
                }

                if (!user.BackGroundPhotos.IsNullObject() && user.BackGroundPhotos.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(user.BackGroundPhotos.FileName);
                    user.BackGroundPhoto = await firebaseStorageHelper.UploadFile(user.BackGroundPhotos.InputStream, ImageName, "User");
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
                var _result = Task.Run(() => UserOperations.Login(loginControl)).Result;

                if (_result.StartsWith("Başarıyla"))
                {

                    _cookieItem.Add("FirstAndLast", UserOperations.UserFirstAndLast(loginControl.UserName));

                    _Cookie.CookieCreateValue("User", _cookieItem);


                    jsonResultModel.Icon = "success";
                    jsonResultModel.Url = "/Anasayfa";
                    FormsAuthentication.SetAuthCookie(loginControl.UserName, false);
                }
                else
                    jsonResultModel.Icon = "error";

                jsonResultModel.Description = _result.Split(',')[0] ?? "Bir hata meydana geldi";
            }
            else
            {
                jsonResultModel.Description = "Lütfen formu eksiksiz doğrulayın";
                jsonResultModel.Icon = "error";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
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
        [Route("OnayKaldırma")]
        [HttpPost]
        public JsonResult ConfirmRemove(int id)
        {
            var _user = UserOperations.UserFind(id);
            _user.IsConfirm = false;
            int _result = Task.Run(() => UserOperations.UserUpdate(_user)).Result;


            if (_result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Onay Kaldırıldı";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Onay Kaldırma Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
        [Route("OnaylaEkle")]
        [HttpPost]
        public JsonResult ConfirmAdd(int id)
        {
            var _user = UserOperations.UserFind(id);
            _user.IsConfirm = true;
            int _result = Task.Run(() => UserOperations.UserUpdate(_user)).Result;


            if (_result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Onay Eklendi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Onay Ekleme Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
        [Route("UserFindRole")]
        [HttpPost]
        public PartialViewResult RoleFind(int UserId)
        {
            RoleListModel _rolemodel = new RoleListModel
            {
                UserId = UserId
            };

            var _user = UserOperations.UserFind(UserId);
            ViewBag.FirstAndLast = _user.FirstName + " " + _user.LastName;

            var _myroles = UserRoleOperation.UserFindRole(UserId);

            foreach (var _role in RoleOperation.GetRoles())
            {
                var _roleFind = _myroles.FirstOrDefault(x => x.RoleId == _role.Id);
                if (_roleFind != null)
                {
                    _rolemodel.Roles.Add(new Role
                    {
                        Id = _roleFind.Id,
                        RoleId = _role.Id,
                        RoleName = _role.Name,
                        Selected = true
                    });
                }
                else
                {
                    _rolemodel.Roles.Add(new Role
                    {
                        RoleId = _role.Id,
                        RoleName = _role.Name
                    });
                }
            }

            return PartialView(_rolemodel);
        }
        [Route("RoleAssignmentOperation")]
        [HttpPost]
        public JsonResult RoleAssignmentOperation(RoleListModel roleListModel)
        {
            int result = 0;
            var _myroles = UserRoleOperation.UserFindRole(roleListModel.UserId);

            foreach (var role in roleListModel.Roles)
            {
                //Eğer role varsa
                if (UserRoleOperation.HasUserRole(roleListModel.UserId, role.RoleId))
                {
                    if (!role.Selected)
                        result += UserRoleOperation.Remove(role.Id);
                }
                //Eğer rol yoksa
                else
                {
                    if (role.Selected)
                        result += UserRoleOperation.UserRoleAdd(new C.UserRoles
                        {
                            RoleId = role.RoleId,
                            UserId = roleListModel.UserId
                        });
                }
            }


            jsonResultModel.Title = "Rol Atama İşlemi";

            if (result > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Rol atama başarıyla gerçekleşti";
                jsonResultModel.Modal = "RoleShowModal";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Rol atama başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
    }
}