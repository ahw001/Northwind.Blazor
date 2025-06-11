using Northwind.Blazor.Model.Cybersource.BaseData;
using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.Cybersource.Authorization
{
    public class AuthTransResponse
    {
        [JsonPropertyName("_links")]
        public Links? Links { get; set; }

        [JsonPropertyName("clientReferenceInformation")]
        public ClientReferenceInformation? ClientReferenceInformation { get; set; }

        [JsonPropertyName("consumerAuthenticationInformation")]
        public ConsumerAuthenticationInformation? ConsumerAuthenticationInformation { get; set; }

        [JsonPropertyName("errorInformation")]
        public ErrorInformation? ErrorInformation { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("PaymentCardId")]
        public string? PaymentCardId { get; set; }

        [JsonPropertyName("B2cCustomerId")]
        public int B2cCustomerId { get; set; }

        [JsonPropertyName("OrderId")]
        public string? OrderId { get; set; }

        [JsonPropertyName("issuerInformation")]
        public IssuerInformation? IssuerInformation { get; set; }

        [JsonPropertyName("orderInformation")]
        public OrderInformation? OrderInformation { get; set; }

        [JsonPropertyName("paymentAccountInformation")]
        public PaymentAccountInformation? PaymentAccountInformation { get; set; }

        [JsonPropertyName("paymentInformation")]
        public PaymentInformation? PaymentInformation { get; set; }

        [JsonPropertyName("pointOfSaleInformation")]
        public PointOfSaleInformation? PointOfSaleInformation { get; set; }

        [JsonPropertyName("processorInformation")]
        public ProcessorInformation? ProcessorInformation { get; set; }

        [JsonPropertyName("reconciliationId")]
        public string? ReconciliationId { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("submitTimeUtc")]
        public DateTime? SubmitTimeUtc { get; set; }

        [JsonPropertyName("tokenInformation")]
        public TokenInformation? TokenInformation { get; set; }

    }
}
