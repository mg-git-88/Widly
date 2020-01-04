using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widly
{
    public class AutoMapperConfig<TSource, TDestination>
    {
        private static MapperConfiguration _mapperConfig;

        public static TDestination MapModels(TSource source)
        {
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            Mapper mapper = new Mapper(_mapperConfig);
            return mapper.Map<TDestination>(source);
        }
    }
}