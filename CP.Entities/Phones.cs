namespace CP.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phones
    {
        public int Id { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
