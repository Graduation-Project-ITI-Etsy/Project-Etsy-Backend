using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    public class BaseCategory
    {
        public int Id { get; set; }
        public string? NameEN { get; set; }
        public string? NameAR { get; set; }
        public string? BaseCategoryImage { get; set; }

        public ICollection<Category>? Categories { get; set; }
    }
}
