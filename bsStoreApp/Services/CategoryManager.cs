using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            return await _manager.Category.GetAllCategoriesAsync(categoryParameters, trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return await GetOneCategoryByIdAndCheckExists(id, trackChanges);
        }

        private async Task<Category> GetOneCategoryByIdAndCheckExists(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(id);

            return category;
        }
    }
}
