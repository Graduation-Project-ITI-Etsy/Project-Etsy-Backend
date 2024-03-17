using Esty_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Dtos.Book
{
    public class CreateOrUpdatePaymentDTO
    {
        public int PaymentID { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "TotalPrice must be a positive number")]
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "Response is required !")]

        public string Response { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }
    }
}
