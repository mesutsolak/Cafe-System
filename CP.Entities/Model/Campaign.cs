namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Campaign")]
    public partial class Campaign
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campaign()
        {
            CampProduct = new HashSet<CampProduct>();
        }

        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int? OldPrice { get; set; }

        public int? NewPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampProduct> CampProduct { get; set; }
    }
}
