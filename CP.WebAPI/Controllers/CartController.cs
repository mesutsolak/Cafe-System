using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Tools;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/Cart")]
    public class CartController : BaseApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Cart cart)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama başarısız");
            }
            else
            {
                var result = await CartOperation.CartAdd(cart);
                if (result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Ürün Başarıyla Eklendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Ürün Ekleme Başarısız");
                }
            }
            return httpResponseMessage;
        }
        [HttpGet]
        public async Task<List<Cart>> Get(int UserId)
        {
            return await CartOperation.GetAllAsync(UserId);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetFind(int id)
        {
            var _product = await CartOperation.GetFindCart(id);
            if (_product.IsNullObject())
            {
                httpResponseMessage.StatusCode = HttpStatusCode.NotFound;
                httpResponseMessage.Headers.Add("Message", "Ürün Bulunamadı");
            }
            else
            {
                var json = new JavaScriptSerializer().Serialize(_product);

                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", json);
            }
            return httpResponseMessage;
        }

        [AllowAnonymous]
        [HttpPut]
        [ResponseType(typeof(HttpResponseMessage))]
        public async Task<HttpResponseMessage> Put([FromBody]Cart cart)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama başarısız");
            }
            else
            {
                var result = await CartOperation.CartAdd(cart);
                if (result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Ürün Başarıyla Güncellendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Ürün Güncelleme Başarısız");
                }
            }
            return httpResponseMessage;

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var _result = await CartOperation.CartRemove(id);
            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Ürün Başarıyla Silindi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Ürün Silme Başarısız");
            }
            return httpResponseMessage;
        }
    }
}
