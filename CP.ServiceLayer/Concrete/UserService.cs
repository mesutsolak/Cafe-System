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
        bool Status;

        public bool IsThereEmail()
        {
            var u = Url;
            try
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = Task.Run(() => client.GetAsync(u)).Result;

                Status = (response.StatusCode == System.Net.HttpStatusCode.OK) ? false : true;

            }
            catch (Exception ex)
            {
                Status = false;
                throw ex;
            }
            return Status;
        }

        public bool IsThereUserName(string UserName)
        {
            var u = Url;
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = Task.Run(() => client.GetAsync(u)).Result;

                Status = (response.StatusCode == System.Net.HttpStatusCode.OK) ? false : true;
            }
            catch (Exception ex)
            {
                Status = false;
                throw ex;
            }
            return Status;
        }


        public async Task<string> LoginControl(LoginControl loginControl)
        {
            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync(Url, loginControl);
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
        public int UserId(string UserName)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = Task.Run(() => client.GetAsync(Url + UserName)).Result;

            if (response.IsSuccessStatusCode)
            {
                _Result = int.Parse(response.Headers.GetValues("Message").FirstOrDefault().ToString());
            }
            else
            {
                _Result = 0;
            }
            return _Result;
        }
        public string PasswordFind(string Email)
        {

            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = Task.Run(() => client.GetAsync(Url + Email)).Result;

                return response.Headers.GetValues("Message").FirstOrDefault().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
