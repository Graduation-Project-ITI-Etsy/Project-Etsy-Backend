﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esty_Models;
using Etsy_DTO.Orders;
using Etsy_DTO;
using Etsy_DTO.OrderItem;

namespace Esty_Applications.Services.OrderItems
{
    public interface IOrderItemsServices
    {
   
        public Task<ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>> AddOrderItem(ReturnAddUpdateOrderItemsDTO OrderItemDto);

        public Task<ReturnResultDTO<ReturnAddUpdateOrderItemsDTO>> DeleteOrderItem(int Id);


    }
}
