namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public Cart()
        {
            IsDelete = false;
        }

        public int Id { get; set; }

        public int? Count { get; set; }

        public int? Time { get; set; }

        public int? Price { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        public int? TableId { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? ConfirmId { get; set; }

        public bool? IsDelete { get; set; }

        public virtual Table Table { get; set; }

        public virtual ConfirmStatus ConfirmStatus { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
