using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using Microsoft.EntityFrameworkCore;
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
            this.EtsyDbContext = EtsyDbContext ?? throw new ArgumentNullException(nameof(EtsyDbContext));
        }

       
        public async Task<Payments> SerachCusromerPayById(string id)
        {
            return await EtsyDbContext.Set<Payments>().FirstOrDefaultAsync(s => s.CustomerId == id);
        }
    }

}
