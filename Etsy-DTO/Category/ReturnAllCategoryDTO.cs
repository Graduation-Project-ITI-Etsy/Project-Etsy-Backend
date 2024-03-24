using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Category
{
    public class ReturnAllCategoryDTO
    {
        public int Id { get; set; }
        public string? NameEN { get; set; }
        public string? NameAR { get; set; }
        public string? CategoryImage { get; set; }

        public int BaseCategoryId { get; set; }
        public ICollection<Esty_Models.Products>? Products { get; set; }

    }
}
