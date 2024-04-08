using Esty_Models;
using Etsy_DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface IOrdersRepository : IRepo<Orders, int>
    {
		public Task<IQueryable<ReturnAllOrdersDTO>> GetAllCartsByCustomerId(string customerId);
	}
}
