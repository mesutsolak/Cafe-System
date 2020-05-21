using CP.BusinessLayer.Operations;
using M = CP.Entities.Model;
using S = CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CP.Entities.Model;
using CP.ServiceLayer.DTO;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/MusicList")]
    public class MusicListController : BaseApiController
    {
        List<MusicListDTO> _musicList = new List<MusicListDTO>();

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Post([FromBody]S.MusicListDTO musicList)
        {
            var _musicDTO = mapper.Map<S.MusicListDTO, M.MusicList>(musicList);

            int _result = MusicListOperation.MusicAdd(_musicDTO);
            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Müzik Başarıyla Eklendi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Müzik Ekleme Başarısız");

            }
            return httpResponseMessage;
        }

        [HttpPut]
        [Route("Put")]
        public HttpResponseMessage Put([FromBody]S.MusicListDTO musicList)
        {

            var _musicDTO = mapper.Map<S.MusicListDTO, M.MusicList>(musicList);

            int _result = MusicListOperation.MusicUpdate(_musicDTO);

            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Müzik Başarıyla Güncellendi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Müzik Güncelleme Başarısız");

            }
            return httpResponseMessage;
        }

        [HttpDelete]
        [Route("Remove/{id:int}")]
        public HttpResponseMessage Remove(int id)
        {
            int _result = MusicListOperation.MusicRemove(id);
            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Müzik Başarıyla Silindi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Müzik Silme Başarısız");

            }
            return httpResponseMessage;
        }

        [HttpGet]
        [Route("MusicListFind/{MusicId:int}")]
        public S.MusicListDTO MusicListFind(int MusicId)
        {
            var _musicList = MusicListOperation.MusicListFind(MusicId);
            var _user = mapper.Map<M.User, S.User>(_musicList.User);
            var _musicListDTO = mapper.Map<MusicList, S.MusicListDTO>(_musicList);
            _musicListDTO.User = _user;

            return _musicListDTO;
        }

        [HttpGet]
        [Route("All")]
        public List<MusicListDTO> GetMusicLists()
        {
            _musicList.Clear();

            foreach (var musiclist in MusicListOperation.GetMusicLists())
            {
                var _user = mapper.Map<M.User, S.User>(musiclist.User);
                var _musicListDTO = mapper.Map<MusicList, S.MusicListDTO>(musiclist);

                _musicList.Add(_musicListDTO);
            }

            return _musicList;
        }

        [HttpGet]
        [Route("MusicList/{UserId:int}")]
        public List<MusicListDTO> GetMusicLists(int UserId)
        {
            _musicList.Clear();

            foreach (var musiclist in MusicListOperation.GetMusicLists(UserId))
            {
                var _user = mapper.Map<M.User, S.User>(musiclist.User);
                var _musicListDTO = mapper.Map<MusicList, S.MusicListDTO>(musiclist);

                _musicList.Add(_musicListDTO);
            }

            return _musicList;
        }


        [HttpGet]
        [Route("IsConfirm/{MusicId:int}")]
        public HttpResponseMessage IsConfirm(int MusicId)
        {
            var _music = MusicListOperation.MusicListFind(MusicId);
            _music.ConfirmId = 3;
            int _result = MusicListOperation.MusicUpdate(_music);

            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Başarıyla Onaylandı");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Onaylama Başarısız");
            }

            return httpResponseMessage;
        }

        [HttpGet]
        [Route("IsConfirmAll/{UserId:int}")]
        public HttpResponseMessage IsConfirmAll(int UserId)
        {
            MusicListOperation.ConfirmAll(UserId);

            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            httpResponseMessage.Headers.Add("Message", "Müzikler Başarıyla Onaylandı");


            return httpResponseMessage;
        }


        [HttpGet]
        [Route("IsRemoveAll/{UserId:int}")]
        public HttpResponseMessage IsRemoveAll(int UserId)
        {
            MusicListOperation.RemoveAll(UserId);

            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            httpResponseMessage.Headers.Add("Message", "Müzikler Başarıyla Silindi");

            return httpResponseMessage;
        }

        [HttpGet]
        [Route("History/{UserId:int}")]
        public List<MusicListDTO> GetHistory(int UserId)
        {
            _musicList.Clear();

            foreach (var musiclist in MusicListOperation.GetHistoryList(UserId))
            {
                var _user = mapper.Map<M.User, S.User>(musiclist.User);
                var _musicListDTO = mapper.Map<MusicList, S.MusicListDTO>(musiclist);

                _musicList.Add(_musicListDTO);
            }

            return _musicList;
        } 

    }
}
