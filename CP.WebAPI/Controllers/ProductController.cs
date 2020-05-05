using AutoMapper;
using CP.BusinessLayer.Operations;
using M=CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CP.WebAPI.Controllers
{
    [Route("api/Product/")]
    public class ProductController : BaseApiController
    {
        List<ProductDTO> ProductDTOs = new List<ProductDTO>();
        [HttpGet]
        public async Task<List<ProductDTO>> Get()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, M.Category>();
                cfg.CreateMap<M.Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, M.Product>();
                cfg.CreateMap<M.Category, Category>();
            });

            IMapper mapper = config.CreateMapper();

            foreach (var item in await ProductOperation.GetProductsAsync())
            {
                var categoryDTO = mapper.Map<M.Category, Category>(item.Category);
                var productDTO = mapper.Map<M.Product, ProductDTO>(item);
                productDTO.Category = categoryDTO;
              
                ProductDTOs.Add(productDTO);
            }

            return ProductDTOs;
        }
    }
}
