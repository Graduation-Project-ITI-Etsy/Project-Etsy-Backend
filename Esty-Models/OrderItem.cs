using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    //Product-Order many to many

    public class OrderItem
    {
       
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }



        //Product-OrderItem one to many

        //public Product? Product { get; set; }
        //public int ProductId { get; set; }

        public Orders? Orders { get; set; }
        public int OrdersId { get; set; }


    }
}
