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
        public string? Name { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
