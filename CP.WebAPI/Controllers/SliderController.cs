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
    [RoutePrefix("api/Slider")]
    public class SliderController : BaseApiController
    {
        SliderOperations so = new SliderOperations();

        List<SliderDTO> sliderDTO = new List<SliderDTO>();

        [HttpGet]
        [Route("GetAll")]
        public List<SliderDTO> GetSliders()
        {
            foreach (var slider in so.GetSliders())
            {
                var _slider = mapper.Map<Slider, SliderDTO>(slider);
                sliderDTO.Add(_slider);
            }
            return sliderDTO;
        }
    }
}
