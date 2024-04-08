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
        Task<ReturnResultHasObjsDTO<ReturnAllOrdersDTO>> GetAllOrders();

        Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> CreateOrder(ReturnAddUpdateOrderDTO order);

        Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> UpdateOrder(ReturnAddUpdateOrderDTO order);

        Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> DeleteOrder(int Id);

        Task<ReturnResultDTO<ReturnAddUpdateOrderDTO>> GetByOrderByID(int OrderId);

        Task ChangeOrderStatus(int orderId, OrderStatus status);

        Task<ReturnResultHasObjsDTO<ReturnAllOrdersDTO>> GetOrdersByCustomerId(string customerId);
	}
}
