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
        bool IsThereUserName(string UserName);
        bool IsThereEmail();
        int UserId(string UserName);
        bool UserNameControl();
        bool EmailControl();
    }
}
