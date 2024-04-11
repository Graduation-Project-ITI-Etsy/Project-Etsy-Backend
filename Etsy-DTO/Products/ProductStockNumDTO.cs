using Etsy_DTO.Products.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Products
{
    public class ProductStockNumDTO
    {
        [Required(ErrorMessage = "Product Id is required !!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Stock is required !!")]
        public int ProductStock { get; set; }
    }
}
