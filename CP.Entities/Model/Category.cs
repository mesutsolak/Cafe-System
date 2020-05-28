namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Category")]
    public partial class Category : BaseEntity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Product = new HashSet<Product>();
            IsDeleted = false;
        }


        [StringLength(100)]
        [Display(Name = "Kategori Adý")]
        [Required(ErrorMessage = "Kategori adý boþ geçilemez")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Resim")]
        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        [NotMapped]
        public HttpPostedFileBase Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
