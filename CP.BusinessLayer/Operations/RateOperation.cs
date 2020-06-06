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
        public static Rate RateFind(int UserId)
        {
            return _data.RateRepository.GetByFilter(x => x.UserId == UserId);
        }
        public static int RateProduct(int ProductId)
        {
            return _data.RateRepository.RateAvg(ProductId);
        }
        public static string RateUserValue(int UserId, int ProductId)
        {
            var _result = _data.RateRepository.GetByFilter(x => x.UserId == UserId && x.ProductId == ProductId);
            if (_result == null)
                return "0";

            return _result.RateValue.Value.ToString() ?? "0";
        }
        public static Rate RateUserValueFind(int UserId, int ProductId)
        {
            return _data.RateRepository.GetByFilter(x => x.UserId == UserId && x.ProductId == ProductId);
        }
    }
}
