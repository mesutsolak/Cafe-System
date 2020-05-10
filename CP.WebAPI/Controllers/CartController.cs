﻿using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Tools;
using CP.Entities.Model;
using CP.ServiceLayer.DTO;
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
                int result=0;

                var _value = mapper.Map<CartDTO, Cart>(cart);

                var product = CartOperation.IsThereProduct(_value.ProductId.Value,_value.UserId.Value);

                if (product.IsNullObject())
                {
                    result = CartOperation.CartAdd(_value);
                }
                else
                {
                    product.Count = product.Count + _value.Count;
                    product.Price = product.Price + _value.Price;
                    product.Time = product.Time + _value.Time;

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
        [Route("Confirm/{CartId}")]
        public HttpResponseMessage ConfirmCart(int CartId)
        {
            var result = CartOperation.CartConfirm(CartId);

            if (result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Ürün Onaylandı");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Ürün Onaylanmadı");
            }
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
                var result = await CartOperation.CartUpdateAsync(cart);
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
