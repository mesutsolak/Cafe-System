namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int? LogStatusId { get; set; }

        public virtual LogStatus LogStatus { get; set; }
    }
}
