namespace CP.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MusicClaim")]
    public partial class MusicClaim
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string MusicName { get; set; }

        public bool? IsApproved { get; set; }
    }
}
