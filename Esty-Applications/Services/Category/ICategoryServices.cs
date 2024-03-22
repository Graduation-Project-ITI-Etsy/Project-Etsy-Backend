using Etsy_DTO.BaseCategory;
using Etsy_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etsy_DTO.Category;

namespace Esty_Applications.Services.Category
{
    public interface ICategoryServices
    {


        public Task<ReturnResultHasObjsDTO<ReturnAllCategoryDTO>> GetAllCategory();

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> GetCategoryById(int CategoryId);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> CreateCategory(ReturnAddUpdateBaseCategoryDTO category);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> UpdateCategory(ReturnAddUpdateCategoryDTO category);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> DeleteCategory(int CategoryId);

        public Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> SearchCategoryByName(string Name);

    }
}
