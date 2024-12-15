using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        // IRepositoryBase'den gelen metodlar direkt kullanılabilir. Onun yerine kendi metodları tanımlanacak.
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
        void CreateOneCategory(Category category);
        void DeleteOneCategory(Category category);
        void UpdateOneCategory(Category category);
    }
}
