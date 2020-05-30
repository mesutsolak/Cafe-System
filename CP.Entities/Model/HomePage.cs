using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.Model
{
    public class HomePage : BaseEntity<int>
    {
        [StringLength(20)]
        [Required(ErrorMessage = "Başlık 1 girilmesi zorunludur")]
        [Display(Name = "Başlık 1")]
        public string Header1 { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage = "Açıklama 1 girilmesi zorunludur")]
        [Display(Name = "Açıklama 1")]
        public string Description1 { get; set; }
        [StringLength(20)]
        [Display(Name = "Başlık 2")]
        public string Header2 { get; set; }
        [StringLength(500)]
        [Display(Name = "Açıklama 2")]
        public string Description2 { get; set; }

    }
}
