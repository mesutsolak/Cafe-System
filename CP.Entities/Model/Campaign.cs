namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Campaign")]
    public partial class Campaign : BaseEntity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campaign()
        {
            IsDeleted = false;
        }
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        [Display(Name = "Baþlýk")]
        [Required(ErrorMessage ="Baþlýk Girmek Zorunludur")]
        public string Title { get; set; }

        [Display(Name = "Açýklama")]
        [Column(TypeName = "text")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Fiyat Girmek Zorunludur")]
        [Display(Name = "Fiyat")]
        public int Price { get; set; }

        [Display(Name = "Miktar")]
        [Required(ErrorMessage = "Miktar Girmek Zorunludur")]
        public int Amount { get; set; }

        [Display(Name = "Resim")]
        [Column(TypeName = "text")]
        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        [NotMapped]
        public HttpPostedFileBase Images { get; set; }

    }
}
