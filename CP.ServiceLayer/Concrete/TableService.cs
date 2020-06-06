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
    public class TableService : Service<TableDTO>, ITableService
    {
        public string IsConfirm(int TableId, int UserId)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = Task.Run(() => client.GetAsync(Url + TableId + "/" + UserId)).Result;


            return response.Headers.GetValues("Message").FirstOrDefault();

        }
    }
}
