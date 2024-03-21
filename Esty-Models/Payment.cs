using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public double TotalPrice { get; set; }
        public string Response { get; set; }

        public string CustomerId { get; set; }

        // Foreign key property
        public int OrderId { get; set; }
        // Navigation property
        public Orders Orders { get; set; }
    }
}
