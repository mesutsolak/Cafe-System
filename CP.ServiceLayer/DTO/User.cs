using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }
        public byte[] Photo { get; set; }

        public bool? IsConfirm { get; set; } = false;
        public bool Status { get; set; } = true;

    }
}
