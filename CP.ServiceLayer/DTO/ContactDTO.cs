using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LocationGeneral { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
    }
}
