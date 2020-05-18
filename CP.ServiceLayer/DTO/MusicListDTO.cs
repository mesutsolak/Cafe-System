using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class MusicListDTO
    {
        public int Id { get; set; }
        public string MusicName { get; set; }
        public string ArtistName { get; set; }
        public int? UserId { get; set; }
        public int? Order { get; set; }
        public int? ConfirmId { get; set; }
        public bool? IsComplete { get; set; }
        public virtual User User { get; set; }
    }
}
