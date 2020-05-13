using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class CartDTO
    {
        public CartDTO()
        {
            IsComplete = false;
            AddedDate = DateTime.Now;
        }
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        public int? Count { get; set; }

        public int? Time { get; set; }

        public int? Price { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        public int? TableId { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? ConfirmId { get; set; }

        public bool? IsComplete { get; set; }

        public ProductDTO productDTO { get; set; }
    }
}
