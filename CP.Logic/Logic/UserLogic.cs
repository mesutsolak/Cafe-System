using CP.BusinessLayer.UnitOfWork.Concrete.Basic;
using CP.Entities;
using CP.Logic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CP.Logic.Logic
{
    public class UserLogic
    {
        static UnitOfWork _data = DataAccess<CafeProjectModel>._UnitOfWOrk;

        public async static Task<string> UserAdd(User user)
        {
            _data.UserRepository.Add(user);
            return await _data.CompleteAsync() > 0 ? "Kullanıcı Başarıyla Kaydedildi" : "Kullanıcı Kaydetme Başarısız";
        }
        public async static Task<string> UserRemove(int id)
        {
            _data.UserRepository.Remove(id);
            return await _data.CompleteAsync() > 0 ? "Kullanıcı Başarıyla Silindi" : "Kullanıcı Silme Başarısız";
        }
        public async static Task<string> UserUpdate(User user)
        {
            _data.UserRepository.Update(user);
            return await _data.CompleteAsync() > 0 ? "Kullanıcı Başarıyla Güncellendi" : "Kullanıcı Güncelleme Başarısız";
        }
        public async static Task<List<User>> UserAllAsync()
        {
            return await _data.UserRepository.GetAllAsync();
        }
        public async static Task<List<User>> UserAllFilterAsync(Expression<Func<User, bool>> expression)
        {
            return await _data.UserRepository.GetFilterAllAsync(expression);
        }
    }
}
