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
    public sealed class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneReview(Review review) => Create(review);

        public void DeleteOneReview(Review review) => Delete(review);

        public async Task<PagedList<Review>> GetAllReviewsAsync(ReviewParameters reviewParameters, bool trackChanges)
        {
            var reviews = await FindAll(trackChanges)
                .Include(r => r.Book)
                .Include(r => r.User)
                .FilterReviews(reviewParameters.Rating)
                .FilterByUser(reviewParameters.UserId)
                .FilterByBook(reviewParameters.BookId)
                .Search(reviewParameters.SearchTerm)
                .Sort(reviewParameters.OrderBy)
                .ToListAsync();
            
            return PagedList<Review>.ToPagedList(reviews, reviewParameters.PageNumber, reviewParameters.PageSize);
        }

        // ReviewController V2 versiyonu için hazırlanan sade metod
        //public async Task<List<Review>> GetAllReviewsAsync(bool trackChanges)
        //{
        //    return await FindAll(trackChanges).OrderBy(b=>b.Id).ToListAsync();
        //}

        public async Task<Review> GetOneReviewByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges).Include(r => r.User).Include(r => r.Book).SingleOrDefaultAsync();

        public void UpdateOneReview(Review review) => Update(review);
    }
}
