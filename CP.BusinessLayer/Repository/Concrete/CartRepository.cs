using CP.BusinessLayer.Repository.Abstract;
using CP.BusinessLayer.Repository.Concrete.Basic;
using CP.Entities.Migrations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Repository.Concrete
{
    public class CartRepository:Repository<Cart>,ICartRepository
    {
        public CartRepository(DbContext dbContext):base(dbContext)
        {
                
        }

        public CafeProjectModel CafeDB => _context as CafeProjectModel; //bu cast işlemine sürekli ihtiyac duyacağız.


        public Task<List<Cart>> CartListAsync(int UserId)
        {
           return CafeDB.Cart.Where(x=>x.ConfirmId==1).ToListAsync();
        }
    }
}
