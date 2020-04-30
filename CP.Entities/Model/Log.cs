namespace CP.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {

        public Log()
        {
            AddedDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Column(TypeName ="varchar")]
        [MaxLength(150)]
        public string IPAddress { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string UrlAccessed { get; set; }
        [Column(TypeName = "text")]
        public string Data { get; set; }
        public long ExecutionMs { get; set; }
        public System.DateTime AddedDate { get; set; }
        public int? LogStatusId { get; set; }
        public virtual LogStatus LogStatus { get; set; }
    }
}
