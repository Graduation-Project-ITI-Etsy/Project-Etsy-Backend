using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    public class Cart
    {
        public int CartID { get; set; }

        public Products? products { get; set; }
        public int ProductId { get; set; }

        public Customer? customer { get; set; }
        public int CustomerId { get; set; }

        public int Quantity { get; set; }
    }
}
