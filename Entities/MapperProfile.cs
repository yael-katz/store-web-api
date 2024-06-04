
using AutoMapper;
using Entities;
using Entities.DtoUser;




namespace Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<User,RegisterDto>();
            CreateMap<LoginDto, User>();
            CreateMap<User, LoginDto>();
        }
    }
}