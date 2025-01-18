using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.ReviewDto;
using DataAccess.Mappers;
using Models;
using Utility.ExtensionHelpers;

namespace AllServices.Services.ReviewContainer
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<Review?> CreateReview(CreateReviewDto createReviewDto)
        {
            var review = createReviewDto.ToCreateReviewDto();
            var createdReview = await _reviewRepo.Create(review);
            return createdReview;
        }

        public async Task<Review?> DeleteReview(int id)
        {
            var review = await _reviewRepo.GetById(id);
            if (review == null)
            {
                return null;
            }
            await _reviewRepo.Delete(review);
            return review;
        }

        public List<Review> GetAllReviews(QueryObject queryObject)
        {
            var reviews = _reviewRepo.Get().Paginate(queryObject.PageNumber, queryObject.PerPage).ToList();
            return reviews;
        }

        public async Task<Review?> GetReviewById(int id)
        {
            return await _reviewRepo.GetById(id);
        }

        public async Task<Review?> UpdateReview(UpdateReviewDto updateReviewDto, int id)
        {
            var review = await _reviewRepo.GetById(id);
            if (review == null)
            {
                return null;
            }

            review.Rating = updateReviewDto.Rating;
            review.UserId = updateReviewDto.UserId;
            review.Title = updateReviewDto.Title;
            review.ProductId = updateReviewDto.ProductId;
            review.Content = updateReviewDto.Content;
            review.ReviewText = updateReviewDto.ReviewText;

            var updatedReview = await _reviewRepo.Update(review);
            return updatedReview;
        }
    }
}