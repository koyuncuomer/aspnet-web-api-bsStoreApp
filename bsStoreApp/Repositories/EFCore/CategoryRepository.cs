using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCategory(Category category) => Create(category);

        public void DeleteOneCategory(Category category) => Delete(category);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Search(categoryParameters.SearchTerm)
                .Sort(categoryParameters.OrderBy)
                .ToListAsync();
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateOneCategory(Category category) => Update(category);
    }
}
