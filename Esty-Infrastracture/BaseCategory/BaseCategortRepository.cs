using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.BaseCategortRepository
{
    public class BaseCategortRepository : Repository<BaseCategory , int> , IBaseCategoryRepository
    {
        EtsyDbContext EtsyDbContext;

        public BaseCategortRepository(EtsyDbContext EtsyDbContext) : base(EtsyDbContext)
        {
            this.EtsyDbContext = EtsyDbContext ?? throw new ArgumentNullException(nameof(EtsyDbContext));
    }

        public async Task<BaseCategory> SearchBaseCategoryByName(string name)
        {
            var baseCategorySearched = await EtsyDbContext.Set<BaseCategory>()
                      .Where(P => P.NameEN!.Contains(name) || P.NameAR!.Contains(name))
                      .FirstOrDefaultAsync();
            return baseCategorySearched;
        }
    }
}
