using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.OrderItem
{
    public class ReturnAddUpdateOrderItemsDTO
    {
        public int OrderItemId { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        public int Quantity { get; set; }


        public int ProductId { get; set; }
        public int OrdersId { get; set; }

    }
}
