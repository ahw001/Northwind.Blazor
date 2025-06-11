using System.Text.Json.Serialization;
using Northwind.Blazor.Model.Cybersource.BaseData;
using Northwind.Blazor.Model.OutboundObjects;


public class CheckEnrollDto
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
}




