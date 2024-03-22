﻿using Etsy_DTO;
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
        public Task<ReturnResultHasObjsDTO<ReturnAllProductsDTO>> GetAllProducts(int ProductsItems, int PageNumber);

        public Task<ReturnResultDTO<ReturnAddUpdateProductDTO>> CreateProduct(ReturnAddUpdateProductDTO product);

        public Task<ReturnResultDTO<ReturnAddUpdateProductDTO>> UpdateProduct(ReturnAddUpdateProductDTO product);

        public Task<ReturnResultDTO<ReturnAddUpdateProductDTO>> DeleteProduct(ReturnAddUpdateProductDTO product);

        public Task<ReturnResultDTO<ReturnAddUpdateProductDTO>> SearchByProductID(int ProductId);

        public Task<ReturnResultDTO<ReturnAddUpdateProductDTO>> SearchByProductName(string ProductName);

        public Task<ReturnResultHasObjsDTO<ReturnAllProductsDTO>> FilterProductByPrice(int MinPrice, int MaxPrice, int CategoryId);


    }
}
