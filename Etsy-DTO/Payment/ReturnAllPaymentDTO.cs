using Esty_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Orders
{
    public class ReturnAllPaymentDTO
    {
        public int PaymentID { get; set; }
        public double TotalPrice { get; set; }
        public string Response { get; set; }
    }
}
