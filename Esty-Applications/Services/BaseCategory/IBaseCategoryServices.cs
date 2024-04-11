using Etsy_DTO;
using Etsy_DTO.BaseCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.BaseCategory
{
    public interface IBaseCategoryServices
    {


        Task<ReturnResultHasObjsDTO<ReturnAllBaseCategoryDTO>> GetAllBaseCategorypag(int CategoriesPerPage, int PageNumber);
        Task<ReturnResultHasObjsDTO<ReturnAllBaseCategoryDTO>> GetAllBaseCategory();

        Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> GetBaseCategoryById(int BaseCategoryId);

        Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> CreateBaseCategory(ReturnAddUpdateBaseCategoryDTO basecategory);

        Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> UpdateBaseCategory(ReturnAddUpdateBaseCategoryDTO basecategory);

        Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> DeleteBaseCategory(int BaseCategoryId);

        Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> SearchBaseCategoryByName(string Name);

        public Task<int> BaseCategoryCount();


    }
}
