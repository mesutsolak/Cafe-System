using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using CP.ServiceLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CP.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public async Task<int> Post([FromBody]User user)
        {
            return await UserOperations.UserAdd(user);
        }

        [HttpGet]
        [Route("api/User")]
        public async Task<List<User>> Get()
        {
            return await UserOperations.GetUsers();
        }
        [HttpGet]
        public async Task<User> GetFind(int id)
        {
            return await UserOperations.UserFindAsync(id);
        }
        [Route("api/User")]
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
