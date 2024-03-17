using Esty_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Dtos.Book
{
    public class GetAllPaymentDTO
    {
        public int PaymentID { get; set; }
        public double TotalPrice { get; set; }
        public string Response { get; set; }
    }
}
