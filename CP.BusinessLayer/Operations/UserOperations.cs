using CP.BusinessLayer.Repository.Abstract.Basic;
using M = CP.Entities.Model;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net.Mail;

namespace CP.BusinessLayer.Operations
{
    public class UserOperations : BaseOperation
    {
        static Random rnd = new Random();
        public static string UserFirstAndLast(string username)
        {
            var user = _data.UserRepository.GetByFilter(x => x.Username == username);
            return user.FirstName + " " + user.LastName;
        }

        public static string PasswordFind(string Email)
        {
            var user = _data.UserRepository.GetByFilter(x => x.Email == Email);
            return user.Password;
        }

        public async static Task<int> UserAdd(M.User user)
        {
            _data.UserRepository.Add(user);
            return await _data.CompleteAsync();
        }
        public async static Task<List<M.User>> GetUsers()
        {
            return await _data.UserRepository.GetAllAsync();
        }
        public async static Task<M.User> UserFindAsync(int id)
        {
            return await _data.UserRepository.GetByIdAsync(id);
        }
        public async static Task<int> UserUpdate(M.User user)
        {
            _data.UserRepository.Update(user);
            return await _data.CompleteAsync();
        }
        public async static Task<int> UserRemove(int id)
        {
            _data.UserRepository.Remove(id);
            return await _data.CompleteAsync();
        }

        public static int UserFindId(string UserName)
        {
            return _data.UserRepository.GetByFilter(x => x.Username == UserName).Id;
        }

        public async static Task<bool> UserNameControl(string UserName)
        {
            return await _data.UserRepository.IsThere(x => x.Username == UserName);
        }
        public async static Task<bool> EmailControl(string Email)
        {
            return await _data.UserRepository.IsThere(x => x.Email == Email);
        }
        public static async Task<string> Login(LoginControl loginControl)
        {
            if (!_data.UserRepository.IsThere(x => x.Username == loginControl.UserName).Result)
            {
                return "Kullanıcı Bulunmadı";
            }

            if (!(_data.UserRepository.GetByFilter(x => x.Username == loginControl.UserName).IsConfirm.Value))
            {
                return "Kullanıcı Onaylanmamıştır";
            }

            if (!_data.UserRepository.IsThere(x => x.Username == loginControl.UserName && x.Password == loginControl.Password).Result)
                return "Kullanıcı veya Şifre Yanlış";

            if (_data.UserRepository.GetByFilter(x => x.Username == loginControl.UserName).IsDeleted.Value)
                return "Kullanıcı Silinmiş";

            return "Başarıyla Giriş Yapıldı";
        }
        public static string PasswordForget(string Email)
        {
            if (!_data.UserRepository.IsThere(x => x.Email == Email && x.IsConfirm == true && x.IsDeleted == false).Result)
                return "Email Bulunmadı";
            else
            {
                MailMessage eposta = new MailMessage
                {
                    Subject = "CP | Şifreniz",
                    Body = "Şifre : " + PasswordFind(Email),
                    From = new MailAddress("mesuttsolakk@gmail.com")
                };

                eposta.To.Add(Email);

                object userState = eposta;

                SmtpClient smtp = new SmtpClient
                {
                    Credentials = new System.Net.NetworkCredential("mesuttsolakk@gmail.com", "Mesut123+-"),
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };

                try
                {
                    smtp.Send(eposta);
                    return "Başarıyla Şifreniz Gönderildi";
                }
                catch (SmtpException ex)
                {
                    return "Şifre gönderme Başarısız";
                }
            }
        }
    }
}