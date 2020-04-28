namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CampProduct = new HashSet<CampProduct>();
            Comment = new HashSet<Comment>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ProductDetail { get; set; }

        public int? Price { get; set; }

        public int? Amount { get; set; }

        public int? Views { get; set; }

        public int? Rating { get; set; }

        [Column(TypeName = "text")]
        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public int Time { get; set; }

        [NotMapped]
        public HttpPostedFileBase Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampProduct> CampProduct { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
