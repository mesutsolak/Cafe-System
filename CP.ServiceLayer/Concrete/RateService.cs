using CP.ServiceLayer.Abstract;
using CP.ServiceLayer.Concrete.Basic;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete
{
    public class RateService : Service<RateDTO>, IRateService
    {
        public int ProductRate()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var _result = Task.Run(() => client.GetAsync(Url)).Result;

            return int.Parse(_result.Headers.GetValues("Message").FirstOrDefault());
        }
    }
}
