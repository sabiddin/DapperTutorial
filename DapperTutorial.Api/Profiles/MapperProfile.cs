using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DapperTutorial.Api.Models;
using DapperTutorial.Entities;

namespace DapperTutorial.Api.Profiles
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();
        }
    }
}