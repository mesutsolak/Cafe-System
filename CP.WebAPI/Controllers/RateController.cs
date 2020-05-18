using CP.BusinessLayer.Operations;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using M = CP.Entities.Model;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/Rate")]
    public class RateController : BaseApiController
    {
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]RateDTO rate)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama Başarısız");
            }
            else
            {
                var _product = mapper.Map<ProductDTO, M.Product>(rate.Product);
                var _user = mapper.Map<User, M.User>(rate.User);
                var _rate = mapper.Map<RateDTO, M.Rate>(rate);

                _rate.Product = _product;
                _rate.User = _user;

                var _result = RateOperation.RateAdd(_rate);
                if (_result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Oran Başarıyla Eklendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Oran Ekleme Başarısız");
                }
            }


            return httpResponseMessage;
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]RateDTO rate)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama Başarısız");
            }
            else
            {
                var _product = mapper.Map<ProductDTO, M.Product>(rate.Product);
                var _user = mapper.Map<User, M.User>(rate.User);
                var _rate = mapper.Map<RateDTO, M.Rate>(rate);

                _rate.Product = _product;
                _rate.User = _user;

                var _result = RateOperation.RateUpdate(_rate);
                if (_result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Oran Başarıyla Güncellendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Oran Güncelleme Başarısız");
                }
            }
            return httpResponseMessage;
        }

        [Route("Remove/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage Remove(int id)
        {
            var _result = RateOperation.RateRemove(id);
            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Oran Başarıyla Silindi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Oran Silme Başarısız");
            }
            return httpResponseMessage;
        }

        [Route("Find/{UserId:int}")]
        [HttpGet]
        public RateDTO GetRate(int UserId)
        {
            var _rate = RateOperation.RateFind(UserId);
            var _UserDTO = mapper.Map<M.User, User>(_rate.User);
            var _ProductDTO = mapper.Map<M.Product, ProductDTO>(_rate.Product);
            var _rateDTO = mapper.Map<M.Rate, RateDTO>(_rate);
            _rateDTO.Product = _ProductDTO;
            _rateDTO.User = _UserDTO;
            return _rateDTO;
        }

        [Route("ProductRate/{ProductId:int}")]
        [HttpGet]
        public HttpResponseMessage ProductRate(int ProductId)
        {
            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            httpResponseMessage.Headers.Add("Message", RateOperation.RateProduct(ProductId).ToString());
            return httpResponseMessage;
        }

    }
}
