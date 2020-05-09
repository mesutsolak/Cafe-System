using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Abstract.Basic
{
    public interface IService<T> where T : class, new()
    {
        Task<string> AddAsync(T entity);
        Task<string> UpdateAsync(T entity);
        Task<string> RemoveAsync(int id);
        Task<T> GetFindAsync(int id);
        List<T> GetAll();
        T GetFind(int id);
    }
}
