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
            var orderItemEntity = _mapper.Map<OrderItem>(OrderItemDto);
            var createdOrderItem = _OrderItemRepository.CreateEntity(orderItemEntity);
            _OrderItemRepository.Save();
            var createdOrderItemDto = _mapper.Map<ReturnAddUpdateOrderItemsDTO>(createdOrderItem);

            return new ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>
            {
                Entity = createdOrderItemDto,
                Message = "OrderItem is Added successfully"
            };
        }


        public ReturnResultDTO<ReturnAddUpdateOrderItemsDTO> DeleteOrderItem(ReturnAddUpdateOrderItemsDTO OrderItemDto)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(OrderItemDto);
            var decreaseOrderItem = _OrderItemRepository.DeleteEntity(orderItemEntity.OrdersId);
            _OrderItemRepository.Save();
            var decreaseOrderItemDto = _mapper.Map<ReturnAddUpdateOrderItemsDTO>(decreaseOrderItem);

            return new ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>
            {
                Entity = decreaseOrderItemDto,
                Message = "OrderItem is decreased successfully"
            };
        }
    }
}
