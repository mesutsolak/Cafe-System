namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampProduct")]
    public partial class CampProduct : BaseEntity<int>
    {
        public CampProduct()
        {
            IsShow = false;
        }


        public int? CampaignId { get; set; }

        public int? ProductId { get; set; }
        public bool? IsShow { get; set; }

        public virtual Campaign Campaign { get; set; }

        public virtual Product Product { get; set; }
    }
}
