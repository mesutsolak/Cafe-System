using CP.ServiceLayer.Abstract.Basic;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<string> LoginControl(LoginControl loginControl);
        Task<bool> IsThereUserName(string UserName);
        Task<bool> IsThereEmail(string Email);
        int UserId(string UserName);
    }
}
