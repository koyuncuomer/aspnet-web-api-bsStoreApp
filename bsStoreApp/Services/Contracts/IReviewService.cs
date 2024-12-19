using Entities.DataTransferObjects.Book;
using Entities.DataTransferObjects.Review;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IReviewService
    {
        Task<(IEnumerable<ReviewDto> reviews, MetaData metaData)> GetAllReviewsAsync(ReviewParameters reviewParameters, bool trackChanges);
        Task<ReviewDto> GetOneReviewByIdAsync(int id, bool trackChanges);
        Task<ReviewDto> CreateOneReviewAsync(ReviewDtoForInsertion reviewDto);
        Task UpdateOneReviewAsync(int id, ReviewDtoForUpdate reviewDto, bool trackChanges);
        Task DeleteOneReviewAsync(int id, bool trackChanges);
    }
}
