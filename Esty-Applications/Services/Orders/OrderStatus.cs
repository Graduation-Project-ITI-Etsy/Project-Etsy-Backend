using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Order
{

    public enum OrderStatus
    {
        Placed,
        Confirm,
        Shipped,
        Delivered,
        Canceled,
        Return
    }
}
