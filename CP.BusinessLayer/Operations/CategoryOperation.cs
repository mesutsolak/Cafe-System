using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class CategoryOperation :BaseOperation
    {
        public static List<Category> GetCategories()
        {
            return _data.CategoryRepository.GetAll();
        }
        public static int CategoryAdd(Category category)
        {
            _data.CategoryRepository.Add(category);
           return _data.Complete();
        }
        public static int CategoryUpdate(Category category)
        {
            _data.CategoryRepository.Update(category);
            return _data.Complete();
        }
        public static int CategoryRemove(int id)
        {
            _data.CategoryRepository.Remove(id);
            return _data.Complete();
        }
        public static Category GetCategory(int id)
        {
            return _data.CategoryRepository.GetById(id);
        }
    }
}
