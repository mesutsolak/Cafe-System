namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Web.Mvc;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CampProduct = new HashSet<CampProduct>();
            Comment = new HashSet<Comment>();
            Order = new HashSet<Order>();
            IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Ürün Adý")]
        [Required(ErrorMessage ="Ürün adý boþ býrakýlamaz")]
        [MaxLength(75,ErrorMessage ="Ürün adý 75 karakterden fazla olamaz")]
        [RegularExpression("^[a-zA-ZçÇðÐýÝöÖþÞüÜ]*$", ErrorMessage ="Sadece harflerden oluþmalýdýr")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ürün detayý boþ býrakýlamaz")]
        [Display(Name = "Kategori")]

        public int? CategoryId { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Ürün detayý boþ býrakýlamaz")]
        [AllowHtml]
        [Display(Name = "Ürün Detayý")]
        public string ProductDetail { get; set; }

        [Required(ErrorMessage = "Ürün fiyatý boþ býrakýlamaz")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakamdan oluþmalýdýr")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Pozitif bir deðer girmelisiniz")]
        [Display(Name = "Ürün Fiyatý")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "Ürün miktarý boþ býrakýlamaz")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakamdan oluþmalýdýr")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Pozitif bir deðer girmelisiniz")]
        [Display(Name = "Ürün Miktarý")]
        public int? Amount { get; set; }


        [Display(Name = "Görüntülenme Sayýsý")]

        public int? Views { get; set; }

        [Display(Name = "Puan")]

        public int? Rating { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Resim")]
        public string Image { get; set; }

        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "Piþme süresi boþ býrakýlamaz")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakamdan oluþmalýdýr")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Pozitif bir deðer girmelisiniz")]
        [Display(Name = "Piþirme Süresi")]

        public int? Time { get; set; }

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
