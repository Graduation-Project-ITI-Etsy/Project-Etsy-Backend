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
        public double TotalPrice { get; set; }
        public string Response { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }
    }
}
