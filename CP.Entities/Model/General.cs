using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CP.Entities.Model
{
    [Table("General")]
    public partial class General : BaseEntity<int>
    {
        [StringLength(500)]
        public string Image { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        [NotMapped]
        public HttpPostedFileBase Images { get; set; }
    }
}
