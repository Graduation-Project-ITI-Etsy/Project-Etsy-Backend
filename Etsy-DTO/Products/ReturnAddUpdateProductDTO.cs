using Esty_Models;
using Etsy_DTO.Products.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Products
{
    public class ReturnAddUpdateProductDTO
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required !!")]
        [MaxLength(50, ErrorMessage = "Product name should be less than 50 Characters")]
        public string? ProductNameEN { get; set; }

        [Required(ErrorMessage = "Product Name is required !!")]
        [MaxLength(50, ErrorMessage = "Product name should be less than 50 Characters")]
        public string? ProductNameAR { get; set; }

        [Required(ErrorMessage = "Product Price is required !!")]
        [NumbersCustomValidation]
        public int ProductPrice { get; set; }

        [Required(ErrorMessage = "Stock is required !!")]
        [NumbersCustomValidation]
        public int ProductStock { get; set; }

        [Required(ErrorMessage = "Product Rating is required !!")]
        [NumbersCustomValidation]
        public int ProductRating { get; set; }

        [Required(ErrorMessage = "Puvlisher Name is required !!")]
        [MaxLength(50, ErrorMessage = "Product name should be less than 50 Characters")]
        public string? ProductPublisher { get; set; }

        [Required(ErrorMessage = "Product Description is required !!")]
        public string? ProductDescriptionEN { get; set; }

        [Required(ErrorMessage = "Product Description is required !!")]
        public string? ProductDescriptionAR { get; set; }

        [Required(ErrorMessage = "Category Id is required !!")]
        [NumbersCustomValidation]
        public int CategoryID { get; set; }

    }
}
