using Esty_Applications.Contract;
using Esty_Context;
using Esty_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Infrastracture.CategoryRepository
{
    public class CategoryRepository : Repository<Category, int> , ICategoryRepository
    {
        EtsyDbContext EtsyDbContext;
        public CategoryRepository(EtsyDbContext _etsyDbContext) : base(_etsyDbContext)
        {
            this.EtsyDbContext = _etsyDbContext ?? throw new ArgumentNullException(nameof(_etsyDbContext));

        }

        public async Task<Category> SearchCategoryByName(string name)
        {
            var CategorySearched = await EtsyDbContext.Set<Category>()
                               .Where(P => P.NameEN!.Contains(name) || P.NameAR!.Contains(name))
                               .FirstOrDefaultAsync();
            if (CategorySearched == null)
                return null!;
            return CategorySearched;
        }
    }
}
