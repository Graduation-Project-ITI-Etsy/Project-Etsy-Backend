using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using Etsy_DTO.Carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.CartRepository
{
    public class CartRepository : Repository<Cart, int>, ICartRepository
    {
        EtsyDbContext EtsyDbContext;

        public CartRepository(EtsyDbContext _etsyDbContext) : base(_etsyDbContext)
        {
            EtsyDbContext = _etsyDbContext ?? throw new ArgumentNullException(nameof(_etsyDbContext));
        }

        public async Task<IQueryable<ReturnAllCartDTO>> GetcartsByCustomerId(string customerId)
        {
            var result = await EtsyDbContext.carts
                .Include(cart => cart.products) // Assuming there's a navigation property named Product in Cart entity
                .Where(cart => cart.CustomerId == customerId) // Apply any filtering conditions if needed
                .Select(cart => new ReturnAllCartDTO
                {
                    CartID = cart.CartID,
                    CustomerId = cart.CustomerId,
                    ProductId = cart.products.ProductId,
                    ProductNameEN = cart.products.ProductNameEN,
                    ProductNameAR = cart.products.ProductNameAR,
                    ProductPrice =cart.products.ProductPrice,
                    ProductStock = cart.products.ProductStock,
                    ProductRating = cart.products.ProductRating,
                    ProductPublisher = cart.products.ProductPublisher,
                    ProductDescriptionEN = cart.products.ProductDescriptionEN,
                    ProductDescriptionAR = cart.products.ProductDescriptionAR,
                    ProductImage = cart.products.ProductImage,
                    CategoryID = cart.products.CategoryID,
                    Quantity = cart.Quantity
                }).ToListAsync();
           
            return result.AsQueryable();
        }

        public async Task<List<Cart>> DeleteCartByCustomerId(string customerId)
        {
            var cartItems = EtsyDbContext.carts.Where(c => c.CustomerId == customerId).ToList();


            if (cartItems == null)
                return null!;

            EtsyDbContext.carts.RemoveRange(cartItems);

            return cartItems;
        }
    }
}

