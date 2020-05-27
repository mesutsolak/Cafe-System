namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Slider")]
    public partial class Slider : BaseEntity<int>
    {
        [StringLength(500)]
        [Display(Name = "Resim")]
        public string Image { get; set; }

        [StringLength(25)]
        [Display(Name = "Baþlýk")]
        [Required(ErrorMessage = "Baþlýk boþ býrakýlamaz")]
        public string Title { get; set; }


        [Display(Name = "Açýklama")]
        [StringLength(75)]
        [Required(ErrorMessage = "Açýklama boþ býrakýlamaz")]
        public string Description { get; set; }

        [NotMapped]
        public HttpPostedFileBase Images { get; set; }
    }
}
