using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Book;
using Entities.DataTransferObjects.Review;
using Entities.Exceptions;
using Entities.Extensions;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using static Entities.Exceptions.BadRequestException;

namespace Services
{
    public class ReviewManager : IReviewService
    {
        private readonly IBookService _bookService;
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ReviewManager(IBookService bookService, IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _bookService = bookService;
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ReviewDto> CreateOneReviewAsync(ReviewDtoForInsertion reviewDto)
        {
            // reviewDtodan gelen kitaba göre öyle bir kitap var mı kontrolü için
            // YAPILACAK! Bu kontrolü User için de gerçekleştir.
            var book = await _bookService.GetOneBookByIdAsync(reviewDto.BookId, false);

            var entity = _mapper.Map<Review>(reviewDto);
            _manager.Review.CreateOneReview(entity);
            await _manager.SaveAsync();
            //return _mapper.Map<ReviewDto>(entity);

            var createdReview = await _manager.Review.GetOneReviewByIdAsync(entity.Id, trackChanges: false);
            return _mapper.Map<ReviewDto>(createdReview);
        }

        public async Task DeleteOneReviewAsync(int id, bool trackChanges)
        {
            var entity = await GetOneReviewByIdAndCheckExists(id, trackChanges);
            _manager.Review.DeleteOneReview(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ReviewDto> reviews, MetaData metaData)> GetAllReviewsAsync(ReviewParameters reviewParameters, bool trackChanges)
        {
            if ((!reviewParameters.ValidRatingRange) && reviewParameters.HasRating)
                throw new RatingOutOfRangeBadRequestException();

            var reviewsWithMetaData = await _manager.Review.GetAllReviewsAsync(reviewParameters, trackChanges);
            var reviewsDto = reviewsWithMetaData.ToMappedPagedList<Review, ReviewDto>(_mapper);

            return (reviewsDto, reviewsWithMetaData.MetaData);
        }

        // ReviewController V2 versiyonu için hazırlanan sade metod
        //public async Task<List<Review>> GetAllReviewsAsync(bool trackChanges)
        //{
        //    var reviews = await _manager.Review.GetAllReviewsAsync(trackChanges);
        //    return reviews;
        //}

        public async Task<ReviewDto> GetOneReviewByIdAsync(int id, bool trackChanges)
        {
            var review = await GetOneReviewByIdAndCheckExists(id, trackChanges);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task UpdateOneReviewAsync(int id, ReviewDtoForUpdate reviewDto, bool trackChanges)
        {
            var entity = await GetOneReviewByIdAndCheckExists(id, trackChanges);
            entity = _mapper.Map<Review>(reviewDto);

            // reviewDtodan gelen kitaba göre öyle bir kitap var mı kontrolü için
            // YAPILACAK! Bu kontrolü User için de gerçekleştir.
            var book = await _bookService.GetOneBookByIdAsync(reviewDto.BookId, false);

            _manager.Review.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Review> GetOneReviewByIdAndCheckExists(int id, bool trackChanges)
        {
            var review = await _manager.Review.GetOneReviewByIdAsync(id, trackChanges);
            if (review is null)
                throw new ReviewNotFoundException(id);

            return review;
        }
    }
}
