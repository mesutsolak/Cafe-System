using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class GeneralOperation : BaseOperation
    {
        public static int GeneralAdd(General general)
        {
            _data.GeneralRepository.Add(general);
            return _data.Complete();
        }
        public static int GeneralUpdate(General general)
        {
            _data.GeneralRepository.Update(general);
            return _data.Complete();
        }
        public static General FirstRecord()
        {
            return _data.GeneralRepository.FirstRecord();
        }
        public static int GeneralRemove(int id)
        {
            _data.GeneralRepository.Remove(id);
            return _data.Complete();
        }
    }
}
