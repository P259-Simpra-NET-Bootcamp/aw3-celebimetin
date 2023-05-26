using AutoMapper;
using Data.Domains;
using WebApi.Schemas;

namespace WebApi.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryResponse, Category>();
            CreateMap<CategoryRequest, Category>();

            CreateMap<Product, ProductResponse>();
            CreateMap<ProductResponse, Product>();
            CreateMap<ProductRequest, Product>();
        }
    }
}