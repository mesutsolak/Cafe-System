using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.ViewModel
{
    public partial class RoleListModel
    {
        public RoleListModel()
        {
            Roles = new List<Role>();
        }
        public int Id { get; set; }
        public List<Role> Roles { get; set; }

    }
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
