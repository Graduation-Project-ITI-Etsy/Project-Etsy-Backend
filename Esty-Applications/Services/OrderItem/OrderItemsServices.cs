using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esty_Applications.Contract;
using Esty_Models;


namespace Esty_Applications.Services.OrderItems
{
    public class OrderItemsServices : IOrderItemsServices
    {
        IOrderItemRepository _OrderItemRepository { get; set; }
        public OrderItemsServices(IOrderItemRepository orderItemRepository)
        {
            _OrderItemRepository = orderItemRepository;

        }


        public OrderItem AddItem(OrderItem item)
        {
            var orderItem = _OrderItemRepository.CreateEntity(item);
            if (orderItem != null)
            {
                _OrderItemRepository.Save();
            }
            return orderItem;
        }

        public OrderItem DeleteItem(int Id)
        {
            var orderItem = _OrderItemRepository.DeleteEntity(Id);
            if (orderItem != null)
            {
                _OrderItemRepository.Save();
            }
            return orderItem;
        }
    }
}
