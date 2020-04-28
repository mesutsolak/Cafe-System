using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class LoginControl
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adı boş bırakmayınız")]
        public string UserName { get; set; }
        [DisplayName("Parola")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parolayı boş bırakmayınız")]
        public string Password { get; set; }
    }
}
