using AutoMapper;
using ProductManagementApi.Domain;

namespace ProductManagementApi.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
