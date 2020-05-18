using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class CampProductDTO
    {
        public CampProductDTO()
        {
            IsShow = false;
        }

        public int Id { get; set; }

        public int? CampaignId { get; set; }

        public int? ProductId { get; set; }
        public bool? IsShow { get; set; }

        public virtual CampaignDTO Campaign { get; set; }

        public virtual ProductDTO Product { get; set; }
    }
}
