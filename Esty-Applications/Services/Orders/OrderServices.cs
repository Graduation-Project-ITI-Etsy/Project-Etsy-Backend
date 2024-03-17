using AutoMapper;
using Ecommerce.Dtos.Book;
using Esty_Applications.Contract;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.Orders;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Order
{
    public class OrderServices : IOrderServices
    {

        private readonly IOrdersRepository _OrderRepository;
        private readonly IMapper _mapper;

        public OrderServices(IOrdersRepository orderRepository, IMapper mapper)
        {
            _OrderRepository = orderRepository;
            _mapper = mapper;

        }


        public ReturnResultHasObjsDTO<ReturnAllOrdersDTO> GetAllOrders()
        {
            var AllOrders = _OrderRepository.GetAllEntity();
            var OrderDto = _mapper.Map<List<ReturnAllOrdersDTO>>(AllOrders);

            return new ReturnResultHasObjsDTO<ReturnAllOrdersDTO>
            {
                Entities = OrderDto,
                Count = AllOrders.Count(),
                Message = "All Orders were Retrieved"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateOrderDTO> CreateOrder(ReturnAddUpdateOrderDTO orderDto)
        {

            var orderEntity = _mapper.Map<Orders>(orderDto);

            var createdOrder = _OrderRepository.CreateEntity(orderEntity);
            _OrderRepository.Save();

            var createdOrderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(createdOrder);

            return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
            {
                Entity = createdOrderDto,
                Message = "Order created successfully"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateOrderDTO> UpdateOrder(ReturnAddUpdateOrderDTO Order)
        {
            var orderEntity = _mapper.Map<Orders>(Order);
            var updatedOrder = _OrderRepository.UpdateEntity(orderEntity);
            _OrderRepository.Save();

            var updatedOrderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(updatedOrder);

            return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
            {
                Entity = updatedOrderDto,
                Message = "Order updated successfully"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateOrderDTO> DeleteOrder(ReturnAddUpdateOrderDTO Order)
        {
            var orderEntity = _mapper.Map<Orders>(Order);
            var deletedOrder = _OrderRepository.DeleteEntity(orderEntity.OrdersId);
            _OrderRepository.Save();

            var deletedOrderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(deletedOrder);

            return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
            {
                Entity = deletedOrderDto,
                Message = "Order deleted successfully"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateOrderDTO> GetByOrderByID(int OrderId)
        {
            var order = _OrderRepository.GetEntitybyId(OrderId);
            var orderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(order);

            return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
            {
                Entity = orderDto,
                Message = "Order retrieved successfully"
            };
        }


        public void ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var order = _OrderRepository.GetEntitybyId(orderId);
            if (order != null)
            {
                order.Status = status.ToString();
                _OrderRepository.Save();
            }
            else
            {
                throw new Exception("Order not found");
            }
        }


    }

}
