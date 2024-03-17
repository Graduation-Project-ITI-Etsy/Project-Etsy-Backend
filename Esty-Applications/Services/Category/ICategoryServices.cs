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
        public ReturnResultHasObjsDTO<ReturnAllCategoryDTO> GetAllCategory();

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> GetCategoryById(int CategoryId);

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> CreateCategory(ReturnAddUpdateBaseCategoryDTO category);

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> UpdateCategory(ReturnAddUpdateCategoryDTO category);

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> DeleteCategory(int CategoryId);

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> SearchByCategoryName(string Name);
    }
}
