using CP.Entities;
using CP.BusinessLayer.Repository.Abstract.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.Entities.Model;
using System.Linq.Expressions;

namespace CP.BusinessLayer.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> LoginControl(User user);
    }
}
