using AutoMapper;
using DapperTutorial.Api.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperTutorial.Api.App_Start
{
    public class AutomapperConfig
    {
        public static IMapper Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
            });

            return config.CreateMapper();
        }
    }
}