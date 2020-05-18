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
    [RoutePrefix("api/CampProduct")]
    public class CampProductController : BaseApiController
    {
        List<CampProductDTO> campProducts = new List<CampProductDTO>();

        [Route("GetAll")]
        public List<CampProductDTO> GetCampProducts()
        {
            campProducts.Clear();

            foreach (var campProduct in CampProductOperation.GetCampProducts())
            {
                var _campaignDTO = mapper.Map<Campaign, CampaignDTO>(campProduct.Campaign);
                var _productDTO = mapper.Map<Product, ProductDTO>(campProduct.Product);
                var _campDTO = mapper.Map<CampProduct, CampProductDTO>(campProduct);

                _campDTO.Campaign = _campaignDTO;
                _campDTO.Product = _productDTO;


                campProducts.Add(_campDTO);

            }

            return campProducts;
        }
    }
}
