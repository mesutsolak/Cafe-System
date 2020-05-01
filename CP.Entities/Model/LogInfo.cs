using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.Model
{
    [Table("LogInfoes")]
    public class LogInfo
    {

        public LogInfo()
        {
            Date = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Controller { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Action { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Type { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string ExceptionMessage { get; set; }
        public int? LogStatusId { get; set; }
        public virtual LogStatus LogStatus { get; set; }

    }
}
