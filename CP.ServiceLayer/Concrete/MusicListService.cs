using CP.ServiceLayer.Abstract;
using CP.ServiceLayer.Concrete.Basic;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete
{
    public class MusicListService : Service<MusicListDTO>, IMusicListService
    {
        public string IsConfirm(int MusicId)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Task.Run(() => client.GetAsync("api/MusicList/IsConfirm/" + MusicId)).Result;
            return response.Headers.GetValues("Message").FirstOrDefault();
        }
    }
}
