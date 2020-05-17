using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Tools;
using CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<CartDTO> ct = new List<CartDTO>();

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Post([FromBody]CartDTO cart)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama başarısız");
            }
            else
            {
                int result = 0;

                var _value = mapper.Map<CartDTO, Cart>(cart);

                var product = CartOperation.IsThereProduct(_value.ProductId.Value, _value.UserId.Value);

                if (product.IsNullObject())
                {
                    result = CartOperation.CartAdd(_value);
                }
                else
                {
                    product.Count += product.Count + _value.Count;
                    product.Price += product.Price + _value.Price;
                    product.Time += product.Time + _value.Time;

                    result = CartOperation.CartUpdate(product);
                }


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
        [Route("Count/{UserId}")]
        public HttpResponseMessage CartCount(int UserId)
        {
            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            httpResponseMessage.Headers.Add("Message", CartOperation.CartCount(UserId).ToString());

            return httpResponseMessage;
        }

        [HttpGet]
        [Route("List/{UserId}")]
        public List<CartDTO> Get(int UserId)
        {
            var _carts = CartOperation.GetAll(UserId);


            foreach (var item in _carts)
            {
                var _product = mapper.Map<Product, ProductDTO>(item.Product);
                var _cart = mapper.Map<Cart, CartDTO>(item);
                _cart.productDTO = _product;

                ct.Add(_cart);
            }

            return ct;
        }
        [HttpGet]
        [Route("Find/{id}")]
        public HttpResponseMessage GetFind(int id)
        {
            var _cart = CartOperation.CartFind(id);

            if (_cart.IsNullObject())
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Ürün Bulunamadı");
            }
            else
            {
                var _productDTO = mapper.Map<Product, ProductDTO>(_cart.Product);
                var _cartDTO = mapper.Map<Cart, CartDTO>(_cart);
                _cartDTO.productDTO = _productDTO;

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(_cartDTO);


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

                var result = CartOperation.CartUpdate(cart);
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

        [HttpGet]
        [Route("OrderAll/{id}")]
        public List<CartDTO> OrderGetAll(int id)
        {
            ct.Clear();

            var _carts = CartOperation.GetAllOrder(id);


            foreach (var item in _carts)
            {
                var _product = mapper.Map<Product, ProductDTO>(item.Product);
                var _cart = mapper.Map<Cart, CartDTO>(item);
                _cart.productDTO = _product;

                ct.Add(_cart);
            }

            return ct;
        }

        [HttpGet]
        [Route("OrderCount/{id}")]
        public HttpResponseMessage OrderCount(int id)
        {
            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            httpResponseMessage.Headers.Add("Message", CartOperation.GetAllOrder(id).Count.ToString());

            return httpResponseMessage;
        }
    }
}
            