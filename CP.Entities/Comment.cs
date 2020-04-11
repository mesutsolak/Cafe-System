namespace CP.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
