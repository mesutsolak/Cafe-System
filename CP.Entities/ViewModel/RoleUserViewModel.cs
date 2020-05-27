using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.ViewModel
{
    public class RoleUserViewModel
    {
        public IList<string> Role { get; set; }
        public IList<int> User { get; set; }
    }
}
