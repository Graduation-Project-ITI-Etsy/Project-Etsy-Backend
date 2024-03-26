using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.CartRepository
{
    public class CartRepository : Repository<Cart, int> , ICartRepository
    {
        EtsyDbContext EtsyDbContext;

        public CartRepository(EtsyDbContext _etsyDbContext) : base(_etsyDbContext)
        {
            EtsyDbContext = _etsyDbContext ?? throw new ArgumentNullException(nameof(_etsyDbContext));
        }

        public async Task<IQueryable<Cart>> GetcartsByCustomerId (string customerId)
        {
            var CustomerCarts = await EtsyDbContext.Set<Cart>()
                .Where(C => C.CustomerId.Contains(customerId))
                .ToListAsync();
            if (CustomerCarts == null)
                return null;

            return CustomerCarts.AsQueryable();
        }
    }
}
