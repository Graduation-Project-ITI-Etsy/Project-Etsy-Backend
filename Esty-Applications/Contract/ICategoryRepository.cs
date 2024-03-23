using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface ICategoryRepository : IRepo<Category, int>
    {
        Task<Category> SearchCategoryByName(string name);

        Task<IQueryable<Category>> GetCategoriesByBaseCategoryId(int BaseCategoryId);
    }
}
