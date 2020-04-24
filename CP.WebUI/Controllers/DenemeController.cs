using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Controllers
{
    public class DenemeController : BaseController
    {
        CafeProjectModel cafe = new CafeProjectModel();
        // GET: Deneme
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void ImageConvertByte(HttpPostedFileBase file2)
        {
            if (file2 != null && file2.ContentLength >0)
            {
                ConverToBytesAsync(file2);
            }
        }
        public  void ConverToBytesAsync(HttpPostedFileBase file)
        {
            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
          

            try
            {
               cafe.User.Add(new User { 
                   Email="oo",
                   IsConfirm=true,
                   FirstName="pooo",
                   LastName="uhhhuh" ,
                            Password="ııı",
                            Username="k",
                 Photo=fileData
               });
            cafe.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}