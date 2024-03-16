using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    public class Orders
    {
     
        public int OrdersId { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime? ArrivedOn { get; set; }


        //Customer-Order one to many
        //public int CustomerId { get; set; }

        //public Customer? Customer { get; set; }


        //OrderItem-Order one to many
        public List<OrderItem>? OrderItems { get; set; }


        //Payment-Order one to one 
        //public Payment? Payment { get; set; }


    }
}
