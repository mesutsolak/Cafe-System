namespace CP.Entities
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

        [Column(TypeName = "text")]
        public string MusicName { get; set; }

        public int? Order { get; set; }
    }
}
