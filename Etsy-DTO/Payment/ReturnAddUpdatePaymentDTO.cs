using Esty_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Payment
{
    public class ReturnAddUpdatePaymentDTO
    {
        public int PaymentID { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "TotalPrice must be a positive number")]
        public double TotalPrice { get; set; }


        [Required(ErrorMessage = "Response is required !")]
        public string Response { get; set; }

        public string CustomerId { get; set; }

        public int OrderId { get; set; }
    }
}
