using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Northwind.Blazor.Model.Cybersource.BaseData;

namespace Northwind.Blazor.Services.DTOs;

public class CaptureContextDto
{
    [JsonPropertyName("ctx")]
    public string? Ctx { get; set; }

    [JsonPropertyName("b2cCustomerId")]
    public string? B2cCustomerId { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("clientReferenceInformation")]
    public ClientReferenceInformation? ClientReferenceInformation { get; set; } = new();

    [JsonPropertyName("orderInformation")]
    public OrderInformation? OrderInformation { get; set; } = new();

    [JsonPropertyName("billTo")]
    public BillTo? BillTo { get; set; } = new();

    [JsonPropertyName("tokenInformation")]
    public TokenInformation? TokenInformation { get; set; } = new();

    [JsonPropertyName("processingInformation")]
    public ProcessingInformation? ProcessingInformation { get; set; } = new();

}

