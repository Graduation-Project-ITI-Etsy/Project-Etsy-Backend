using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO
{
    public class ReturnResultDTO<T>
    {
        public T? Entity { get; set; }
        public string? Message { get; set; }
    }
}
