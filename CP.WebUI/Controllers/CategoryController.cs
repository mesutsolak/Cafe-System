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
    public class CategoryController : BaseController
    {

        // GET: Category
        [Route("Kategoriler")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoryAdd()
        {
            return PartialView(new Category());
        }

        [Route("KategoriList")]
        public PartialViewResult CategoryList()
        {
            var categories = CategoryOperation.GetCategories();

            return PartialView(categories);
        }

        [Route("SearchCategory")]
        [HttpPost]
        public JsonResult CategorySearch(string Prefix)
        {
            var item = CategoryOperation.CategorySearch(Prefix);
            return Json(item, JsonRequestBehavior.AllowGet);
        }


        [Route("KategoriUpdate")]
        public PartialViewResult CategoryUpdate(int id)
        {
            var category = CategoryOperation.GetCategory(id);
            if (!category.Image.IsNullString())
            {
                var CategoryName = category.Image.Substring(124, category.Image.Length - 124).Split('?');
                ViewBag.CategoryName = CategoryName[0];
            }
            return PartialView(category);
        }

        [HttpPost]
        public async Task<JsonResult> CategoryAddOperation(Category category)
        {
            jsonResultModel.Title = "Kategori Ekleme";
            if (ModelState.IsValid)
            {
                if (!CategoryOperation.IsThereCategory(category.Name))
                {
                    if (!category.Images.IsNullObject() && category.Images.ContentLength > 0)
                    {
                        var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(category.Images.FileName);
                        category.Image = await firebaseStorageHelper.UploadFile(category.Images.InputStream, ImageName, "category");
                    }

                    var result = CategoryOperation.CategoryAdd(category);

                    if (result > 0)
                    {
                        jsonResultModel.Icon = "success";
                        jsonResultModel.Modal = "CategoryAddModal";
                        jsonResultModel.Description = "Kategori Ekleme Başarılı";
                        jsonResultModel.Function = "CategoryList";
                    }
                    else
                    {
                        jsonResultModel.Icon = "error";
                        jsonResultModel.Description = "Kategori Ekleme Başarısız";
                    }
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kategori adı zaten kullanılmış";
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
        public async Task<JsonResult> CategoryUpdateOperation(Category category)
        {
            if (ModelState.IsValid)
            {
                if (!CategoryOperation.IsThereCategory(category.Name, category.Id))
                {
                    if (!category.Images.IsNullObject() && category.Images.ContentLength > 0)
                    {
                        var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(category.Images.FileName);
                        category.Image = await firebaseStorageHelper.UploadFile(category.Images.InputStream, ImageName, "category");
                    }

                    int id = CategoryOperation.CategoryUpdate(category);

                    if (id > 0)
                    {
                        jsonResultModel.Icon = "success";
                        jsonResultModel.Description = "Kategori Başarıyla Güncellendi";
                        jsonResultModel.Modal = "CategoryUpdateModal";
                    }
                    else
                    {
                        jsonResultModel.Icon = "error";
                        jsonResultModel.Description = "Kategori Güncelleme Başarısız";
                    }
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Kategori adı zaten kullanılmış";
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
        [Route("RemoveCategory")]
        public JsonResult RemoveCategory(int id)
        {
            int _id = CategoryOperation.CategoryRemove(id);

            if (_id > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Silindi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Kategori Silme Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

    }
}