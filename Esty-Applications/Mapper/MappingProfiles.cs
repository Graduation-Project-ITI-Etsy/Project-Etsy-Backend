using AutoMapper;
using Esty_Models;
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
        }
    }
}
