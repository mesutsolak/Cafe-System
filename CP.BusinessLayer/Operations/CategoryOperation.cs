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
    }
}
