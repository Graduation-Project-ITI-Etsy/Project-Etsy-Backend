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
        public ReturnResultHasObjsDTO<ReturnAllBaseCategoryDTO> GetAllBaseCategory();

        public ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO> GetBaseCategoryById (int BaseCategoryId);

        public ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO> CreateBaseCategory(ReturnAddUpdateBaseCategoryDTO basecategory);

        public ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO> UpdateBaseCategory(ReturnAddUpdateBaseCategoryDTO basecategory);

        public ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO> DeleteBaseCategory(int BaseCategoryId);

        public ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO> SearchBaseCategoryByName(string Name);
    }
}
