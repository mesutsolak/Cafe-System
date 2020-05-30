using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class HomePageOperation : BaseOperation
    {
        public static HomePage DefaultHomePage()
        {
            return _data.HomePageRepository.FirstRecord();
        }
        public static int HomePageAdd(HomePage homePage)
        {
            _data.HomePageRepository.Add(homePage);
            return _data.Complete();
        }

        public static int HomePageUpdate(HomePage homePage)
        {
            _data.HomePageRepository.Update(homePage);
            return _data.Complete();
        }

        public static int HomeRemove(int id)
        {
            _data.HomePageRepository.Remove(id);
            return _data.Complete();
        }
    }
}
