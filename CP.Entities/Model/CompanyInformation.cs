namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyInformation")]
    public partial class CompanyInformation : BaseEntity<int>
    {
        [Column(TypeName = "text")]
        [Display(Name = "Açýklama 1")]
        [Required(ErrorMessage ="1.ci açýklamayý girmek zorunludur.")]
        public string Description1 { get; set; }
        [Column(TypeName = "text")]
        [Display(Name = "Açýklama 2")]
        public string Description2 { get; set; }

        [StringLength(150)]
        [Display(Name = "Baþlýk 1")]
        [Required(ErrorMessage = "1.ci baþlýðý girmek zorunludur.")]
        public string Header1 { get; set; }

        [StringLength(150)]
        [Display(Name = "Baþlýk 2")]
        public string Header2 { get; set; }
    }
}
