using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Dtos.ReviewDto
{
    public class CreateReviewDto
    {
        [Required]
        public required int ProductId { get; set; }
        [Required]
        public required int UserId { get; set; }
        [Required]
        public required string Title { get; set; }
        public string Content { get; set; } = String.Empty;
        [Required]
        public int Rating { get; set; }
        public string ReviewText { get; set; } = String.Empty;
    }
}