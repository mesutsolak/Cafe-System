using AutoMapper;
using M = CP.Entities.Model;
using CP.ServiceLayer.DTO;
using C = CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using CP.Entities.Model;

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
                cfg.CreateMap<C.Category, M.Category>();
                cfg.CreateMap<M.Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, M.Product>();
                cfg.CreateMap<M.Category, C.Category>();
                cfg.CreateMap<CartDTO, M.Cart>();
                cfg.CreateMap<M.Cart, CartDTO>();
                cfg.CreateMap<M.Table, TableDTO>();
                cfg.CreateMap<TableDTO, M.Table>();
                cfg.CreateMap<M.HomePage, HomePageDTO>();
                cfg.CreateMap<HomePageDTO, M.HomePage>();
                cfg.CreateMap<M.Slider, SliderDTO>();
                cfg.CreateMap<SliderDTO, M.Slider>();
                cfg.CreateMap<M.Comment, CommentDTO>();
                cfg.CreateMap<CommentDTO, M.Comment>();
                cfg.CreateMap<M.User, C.User>();
                cfg.CreateMap<C.User, M.User>();
                cfg.CreateMap<M.Rate, RateDTO>();
                cfg.CreateMap<RateDTO, M.Rate>();
                cfg.CreateMap<M.Campaign, CampaignDTO>();
                cfg.CreateMap<CampaignDTO, M.Campaign>();
                cfg.CreateMap<CompanyInformation, CompanyDTO>();
                cfg.CreateMap<CompanyDTO, CompanyInformation>();
                cfg.CreateMap<Contact, C.ContactDTO>();
                cfg.CreateMap<ContactDTO, Contact>();
                cfg.CreateMap<MusicList, MusicListDTO>();
                cfg.CreateMap<MusicListDTO, MusicList>();
                cfg.CreateMap<Gender, GenderDTO>();
                cfg.CreateMap<GenderDTO, Gender>();
            }).CreateMapper();
        }
    }
}
