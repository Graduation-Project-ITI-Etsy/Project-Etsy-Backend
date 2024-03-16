using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esty_Models;

namespace Esty_Applications.Services.OrderItems
{
    public interface IOrderItemsServices
    {
        OrderItem AddItem(OrderItem item);
        OrderItem DeleteItem(int Id);

    }
}
