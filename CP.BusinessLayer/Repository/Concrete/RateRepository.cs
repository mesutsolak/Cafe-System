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
            var _product= CafeDB.Rate.FirstOrDefault(x => x.ProductId == ProductId);
            if (_product == null)
                return 0;

            var _Rate = CafeDB.Rate.Where(x => x.ProductId == ProductId).Select(x => x.RateValue).ToList();
            return (int)_Rate.Average().Value;
        }
    }
}
