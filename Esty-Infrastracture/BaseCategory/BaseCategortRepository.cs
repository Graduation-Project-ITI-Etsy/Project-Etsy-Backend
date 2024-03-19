using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
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
            this.EtsyDbContext = EtsyDbContext;
        }

        public BaseCategory SearchBaseCategoryByName(string name)
        {
            var BaseCategorySearched = EtsyDbContext?.Set<BaseCategory>()
                           ?.Where(P => P.NameEN!.Contains(name) || P.NameAR!.Contains(name))
                           ?.FirstOrDefault();
            if (BaseCategorySearched == null)
                return null!;
            return BaseCategorySearched;
        }
    }
}
