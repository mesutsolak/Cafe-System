using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CP.WebUI.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles;

            int sayac =0;

            try
            {
                using (CafeProjectModel db = new CafeProjectModel())
                {
                    var _userId = db.User.SingleOrDefault(x => x.Username == username);
                    var _rolesId = db.UserRoles.Where(x => x.UserId == _userId.Id).Select(y => y.RoleId).ToList();

                    roles = new string[_rolesId.Count];

                    foreach (var id in _rolesId)
                    {
                        roles[sayac] = db.Roles.Find(id).Name;
                        sayac++;
                    }
                }

                sayac = 0;
                return roles;

            }
            catch (Exception ex)
            {

                throw ex;
            }

          
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}