using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class ReviewRepositoryExtensions
    {     
        public static IQueryable<Review> FilterReviews(this IQueryable<Review> reviews, int? rating)
        {
            if (rating.HasValue)
                reviews = reviews.Where(review => review.Rating == rating);

            return reviews;
        }
        public static IQueryable<Review> Search(this IQueryable<Review> reviews, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return reviews;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return reviews.Where(review => review.Comment.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Review> Sort(this IQueryable<Review> reviews, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return reviews.OrderBy(b => b.Id);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Review>(orderByQueryString);

            if (orderQuery is null)
                return reviews.OrderBy(b => b.Id);

            return reviews.OrderBy(orderQuery);
        }

        public static IQueryable<Review> FilterByUser(this IQueryable<Review> reviews, String? userId)
        {
            if (!string.IsNullOrWhiteSpace(userId))
                reviews = reviews.Where(review => review.UserId.Equals(userId));

            return reviews;
        }

        public static IQueryable<Review> FilterByBook(this IQueryable<Review> reviews, int? bookId)
        {
            if (bookId.HasValue)
                reviews = reviews.Where(review => review.BookId == bookId.Value);

            return reviews;
        }

    }
}
