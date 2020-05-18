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
    [RoutePrefix("api/Company")]
    public class CompanyController : BaseApiController
    {
        [Route("Get")]
        public CompanyDTO GetCompany()
        {
            var _company = CompanyOperation.GetCompanyInformation();
            return mapper.Map<CompanyInformation, CompanyDTO>(_company);
        }
    }
}
