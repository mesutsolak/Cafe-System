using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using US = CP.BusinessLayer.UnitOfWork.Concrete.Basic;
using CP.BusinessLayer.Tools;

namespace CP.BusinessLayer
{
    public class DataAccess<TT> where TT : DbContext, new()
    {
        private static US.UnitOfWork _unitOfWork { get; set; }

        public static US.UnitOfWork _UnitOfWOrk
        {
            get
            {
                var _singleton = SingletonClass<TT>.Class;
                return _unitOfWork = new US.UnitOfWork(_singleton);
            }
        }
    }
}
