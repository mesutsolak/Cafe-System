using CP.ServiceLayer.Abstract;
using CP.ServiceLayer.Concrete.Basic;
using CP.ServiceLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete
{
    public class HomePageService : Service<HomePageDTO>, IHomePageService
    {
        public HomePageDTO GetHome()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var _result = Task.Run(() => client.GetStringAsync(Url)).Result;

            return JsonConvert.DeserializeObject<HomePageDTO>(_result, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            ////client.Timeout = TimeSpan.FromMinutes(60);
            //client.DefaultRequestHeaders.Accept.Clear();
            ////client.DefaultRequestHeaders.ConnectionClose = true; 
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _result = await client.GetStringAsync(Url);

            //return JsonConvert.DeserializeObject<HomePageDTO>(_result, new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //});
        }
        public static HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://192.168.1.106:44318/"),
                Timeout = TimeSpan.FromMinutes(60)
               
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
