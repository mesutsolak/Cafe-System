using CP.BusinessLayer.Repository.Abstract;
using CP.BusinessLayer.Repository.Concrete.Basic;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Repository.Concrete
{
    public class RateRepository : Repository<Rate>, IRateRepository
    {
        public RateRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public CafeProjectModel CafeDB => _context as CafeProjectModel; //bu cast işlemine sürekli ihtiyac duyacağız.


        public int RateAvg(int ProductId)
        {
            return CafeDB.Database.SqlQuery<int>("DECLARE @EmployeeTotal INT EXECUTE @EmployeeTotal = SP_RatingAVG " + ProductId + "  PRINT @EmployeeTotal").First();
        }
    }
}
