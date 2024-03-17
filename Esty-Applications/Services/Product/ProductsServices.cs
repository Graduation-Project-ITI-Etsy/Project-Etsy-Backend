﻿using AutoMapper;
using Esty_Applications.Contract;
using Esty_Models;
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
            var Products = AllProducts.Skip(ProductsItems * (PageNumber - 1))
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
                Entities = Products,
                Count = AllProducts.Count(),
                Message = "All Products were Retrieved"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> CreateProduct(ReturnAddUpdateProductDTO product)
        {
            if (product != null)
            {
                try
                {
                    var ProductWillBeCreated = _mapper.Map<ReturnAddUpdateProductDTO, Products>(product);
                    _ProductRepository.CreateEntity(ProductWillBeCreated);
                    if (_ProductRepository.Save() > 0)
                    {
                        var ProductMapped = _mapper.Map<ReturnAddUpdateProductDTO>(ProductWillBeCreated);
                        return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                        {
                            Entity = ProductMapped,
                            Message = "Product is Created"
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                    {
                        Entity = null,
                        Message = ex.Message
                    };
                }
            }
            return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
            {
                Entity = null,
                Message = "The Object returned from the Created view is Null !!"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> UpdateProduct(ReturnAddUpdateProductDTO product)
        {
            if (product != null)
            {
                try
                {
                    var ProductWillBeUpdated = _mapper.Map<ReturnAddUpdateProductDTO, Products>(product);
                    _ProductRepository.UpdateEntity(ProductWillBeUpdated);
                    if (_ProductRepository.Save() > 0)
                    {
                        var ProductMapped = _mapper.Map<ReturnAddUpdateProductDTO>(ProductWillBeUpdated);
                        return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                        {
                            Entity = ProductMapped,
                            Message = "Product is Updated"
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                    {
                        Entity = null,
                        Message = ex.Message
                    };
                }
            }
            return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
            {
                Entity = null,
                Message = "The Object returned from the Created view is Null !!"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> DeleteProduct(ReturnAddUpdateProductDTO product)
        {
            if (product != null)
            {
                try
                {
                    var ProductWillBeDeleted = _mapper.Map<ReturnAddUpdateProductDTO, Products>(product);
                    _ProductRepository.DeleteEntity(ProductWillBeDeleted.ProductId);
                    if (_ProductRepository.Save() > 0)
                    {
                        var ProductMapped = _mapper.Map<ReturnAddUpdateProductDTO>(ProductWillBeDeleted);
                        return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                        {
                            Entity = ProductMapped,
                            Message = "Product is Deleted"
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                    {
                        Entity = null,
                        Message = ex.Message
                    };
                }
            }
            return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
            {
                Entity = null,
                Message = "The Object returned from the Created view is Null !!"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> SearchByProductID(int ProductId)
        {
            var ProductResearched = _ProductRepository.GetEntitybyId(ProductId);
            var ProductWillBeGet = _mapper.Map<ReturnAddUpdateProductDTO>(ProductResearched);
            if (ProductResearched != null)
                return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                {
                    Entity = ProductWillBeGet,
                    Message = "Product is obtained"
                };
            return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
            {
                Entity = null,
                Message = "Product is not obtained"
            };
        }

        public ReturnResultDTO<ReturnAddUpdateProductDTO> SearchByProductName(string ProductName)
        {
            var ProductResearched = _ProductRepository.SearchProductByName(ProductName);
            var ProductWillBeGet = _mapper.Map<ReturnAddUpdateProductDTO>(ProductResearched);
            if (ProductResearched != null)
                return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
                {
                    Entity = ProductWillBeGet,
                    Message = "Product is obtained"
                };
            return new ReturnResultDTO<ReturnAddUpdateProductDTO>()
            {
                Entity = null,
                Message = "Product is not obtained"
            };
        }

        public ReturnResultHasObjsDTO<ReturnAllProductsDTO> FilterProductByPrice(int MinPrice, int MaxPrice)
        {
            try
            {
                var FilterProducts = _ProductRepository.FilterProductByPrice(MinPrice, MaxPrice)
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
                    }).ToList(); ;

                if (FilterProducts != null)
                    return new ReturnResultHasObjsDTO<ReturnAllProductsDTO>()
                    {
                        Entities = FilterProducts,
                        Count = FilterProducts.Count(),
                        Message = "All Products were Retrieved"
                    };

                return new ReturnResultHasObjsDTO<ReturnAllProductsDTO>()
                {
                    Entities = null,
                    Message = "The Object returned from the Created view is Null !!"
                };
            }
            catch (Exception ex)
            {
                return new ReturnResultHasObjsDTO<ReturnAllProductsDTO>()
                {
                    Entities = null,
                    Message = ex.Message
                };
            }
        }
    }
}