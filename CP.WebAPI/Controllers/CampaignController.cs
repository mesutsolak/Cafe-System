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
    [RoutePrefix("api/Campaign")]
    public class CampaignController : BaseApiController
    {
        List<CampaignDTO> _campaignDTO = new List<CampaignDTO>();

        [HttpGet]
        [Route("All")]
        public List<CampaignDTO> OrderGetAll(int id)
        {
            _campaignDTO.Clear();

            foreach (var campaign in CampaignOperation.GetListCampaigns())
                _campaignDTO.Add(mapper.Map<Campaign, CampaignDTO>(campaign));

            return _campaignDTO;
        }
    }
}
