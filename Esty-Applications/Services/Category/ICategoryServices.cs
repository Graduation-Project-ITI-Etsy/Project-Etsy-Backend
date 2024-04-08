using Etsy_DTO.BaseCategory;
using Etsy_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etsy_DTO.Category;
using Esty_Applications.Contract;

namespace Esty_Applications.Services.Category
{
    public interface ICategoryServices
    {
        public Task<ReturnResultHasObjsDTO<ReturnAllCategoryDTO>> GetCategoriesByBaseCategoryId(int BaseCategoryId);

        public Task<ReturnResultHasObjsDTO<ReturnAllCategoryDTO>> GetAllCategory();

        public  Task<ReturnResultHasObjsDTO<ReturnAllCategoryDTO>> GetAllCategorypag(int CategoriesPerPage, int PageNumber);


        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> GetCategoryById(int CategoryId);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> CreateCategory(ReturnAddUpdateCategoryDTO category);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> UpdateCategory(ReturnAddUpdateCategoryDTO category);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> DeleteCategory(int CategoryId);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> SearchCategoryByName(string Name);

    }
}
