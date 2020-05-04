using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Tools;
using M = CP.Entities.Model;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;

namespace CP.WebAPI.Controllers
{
    [Route("api/User/")]
    public class UserController : BaseApiController
    {
        [HttpPost]
        [Route("api/User/")]
        public async Task<HttpResponseMessage> Post([FromBody]M.User user)
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
        [Route("api/User/Login")]
        public async Task<HttpResponseMessage> Login([FromBody]LoginControl loginControl)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama başarısız");
            }
            else
            {
                var result = await UserOperations.Login(loginControl);

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
        public async Task<List<M.User>> Get()
        {
            return await UserOperations.GetUsersAsync();
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetFind(int id)
        {
            var _user = await UserOperations.UserFindAsync(id);
            if (_user.IsNullObject())
            {
                httpResponseMessage.StatusCode = HttpStatusCode.NotFound;
                httpResponseMessage.Headers.Add("Message", "Kullanıcı Bulunamadı");
            }
            else
            {
                var json = new JavaScriptSerializer().Serialize(_user);

                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", json);
            }
            return httpResponseMessage;
        }
        [HttpGet]
        [Route("api/User/IsThereUserName/{UserName}")]
        public async Task<HttpResponseMessage> IsThereUserName(string UserName)
        {
            var _bool = await UserOperations.UserNameControl(UserName);
            if (_bool)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
            }
            return httpResponseMessage;
        }

        [HttpGet]
        [Route("api/User/IsThereEmail")]
        public async Task<HttpResponseMessage> IsThereEmail(string Email)
        {
            var _bool = await UserOperations.EmailControl(Email);
            if (_bool)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
            }
            return httpResponseMessage;
        }

        [AllowAnonymous]
        [HttpPut]
        [ResponseType(typeof(HttpResponseMessage))]
        public async Task<HttpResponseMessage> Put([FromBody]M.User user)
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
