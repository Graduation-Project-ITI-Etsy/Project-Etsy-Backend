using AutoMapper;
using Esty_Applications.Contract;
using Esty_Applications.Services.BaseCategory;
using Esty_Applications.Services.BaseCategoryServices;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.BaseCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.BaseCategoryServices
{
    public class BaseCategoryServices : IBaseCategoryServices
    {
        private readonly IBaseCategoryRepository _baseCategoryRepository ;
        private readonly IMapper _mapper;

        public BaseCategoryServices(IBaseCategoryRepository baseCategoryRepository, IMapper mapper)
        {
            _baseCategoryRepository = baseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> CreateBaseCategory(ReturnAddUpdateBaseCategoryDTO baseCategory)
        {
            var baseCategoryMapped = _mapper.Map<Esty_Models.BaseCategory>(baseCategory);
            var BaseCreate = _baseCategoryRepository.CreateEntity(baseCategoryMapped);
            await _baseCategoryRepository.Save();
            var BaseCategoryAfterMap = _mapper.Map<ReturnAddUpdateBaseCategoryDTO>(BaseCreate);
            return new ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>()
            {
                Entity = BaseCategoryAfterMap,
                Message = "Base Category Created"
            };
            
        }

        public async Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> DeleteBaseCategory(int BaseCategoryId)
        {
            var BaseDeleted = _baseCategoryRepository.DeleteEntity(BaseCategoryId);
            await _baseCategoryRepository.Save();
            var BaseCategoryAfterMap = _mapper.Map<ReturnAddUpdateBaseCategoryDTO>(BaseDeleted);
            return new ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>()
            {
                Entity = BaseCategoryAfterMap,
                Message = "Base Category Deleted"
            };
           
        }

        public async Task<ReturnResultHasObjsDTO<ReturnAllBaseCategoryDTO>> GetAllBaseCategory()
        {

            var AllBaseCategoryQuery = await _baseCategoryRepository.GetAllEntity();
            var allBaseCategory = AllBaseCategoryQuery.ToList();

            var BaseCategoryDTO = _mapper.Map<List<ReturnAllBaseCategoryDTO>>(allBaseCategory);
            return new ReturnResultHasObjsDTO<ReturnAllBaseCategoryDTO>
            {
                Entities = BaseCategoryDTO,
                Count = allBaseCategory.Count,
                Message = "All Base Category were Retrieved"
            };
           
        }

        public async Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> GetBaseCategoryById(int BaseCategoryId)
        {
            var _BaseCategory = await _baseCategoryRepository.GetEntitybyId(BaseCategoryId);
            var BaseCategoryDTO = _mapper.Map<ReturnAddUpdateBaseCategoryDTO>(_BaseCategory);
            return new ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>
            {
                Entity = BaseCategoryDTO,
                Message = "Base Category Found"
            };
          
        }

        public async Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>>  SearchBaseCategoryByName(string Name)
        {
            var BaseCategoryResearched = await _baseCategoryRepository.SearchBaseCategoryByName(Name);
            var BaseCategoryDTO = _mapper.Map<ReturnAddUpdateBaseCategoryDTO>(BaseCategoryResearched);
            if (BaseCategoryResearched == null)
            {
                return new ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>
                {
                    Entity = null,
                    Message = "Base Category Not Found"
                };
            }
            return new ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>
            {
                Entity = BaseCategoryDTO,
                Message = "Base Category Found"
            };
           
        }

        public async Task<ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>> UpdateBaseCategory(ReturnAddUpdateBaseCategoryDTO basecategory)
        {
            var baseCategoryMapped = _mapper.Map<Esty_Models.BaseCategory>(basecategory);
            var BaseUpdated = _baseCategoryRepository.UpdateEntity(baseCategoryMapped);
            await _baseCategoryRepository.Save();
            var BaseCategoryAfterMap = _mapper.Map<ReturnAddUpdateBaseCategoryDTO>(BaseUpdated);
            return new ReturnResultDTO<ReturnAddUpdateBaseCategoryDTO>()
            {
                Entity = BaseCategoryAfterMap,
                Message = "Base Category Updated"
            };
        }
    }
}
