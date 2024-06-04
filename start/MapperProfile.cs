
using AutoMapper;
using Entities;
using Entities.DtoOrder;
using Entities.DtoOrderItem;
using Entities.DtoPtoduct;
using Entities.DtoUser;




namespace Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterDto, User>().ReverseMap();
          
            CreateMap<LoginDto, User>().ReverseMap();

            CreateMap<Product, ProductDto>()
           .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategotyName : null))
           .ForMember(dest => dest.Img, opt => opt.MapFrom(src => "image/"+ src.Img+".jpg"));

            CreateMap<ProductDto, Product>();



            CreateMap<AddOrderDto, Order>()
           .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
           .ForMember(dest => dest.OrderSum, opt => opt.MapFrom(src => src.OrderSum));


            CreateMap<Order, AddOrderDto>();


            CreateMap<AddOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<AddProductDto, Product>().ReverseMap();


            CreateMap<UpdateDto, User>().ReverseMap();
        }

    }
}