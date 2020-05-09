using AutoMapper;
using CP.BusinessLayer.Operations;
using M = CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CP.WebAPI.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseApiController
    {
        List<ProductDTO> ProductDTOs = new List<ProductDTO>();

        private MapperConfiguration config;

        public ProductController()
        {
              config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<Category, M.Category>();
                  cfg.CreateMap<M.Product, ProductDTO>();
                  cfg.CreateMap<ProductDTO, M.Product>();
                  cfg.CreateMap<M.Category, Category>();
              });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ProductAll")]
        public IHttpActionResult Get()
        {

            IMapper mapper = config.CreateMapper();

            try
            {
                foreach (var item in ProductOperation.GetProducts())
                {
                    var categoryDTO = mapper.Map<M.Category, Category>(item.Category);
                    var productDTO = mapper.Map<M.Product, ProductDTO>(item);
                    productDTO.Category = categoryDTO;

                    ProductDTOs.Add(productDTO);

                }
                return Ok(ProductDTOs);
            }
            catch (Exception ex)
            {

                //returns 500
                return InternalServerError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            IMapper mapper = config.CreateMapper();

           var item =  ProductOperation.ProductFind(id);

            var categoryDTO = mapper.Map<M.Category, Category>(item.Category);
            var productDTO = mapper.Map<M.Product, ProductDTO>(item);
            productDTO.Category = categoryDTO;

            return Ok(productDTO);
        }
    }
}
