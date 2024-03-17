using Etsy_DTO;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Product
{
    public interface IProductsServices
    {
        public ReturnResultHasObjsDTO<ReturnAllProductsDTO> GetAllProducts(int ProductsItems , int PageNumber);

        public ReturnResultDTO<ReturnAddUpdateProductDTO> CreateProduct (ReturnAddUpdateProductDTO product);

        public ReturnResultDTO<ReturnAddUpdateProductDTO> UpdateProduct (ReturnAddUpdateProductDTO product);

        public ReturnResultDTO<ReturnAddUpdateProductDTO> DeleteProduct (ReturnAddUpdateProductDTO product);

        public ReturnResultDTO<ReturnAddUpdateProductDTO> SearchByProductID (int ProductId);

        public ReturnResultDTO<ReturnAddUpdateProductDTO> SearchByProductName(string ProductName);

        public ReturnResultHasObjsDTO<ReturnAllProductsDTO> FilterProductByPrice(string ProductName);
    }
}
