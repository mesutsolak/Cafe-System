namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rate")]
    public partial class Rate : BaseEntity<int>
    {
        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        [Column("Rate")]
        public int? RateValue { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
