using Esty_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Carts
{
    public class ReturnAddUpdateCartDTO
    {
        public int CartID { get; set; }

        [Required(ErrorMessage = "Product Id is required !!")]
        [Range(0, double.MaxValue, ErrorMessage = "Product Id must be a positive number")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Customer Id is required !!")]
        public string? CustomerId { get; set; }

        [Required(ErrorMessage = "Quantity is required !!")]
        [Range(0, double.MaxValue, ErrorMessage = "Product Id must be a positive number")]
        public int Quantity { get; set; }
    }
}
