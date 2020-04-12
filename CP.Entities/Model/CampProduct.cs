namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampProduct")]
    public partial class CampProduct
    {
        public int Id { get; set; }

        public int? CampaignId { get; set; }

        public int? ProductId { get; set; }

        public virtual Campaign Campaign { get; set; }

        public virtual Product Product { get; set; }
    }
}
