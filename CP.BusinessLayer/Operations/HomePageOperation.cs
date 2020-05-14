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
        public HomePage GetHomePage(int id)
        {
            return _data.HomePageRepository.GetById(id);
        }
        public HomePage DefaultHomePage()
        {
            return _data.HomePageRepository.GetAll().FirstOrDefault();
        }
        public int HomePageAdd(HomePage homePage)
        {
            _data.HomePageRepository.Add(homePage);
            return _data.Complete();
        }   

        public int HomePageUpdate(HomePage homePage)
        {
            _data.HomePageRepository.Update(homePage);
            return _data.Complete();
        }

        public int HomeRemove(int id)
        {
            _data.HomePageRepository.Remove(id);
            return _data.Complete();
        }
    }
}
