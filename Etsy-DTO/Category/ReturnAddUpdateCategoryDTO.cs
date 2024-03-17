using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Category
{
    public class ReturnAddUpdateCategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category name should be less than 50 Characters")]
        public string? NameEN { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Category name should be less than 50 Characters")]
        public string? NameAR { get; set; }

        [Required]
        public int BaseCategoryId { get; set; }

        [Required]
        public ICollection<Esty_Models.Products>? Products { get; set; }

    }
}
