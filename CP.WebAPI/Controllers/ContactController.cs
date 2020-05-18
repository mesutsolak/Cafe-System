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
    [RoutePrefix("api/Contact")]
    public class ContactController : BaseApiController
    {
        [Route("Get")]
        public ContactDTO GetContact()
        {
            var _contact = ContactOperation.GetContact();
            return mapper.Map<Contact, ContactDTO>(_contact);
        }
    }
}
