namespace CP.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public int? ImageId { get; set; }

        public virtual Images Images { get; set; }
    }
}
