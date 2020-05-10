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
        public static async Task<int> CartAddAsync(Cart cart)
        {
            _data.CartRepository.Add(cart);
           return await _data.CompleteAsync();
        }

        public static int CartAdd(Cart cart)
        {
            _data.CartRepository.Add(cart);
            return _data.Complete(); 
        }

        public static int CartUpdate(Cart cart)
        {
            _data.CartRepository.Update(cart);
            return _data.Complete();
        }

        public static async Task<int> CartUpdateAsync(Cart cart)
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
        public static List<Cart> GetAll(int UserId)
        {
            return _data.CartRepository.GetAll(x=>x.Product,x => x.UserId == UserId && x.IsDeleted==false); 
        }
        public static Cart IsThereProduct(int productId)
        {
           return _data.CartRepository.GetByFilter(x => x.ProductId == productId && x.IsDeleted == false);
        } 

    }
}
