using AutoMapper;
using ManagerBack.Data.Dto;
using ManagerBack.Models;

namespace ManagerBack.Profiles
{
    public class ManagerBackProductProfile : Profile
    {
        public ManagerBackProductProfile() 
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<ReadProductDto, Product>();
            CreateMap<Product, ReadProductDto>().ForMember(proDto =>
             proDto.Sales, opt => opt.MapFrom(pro => pro.Sales));
            CreateMap<UpdateProductDto, Product>();
            CreateMap< Product,UpdateProductDto>();
        }
    }
}
