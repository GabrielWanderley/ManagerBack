using AutoMapper;
using ManagerBack.Data.Dto;
using ManagerBack.Models;

namespace ManagerBack.Profiles
{
    public class ManagerBackSaleProfile : Profile
    {
        public ManagerBackSaleProfile() 
        {

            CreateMap<CreateSaleDto, Sale>();
            CreateMap<ReadSaleDto, Sale>();
            CreateMap<Sale, ReadSaleDto>();
            CreateMap<UpdateSaleDto, Sale>();

        }
    }
}
