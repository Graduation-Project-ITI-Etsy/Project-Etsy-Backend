using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esty_Models;

namespace Esty_Applications.Services.Order
{
    public interface IOrderServices
    {
        Orders AddOrder(Orders orders);

        Orders GetOrderById(int Id);
        Orders DeleteOrder(int Id);
        public List<Orders> GetAllOrders();

        void ChangeOrderStatus(int orderId, OrderStatus status);

    }
}
