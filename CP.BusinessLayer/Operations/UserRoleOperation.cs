using CP.Entities.Model;
using CP.Entities.ViewModel;
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
        public static List<UserRoles> UserFindRole(int UserId)
        {
            return _data.UserRoleRepository.GetAll(null, x => x.UserId == UserId);
        }
        public static int UserRoleAddAll(IEnumerable<UserRoles> userRoles)
        {
            _data.UserRoleRepository.AddRange(userRoles);
            return _data.Complete();
        }
        public static int UserRoleAdd(UserRoles userRoles)
        {
            _data.UserRoleRepository.Add(userRoles);
            return _data.Complete();
        }
        public static int UserRoleUpdate(UserRoles userRoles)
        {
            _data.UserRoleRepository.Update(userRoles);
            return _data.Complete();
        }
        public static bool HasUserRole(int UserId, int RoleId)
        {
            return _data.UserRoleRepository.IsThereResult(x => x.UserId == UserId && x.RoleId == RoleId);
        }
        public static int Remove(int Id)
        {
            _data.UserRoleRepository.Remove(Id);
            return _data.Complete();
        }
    }
}
