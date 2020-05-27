using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class UserRoleOperation : BaseOperation
    {
        public static int UserRoleCount(int RoleId)
        {
            return _data.UserRoleRepository.GetFilterAll(x => x.RoleId == RoleId).Count;
        }
    }
}
