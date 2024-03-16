using Esty_Applications.Contract;
using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Order
{
    public class OrderServices : IOrderServices
    {

        IOrdersRepository _OrderRepository { get; set; }

        public OrderServices(IOrdersRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }


        Orders IOrderServices.AddOrder(Orders orders)
        {
            var order = _OrderRepository.CreateEntity(orders);
            if(order != null)
            {
                _OrderRepository.Save();
            }
            return order;
        }


        public Orders GetOrderById(int Id)
        {
            var order = _OrderRepository.GetEntitybyId(Id);

            return order;
        }

      
        Orders IOrderServices.DeleteOrder(int Id)
        {
            var order = _OrderRepository.DeleteEntity(Id);
            if (order != null)
            {
                _OrderRepository.Save();
            }
            return order;
        }

        public List<Orders> GetAllOrders()
        {
            var order = _OrderRepository.GetAllEntity();
            return order;
        }

        
        public void ChangeOrderStatus(int orderId, OrderStatus status)
        {
            _OrderRepository.GetEntitybyId(orderId).Status = status.ToString();
        }


    }

}
