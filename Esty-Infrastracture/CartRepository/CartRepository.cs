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
                    // Include other properties from both tables as needed
                }).ToListAsync();
            //var CustomerCarts = await EtsyDbContext.Set<Cart>()
            //    .Where(c => c.CustomerId == customerId).Join(EtsyDbContext.products,
            //                                                        carts => carts.ProductId,
            //                                                        products => products.ProductId,
            //                                                        (carts, products) => new Products
            //                                                        {
            //                                                            ProductNameEN = products.ProductNameEN,
            //                                                            ProductNameAR = products.ProductNameAR,
            //                                                            ProductPrice = products.ProductPrice
            //                                                        }).ToListAsync();
            //if (CustomerCarts == null)
            //    return null;

            return result.AsQueryable();
        }
    }
}


//        var customerCartItems = dbContext.Carts
//.Where(c => c.CustomerId == customerId) // Filter by customer ID
//.Join(
//    dbContext.Products, // Join with Products table
//    cart => cart.ProductId, // Join condition: Cart.ProductId
//    product => product.Id, // Join condition: Product.Id
//    (cart, product) => new // Result selector: Create a new object containing cart and product information
//    {
//        CartId = cart.Id,
//        CustomerId = cart.CustomerId,
//        ProductId = product.Id,
//        ProductName = product.Name,
//        // Include other properties as needed
//    })
//.ToList();