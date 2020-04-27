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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(75)]
        [Display(Name ="Adý")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Kategori Adý")]
        public int? CategoryId { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Ürün Detayý")]
        public string ProductDetail { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Ürün Bilgileri")]
        public string Information { get; set; }

        [Display(Name = "Fiyat")]
        public int? Price { get; set; }

        [Display(Name = "Miktar")]
        public int? Amount { get; set; }

        [Display(Name = "Görüntülenme Sayýsý")]

        public int? Views { get; set; }

        [Display(Name = "Puan")]
        public int? Rating { get; set; }

        [NotMapped]
        public HttpPostedFileBase Images  { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Resim")]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampProduct> CampProduct { get; set; }

        public  Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
