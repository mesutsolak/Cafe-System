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
    public class CompanyRepository : Repository<CompanyInformation>, ICompanyRepository
    {
        public CompanyRepository(DbContext dbContext) : base(dbContext)
        {

        }


        public CafeProjectModel CafeDB => _context as CafeProjectModel; //bu cast işlemine sürekli ihtiyac duyacağız.



        public CompanyInformation FirstRecord()
        {
            return CafeDB.CompanyInformation.FirstOrDefault();
        }
    }
}
