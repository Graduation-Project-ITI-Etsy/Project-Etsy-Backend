using AutoMapper;
using Esty_Applications.Contract;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.BaseCategory;
using Etsy_DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Category
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public CategoryServices(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }
        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> CreateCategory(ReturnAddUpdateBaseCategoryDTO category)
        {
            var CategoryMapped = _mapper.Map<Esty_Models.Category>(category);

            var CategoryCreate = _CategoryRepository.CreateEntity(CategoryMapped);
            _CategoryRepository.Save();

            var CategoryAfterMap = _mapper.Map<ReturnAddUpdateCategoryDTO>(CategoryCreate);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>()
            {
                Entity = CategoryAfterMap,
                Message = "Category Created"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> DeleteCategory(int CategoryId)
        {
            var CategoryDeleted = _CategoryRepository.DeleteEntity(CategoryId);
            _CategoryRepository.Save();

            var CategoryAfterMap = _mapper.Map<ReturnAddUpdateCategoryDTO>(CategoryDeleted);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>()
            {
                Entity = CategoryAfterMap,
                Message = "Category Deleted"
            };
        }

        public ReturnResultHasObjsDTO<ReturnAllCategoryDTO> GetAllCategory()
        {
            var AllCategory = _CategoryRepository.GetAllEntity();
            var CategoryDTO = _mapper.Map<List<ReturnAllCategoryDTO>>(AllCategory);
            return new ReturnResultHasObjsDTO<ReturnAllCategoryDTO>
            {
                Entities = CategoryDTO,
                Count = AllCategory.Count,
                Message = "All Categorty were Retrieved"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> GetCategoryById(int CategoryId)
        {
            var _Category = _CategoryRepository.GetEntitybyId(CategoryId);
            var CategoryDTO = _mapper.Map<ReturnAddUpdateCategoryDTO>(_Category);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>
            {
                Entity = CategoryDTO,
                Message = "Category Found"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> SearchCategoryByName(string Name)
        {
            var CategoryResearched = _CategoryRepository.SearchCategoryByName(Name);
            var CategoryDTO = _mapper.Map<ReturnAddUpdateCategoryDTO>(CategoryResearched);
            if (CategoryResearched == null)
            {
                return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>
                {
                    Entity = null,
                    Message = "Category Not Found"
                };
            }
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>
            {
                Entity = CategoryDTO,
                Message = "Category Found"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateCategoryDTO> UpdateCategory(ReturnAddUpdateCategoryDTO category)
        {
            var CategoryMapped = _mapper.Map<Esty_Models.Category>(category);

            var CategoryUpdated = _CategoryRepository.UpdateEntity(CategoryMapped);
            _CategoryRepository.Save();

            var CategoryAfterMap = _mapper.Map<ReturnAddUpdateCategoryDTO>(CategoryUpdated);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>()
            {
                Entity = CategoryAfterMap,
                Message = "Category Updated"
            };
        }
    }
}
