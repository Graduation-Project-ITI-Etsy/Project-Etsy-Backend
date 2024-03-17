using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.OrderItem
{
    public class ReturnAllOrderItemsDTO
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public int OrdersId { get; set; }

    }
}
