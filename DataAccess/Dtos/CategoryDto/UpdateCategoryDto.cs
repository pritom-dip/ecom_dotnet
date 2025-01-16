using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
    }
}