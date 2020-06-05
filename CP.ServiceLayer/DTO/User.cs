using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class User
    {
        public User()
        {
            IsConfirm = false;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string ProfilPhoto { get; set; }
        public int? GenderId { get; set; }
        public string BackGroundPhoto { get; set; }
        public bool? IsConfirm { get; set; }
        public bool IsDeleted { get; set; }
        public GenderDTO Gender { get; set; }
    }
}
