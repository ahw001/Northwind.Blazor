using System.Text.Json.Serialization;
using Northwind.Blazor.Model.Cybersource.BaseData;

namespace Northwind.Blazor.Services.DTOs;

public class AftValidateDto
{
    [JsonPropertyName("orderInformation")]
    public OrderInformation? OrderInformation { get; set; }

    [JsonPropertyName("buyerInformation")]
    public BuyerInformation? BuyerInformation { get; set; }

    [JsonPropertyName("deviceInformation")]
    public DeviceInformation? DeviceInformation { get; set; }

    [JsonPropertyName("consumerAuthenticationInformation")]
    public ConsumerAuthenticationInformation? ConsumerAuthenticationInformation { get; set; }

    [JsonPropertyName("tokenInformation")]
    public TokenInformation? TokenInformation { get; set; }

    [JsonPropertyName("clientReferenceInformation")]
    public ClientReferenceInformation? ClientReferenceInformation { get; set; }

    [JsonPropertyName("paymentInformation")]
    public PaymentInformation? PaymentInformation { get; set; }

    [JsonPropertyName("processingInformation")]
    public ProcessingInformation? ProcessingInformation { get; set; }

    [JsonPropertyName("merchantInformation")]
    public MerchantInformation? MerchantInformation { get; set; }

    [JsonPropertyName("senderInformation")]
    public SenderInformation? SenderInformation { get; set; }

    [JsonPropertyName("recipientInformation")]
    public RecipientInformation? RecipientInformation { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

}




