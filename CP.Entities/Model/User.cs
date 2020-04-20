namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comment = new HashSet<Comment>();
            Order = new HashSet<Order>();
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage ="Kullanýcý Adý Gerekli")]
        public string Username { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string FirstName { get; set; }

        public string Password { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }
        public byte[] Photo { get; set; }

        public bool? IsConfirm { get; set; } = false;
        public bool Status { get; set; } = true;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
