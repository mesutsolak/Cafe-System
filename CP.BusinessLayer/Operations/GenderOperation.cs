using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class GenderOperation : BaseOperation
    {
        public static List<Gender> GetGenders()
        {
            return _data.GenderRepository.GetAll();
        }
    }
}
