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
        public static List<Product> GetProducts(Expression<Func<Product, object>> expression = null, Expression<Func<Product, bool>> condition = null)
        {
            return _data.ProductRepository.GetAll(expression,condition);
        }
        public  static int ProductAdd(Product product)
        {                    
            _data.ProductRepository.Add(product);
            return  _data.Complete();
        }
        public static Product ProductFind(int id)
        {
            return _data.ProductRepository.GetById(id);
        }
        public static int ProductUpdate(Product product)
        {
            _data.ProductRepository.Update(product);
            return _data.Complete();
        }
        public static int ProductRemove(int id)
        {
            _data.ProductRepository.Remove(id);
            return _data.Complete();
        }
        public static List<Product> GetProducts()
        {
            return _data.ProductRepository.GetAll(x=>x.Category,y=>y.IsDeleted==false);
        }
    }
}
