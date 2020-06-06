using CP.BusinessLayer.Operations;
using CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/Table")]
    public class TableController : BaseApiController
    {
        List<TableDTO> tables = new List<TableDTO>();

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public IHttpActionResult GetTables()
        {
            foreach (var table in TableOperation.GetTables())
            {
                var _table = mapper.Map<Table, TableDTO>(table);
                tables.Add(_table);
            }
            return Ok(tables);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Get/{id}")]
        public IHttpActionResult GetFind(int id)
        {
            var _table = TableOperation.GetTable(id);
            var _tableDTO = mapper.Map<Table, TableDTO>(_table);

            return Ok(_tableDTO);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Add")]
        public HttpResponseMessage Post([FromBody]Table table)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama başarısız");
            }
            else
            {
                var _result = TableOperation.TableAdd(table);
                if (_result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Masa Başarıyla Eklendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Masa Ekleme Başarısız");
                }
            }
            return httpResponseMessage;
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("Update")]
        public HttpResponseMessage Put([FromBody]Table table)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama başarısız");
            }
            else
            {
                var _result = TableOperation.TableUpdate(table);
                if (_result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Masa Başarıyla Güncellendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Masa Güncelleme Başarısız");
                }
            }
            return httpResponseMessage;
        }

        [HttpDelete]
        [Route("Remove/{id}")]
        public HttpResponseMessage Remove(int id)
        {
            var _result = TableOperation.TableRemove(id);
            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Masa Başarıyla Silindi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Masa Silme Başarısız");
            }
            return httpResponseMessage;
        }

        [HttpGet]
        [Route("IsConfirm/{TableId}/{UserId}")]
        public HttpResponseMessage IsConfirm(int TableId, int UserId)
        {
            var _Table = TableOperation.GetTable(TableId);

            _Table.ConfirmId = 3;
            _Table.UserId = UserId;

            var _result = TableOperation.TableUpdate(_Table);

            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Başarıyla İstekde Bulunuldu");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "İstekte Bulunma Başarısız");
            }
            return httpResponseMessage;

        }
    }
}
