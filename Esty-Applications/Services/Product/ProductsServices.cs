using AutoMapper;
using Esty_Applications.Contract;
using Etsy_DTO;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Product
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public ProductsServices(IProductRepository productRepository, IMapper mapper)
        {
            _ProductRepository = productRepository;
            _mapper = mapper;
        }

        public ReturnResultHasObjsDTO<ReturnAllProductsDTO> GetAllProducts(int ProductsItems, int PageNumber)
        {
            var AllProducts = _ProductRepository.GetAllEntity();
            var ProductsEN = AllProducts.Skip(ProductsItems * (PageNumber - 1))
                .Take(ProductsItems)
                .Select(_products => new ReturnAllProductsDTO
                {
                    ProductId = _products.ProductId,
                    ProductNameEN = _products.ProductNameEN,
                    ProductNameAR = _products.ProductNameAR,
                    ProductPrice = _products.ProductPrice,
                    ProductStock = _products.ProductStock,
                    ProductRating = _products.ProductRating,
                    ProductPublisher = _products.ProductPublisher,
                    ProductDescriptionEN = _products.ProductDescriptionEN,
                    ProductDescriptionAR = _products.ProductDescriptionAR,
                    CategoryID = _products.CategoryID
                }).ToList();
            return new ReturnResultHasObjsDTO<ReturnAllProductsDTO>
            {
                Entities = ProductsEN,
                Count = AllProducts.Count(),
                Message = "All Products were Retrieved"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> CreateProduct(ReturnAddUpdateProductDTO product)
        {
            throw new NotImplementedException();
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> UpdateProduct(ReturnAddUpdateProductDTO product)
        {
            throw new NotImplementedException();
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> DeleteProduct(ReturnAddUpdateProductDTO product)
        {
            throw new NotImplementedException();
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> SearchByProductID(int ProductId)
        {
            throw new NotImplementedException();
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> SearchByProductName(string ProductName)
        {
            throw new NotImplementedException();
        }

        public ReturnResultHasObjsDTO<ReturnAllProductsDTO> FilterProductByPrice(string ProductName)
        {
            throw new NotImplementedException();
        }
    }
}
