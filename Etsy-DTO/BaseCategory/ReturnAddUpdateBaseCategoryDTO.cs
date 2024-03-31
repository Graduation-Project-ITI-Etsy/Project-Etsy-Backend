using Esty_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.BaseCategory
{
    public class ReturnAddUpdateBaseCategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Base Category name should be less than 50 Characters")]
        public string? NameEN { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Base Category name should be less than 50 Characters")]
        public string? NameAR {get; set;}
        [Required]
        public string? BaseCategoryImage { get; set; }


        public ICollection<Esty_Models.Category>? Categories { get; set; }

    }
}
