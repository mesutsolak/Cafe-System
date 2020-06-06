using CP.BusinessLayer.Operations;
using CP.BusinessLayer.Tools;
using M = CP.Entities.Model;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using C = CP.ServiceLayer.DTO;
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
using System.Web.Routing;
using CP.Entities.Model;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : BaseApiController
    {
        [HttpPost]
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
                if (result > 0)
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
        [Route("Login")]
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
                    httpResponseMessage.Headers.Add("Message", result);
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", result);
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
        [Route("Find/{id:int}")]
        [AllowAnonymous]
        public C.User GetFind(int id)
        {
            var _user = UserOperations.UserFind(id);
            var _gender = mapper.Map<Gender, GenderDTO>(_user.Gender);
            var _userDTO = mapper.Map<M.User, C.User>(_user);
            _userDTO.Gender = _gender;
            return _userDTO;
        }
        [HttpGet]
        [Route("IsThereUserName/{UserName}")]
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
        [Route("IsThereEmail/{Email}")]
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
        [Route("Update")]
        public async Task<HttpResponseMessage> Put([FromBody]C.User user)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama başarısız");
            }
            else
            {
                var _old = UserOperations.UserFind(user.Id);

                var _user = mapper.Map<C.User, M.User>(user);

                _user.ProfilPhoto = _user.ProfilPhoto ?? _old.ProfilPhoto;
                _user.BackGroundPhoto = _user.BackGroundPhoto ?? _old.BackGroundPhoto;
                _user.IsConfirm = _old.IsConfirm;
                _user.IsDeleted = _old.IsDeleted;

                var result = await UserOperations.UserUpdate(_user);
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
        [Route("{id:int}")]
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

        [HttpGet]
        [Route("UserId/{UserName}")]
        public HttpResponseMessage UserId(string UserName)
        {
            int _result = UserOperations.UserFindId(UserName);
            if (_result <= 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Kullanıcı Bulunamadı");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", _result.ToString());
            }
            return httpResponseMessage;
        }
        [HttpGet]
        [Route("PasswordForget/{Email}")]
        public HttpResponseMessage PasswordForget(string Email)
        {
            var _result = UserOperations.PasswordForget(Email);

            if (string.IsNullOrEmpty(_result))
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Bir hata meydana geldi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", _result);
            }
            return httpResponseMessage;
        }
        [HttpGet]
        [Route("UserNameControl/{UserName}/{id:int}")]
        public async Task<HttpResponseMessage> UserNameControl(string UserName,int id)
        {

            var _bool = await UserOperations.UserNameControl(UserName,id);
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
        [Route("EmailControl/{Email}/{id:int}")]
        public async Task<HttpResponseMessage> EmailControl(string Email, int id)
        {

            var _bool = await UserOperations.EmailControl(Email, id);
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


    }
}
