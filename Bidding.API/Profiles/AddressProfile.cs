﻿using AutoMapper;
using Bidding.API.Entities;
using Bidding.API.Models;

namespace Bidding.API.Profiles
{

    /// <summary>
    /// Profile for mapping between address and its related models.
    /// </summary>
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {

            CreateMap<Address, AdressResponseModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))

                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.StreetNumber))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode));


            CreateMap<Address, AddressNewResponseModel>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))

                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.StreetNumber))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode));


            CreateMap<AddressUpdateModel, Address>()

    .ForMember(dest => dest.Country, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Country)))
    .ForMember(dest => dest.Street, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Street)))
    .ForMember(dest => dest.StreetNumber, opt => opt.Condition(src => !string.IsNullOrEmpty(src.StreetNumber)))
    .ForMember(dest => dest.Place, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Place)))
    .ForMember(dest => dest.ZipCode, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ZipCode)));



            CreateMap<AddressRequestModel, Address>()
              .ForMember(dest => dest.Country, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Country)))
    .ForMember(dest => dest.Street, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Street)))
    .ForMember(dest => dest.StreetNumber, opt => opt.Condition(src => !string.IsNullOrEmpty(src.StreetNumber)))
    .ForMember(dest => dest.Place, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Place)))
    .ForMember(dest => dest.ZipCode, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ZipCode)));





        }
    }
}
