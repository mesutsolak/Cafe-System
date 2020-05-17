using CP.BusinessLayer.Operations;
using M = CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/Comment")]
    public class CommentController : BaseApiController
    {
        List<CommentDTO> _comments = new List<CommentDTO>();

        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CommentDTO comment)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama Başarısız");
            }
            else
            {
                var _product = mapper.Map<ProductDTO, M.Product>(comment.Product);
                var _user = mapper.Map<User, M.User>(comment.User);
                var _comment = mapper.Map<CommentDTO, M.Comment>(comment);

                _comment.Product = _product;
                _comment.User = _user;

                var _result = CommentOperation.CommentAdd(_comment);
                if (_result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Yorum Başarıyla Eklendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Yorum Ekleme Başarısız");
                }
            }


            return httpResponseMessage;
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]CommentDTO comment)
        {
            if (!ModelState.IsValid)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Doğrulama Başarısız");
            }
            else
            {
                var _product = mapper.Map<ProductDTO, M.Product>(comment.Product);
                var _user = mapper.Map<User, M.User>(comment.User);
                var _comment = mapper.Map<CommentDTO, M.Comment>(comment);

                _comment.Product = _product;
                _comment.User = _user;
                 
                var _result = CommentOperation.CommentUpdate(_comment);
                if (_result > 0)
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    httpResponseMessage.Headers.Add("Message", "Yorum Başarıyla Güncellendi");
                }
                else
                {
                    httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                    httpResponseMessage.Headers.Add("Message", "Yorum Güncelleme Başarısız");
                }
            }
            return httpResponseMessage;
        }

        [Route("Remove/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage Remove(int id)
        {
            var _result = CommentOperation.CommentRemove(id);
            if (_result > 0)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                httpResponseMessage.Headers.Add("Message", "Yorum Başarıyla Silindi");
            }
            else
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add("Message", "Yorum Silme Başarısız");
            }
            return httpResponseMessage;
        }

        [Route("Find/{CommentId:int}")]
        [HttpGet]
        public CommentDTO GetComment(int CommentId)
        {
            var _comment = CommentOperation.CommentById(CommentId);
            var _UserDTO = mapper.Map<M.User, User>(_comment.User);
            var _ProductDTO = mapper.Map<M.Product, ProductDTO>(_comment.Product);
            var _CommentDTO = mapper.Map<M.Comment, CommentDTO>(_comment);
            _CommentDTO.Product = _ProductDTO;
            _CommentDTO.User = _UserDTO;
            return _CommentDTO;
        }

        [Route("GetAllProduct/{ProductId:int}")]
        [HttpGet]
        public List<CommentDTO> GetAllProduct(int ProductId)
        {
            _comments.Clear();

            var _commentProduct = CommentOperation.CommentProductAll(ProductId);
            foreach (var comment in _commentProduct)
            {
                var _UserDTO = mapper.Map<M.User, User>(comment.User);
                var _ProductDTO = mapper.Map<M.Product, ProductDTO>(comment.Product);
                var _CommentDTO = mapper.Map<M.Comment, CommentDTO>(comment);
                _CommentDTO.Product = _ProductDTO;
                _CommentDTO.User = _UserDTO;

                _comments.Add(_CommentDTO);
            }
            return _comments;
        }

        [Route("GetAllUser/{UserId:int}")]
        [HttpGet]
        public List<CommentDTO> GetAllUser(int UserId)
        {
            _comments.Clear();

            var _commentProduct = CommentOperation.CommentUserAll(UserId);
            foreach (var comment in _commentProduct)
            {
                var _UserDTO = mapper.Map<M.User, User>(comment.User);
                var _ProductDTO = mapper.Map<M.Product, ProductDTO>(comment.Product);
                var _CommentDTO = mapper.Map<M.Comment, CommentDTO>(comment);
                _CommentDTO.Product = _ProductDTO;
                _CommentDTO.User = _UserDTO;

                _comments.Add(_CommentDTO);
            }
            return _comments;
        }


    }
}
