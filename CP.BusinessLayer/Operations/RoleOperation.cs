using CP.Entities.Model;
using CP.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class RoleOperation : BaseOperation
    {
        private static RoleUserViewModel _ChartModel = new RoleUserViewModel();

        public static List<Roles> GetRoles()
        {
            return _data.RoleRepository.GetAll();
        }
        public static int RoleAdd(Roles Role)
        {
            _data.RoleRepository.Add(Role);
            return _data.Complete();
        }
        public static int RoleUpdate(Roles Role)
        {
            _data.RoleRepository.Update(Role);
            return _data.Complete();
        }
        public static int RoleRemove(int id)
        {
            _data.RoleRepository.Remove(id);
            return _data.Complete();
        }
        public static Roles GetRole(int id)
        {
            return _data.RoleRepository.GetById(id);
        }
        public static RoleUserViewModel RoleUser()
        {
            _ChartModel.Role.Clear();
            _ChartModel.User.Clear();
            foreach (var role in GetRoles())
            {
                _ChartModel.Role.Add(role.Name);
                _ChartModel.User.Add(UserRoleOperation.UserRoleCount(role.Id));
            }
            return _ChartModel;
        }
    }
}
