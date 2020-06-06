using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class TableDTO
    {
        public TableDTO()
        {
            
        }

        public int Id { get; set; }
        public int? Number { get; set; }
        public int? UserId { get; set; }

        public int? ConfirmId { get; set; }
    }
}
