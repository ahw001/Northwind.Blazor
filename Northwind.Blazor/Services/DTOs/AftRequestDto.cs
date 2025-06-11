using Northwind.Blazor.Model.Cybersource.BaseData;
using System.Text.Json.Serialization;

namespace Northwind.Blazor.Services.DTOs
{
    public class AftRequestDto
    {
        [JsonPropertyName("clientReferenceInformation")]
        public ClientReferenceInformation? ClientReferenceInformation { get; set; }

        [JsonPropertyName("paymentInformation")]
        public PaymentInformation? PaymentInformation { get; set; }

        [JsonPropertyName("orderInformation")]
        public OrderInformation? OrderInformation { get; set; }

        [JsonPropertyName("processingInformation")]
        public ProcessingInformation? ProcessingInformation { get; set; }

        [JsonPropertyName("merchantInformation")]
        public MerchantInformation? MerchantInformation { get; set; }

        [JsonPropertyName("senderInformation")]
        public SenderInformation? SenderInformation { get; set; }

        [JsonPropertyName("recipientInformation")]
        public RecipientInformation? RecipientInformation { get; set; }

        [JsonPropertyName("tokenInformation")]
        public TokenInformation? TokenInformation { get; set; } = new();

        [JsonPropertyName("error")]
        public string? Error { get; set; }

        [JsonPropertyName("CurrentTransaction")]
        public string? CurrentTransaction { get; set; }

        [JsonPropertyName("AftOnly")]
        public bool AftOnly { get; set; }
    }
}
