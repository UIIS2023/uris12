﻿using Bidding.API.Enums;
using System.Text.Json.Serialization;


namespace Bidding.API.Models
{
    public class DocumentUpdateModel
    {

        public Guid PublicBiddingGuid { get; set; }
        [JsonConverter(typeof(DocumentTypeConverter))]
        public DocumentType? documentType { get; set; }
        public string? ReferenceNumber { get; set; }

        public DateTime? DateSubmited { get; set; }

        public DateTime? DateSertified { get; set; }

        public string? Template { get; set; }

        public DocumentUpdateModel() { }

        public DocumentUpdateModel(Guid publicBidding, DocumentType? documentType, string? referenceNumber, DateTime? dateSubmited, DateTime? dateSertified, string? template)
        {

            this.PublicBiddingGuid = publicBidding;
            this.documentType = documentType;
            ReferenceNumber = referenceNumber;
            DateSubmited = dateSubmited;
            DateSertified = dateSertified;
            Template = template;
        }
    }
}
