using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.ReviewDto;
using Models;

namespace AllServices.Services.ReviewContainer
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();

        Task<Review?> GetReviewById(int id);

        Task<Review?> CreateReview(CreateReviewDto createReviewDto);

        Task<Review?> DeleteReview(int id);

        Task<Review?> UpdateReview(UpdateReviewDto updateReviewDto, int id);
    }
}