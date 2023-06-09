﻿using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap(); // we indicate that its convertible within each other 
            CreateMap<Category,CategoryDto>().ReverseMap(); // we indicate that its convertible within each other 
            CreateMap<ProductFeature,ProductFeatureDto>().ReverseMap(); // we indicate that its convertible within each other 
            CreateMap<CategoryWithProductsDto,Category>().ReverseMap(); // we indicate that its convertible within each other 
        }
    }
}
