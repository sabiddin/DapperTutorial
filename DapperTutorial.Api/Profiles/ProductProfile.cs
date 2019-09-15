using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DapperTutorial.Api.Models;
using DapperTutorial.Entities;

namespace DapperTutorial.Api.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, Product>().ForMember(dest => dest.ProductId, map => map.MapFrom(
                src => src.Id
                ));
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.ProductId));
        }
    }
}