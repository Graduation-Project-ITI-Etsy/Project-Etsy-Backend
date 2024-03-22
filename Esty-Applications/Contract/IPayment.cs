using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface IPayment : IRepo<Payments, int>
    {
        Task<Payments> SerachCusromerPayById(string id);
    }


}
