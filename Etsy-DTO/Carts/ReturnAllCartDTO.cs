using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Carts
{
    public class ReturnAllCartDTO
    {
        public int CartID { get; set; }

        public int ProductId { get; set; }

        public string CustomerId { get; set; }

        public int Quantity { get; set; }
    }
}
