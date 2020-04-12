namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? TableId { get; set; }

        public int? ProductId { get; set; }

        public int? Amount { get; set; }

        public int? TotalPrice { get; set; }

        public bool? IsComplete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }

        public virtual Product Product { get; set; }

        public virtual Table Table { get; set; }

        public virtual User User { get; set; }
    }
}
