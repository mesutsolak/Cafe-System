using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class CartOperation:BaseOperation
    {
        public static async Task<int> CartAdd(Cart cart)
        {
            _data.CartRepository.Add(cart);
           return await _data.CompleteAsync();
        }
        public static async Task<int> CartUpdate(Cart cart)
        {
            _data.CartRepository.Update(cart);
            return await _data.CompleteAsync();
        }
        public static async Task<int> CartRemove(int id)
        {
            _data.CartRepository.Remove(id);
            return await _data.CompleteAsync();
        }
        public static async Task<List<Cart>> GetAllAsync(int id)
        {
          return await  _data.CartRepository.CartListAsync(id);
        }
        public static async Task<Cart> GetFindCart(int id)
        {
            return await _data.CartRepository.GetByIdAsync(id);
        }
    }
}
