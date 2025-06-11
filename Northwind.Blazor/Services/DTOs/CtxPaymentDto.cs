using Northwind.Blazor.Model;
using Northwind.Blazor.Model.Cybersource.BaseData;
using System.Text.Json.Serialization;

namespace Northwind.Blazor.Services.DTOs
{
    public class CtxPaymentDto
    {
        [JsonPropertyName("B2cCustomerId")]
        public string? B2cCustomerId { get; set; }

        [JsonPropertyName("OrderId")]
        public string? OrderId { get; set; }

        [JsonPropertyName("transactionType")]
        public CcTransactionTypes? TransactionType { get; set; }

        [JsonPropertyName("clientReferenceInformation")]
        public ClientReferenceInformation? ClientReferenceInformation { get; set; } = new();

        [JsonPropertyName("orderInformation")]
        public OrderInformation? OrderInformation { get; set; } = new();

        [JsonPropertyName("tokenInformation")]
        public TokenInformation? TokenInformation { get; set; } = new();

        [JsonPropertyName("processingInformation")]
        public ProcessingInformation? ProcessingInformation { get; set; } = new();

    }
}
