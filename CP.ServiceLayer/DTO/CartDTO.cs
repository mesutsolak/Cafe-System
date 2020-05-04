using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUse { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
    }
}
