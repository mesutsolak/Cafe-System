namespace CP.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Emails
    {
        public int Id { get; set; }

        [StringLength(175)]
        public string Email { get; set; }

        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
