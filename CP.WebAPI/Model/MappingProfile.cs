using AutoMapper;
using CP.Entities.Model;
using D=CP.ServiceLayer.DTO;
using M = CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.WebAPI.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<D.Category, M.Category>();
                cfg.CreateMap<M.Product, D.ProductDTO>();
                cfg.CreateMap<D.ProductDTO, M.Product>();
                cfg.CreateMap<M.Category, D.Category>();
            });


            IMapper mapper = config.CreateMapper();

        }
    }
}