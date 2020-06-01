using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/HomePage")]
    public class HomePageController : BaseApiController
    {
        [Route("GetAll")]
        public HomePageDTO GetHomePage()
        {
           return mapper.Map<HomePage,HomePageDTO>(HomePageOperation.DefaultHomePage());
        }
    }
}
