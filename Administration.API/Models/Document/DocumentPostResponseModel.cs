﻿using Administration.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Administration.API.Models.Document;

/// <summary>
/// Represents a post response model for the document retrieval operation.
/// </summary>
[DataContract(Name = "Document", Namespace = "")]
public class DocumentPostResponseModel
{
    /// <summary>
    /// Gets or sets the type of the document, which is converted from JSON format using a custom converter.
    /// </summary>
    [DataMember]
    [JsonConverter(typeof(DocumentTypeConverter))]
    public DocumentType Type { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the committee that the document belongs to.
    /// </summary>
    [DataMember]
    public Guid CommitteeGuid { get; set; }

    /// <summary>
    /// Gets or sets the reference number of the document.
    /// </summary>
    [DataMember]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the date when the document was submitted.
    /// </summary>
    [DataMember]
    public DateTime DateSubbmitted { get; set; }

    /// <summary>
    /// Gets or sets the date when the document was certified.
    /// </summary>
    [DataMember]
    public DateTime DateCertified { get; set; }

    /// <summary>
    /// Gets or sets the template of the document.
    /// </summary>
    [DataMember]
    public string? Template { get; set; }

    /// <summary>
    /// Initializes a new instance of the DocumentPostResponseModel class.
    /// </summary>
    public DocumentPostResponseModel() { }
}
