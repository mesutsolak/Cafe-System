using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string ProductDetail { get; set; }
        public int? Price { get; set; }
        public int? Amount { get; set; }
        public int? Views { get; set; }
        public int? Rating { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public int? Time { get; set; }
    }
}
