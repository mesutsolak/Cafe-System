using CP.BusinessLayer.Repository.Abstract.Basic;
using CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class UserOperations : BaseOperation
    {
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
        public async static Task<string> UserControl(User user)
        {
            if (await _data.UserRepository.LoginControl(user))
            {
                return "Başarıyla Giriş Yapıldı";
            }
            else
            {
                return "Giriş Başarısız";
            }
        }
        public async static Task<bool> UserNameControl(string UserName)
        {
           return await _data.UserRepository.IsThere(x=>x.Username == UserName);
        }
        public async static Task<bool> EmailControl(string Email)
        {
            return await _data.UserRepository.IsThere(x=>x.Email == Email);
        }
        public static async Task<string> Login(LoginControl loginControl)
        {
            if (!_data.UserRepository.IsThere(x => x.Username == loginControl.UserName).Result)
            {
                return  "Kullanıcı Bulunmadı";
            }

            if (!(_data.UserRepository.GetByFilter(x => x.Username == loginControl.UserName).IsConfirm.Value))
            {
                return "Kullanıcı Onaylanmamıştır";
            }

            if (!_data.UserRepository.IsThere(x => x.Username == loginControl.UserName && x.Password == loginControl.Password).Result)
                return "Kullanıcı veya Şifre Yanlış";

            if (_data.UserRepository.GetByFilter(x => x.Username == loginControl.UserName).Status)
                return "Kullanıcı Silinmiş";
           
            return "Başarıyla Giriş Yapıldı";
        }
    }                                        
}
