using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CP.WebAPI.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await ProductOperation.GetProductsAsync();
        }
    }
}
