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
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/User/PostCreate")]
        public async Task<int> PostCreate([FromBody]User user)
        {
            return await UserOperations.UserAdd(user);
        }
        [HttpPost]
        [Route("api/User/GetLoginControl")]
        public async  Task<HttpResponseMessage> GetLoginControl([FromBody]User user)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
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
        [ResponseType(typeof(Task))]
        public async Task Put([FromBody]User user)
        {
            await UserOperations.UserUpdate(user);
        }
        [HttpDelete]
        [Route("api/User/{id:int}")]
        public async Task Delete(int id)
        {
            await UserOperations.UserRemove(id);
        }
    }
}
