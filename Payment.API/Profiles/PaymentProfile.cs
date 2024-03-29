﻿using AutoMapper;
using Payment.API.Models.PaymentModel;
using Payment.API.Models.PaymentModels;

namespace Payment.API.Profiles;

/// <summary>
/// AutoMapper profile for Payment related classes.
/// </summary>
public class PaymentProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the PaymentProfile class.
    /// </summary>
    public PaymentProfile()
    {
        CreateMap<Entities.Payment, PaymentResponseModel>()
            .ForMember(dest => dest.PaymentWarrant, opt => opt.MapFrom(src => src.PaymentWarrant));
        CreateMap<PaymentRequestModel, Entities.Payment>();
        CreateMap<PaymentUpdateModel, Entities.Payment>()
            .ForMember(dest => dest.AccountNumber, opt => opt.Condition(src => src.AccountNumber != null))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.TotalAmount, opt => opt.Condition(src => src.TotalAmount != null))
            .ForMember(dest => dest.PaymentTitle, opt => opt.Condition(src => src.PaymentTitle != null))
            .ForMember(dest => dest.PaymentDate, opt => opt.Condition(src => src.PaymentDate != null))
            .ForMember(dest => dest.PayerGuid, opt => opt.Condition(src => src.PayerGuid != null));
    }
}
