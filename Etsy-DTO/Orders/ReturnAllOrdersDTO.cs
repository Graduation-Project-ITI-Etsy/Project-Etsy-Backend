using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Orders
{
    public class ReturnAllOrdersDTO
    {
        public int OrdersId { get; set; }

       public string Address { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? ArrivedOn { get; set; }

        public string? CustomerId { get; set; }


		public string? Status { get; set; }



		//>>Should I Put List or Prop From these classes that exist in Model ??? 

		//public List<OrderItemDTO> OrderItems { get; set; } // List of nested DTOs for OrderItems

		//public CustomerDTO Customer { get; set; } // Nested DTO for Customer
		// public PaymentsDTO Payments { get; set; } // Nested DTO for Payments


		//>>>>
		//For Admin
		//public string? Status { get; set; }
		//public DateTime OrderedAt { get; set; }



	}
}
