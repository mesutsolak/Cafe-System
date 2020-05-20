using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class MusicListDTO
    {
        public MusicListDTO()
        {
            IsDeleted = false;
            IsComplete = false;
            ConfirmId = 2;
        }
        public int Id { get; set; }
        public string MusicName { get; set; }
        public string ArtistName { get; set; }
        public int? UserId { get; set; }
        public int? ConfirmId { get; set; }
        public bool? IsComplete { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual User User { get; set; }
    }
}
