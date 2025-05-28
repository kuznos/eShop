using eShop.Application.Features.Products.Commands.CreateProduct;
using AutoMapper;
using eShop.Domain;

namespace eShop.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            //CreateMap<Cart, CreateCartCommand>().ReverseMap();
        }
    }
}
