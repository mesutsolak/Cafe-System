using System;
using System.Collections.Generic;

namespace CP.ServiceLayer.DTO
{
   public partial class ProductDTO
   {
        public ProductDTO()
        {
            AddedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ProductDetail { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int Views { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? AddedDate { get; set; }
        public int Time { get; set; }
        public Category Category { get; set; }

    }

}
