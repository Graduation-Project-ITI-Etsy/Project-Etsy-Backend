
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    public class Customer :IdentityUser
    {
        public string Address { get; set; }

        public string Image { get; set; }
       
       public DateOnly BirthDate { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Orders>? Orders { get; set; }
    }
}
