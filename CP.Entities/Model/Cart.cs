using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.Model
{
    public class Cart
    {
        public Cart()
        {
            IsConfirm = false;
            IsDeleted = false;
            IsUse = false;
            AddedDate = DateTime.Now;
        }

        public int? Id { get; set; }
        public int? Count { get; set; }
        public int? Time { get; set; }
        public int? Price { get; set; }
        public bool? IsConfirm { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsUse { get; set; }
        public int? ProductId { get; set; }   
        public int? UserId { get; set; }
        public DateTime? AddedDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
