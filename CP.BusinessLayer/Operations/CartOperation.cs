using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class CartOperation : BaseOperation
    {
        public static async Task<int> CartAddAsync(Cart cart)
        {
            _data.CartRepository.Add(cart);
            return await _data.CompleteAsync();
        }

        public static Cart CartFind(int id)
        {
            return _data.CartRepository.GetByFilter(x => x.Id == id);
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
            return await _data.CartRepository.CartListAsync(id);
        }
        public static async Task<Cart> GetFindCart(int id)
        {
            return await _data.CartRepository.GetByIdAsync(id);
        }


        public static List<Cart> GetAll(int UserId)
        {
            return _data.CartRepository.GetAll(x => x.Product, x => x.UserId == UserId && x.ConfirmId == 2 && x.IsDeleted == false);
        }

        public static List<Cart> GetAllOrder(int UserId)
        {
            return _data.CartRepository.GetAll(x => x.Product, y => y.ConfirmId == 1 && y.UserId == UserId && y.IsDeleted == false);
        }

        public static Cart GetCart(int Id)
        {
            return _data.CartRepository.GetById(Id);
        }

        public static Cart IsThereProduct(int productId, int UserId)
        {
            return _data.CartRepository.GetByFilter(x => x.ProductId == productId && x.UserId == UserId && x.ConfirmId == 2 && x.IsDeleted == false);
        }

        public static int CartCount(int UserId)
        {
            return _data.CartRepository.GetAll(null, x => x.UserId == UserId && x.ConfirmId == 2 && x.IsDeleted == false).Count;
        }

        public static int ConfirmAll(int UserId)
        {
            var _values = _data.CartRepository.GetFilterAll(x => x.UserId == UserId && x.ConfirmId == 2 && x.IsDeleted == false);

            foreach (var value in _values)
            {
                value.ConfirmId = 3;
                _data.CartRepository.Update(value);
            }

            return _data.Complete();
        }

        public static int RemoveAll(int UserId)
        {
            var _values = _data.CartRepository.GetFilterAll(x => x.UserId == UserId && x.ConfirmId == 2);

            foreach (var value in _values)
            {
                value.IsDeleted = true;
                _data.CartRepository.Update(value);
            }

            return _data.Complete();
        }

        public static List<Cart> GetHistoryCarts(int UserId)
        {
            return _data.CartRepository.GetAll(x => x.Product, y => y.ConfirmId == 4 && y.UserId == UserId);
        }
        public static List<Cart> GetAllWaitCart()
        {
            return _data.CartRepository.GetAllWaitCart();
        }
        public static int CartApproved(int id)
        {
            var _cart = _data.CartRepository.GetById(id);
            _cart.ConfirmId = 4;
            _data.CartRepository.Update(_cart);
            return _data.Complete();
        }
        public static int CartConfirmRemove(int id)
        {

            var _cart = _data.CartRepository.GetById(id);
            _cart.ConfirmId = 5;
            _data.CartRepository.Update(_cart);
            return _data.Complete();
        }
    }
}
