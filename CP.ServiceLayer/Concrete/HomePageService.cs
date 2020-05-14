using CP.ServiceLayer.Abstract;
using CP.ServiceLayer.Concrete.Basic;
using CP.ServiceLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete
{
    public class HomePageService : Service<HomePageDTO>, IHomePageService
    {
        public HomePageDTO GetHome()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var _result = Task.Run(()=> client.GetStringAsync(Url)).Result;

            return JsonConvert.DeserializeObject<HomePageDTO>(_result, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}                                                    
