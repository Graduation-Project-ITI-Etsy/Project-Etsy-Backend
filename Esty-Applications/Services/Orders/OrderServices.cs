﻿using AutoMapper;
using Etsy_DTO.Payment;
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


        public async Task<ReturnResultHasObjsDTO<ReturnAllOrdersDTO>> GetAllOrders()
        {
            try
            {
                var allOrders = await _OrderRepository.GetAllEntity();
                var orderDtos = _mapper.Map<List<ReturnAllOrdersDTO>>(allOrders);

                return new ReturnResultHasObjsDTO<ReturnAllOrdersDTO>
                {
                    Entities = orderDtos,
                    Count = orderDtos.Count,
                    Message = "All orders were retrieved successfully"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all orders: {ex.Message}");
                return new ReturnResultHasObjsDTO<ReturnAllOrdersDTO>
                {
                    Entities = null,
                    Count = 0,
                    Message = $"Failed to retrieve all orders: {ex.Message}"
                };
            }

        }

        public async Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> CreateOrder(ReturnAddUpdateOrderDTO orderDto)
        {
            try
            {
                var orderEntity = _mapper.Map<Orders>(orderDto);
                var createdOrder = _OrderRepository.CreateEntity(orderEntity);
                await _OrderRepository.Save();

                var createdOrderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(createdOrder);

                return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                {
                    Entity = createdOrderDto,
                    Message = "Order created successfully"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the order: {ex.Message}");
                return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                {
                    Entity = null,
                    Message = $"Failed to create the order: {ex.Message}"
                };
            }

        }

        public async Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> UpdateOrder(ReturnAddUpdateOrderDTO orderDto)
        {
            try
            {
                var orderEntity = _mapper.Map<Orders>(orderDto);
                var updatedOrder = _OrderRepository.UpdateEntity(orderEntity);
                await _OrderRepository.Save();

                var updatedOrderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(updatedOrder);

                return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                {
                    Entity = updatedOrderDto,
                    Message = "Order updated successfully"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the order: {ex.Message}");
                return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                {
                    Entity = null,
                    Message = $"Failed to update the order: {ex.Message}"
                };
            }

        }

        public async Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> DeleteOrder(int Id)
        {
            try
            {
                var deletedOrder = _OrderRepository.DeleteEntity(Id);
                await _OrderRepository.Save();

                var deletedOrderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(deletedOrder);

                return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                {
                    Entity = deletedOrderDto,
                    Message = "Order deleted successfully"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the order: {ex.Message}");
                return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                {
                    Entity = null,
                    Message = $"Failed to delete the order: {ex.Message}"
                };
            }

        }

        public async Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> GetByOrderByID(int OrderId)
        {
            try
            {
                var order = await _OrderRepository.GetEntitybyId(OrderId);

                if (order != null)
                {
                    var orderDto = _mapper.Map<ReturnAddUpdateOrderDTO>(order);
                    return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                    {
                        Entity = orderDto,
                        Message = "Order retrieved successfully"
                    };
                }
                else
                {
                    return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                    {
                        Entity = null,
                        Message = "Order not found"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the order: {ex.Message}");
                return new ReturnResultDTO<ReturnAddUpdateOrderDTO>
                {
                    Entity = null,
                    Message = $"Failed to retrieve the order: {ex.Message}"
                };
            }
        }


        public async Task ChangeOrderStatus(int orderId, OrderStatus status)
        {
            try
            {
                var order = await _OrderRepository.GetEntitybyId(orderId);

                if (order != null)
                {
                    order.Status = status.ToString();
                    await _OrderRepository.Save();
                }
                else
                {
                    throw new Exception("Order not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while changing the order status: {ex.Message}");
                throw;
            }
        }


    }

}
