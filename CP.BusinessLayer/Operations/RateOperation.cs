using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class RateOperation : BaseOperation
    {
        public static int RateAdd(Rate rate)
        {
            _data.RateRepository.Add(rate);
            return _data.Complete();
        }
        public static int RateUpdate(Rate rate)
        {
            _data.RateRepository.Update(rate);
            return _data.Complete();
        }
        public static int RateRemove(int RateId)
        {
            _data.RateRepository.Remove(RateId);
            return _data.Complete();
        }
        public static Rate RateFind(int UserId, int ProductId)
        {
            return _data.RateRepository.GetByFilter(x => x.UserId == UserId && x.ProductId == ProductId);
        }
        public static int RateProduct(int ProductId)
        {
            return _data.RateRepository.RateAvg(ProductId);
        }
    }
}
