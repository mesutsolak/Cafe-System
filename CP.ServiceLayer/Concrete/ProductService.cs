using CP.ServiceLayer.Abstract;
using CP.ServiceLayer.Concrete.Basic;
using CP.ServiceLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete
{
    public class ProductService : Service<ProductDTO>, IProductService
    {
        List<ProductDTO> entities;
        public List<ProductDTO> GetFilterAll(int CategoryId)
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var _result = Task.Run(() => client.GetStringAsync(Url + CategoryId)).Result;

            entities = JsonConvert.DeserializeObject<List<ProductDTO>>(_result, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return entities;
        }

        public string ProductCount()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var _result = Task.Run(() => client.GetAsync(Url)).Result;
            return _result.Headers.GetValues("Message").Single();
        }

        public string ViewsAdd()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var _result = Task.Run(() => client.GetAsync(Url)).Result;
            return _result.Headers.GetValues("Message").Single();
        }
    }
}
