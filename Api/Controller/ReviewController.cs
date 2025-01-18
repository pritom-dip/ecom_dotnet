using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.ReviewContainer;
using DataAccess.Dtos.ReviewDto;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controller
{
    [ApiController]
    [Route("/api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAllReviews([FromQuery] QueryObject queryObject)
        {
            var results = _reviewService.GetAllReviews(queryObject);
            var reviews = results.Select(r => r.ToReviewDto());
            return Ok(reviews);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetReviewById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var review = await _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review.ToReviewDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto createReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var review = await _reviewService.CreateReview(createReviewDto);
            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review.ToReviewDto());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReview(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var review = await _reviewService.DeleteReview(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review.ToReviewDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromBody] UpdateReviewDto updateReviewDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var review = await _reviewService.UpdateReview(updateReviewDto, id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review.ToReviewDto());
        }

    }
}