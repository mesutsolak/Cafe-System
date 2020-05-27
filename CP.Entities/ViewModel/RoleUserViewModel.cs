using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.ViewModel
{
    public class RoleUserViewModel
    {
        public RoleUserViewModel()
        {
            Role = new List<string>();
            User = new List<int>();
        }
        public List<string> Role { get; set; }
        public List<int> User { get; set; }
    }
}
