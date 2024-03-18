using Etsy_DTO.Products.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Orders
{
    public class ReturnAddUpdateOrderDTO
    {
        public int OrdersId { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }


        [Required(ErrorMessage = "Adress Of Shipping is required !!")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Address should be between 5 and 255 characters")]
        public string Address { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "TotalPrice must be a positive number")]
        public double TotalPrice { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? OrderedAt { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? ArrivedOn { get; set; }


        public string? CustomerId { get; set; }

    }
}
