using CP.ServiceLayer.Abstract.Basic;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Abstract
{
    public interface IRateService : IService<RateDTO>
    {
        int GetRate(int UserId, int ProductId);
    }
}
