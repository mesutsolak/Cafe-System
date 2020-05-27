namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact:BaseEntity<int>
    {
        [StringLength(250)]
        [Display(Name ="Açýklama")]
        public string Description { get; set; }

        [StringLength(100)]
        [Display(Name = "Konum")]
        public string LocationGeneral { get; set; }

        [StringLength(11)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [StringLength(100)]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [StringLength(100)]
        public string Twitter { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(100)]
        public string Instagram { get; set; }
    }
}
