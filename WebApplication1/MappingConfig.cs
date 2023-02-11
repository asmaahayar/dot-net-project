using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CosmeticDto, Cosmetic>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
