using Esty_Models;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface IProductRepository : IRepo<Products, int>
    {
        Task<Products> SearchProductByName(string Name);

        Task<IQueryable<Products>> FilterProductByPrice(int MinPrice, int MaxPrice, int CategoryId);

        Task<IQueryable<Products>> GetByCategoryIdProducts(int CategoryId);
    }
}
