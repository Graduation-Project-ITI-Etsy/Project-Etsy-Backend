using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO
{
    public class ReturnResultHasObjsDTO<T>
    {
        public List<T>? Entities { get; set; }
        public int Count { get; set; }
        public string? Message { get; set; }
    }
}
