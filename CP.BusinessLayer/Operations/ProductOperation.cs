using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using CP.Entities.ViewModel;

namespace CP.BusinessLayer.Operations
{
    public class ProductOperation : BaseOperation
    {
        private static ProcCatViewModel _ChartModel = new ProcCatViewModel();
        public static List<Product> GetProducts(Expression<Func<Product, object>> expression = null, Expression<Func<Product, bool>> condition = null)
        {
            return _data.ProductRepository.GetAll(expression, condition);
        }
        public static int ProductAdd(Product product)
        {
            _data.ProductRepository.Add(product);
            return _data.Complete();
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
            return _data.ProductRepository.GetAll(x => x.Category, y => y.IsDeleted == false);
        }
        public static List<Product> GetFilterCategory(int CategoryId)
        {
            return _data.ProductRepository.GetAll(x => x.Category, x => x.CategoryId == CategoryId);
        }

        public static int ViewAdd(int ProductId)
        {
            var product = _data.ProductRepository.GetById(ProductId);
            product.Views += 1;
            _data.ProductRepository.Update(product);
            return _data.Complete();
        }

        public static int ProductCategoryCount(int CategoryId)
        {
            return _data.ProductRepository.GetAll(null, x => x.CategoryId == CategoryId).Count;
        }
        public static List<Product> GetPreferences()
        {
            return _data.ProductRepository.GetAll(x => x.Category, y => y.IsDeleted == false && y.Preference == true);
        }
        public static List<Product> GetChooses()
        {
            return _data.ProductRepository.GetAll(x => x.Category, y => y.IsDeleted == false && y.Choose == true);
        }
        public static int ProductCount()
        {
            return GetProducts().Count;
        }
        public static ProcCatViewModel CategoryProduct()
        {
            _ChartModel.Category.Clear();
            _ChartModel.Product.Clear();
            foreach (var category in CategoryOperation.GetCategories())
            {
                _ChartModel.Category.Add(category.Name);
                _ChartModel.Product.Add(ProductCategoryCount(category.Id));
            }
            return _ChartModel;
        }
        public static bool IsThereProduct(string ProductName, int? id = null)
        {
            if (id == null)
            {
                return _data.ProductRepository.IsThereResult(x => x.Name == ProductName);
            }
            return _data.ProductRepository.IsThereResult(x => x.Name == ProductName && x.Id != id);

        }
    }
}
