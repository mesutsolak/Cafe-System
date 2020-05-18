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
        public int GetRate(int UserId, int ProductId)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = Task.Run(() => client.GetAsync(Url + UserId + "/" + ProductId)).Result;


            return int.Parse(response.Headers.GetValues("Message").FirstOrDefault());

        }
    }
}
