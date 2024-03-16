using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.OrderRepository
{
    public class OrderRepository : Repository<Orders, int>, IOrdersRepository
    {
        EtsyDbContext EtsyDbContext;

        public OrderRepository(EtsyDbContext _etsyDbContext) : base(_etsyDbContext)
        {
            EtsyDbContext = _etsyDbContext;
        }
    }
}
