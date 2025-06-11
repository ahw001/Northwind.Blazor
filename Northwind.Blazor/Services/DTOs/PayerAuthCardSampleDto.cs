using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Northwind.Blazor.Services.DTOs;

public partial class PayerAuthCardSampleDto
{
    [JsonPropertyName("samplePayAuthPaymentCardId")]
    public int SamplePayAuthPaymentCardId { get; set; }

    [JsonPropertyName("cardBrand")]
    public string CardBrand { get; set; } = null!;

    [JsonPropertyName("accountNumber")]
    public string AccountNumber { get; set; } = null!;

    [JsonPropertyName("expMonth")]
    public string? ExpMonth { get; set; }

    [JsonPropertyName("expYear")]
    public string? ExpYear { get; set; }

    [JsonPropertyName("cvv")]
    public string? Cvv { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}
