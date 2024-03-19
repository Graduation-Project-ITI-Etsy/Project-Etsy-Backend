using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Esty_Applications.Contract;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.OrderItem;
using Etsy_DTO.Orders;


namespace Esty_Applications.Services.OrderItems
{
    public class OrderItemsServices : IOrderItemsServices
    {
        private readonly IOrderItemRepository _OrderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemsServices(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _OrderItemRepository = orderItemRepository;
            _mapper = mapper;

        }

  
        public ReturnResultDTO<ReturnAddUpdateOrderItemsDTO> AddOrderItem(ReturnAddUpdateOrderItemsDTO OrderItemDto)
        {
            try
            {
                var orderItemEntity = _mapper.Map<OrderItem>(OrderItemDto);
                var createdOrderItem = _OrderItemRepository.CreateEntity(orderItemEntity);
                _OrderItemRepository.Save();

                var createdOrderItemDto = _mapper.Map<ReturnAddUpdateOrderItemsDTO>(createdOrderItem);

                return new ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>
                {
                    Entity = createdOrderItemDto,
                    Message = "Order item added successfully"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the order item: {ex.Message}");

                return new ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>
                {
                    Entity = null,
                    Message = $"Failed to add the order item: {ex.Message}"
                };
            }
        }


        public ReturnResultDTO<ReturnAddUpdateOrderItemsDTO> DeleteOrderItem(ReturnAddUpdateOrderItemsDTO OrderItemDto)
        {
            try
            {
                var orderItemEntity = _mapper.Map<OrderItem>(OrderItemDto);
                var deletedOrderItem = _OrderItemRepository.DeleteEntity(orderItemEntity.OrdersId);

                if (deletedOrderItem == null)
                {
                    throw new InvalidOperationException("Failed to delete order item. Item not found.");
                }

                _OrderItemRepository.Save();

                var deletedOrderItemDto = _mapper.Map<ReturnAddUpdateOrderItemsDTO>(deletedOrderItem);

                return new ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>
                {
                    Entity = deletedOrderItemDto,
                    Message = "Order item deleted successfully"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the order item: {ex.Message}");

                return new ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>
                {
                    Entity = null,
                    Message = $"Failed to delete the order item: {ex.Message}"
                };
            }
        }
    }
}
