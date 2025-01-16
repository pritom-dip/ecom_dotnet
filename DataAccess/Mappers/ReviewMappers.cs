using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.ReviewDto;
using Models;

namespace DataAccess.Mappers
{
    public static class ReviewMappers
    {
        public static ReviewDto ToReviewDto(this Review review){
            return new ReviewDto
            {
                Id = review.Id,
                ProductId = review.ProductId,
                UserId = review.UserId,
                Title = review.Title,
                Content = review.Content,
                Rating = review.Rating,
                ReviewText = review.ReviewText,
                CreateAt = review.CreateAt,
                UpdatedAt = review.UpdatedAt
            };
        }

        public static Review ToCreateReviewDto(this CreateReviewDto createReviewDto){
            return new Review {
                ProductId = createReviewDto.ProductId,
                UserId = createReviewDto.UserId,
                Title = createReviewDto.Title,
                Content = createReviewDto.Content,
                Rating = createReviewDto.Rating,
                ReviewText = createReviewDto.ReviewText
            };
        }

        public static Review ToUpdateReviewDto(this UpdateReviewDto updateReviewDto){
            return new Review {
                ProductId = updateReviewDto.ProductId,
                UserId = updateReviewDto.UserId,
                Title = updateReviewDto.Title,
                Content = updateReviewDto.Content,
                Rating = updateReviewDto.Rating,
                ReviewText = updateReviewDto.ReviewText
            };
        }
    }
}