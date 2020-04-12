using CP.BusinessLayer.Repository.Abstract.Basic;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U = CP.BusinessLayer.UnitOfWork.Concrete.Basic;

namespace CP.BusinessLayer.Operations
{
    public class UserOperations
    {
        static U.UnitOfWork _data = DataAccess<CafeProjectModel>._UnitOfWOrk;

        public async static Task<int> UserAdd(User user)
        {
            _data.UserRepository.Add(user);
            return await _data.CompleteAsync();
        }
        public async static Task<List<User>> GetUsers()
        {
            return await _data.UserRepository.GetAllAsync();
        }
        public async static Task<User> UserFindAsync(int id)
        {
            return await _data.UserRepository.GetByIdAsync(id);
        }
        public async static Task<int> UserUpdate(User user)
        {
            _data.UserRepository.Update(user);
            return await _data.CompleteAsync();
        }
        public async static Task<int> UserRemove(int id)
        {
            _data.UserRepository.Remove(id);
            return await _data.CompleteAsync();
        }
    }
}
