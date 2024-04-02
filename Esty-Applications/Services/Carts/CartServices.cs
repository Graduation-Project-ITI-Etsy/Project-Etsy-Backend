using AutoMapper;
using Esty_Applications.Contract;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.Carts;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Carts
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CartServices(ICartRepository repo, IMapper mapper,IProductRepository productRepository)
        {
            _cartRepository = repo;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ReturnResultDTO<ReturnAddUpdateCartDTO>> CreateCart(ReturnAddUpdateCartDTO cart)
        {
            if (cart != null)
            {
                try
                {
                    var CartWillBeCreated = _mapper.Map<ReturnAddUpdateCartDTO, Cart>(cart);
                    await _cartRepository.CreateEntity(CartWillBeCreated);
                    if (await _cartRepository.Save() > 0)
                    {
                        var CartMapped = _mapper.Map<ReturnAddUpdateCartDTO>(CartWillBeCreated);
                        return new ReturnResultDTO<ReturnAddUpdateCartDTO>()
                        {
                            Entity = CartMapped,
                            Message = "Cartr is Created"
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new ReturnResultDTO<ReturnAddUpdateCartDTO>()
                    {
                        Entity = null,
                        Message = ex.Message
                    };
                }
            }
            return new ReturnResultDTO<ReturnAddUpdateCartDTO>()
            {
                Entity = null,
                Message = "The Object returned from the Created view is Null !!"
            };
        }

        public async Task<ReturnResultHasObjsDTO<ReturnAllCartDTO>> GetAllCards(string customerId)
        {
            var CustomerCards = await _cartRepository.GetcartsByCustomerId(customerId);
            
            ReturnAllCartDTO returnAllCartDTO = new ReturnAllCartDTO();
            var FilterCards = CustomerCards
                .Select(_carts => new ReturnAllCartDTO
                {
                    CartID = _carts.CartID,
                    CustomerId = _carts.CustomerId,
                    ProductId = _carts.ProductId,
                    ProductNameEN = _carts.ProductNameEN,
                    ProductNameAR = _carts.ProductNameAR,
                    ProductPrice = _carts.ProductPrice,
                    ProductStock = _carts.ProductStock,
                    ProductRating = _carts.ProductRating,
                    ProductPublisher = _carts.ProductPublisher,
                    ProductDescriptionEN = _carts.ProductDescriptionEN,
                    ProductDescriptionAR = _carts.ProductDescriptionAR,
                    ProductImage = _carts.ProductImage,
                    CategoryID = _carts.CategoryID,
                    Quantity = _carts.Quantity,
                }).ToList();

            if (FilterCards != null)
                return new ReturnResultHasObjsDTO<ReturnAllCartDTO>()
                {
                    Entities = FilterCards,
                    Count = FilterCards.Count(),
                    Message = "All Carts were Retrieved"
                };

            return new ReturnResultHasObjsDTO<ReturnAllCartDTO>()
            {
                Entities = null,
                Message = "The Object returned from the Created view is Null !!"
            };
        }
    }
}
