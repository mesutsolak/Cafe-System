namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rate")]
    public partial class Rate
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        [Column("Rate")]
        public int? Rate1 { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
