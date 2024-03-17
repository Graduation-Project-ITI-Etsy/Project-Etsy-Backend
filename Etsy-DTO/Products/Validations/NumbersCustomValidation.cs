using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Products.Validations
{
    public class NumbersCustomValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var Product = (ReturnAddUpdateProductDTO)validationContext.ObjectInstance;
            if (Product.ProductPrice == 0 || Product.ProductStock == 0 || Product.ProductRating == 0 || Product.CategoryID == 0)
                return new ValidationResult("0 is not allowed !!");
            else if (Product.ProductPrice < 0 || Product.ProductStock < 0 || Product.ProductRating < 0 || Product.CategoryID == 0)
                return new ValidationResult("Negative Numbers are not allowed !!");
            return ValidationResult.Success;
        }
    }
}
