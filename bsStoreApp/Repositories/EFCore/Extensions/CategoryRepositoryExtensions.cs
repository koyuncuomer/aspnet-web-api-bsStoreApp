using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class CategoryRepositoryExtensions
    {
        public static IQueryable<Category> Sort(this IQueryable<Category> categories, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return categories.OrderBy(c => c.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Category>(orderByQueryString);

            if (orderQuery is null)
                return categories.OrderBy(c => c.Name);

            return categories.OrderBy(orderQuery);
        }

        public static IQueryable<Category> Search(this IQueryable<Category> categories, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return categories;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return categories.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
