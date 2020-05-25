using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class SliderOperations : BaseOperation
    {
        public static int SliderAdd(Slider slider)
        {
            _data.SliderRepository.Add(slider);
            return _data.Complete();
        }

        public static int SliderUpdate(Slider slider)
        {
            _data.SliderRepository.Update(slider);
           return _data.Complete();
        }

        public static int SliderRemove(int id)
        {
            _data.SliderRepository.Remove(id);
            return _data.Complete();
        } 

        public static Slider SliderFind(int id)
        {
            return _data.SliderRepository.GetById(id);
        }

        public static List<Slider> GetSliders()
        {
            return _data.SliderRepository.GetAll();
        }
    }
}
