using CP.ServiceLayer.Abstract.Basic;
using CP.ServiceLayer.DTO;
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
        public string ResponseMessage { get; set; }
        public int _Result { get; set; }
        public HttpClient client
        {
            get
            {
                return new HttpClient
                {
                    BaseAddress = new Uri("http://192.168.1.106:44318/")
                };
            }
        }

        public string Add(T entity)
        {
            try
            {

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = Task.Run(() => client.PostAsJsonAsync(Url, entity)).Result;

                ResponseMessage = response.Headers.GetValues("Message").FirstOrDefault().ToString();

                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    ResponseMessage = response.Headers.GetValues("Message").FirstOrDefault().ToString();
                }

            }
            catch (Exception ex)
            {
                ResponseMessage = "Gönderirken Hata Meydana Geldi";

                throw ex;
            }

            return ResponseMessage;
        }

        public async Task<string> AddAsync(T entity)
        {
            try
            {

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = await client.PostAsJsonAsync(Url, entity);


                if (response.IsSuccessStatusCode)
                {
                    ResponseMessage = response.Headers.GetValues("Message").FirstOrDefault().ToString();
                }
                else
                {
                    ResponseMessage = "İşleminiz Başarısız Oldu";
                }

            }
            catch (Exception ex)
            {
                ResponseMessage = "Gönderirken Hata Meydana Geldi";

                throw ex;
            }

            return ResponseMessage;
        }


        public List<T> GetAll()
        {
            List<T> entities = null;

            try
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var _result = Task.Run(() => client.GetStringAsync(Url)).Result;

                entities = JsonConvert.DeserializeObject<List<T>>(_result, new JsonSerializerSettings
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

        public T GetFind(int id)
        {
            T entity = null;
            try
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var _result = Task.Run(() => client.GetStringAsync(Url + id)).Result;
                entity = JsonConvert.DeserializeObject<T>(_result, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public async Task<T> GetFindAsync(int id)
        {
            T entity = null;
            try
            {
                await Task.Run(async () =>
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var _result = await client.GetStringAsync(Url + id);
                    entity = JsonConvert.DeserializeObject<T>(_result);

                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
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
