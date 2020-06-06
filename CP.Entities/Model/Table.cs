namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table : BaseEntity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table()
        {
            Cart = new HashSet<Cart>();
            IsDeleted = false;
            ConfirmId = 2;
        }
        [Display(Name="Numara")]
        [Required(ErrorMessage ="Numara Girilmesi Zorunludur")]
        public int? Number { get; set; }

        public int? ConfirmId { get; set; }
        public int? UserId { get; set; }

        public bool? IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        public virtual ConfirmStatus ConfirmStatus { get; set; }
        public virtual User User { get; set; }
    }
}
