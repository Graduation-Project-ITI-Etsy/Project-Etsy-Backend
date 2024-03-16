using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.OrderItemRepository
{
    public class OrderItemRepository : Repository<OrderItem, int>, IOrderItemRepository
    {
        EtsyDbContext EtsyDbContext;

        public OrderItemRepository(EtsyDbContext _etsyDbContext) : base(_etsyDbContext)
        {
            EtsyDbContext = _etsyDbContext;
        }
    }
}
