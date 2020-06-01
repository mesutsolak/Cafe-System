namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product : BaseEntity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Cart = new HashSet<Cart>();
            Comment = new HashSet<Comment>();
            Rate = new HashSet<Rate>();

            Views = 0;

            Preference = false;
            Choose = false;
        }

        [Required(ErrorMessage = "Ürün adý boþ býrakýlamaz.")]
        [StringLength(75)]
        [Display(Name = "Adý")]
        [RegularExpression(@"^[a-zA-ZçÇIiðÐþÞüÜöÖ]*$", ErrorMessage = "Ürün adý sadece harflerden oluþmalýdýr.")]
        public string Name { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori boþ býrakýlamaz")]
        public int? CategoryId { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Ürün detayý boþ býrakýlamaz")]
        [Display(Name = "Ürün Detayý")]
        public string ProductDetail { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Ürün fiyatý boþ býrakýlamaz")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Ürün fiyatý sadece rakamlardan oluþmalýdýr")]
        public int? Price { get; set; }
        [Display(Name = "Miktar")]
        [Required(ErrorMessage = "Ürün miktarý boþ býrakýlamaz")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = " Ürün fiyatý sadece rakamlardan oluþmalýdýr")]
        public int? Amount { get; set; }

        public int? Views { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Ürün Resmi")]
        public string Image { get; set; }

        public bool IsDeleted { get; set; }
        [Display(Name = "Zaman")]
        [Required(ErrorMessage = "Ürün zamaný boþ býrakýlamaz")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = " Ürün zamaný sadece rakamlardan oluþmalýdýr")]

        public int Time { get; set; }

        public DateTime? AddedDate { get; set; }

        [Display(Name = "Tercih")]
        [Required(ErrorMessage ="Lütfen belli ediniz")]
        public bool? Preference { get; set; }
        [Display(Name = "Kafe")]
        [Required(ErrorMessage = "Lütfen belli ediniz")]
        public bool? Choose { get; set; }

        [NotMapped]
        [Display(Name = "Ürün Resmi")]

        public HttpPostedFileBase Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rate { get; set; }
    }
}
