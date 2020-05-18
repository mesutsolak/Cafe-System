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
    public class CampProductRepository : Repository<CampProduct>, ICampProductRepository
    {
        public CampProductRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public CafeProjectModel CafeDB => _context as CafeProjectModel; //bu cast işlemine sürekli ihtiyac duyacağız.


        public List<CampProduct> GetCampProducts()
        {
            return CafeDB.CampProduct.Include(x => x.Campaign).Include(x => x.Product).ToList();
        }
    }
}
