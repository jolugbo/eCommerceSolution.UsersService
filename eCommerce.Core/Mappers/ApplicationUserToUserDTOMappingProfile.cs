using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserToUserDTOMappingProfile : Profile
{
    public ApplicationUserToUserDTOMappingProfile()
    {
        CreateMap<ApplicationUser, UserDTO>()
        .ForMember(destination => destination.UserId, opt => opt.MapFrom(source => source.UserId))
        .ForMember(destination => destination.Email, opt => opt.MapFrom(source => source.Email))
        .ForMember(destination => destination.PersonName, opt => opt.MapFrom(source => source.PersonName))
        .ForMember(destination => destination.Gender, opt => opt.MapFrom(source => source.Gender));
    }
}
