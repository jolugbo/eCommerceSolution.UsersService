using AutoMapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile() {


        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(destination => destination.Email, opt => opt.MapFrom(source => source.Email))
            .ForMember(destination => destination.PersonName, opt => opt.MapFrom(source => source.PersonName))
            .ForMember(destination => destination.Gender, opt => opt.MapFrom(source => source.Gender.ToString()))
            .ForMember(destination => destination.Password, opt => opt.MapFrom(source => source.Password))
            .ForMember(destination => destination.UserId, opt => opt.Ignore());
    }
}
