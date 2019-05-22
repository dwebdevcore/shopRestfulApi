using AutoMapper;

namespace SampleAPI.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.AddressOne))
                .ForMember(dest => dest.UnitNumber, opts => opts.MapFrom(src => src.AddressTwo));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.AddressOne, opts => opts.MapFrom(src => src.Address))
                .ForMember(dest => dest.AddressTwo, opts => opts.MapFrom(src => src.UnitNumber))
                .ForMember(dest => dest.Id, opts => opts.Ignore());

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.SalePrice))
                .ForMember(dest => dest.DisplayImage, opts => opts.MapFrom(src => src.ImageUrl));

        }

    }
}