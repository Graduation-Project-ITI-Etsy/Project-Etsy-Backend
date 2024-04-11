using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using Etsy_DTO.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.OrderRepository
{
	public class OrderRepository : Repository<Orders, int>, IOrdersRepository
	{
		EtsyDbContext EtsyDbContext;

		public OrderRepository(EtsyDbContext _etsyDbContext) : base(_etsyDbContext)
		{
			EtsyDbContext = _etsyDbContext ?? throw new ArgumentNullException(nameof(_etsyDbContext));
		}
		public async Task<IQueryable<ReturnAllOrdersDTO>> GetAllOrdersByCustomerId(string customerId)
		{
			var QueryResult = await EtsyDbContext.orders
							.Where(O => O.CustomerId == customerId)
							.Select(order => new ReturnAllOrdersDTO
							{
								OrdersId = order.OrdersId,
								Address = order.Address,
								TotalPrice = order.TotalPrice,
								ArrivedOn = order.ArrivedOn,
								CustomerId = order.CustomerId,
								Status = order.Status
							}).ToListAsync();
			return QueryResult.AsQueryable();
		}
	}
}

