using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
    }
}
