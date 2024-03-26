using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface ICartRepository : IRepo<Cart, int>
    {
        public Task<IQueryable<Cart>> GetcartsByCustomerId(string customerId);
    }
}
