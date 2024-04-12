using Esty_Models;
using Etsy_DTO.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface ICartRepository : IRepo<Cart, int>
    {
        public Task<IQueryable<ReturnAllCartDTO>> GetcartsByCustomerId(string customerId);

        public Task<List<Cart>> DeleteCartByCustomerId(string customerId);

        public Task<Cart> CheckProductInCart(int productId);

    }
}
