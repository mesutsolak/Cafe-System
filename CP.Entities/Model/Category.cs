namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Kategori Adý")]
        [Required(ErrorMessage = "Kategori adý boþ býrakýlamaz")]
        [MaxLength(75, ErrorMessage = "Kategori adý 75 karakterden fazla olamaz")]
        [RegularExpression("^[a-zA-ZçÇðÐýÝöÖþÞüÜ]*$", ErrorMessage = "Sadece harflerden oluþmalýdýr")]
        public string Name { get; set; }

        [Display(Name = "Kategori Resmi")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Images { get; set; }
    }
}
