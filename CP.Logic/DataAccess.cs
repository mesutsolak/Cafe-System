using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CP.BusinessLayer.UnitOfWork.Concrete.Basic;
using PES.Logic.Singleton;

namespace CP.Logic.Tools
{
    public class DataAccess<TT> where TT : DbContext, new()
    {
        private static UnitOfWork _unitOfWork { get; set; }

        public static UnitOfWork _UnitOfWOrk
        {
            get
            {
                var _singleton = SingletonClass<TT>.Class;
                return _unitOfWork = new UnitOfWork(_singleton);
            }
        }
    }
}
