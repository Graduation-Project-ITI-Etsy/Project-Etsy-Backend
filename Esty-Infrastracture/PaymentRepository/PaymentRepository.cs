using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.PaymentReposatory
{
    public class PaymentRepository : Repository<Payments, int>, IPayment
    {
        EtsyDbContext EtsyDbContext;
        public PaymentRepository(EtsyDbContext EtsyDbContext) : base(EtsyDbContext)
        {
            this.EtsyDbContext = EtsyDbContext;
        }

        public Payments SerachCusromerPayById(string id)
        {
            var pay = EtsyDbContext.Set<Payments>().FirstOrDefault(s => s.CustomerId == id);
            return pay;
        }
    }

}
