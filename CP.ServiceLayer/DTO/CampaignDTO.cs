using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class CampaignDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? OldPrice { get; set; }

        public int? NewPrice { get; set; }

        public virtual ICollection<CampProductDTO> CampProduct { get; set; }
    }
}
