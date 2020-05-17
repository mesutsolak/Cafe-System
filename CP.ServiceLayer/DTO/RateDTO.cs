using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class RateDTO
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        public int? RateValue { get; set; }

        public virtual ProductDTO Product { get; set; }

        public virtual User User { get; set; }
    }
}
