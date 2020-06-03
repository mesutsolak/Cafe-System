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
    [AccessDeniedAuthorize(Roles = "Customer,Employee")]
    public class TableController : BaseController
    {
        // GET: Table
        [Route("Masalar")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("MasaList")]
        public PartialViewResult TableList()
        {
            return PartialView(TableOperation.GetTables());
        }
        [Route("MasaEkle")]
        public PartialViewResult TableAdd()
        {
            return PartialView(new Table());
        }
        [Route("MasaGüncelle")]
        public PartialViewResult TableUpdate(int id)
        {
            return PartialView(TableOperation.GetTable(id));
        }

        [HttpPost]
        public JsonResult TableAddOperation(Table table)
        {
            jsonResultModel.Title = "Rol Ekleme";
            if (ModelState.IsValid)
            {

                if (!TableOperation.TableNumberControl(table.Number.Value))
                {
                    var result = TableOperation.TableAdd(table);

                    if (result > 0)
                    {
                        jsonResultModel.Icon = "success";
                        jsonResultModel.Modal = "TableAddModal";
                        jsonResultModel.Description = "Masa Ekleme Başarılı";

                    }
                    else
                    {
                        jsonResultModel.Icon = "error";
                        jsonResultModel.Description = "Masa Ekleme Başarısız";
                    }
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Masa Numarası Kullanılmış";
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
        public JsonResult TableUpdateOperation(Table table)
        {
            jsonResultModel.Title = "Masa Güncelleme";
            if (ModelState.IsValid)
            {
                if (!TableOperation.TableUpdateContol(table.Number.Value,table.Id))
                {
                    var result = TableOperation.TableUpdate(table);

                    if (result > 0)
                    {
                        jsonResultModel.Icon = "success";
                        jsonResultModel.Modal = "TableUpdateModal";
                        jsonResultModel.Description = "Masa Güncelleme Başarılı";

                    }
                    else
                    {
                        jsonResultModel.Icon = "error";
                        jsonResultModel.Description = "Masa Güncelleme Başarısız";
                    }
                }
                else
                {
                    jsonResultModel.Icon = "error";
                    jsonResultModel.Description = "Masa Numarası Kullanılmış";
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
        [Route("RemoveTable")]
        public JsonResult RemoveRole(int id)
        {
            int _id = TableOperation.TableRemove(id);

            if (_id > 0)
            {
                jsonResultModel.Icon = "success";
                jsonResultModel.Description = "Başarıyla Silindi";
            }
            else
            {
                jsonResultModel.Icon = "error";
                jsonResultModel.Description = "Masa Silme Başarısız";
            }

            return Json(jsonResultModel, JsonRequestBehavior.AllowGet);
        }
    }
}