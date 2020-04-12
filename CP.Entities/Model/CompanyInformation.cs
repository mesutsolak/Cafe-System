namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyInformation")]
    public partial class CompanyInformation
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
