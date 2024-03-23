using AutoMapper;
using Esty_Applications.Contract;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.BaseCategory;
using Etsy_DTO.Category;
using Etsy_DTO.Products;
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

        public async Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> CreateCategory(ReturnAddUpdateBaseCategoryDTO category)
        {
            var CategoryMapped = _mapper.Map<Esty_Models.Category>(category);

            var CategoryCreate = await _CategoryRepository.CreateEntity(CategoryMapped);
            await _CategoryRepository.Save();

            var CategoryAfterMap = _mapper.Map<ReturnAddUpdateCategoryDTO>(CategoryCreate);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>()
            {
                Entity = CategoryAfterMap,
                Message = "Category Created"
            };

        }

        public async Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> DeleteCategory(int CategoryId)
        {
            var CategoryDeleted = await _CategoryRepository.DeleteEntity(CategoryId);
            await _CategoryRepository.Save();

            var CategoryAfterMap = _mapper.Map<ReturnAddUpdateCategoryDTO>(CategoryDeleted);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>()
            {
                Entity = CategoryAfterMap,
                Message = "Category Deleted"
            };
        }

        public async Task<ReturnResultHasObjsDTO<ReturnAllCategoryDTO>> GetAllCategory()
        {
            var AllCategoryQuery = await _CategoryRepository.GetAllEntity();
            var AllCategory = AllCategoryQuery.ToList();

            var CategoryDTO = _mapper.Map<List<ReturnAllCategoryDTO>>(AllCategory);
            return new ReturnResultHasObjsDTO<ReturnAllCategoryDTO>
            {
                Entities = CategoryDTO,
                Count = AllCategory.Count,
                Message = "All Categorty were Retrieved"
            };

        }

        public async Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> GetCategoryById(int CategoryId)
        {
            var _Category = await _CategoryRepository.GetEntitybyId(CategoryId);
            var CategoryDTO = _mapper.Map<ReturnAddUpdateCategoryDTO>(_Category);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>
            {
                Entity = CategoryDTO,
                Message = "Category Found"
            };


        }

        public async Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> SearchCategoryByName(string Name)
        {
            var CategoryResearched = await _CategoryRepository.SearchCategoryByName(Name);
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

        public async Task<ReturnResultDTO<ReturnAddUpdateCategoryDTO>> UpdateCategory(ReturnAddUpdateCategoryDTO category)
        {
            var CategoryMapped = _mapper.Map<Esty_Models.Category>(category);

            var CategoryUpdated = await _CategoryRepository.UpdateEntity(CategoryMapped);
            await _CategoryRepository.Save();

            var CategoryAfterMap = _mapper.Map<ReturnAddUpdateCategoryDTO>(CategoryUpdated);
            return new ReturnResultDTO<ReturnAddUpdateCategoryDTO>()
            {
                Entity = CategoryAfterMap,
                Message = "Category Updated"
            };

        }

        public async Task<ReturnResultHasObjsDTO<ReturnAllCategoryDTO>> GetCategoriesByBaseCategoryId(int BaseCategoryId)
        {

            var CategoriesByBaseCategoryId = await _CategoryRepository.GetCategoriesByBaseCategoryId(BaseCategoryId);
            var FilterCategories = CategoriesByBaseCategoryId
                .Select(_Categories => new ReturnAllCategoryDTO
                {
                    Id = _Categories.Id,
                    NameEN = _Categories.NameEN,
                    NameAR = _Categories.NameAR,
                    BaseCategoryId = BaseCategoryId
                }).ToList();

            if (FilterCategories != null)
            {
                return new ReturnResultHasObjsDTO<ReturnAllCategoryDTO>()
                {
                    Entities = FilterCategories,
                    Count = FilterCategories.Count(),
                    Message = "All Products were Retrieved"
                };
            }

            return new ReturnResultHasObjsDTO<ReturnAllCategoryDTO>()
            {
                Entities = null,
                Message = "The Object returned from the Created view is Null !!"
            };
        }
    }
}
