using CP.ServiceLayer.Abstract.Basic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete.Basic
{
    public class Service<T> : IService<T> where T : class, new()
    {
        public string Url { get; set; }

        string ResponseMessage;


        HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44318/")
        };

        public async Task<string> AddAsync(T entity)
        {
            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var response = await client.PostAsJsonAsync(Url, entity);

                    if (response.IsSuccessStatusCode)
                    {
                        ResponseMessage = "Başarıyla İşleminiz Gerçekleşti";
                    }
                    else
                    {
                        ResponseMessage = "İşleminiz Başarısız Oldu";
                    }

                });
            }
            catch (Exception ex)
            {
                ResponseMessage = "Gönderirken Hata Meydana Geldi";

                throw ex;
            }

            return ResponseMessage;
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> users = null;
            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var _result = await client.GetStringAsync(Url);
                    users = JsonConvert.DeserializeObject<List<T>>(_result);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }

        public async Task<T> GetFindAsync(int id)
        {
            T user = null;
            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var _result = await client.GetStringAsync(Url + id);
                    user = JsonConvert.DeserializeObject<T>(_result);

                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public async Task<string> RemoveAsync(int id)
        {
            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.DeleteAsync(Url + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        ResponseMessage = "Başarıyla İşleminiz Gerçekleşti";
                    }
                    else
                    {
                        ResponseMessage = "İşleminiz Başarısız Oldu";
                    }

                });
            }
            catch (Exception ex)
            {
                ResponseMessage = "Gönderirken Hata Meydana Geldi";

                throw ex;
            }

            return ResponseMessage;
        }

        public async Task<string> UpdateAsync(T entity)
        {
            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var response = await client.PutAsJsonAsync(Url, entity);

                    if (response.IsSuccessStatusCode)
                    {
                        ResponseMessage = "Başarıyla İşleminiz Gerçekleşti";
                    }
                    else
                    {
                        ResponseMessage = "İşleminiz Başarısız Oldu";
                    }
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
