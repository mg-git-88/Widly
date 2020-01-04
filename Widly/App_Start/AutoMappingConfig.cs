using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widly.App_Start
{
    public class AutoMappingConfig<TSource, TDestination>
    {
        public MapperConfiguration Config()
        {
            var config = new MapperConfiguration
                (cfg =>
                {
                    cfg.CreateMap<TSource, TDestination>();
                });
            return config;
        }
    }
}