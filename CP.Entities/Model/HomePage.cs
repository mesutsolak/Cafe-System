using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.Model
{
    public class HomePage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(20)]
        public string Header1 { get; set; }
        [StringLength(500)]
        public string Description1 { get; set; }
        [StringLength(20)]
        public string Header2 { get; set; }
        [StringLength(500)]
        public string Description2 { get; set; }

    }
}
