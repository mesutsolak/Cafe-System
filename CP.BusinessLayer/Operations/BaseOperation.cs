using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U = CP.BusinessLayer.UnitOfWork.Concrete.Basic;

namespace CP.BusinessLayer.Operations
{
    public class BaseOperation
    {
        protected static  U.UnitOfWork _data = DataAccess<CafeProjectModel>._UnitOfWOrk;
    }
}
