using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Task<PagedList<Review>> GetAllReviewsAsync(ReviewParameters reviewParameters, bool trackChanges);
        Task<Review> GetOneReviewByIdAsync(int id, bool trackChanges);
        void CreateOneReview(Review book);
        void UpdateOneReview(Review book);
        void DeleteOneReview(Review book);

        // ReviewController V2 versiyonu için hazırlanan sade metod
        //Task<List<Review>> GetAllReviewsAsync(bool trackChanges);
    }
}
