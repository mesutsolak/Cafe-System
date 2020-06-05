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
    [RoutePrefix("api/General")]
    public class GeneralController : BaseApiController
    {
        [Route("Get")]
        public GeneralDTO Get()
        {
            return mapper.Map<General, GeneralDTO>(GeneralOperation.FirstRecord());
        }
    }
}
