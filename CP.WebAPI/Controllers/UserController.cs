using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using CP.ServiceLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace CP.WebAPI.Controllers
{
    [Route("api/User/")]
    public class UserController : BaseApiController
    {
        [HttpPost]
        [Route("api/User/Post")]
        public async Task<HttpResponseMessage> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulana başarısız");
            }
            else
            {
                var result = await UserOperations.UserAdd(user);
                if (result >0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Kullanıcı Başarıyla Eklendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Kullanıcı Ekleme Başarısız");
                }
            }
            return httpResponseMessage;
        }
        [HttpPost]
        [Route("api/User/GetLoginControl")]
        public async  Task<HttpResponseMessage> GetLoginControl([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulana başarısız");
            }
            else
            {
                var result = await UserOperations.UserControl(user);

                if (result.Contains("Başarıyla"))
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Başarıyla Giriş Yaptınız");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Başarısız");
                }
            }
            return httpResponseMessage;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await UserOperations.GetUsers();
        }
        [HttpGet]
        public async Task<User> GetFind(int id)
        {
            return await UserOperations.UserFindAsync(id);
        }
        [AllowAnonymous]
        [HttpPut]
        [ResponseType(typeof(HttpResponseMessage))]
        public async Task<HttpResponseMessage> Put([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulana başarısız");
            }
            else
            {
                var result = await UserOperations.UserUpdate(user);
                if (result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Kullanıcı Başarıyla Güncellendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Kullanıcı Güncelleme Başarısız");
                }
            }
            return httpResponseMessage;

        }
        [HttpDelete]
        [Route("api/User/{id:int}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
           var _result = await UserOperations.UserRemove(id);
            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Kullanıcı Başarıyla Silindi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Kullanıcı Silme Başarısız");
            }
            return httpResponseMessage;
        }
    }
}
