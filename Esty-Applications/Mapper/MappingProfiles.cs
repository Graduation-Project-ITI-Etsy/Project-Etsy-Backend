using AutoMapper;
using Etsy_DTO.Payment;
using Esty_Models;
using Etsy_DTO.BaseCategory;
using Etsy_DTO.Category;
using Etsy_DTO.OrderItem;
using Etsy_DTO.Orders;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Products, ReturnAllProductsDTO>().ReverseMap();
            CreateMap<Products, ReturnAddUpdateProductDTO>().ReverseMap();

            CreateMap<Orders, ReturnAllOrdersDTO>().ReverseMap();
            CreateMap<Orders, ReturnAddUpdateOrderDTO>().ReverseMap();

            CreateMap<OrderItem, ReturnAllOrderItemsDTO>().ReverseMap();
            CreateMap<OrderItem, ReturnAddUpdateOrderItemsDTO>().ReverseMap();

            CreateMap<Payments, ReturnAllPaymentDTO>().ReverseMap();
            CreateMap<Payments, ReturnAddUpdatePaymentDTO>().ReverseMap();


            CreateMap<BaseCategory, ReturnAddUpdateBaseCategoryDTO>().ReverseMap();
            CreateMap<BaseCategory, ReturnAllBaseCategoryDTO>().ReverseMap();

            CreateMap<Category, ReturnAddUpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, ReturnAllCategoryDTO>().ReverseMap();

        }
    }
}
