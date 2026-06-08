using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopFlow.Application.DTOs;
using ShopFlow.Domain.Entities;

namespace ShopFlow.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();

            CreateMap<Product, ProductDto>();

            CreateMap<UpdateProductDto, Product>();

            CreateMap<RegisterDto, User>();
        }
    }
}
