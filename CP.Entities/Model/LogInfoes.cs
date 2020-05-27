namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LogInfoes : BaseEntity<int>
    {
        public int? UserId { get; set; }

        [StringLength(50)]
        public string Controller { get; set; }

        [StringLength(50)]
        public string Action { get; set; }

        public DateTime Date { get; set; }

        [StringLength(150)]
        public string Type { get; set; }

        [StringLength(500)]
        public string ExceptionMessage { get; set; }

        public int? LogStatusId { get; set; }

        public virtual LogStatus LogStatus { get; set; }
    }
}
