using CP.Entities.Model;
using CP.ServiceLayer.Abstract;
using CP.ServiceLayer.Concrete.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Concrete
{
    public class UserService : Service<User>, IUserService
    {

    }
}
