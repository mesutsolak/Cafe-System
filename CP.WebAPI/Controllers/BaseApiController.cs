using AutoMapper;
using M=CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace CP.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
        public IMapper mapper;

        public BaseApiController()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, M.Category>();
                cfg.CreateMap<M.Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, M.Product>();
                cfg.CreateMap<M.Category, Category>();
                cfg.CreateMap<CartDTO, M.Cart>();
                cfg.CreateMap<M.Cart, CartDTO>();
                cfg.CreateMap<M.Table, TableDTO>();
                cfg.CreateMap<TableDTO, M.Table>();
                cfg.CreateMap<M.HomePage, HomePageDTO>();
                cfg.CreateMap<HomePageDTO, M.HomePage>();

            }).CreateMapper();
        }
    }
}
