namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MusicList")]
    public partial class MusicList
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string MusicName { get; set; }

        [StringLength(150)]
        public string ArtistName { get; set; }

        public int? UserId { get; set; }

        public int? Order { get; set; }

        public int? ConfirmId { get; set; }

        public bool? IsComplete { get; set; }

        public virtual ConfirmStatus ConfirmStatus { get; set; }

        public virtual User User { get; set; }
    }
}
