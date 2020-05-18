using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class CompanyOperation : BaseOperation
    {
        public static int CompanyInfoAdd(CompanyInformation companyInformation)
        {
            _data.CompanyRepository.Add(companyInformation);
            return _data.Complete();
        }
        public static int CompanyInfoUpdate(CompanyInformation companyInformation)
        {
            _data.CompanyRepository.Update(companyInformation);
            return _data.Complete();
        }
        public static int CompanyInfoRemove(int id)
        {
            _data.CompanyRepository.Remove(id);
            return _data.Complete();
        }
        public static CompanyInformation GetCompanyInformation()
        {
            return _data.CompanyRepository.FirstRecord();
        }
    }
}
