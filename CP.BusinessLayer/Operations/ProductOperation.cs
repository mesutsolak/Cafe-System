using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace CP.BusinessLayer.Operations
{
    public class ProductOperation : BaseOperation
    {
        public async static Task<List<Product>> GetProductsAsync()
        {
            return await _data.ProductRepository.GetAllAsync();
        }
        public static List<Product> GetUsers(Expression<Func<Product, object>> expression = null)
        {
            return _data.ProductRepository.GetAll(expression);
        }
        public  static int ProductAdd(Product product)
        {                    
            _data.ProductRepository.Add(product);
            return  _data.Complete();
        }
    }
}
