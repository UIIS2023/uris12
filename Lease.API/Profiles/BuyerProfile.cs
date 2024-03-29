﻿using AutoMapper;
using Lease.API.Entities;
using Lease.API.Models.Buyer;

namespace Lease.API.Profiles;

/// <summary>
/// The profile for mapping between entities and response/request models for buyers.
/// </summary>
public class BuyerProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BuyerProfile"/> class.
    /// </summary>
    public BuyerProfile()
    {
        CreateMap<Buyer, BuyerGetResponseModel>();
        CreateMap<Buyer, BuyerPostResponseModel>();
        CreateMap<Buyer, BuyerPatchResponseModel>();
        CreateMap<BuyerPostRequestModel, Buyer>();
        CreateMap<BuyerPatchRequestModel, Buyer>()
            .ForMember(dest => dest.RealisedArea, opt => opt.Condition(src => src.RealisedArea != null))
            .ForMember(dest => dest.Ban, opt => opt.Condition(src => src.Ban != null))
            .ForMember(dest => dest.StartDateOfBan, opt => opt.Condition(src => src.StartDateOfBan != null))
            .ForMember(dest => dest.BanDuration, opt => opt.Condition(src => src.BanDuration != null))
            .ForMember(dest => dest.BanEndDate, opt => opt.Condition(src => src.BanEndDate != null))
            .ForMember(dest => dest.BiddingGuid, opt => opt.Condition(src => src.BiddingGuid != null))
            .ForMember(dest => dest.PersonGuid, opt => opt.Condition(src => src.PersonGuid != null))
            .ForMember(dest => dest.Priorities, opt => opt.Condition(src => src.Priorities != null));


    }
}


