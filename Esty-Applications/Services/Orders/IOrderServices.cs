using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etsy_DTO.Payment;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.Orders;

namespace Esty_Applications.Services.Order
{
    public interface IOrderServices
    {
        public ReturnResultHasObjsDTO<ReturnAllOrdersDTO> GetAllOrders();
        public ReturnResultDTO<ReturnAddUpdateOrderDTO> CreateOrder(ReturnAddUpdateOrderDTO order);
        public ReturnResultDTO<ReturnAddUpdateOrderDTO> UpdateOrder(ReturnAddUpdateOrderDTO Order);
        public ReturnResultDTO<ReturnAddUpdateOrderDTO> DeleteOrder(ReturnAddUpdateOrderDTO Order);

        public ReturnResultDTO<ReturnAddUpdateOrderDTO> GetByOrderByID(int OrderId);

        public void ChangeOrderStatus(int orderId, OrderStatus status);

    }
}
