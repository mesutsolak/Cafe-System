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
    public class CartService : Service<CartDTO>, ICartService
    {
        public List<CartDTO> Carts(int id)
        {
            List<CartDTO> entities = null;

            try
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var _result = Task.Run(() => client.GetStringAsync(Url+id)).Result;

                entities = JsonConvert.DeserializeObject<List<CartDTO>>(_result, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }




            return entities;
        }
    }
}
