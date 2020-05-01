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
    public class HomeController : BaseController
    {
        // GET: Home
        [Route("Anasayfa")]
        [AccessDeniedAuthorize(Roles = "Customer,Employee")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Ürünler")]
        [AccessDeniedAuthorize(Roles = "Customer,Admin")]
        public ActionResult Products()
        {
            return View(ProductOperation.GetUsers(x => x.Category));
        }
        [Route("Kategoriler")]
        public ActionResult Categories()
        {
            return View();
        }
        [Route("ProductList")]
        public PartialViewResult ProductList()
        {
            return PartialView(ProductOperation.GetUsers(x => x.Category));
        }

        [Route("ProductUpdate")]
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult ProductUpdate(int id)
        {
            var product = ProductOperation.ProductFind(id);

            if (product.Image!=null)
            {             
                   var productName = product.Image.Substring(124, product.Image.Length-124).Split('?');
                ViewBag.ProductName = productName[0];
            }
           

            SelectListItems.Clear();

            foreach (var item in CategoryOperation.GetCategories())
            {
                if (product.CategoryId == item.Id)
                {
                    SelectListItems.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected=true
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

            TempData["Categories"] = SelectListItems;

            return PartialView(product);
        }  

        [HttpPost]
        public async Task<JsonResult> ProductUpdateOperation(Product product)
        {
            if (ModelState.IsValid)
            {
                if (!product.Images.IsNullObject() && product.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(product.Images.FileName);
                    product.Image = await firebaseStorageHelper.UploadFile(product.Images.InputStream, ImageName, "Product");
                }

                int id = ProductOperation.ProductUpdate(product);

                if (id > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Description = "Ürün Başarıyla Güncellendi";
                    jsonResultModel.Modal = "ProductUpdateModal";
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Ürün Güncelleme Başarısız";
                }
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Lütfen eksiksiz doldurun";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }

        [Route("ProductAdd")]
        public PartialViewResult ProductAdd()
        {
            SelectListItems.Clear();

            foreach (var item in CategoryOperation.GetCategories())
            {
                SelectListItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            TempData["Categories"] = SelectListItems;

            return PartialView(new Product());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ProductAddOperation(Product product)
        {
            if (ModelState.IsValid)
            {
                if (!product.Images.IsNullObject() && product.Images.ContentLength > 0)
                {
                    var ImageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(product.Images.FileName);
                    product.Image = await firebaseStorageHelper.UploadFile(product.Images.InputStream, ImageName, "Product");
                }

                int id = ProductOperation.ProductAdd(product);

                if (id > 0)
                {
                    jsonResultModel.Icon = "success";
                    jsonResultModel.Description = "Ürün Başarıyla Eklendi";
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Ürün Ekleme Başarısız";
                }
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Lütfen eksiksiz doldurun";
            }
            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
    }
}