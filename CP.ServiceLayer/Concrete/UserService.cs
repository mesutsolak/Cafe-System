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
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete
{
    public class UserService : Service<User>, IUserService
    {

        public async Task<string> LoginControl(User user)
        {

            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync<User>(Url, user);
                    response.Wait();

                    var result = response.Result;



                    IEnumerable<string> headerValues = result.Headers.GetValues("Message");

                    ResponseMessage = headerValues.FirstOrDefault().ToString();

                });
            }
            catch (Exception ex)
            {
                ResponseMessage = "Gönderirken Hata Meydana Geldi";

                throw ex;
            }

            return ResponseMessage;


        }
    }
}
