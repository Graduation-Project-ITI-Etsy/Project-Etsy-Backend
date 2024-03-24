using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.ProductRepository
{
    public class ProductRepository : Repository<Products, int>, IProductRepository
    {
        EtsyDbContext EtsyDbContext;

        public ProductRepository(EtsyDbContext _etsyDbContext) : base(_etsyDbContext)
        {
            EtsyDbContext = _etsyDbContext ?? throw new ArgumentNullException(nameof(_etsyDbContext)) ;
        }

        public async Task<IQueryable<Products>> GetByCategoryIdProducts(int CategoryId)
        {
            var ProductsByCategoryId = await EtsyDbContext.Set<Products>()
                                  .Where( P=>P.CategoryID == CategoryId)
                                  .ToListAsync();
            if (ProductsByCategoryId == null)
                return null!;

            return ProductsByCategoryId.AsQueryable();
        }

        public async Task<Products> SearchProductByName(string Name)
        {
            var Product = await EtsyDbContext.Set<Products>()
                                      .Where(P => P.ProductNameEN!.Contains(Name) || P.ProductNameAR!.Contains(Name))
                                      .FirstOrDefaultAsync();
            if (Product == null)
                return null!;
            return Product;
        }

        public async Task<IQueryable<Products>> FilterProductByPrice(int MinPrice, int MaxPrice, int CategoryId)
        {
            var FilterProducts = await EtsyDbContext.Set<Products>()
                                 .Where(P => P.ProductPrice >= MinPrice && P.ProductPrice <= MaxPrice && P.CategoryID == CategoryId)
                                 .ToListAsync();
            if (FilterProducts == null)
                return null!;

            return FilterProducts.AsQueryable();
        }

        public async Task<IQueryable<Products>> FilterPriceAscending(int CategoryId)
        {
            var ProductsByCategoryIdTask = GetByCategoryIdProducts(CategoryId);
            var ProductsByCategoryId = await ProductsByCategoryIdTask;
            var ProductPriceAscending = ProductsByCategoryId.OrderBy(P => P.ProductPrice).ToList();
            return ProductPriceAscending.AsQueryable();
        }

        public async Task<IQueryable<Products>> FilterPriceDescending(int CategoryId)
        {
            var ProductsByCategoryIdTask = GetByCategoryIdProducts(CategoryId);
            var ProductsByCategoryId = await ProductsByCategoryIdTask;
            var ProductPriceAscending = ProductsByCategoryId.OrderByDescending(P => P.ProductPrice).ToList();
            return ProductPriceAscending.AsQueryable();
        }

        public async Task<IQueryable<Products>> FilterByCustomerReview(int CategoryId)
        {
            var ProductsCustomerReviewTask = GetByCategoryIdProducts(CategoryId);
            var Reviews = await ProductsCustomerReviewTask;
            var CustomerReviews = Reviews.OrderByDescending(P => P.ProductRating).ToList();
            return CustomerReviews.AsQueryable();
        }
    }
}
