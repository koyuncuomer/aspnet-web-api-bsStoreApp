using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DataTransferObjects.Category;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            return await _manager.Category.GetAllCategoriesAsync(categoryParameters, trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return await GetOneCategoryByIdAndCheckExists(id, trackChanges);
        }

        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);
            _manager.Category.CreateOneCategory(entity);
            await _manager.SaveAsync();

            return _mapper.Map<CategoryDto>(entity);
        }

        private async Task<Category> GetOneCategoryByIdAndCheckExists(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(id);

            return category;
        }

        public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExists(id, trackChanges);
            entity = _mapper.Map<Category>(categoryDto);
            _manager.Category.Update(entity);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExists(id, trackChanges);
            _manager.Category.DeleteOneCategory(entity);
            await _manager.SaveAsync();
        }
    }
}
