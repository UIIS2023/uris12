﻿using Administration.API.Entities;
using Administration.API.Models.Document;
using AutoMapper;

namespace Administration.API.Profiles;

/// <summary>
/// AutoMapper profile for mapping between entities and response/request models for document.
/// </summary>
public class DocumentProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class and sets up mappings between
    /// <see cref="Document"/> and its corresponding response/request models.
    /// </summary>
    public DocumentProfile()
    {
        CreateMap<Document, DocumentGetResponseModel>();
        CreateMap<Document, DocumentPostResponseModel>();
        CreateMap<Document, DocumentPatchResponseModel>();
        CreateMap<DocumentPostRequestModel, Document>();
        CreateMap<DocumentPatchRequestModel, Document>()
            .ForMember(dest => dest.Type, opt => opt.Condition(src => src.Type.HasValue))
            .ForMember(dest => dest.CommitteeGuid, opt => opt.Condition(src => src.CommitteeGuid != Guid.Empty))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.Condition(src => src.ReferenceNumber != null))
            .ForMember(dest => dest.DateSubbmitted, opt => opt.Condition(src => src.DateSubbmitted != null))
            .ForMember(dest => dest.DateCertified, opt => opt.Condition(src => src.DateCertified != null))
            .ForMember(dest => dest.Template, opt => opt.Condition(src => src.Template != null));
    }
}