using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
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
            EtsyDbContext = _etsyDbContext;
        }

        public Products SearchProductByName(string Name)
        {
            var Product = EtsyDbContext.Set<Products>()
                                       .Where(P => P.ProductNameEN!.Contains(Name) || P.ProductNameAR!.Contains(Name))
                                       .FirstOrDefault();
            if (Product == null) 
                return null!;
            return Product;
        }

        public List<Products> FilterProductByPrice(int MinPrice, int MaxPrice)
        {
            var FilterProducts = EtsyDbContext.Set<Products>()
                                 .Where(P => P.ProductPrice >= MinPrice && P.ProductPrice <= MaxPrice)
                                 .ToList();
            if (FilterProducts == null)
                return null!;

            return FilterProducts;
        }
    }
}
