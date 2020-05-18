using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class CampProductOperation : BaseOperation
    {
        public static int CampProductAdd(CampProduct campProduct)
        {
            _data.CampProductRepository.Add(campProduct);
            return _data.Complete();
        }
        public static int CampProductUpdate(CampProduct campProduct)
        {
            _data.CampProductRepository.Update(campProduct);
            return _data.Complete();
        }
        public static int CampProductRemove(int id)
        {
            _data.CampProductRepository.Remove(id);
            return _data.Complete();
        }

        public static CampProduct GetCampProduct(int id)
        {
            return _data.CampProductRepository.GetByFilter(x => x.Id == id);
        }

        public static List<CampProduct> GetCampProducts()
        {
            return _data.CampProductRepository.GetCampProducts();
        }


    }
}
