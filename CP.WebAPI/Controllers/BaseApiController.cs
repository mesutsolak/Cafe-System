using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CP.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
    }
}
